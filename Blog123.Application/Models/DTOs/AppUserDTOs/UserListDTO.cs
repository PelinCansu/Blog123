using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Models.DTOs.AppUserDTOs
{
	public class UserListDTO
	{
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
	}
}
