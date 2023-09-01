using System;
using MSQL.Common.Rsp;
using MSQL.Models;
using MSQL.Data;

namespace MSQL.Service
{
    public interface IUserRepository
    {
        public object GetAll(int page, string? sortBy, string? search);
        public SingleRsp Create(UserModel u);
        public SingleRsp Update(UserModel u);
        public SingleRsp Delete(int id);
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public User GetById(int id);
    }
}

