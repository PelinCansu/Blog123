﻿using Blog123.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Models.DTOs.PostDTOs
{
    public class PostUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
      
        public string Summary { get; set; }
        public string MinRead { get; set; }
        public ushort ViewCount { get; set; }
        public List<Category> Categories { get; set; }
    }
}
