﻿using Domain.Common;

namespace Domain.Entities
{
    public class Education:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Group> Groups { get; set; }

    }
}
