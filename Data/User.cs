﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MSQL.Data
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }
        public string FistName { get; set; }
		public string LastName { get; set; }
	}
}

