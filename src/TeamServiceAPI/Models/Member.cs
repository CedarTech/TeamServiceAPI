using System;
using System.ComponentModel.DataAnnotations;

namespace TeamServiceAPI.Models
{
    public class Member
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        // public Guid TeamID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public Member() { }

        public Member(Guid id) : this()
        {
            ID = id;
        }

        public Member(string firstName, string lastName, Guid id) : this(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return LastName;
        }

    }

}