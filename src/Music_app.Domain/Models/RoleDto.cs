﻿namespace Music_app.Domain.Models
{
    public class RoleDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool disable { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? modified_at { get; set; }
    }
}