using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamServiceAPI.Models
{
    public class Team
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }

        public Team() { }
        public Team(string name) : this()
        {
            Name = name;
        }
        public Team(string name, Guid id) : this(name)
        {
            ID = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}