﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Models.DTOs.AppUserDTOs
{
	public class UserRoleAssignDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

        public bool HasAssign { get; set; }
    }
}
