using System;
using System.ComponentModel.DataAnnotations;

namespace TeamServiceAPI.Dtos
{
    public class MemberCreateDto
    {
        [Required]
        Guid ID { get; set; }
        [Required]
        string FirstName { get; set; }
        [Required]
        string LastName { get; set; }
    }
}