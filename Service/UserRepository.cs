using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MSQL.Common;
using MSQL.Common.Rsp;
using MSQL.Data;
using MSQL.Models;
using MSQL.Helpers;
using Microsoft.Extensions.Options;

namespace MSQL.Service
{
    public class UserRepository : IUserRepository
    {




        private readonly AppSettings _appSettings;
        public static int PAGE_SIZE { get; set; } = 5;
        private readonly MsqlContext _context;
        private readonly JwtService _service;
        public UserRepository(MsqlContext context, JwtService service, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _service = service;
            _appSettings = appSettings.Value;
        }
        public object GetAll(int page, string sortBy, string search)
        {
            var rs = _context.Users.AsQueryable();
            rs = rs.OrderBy(c => c.Id);
            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "id_asc": rs = rs.OrderBy(hh => hh.Id); break;
                    case "id_desc": rs = rs.OrderByDescending(hh => hh.Id); break;
                    case "email_asc": rs = rs.OrderBy(hh => hh.Email); break;
                    case "email_desc": rs = rs.OrderByDescending(hh => hh.Email); break;

                }

            }
            if (!String.IsNullOrEmpty(search))
            {
                rs = rs.Where(hh => hh.Email.Contains(search));

            }





            var offset = (page - 1) * PAGE_SIZE;
            var total = rs.Count();
            int totalPage = (total % PAGE_SIZE) == 0 ? (int)(total / PAGE_SIZE) :
                (int)(1 + (total / PAGE_SIZE));
            var result = rs.Skip(offset).Take(PAGE_SIZE).ToList();



            return new
            {
                data = result.Select(n => new { n.Id, n.Email, n.LastName, n.FistName, n.Password }),
                per_page = PAGE_SIZE,
                TotalRecord = total,
                TotalPages = totalPage,
                Size = PAGE_SIZE
            };
        }

        public SingleRsp Create(UserModel u)
        {
            var res = new SingleRsp();

            var us = new User()
            {
                Email = u.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(u.Password),
                FistName = u.FistName,
                LastName = u.LastName

            };

            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var p = _context.Add(us);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            res.Data = us;


            return res;
        }
        public SingleRsp Update(UserModel u)
        {
            var _c = _context.Users.SingleOrDefault(p => p.Id == u.Id);
            _c.Email = u.Email;
            _c.LastName = u.LastName;
            _c.FistName = u.FistName;
            var res = new SingleRsp();



            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var p = _context.Update(_c);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            res.Data = _c;


            return res;
        }
        public SingleRsp Delete(int id)
        {
            var rs = new SingleRsp();
            var _c = _context.Users.SingleOrDefault(p => p.Id == id);
            if (_c != null)
            {
                _context.Remove(_c);
                _context.SaveChanges();

            }
            return rs;

        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return null;
            }


            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);

        }
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

    }
}

