﻿using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Entities.Concrete
{
    public class AppRole : IdentityRole<Guid>, IBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}