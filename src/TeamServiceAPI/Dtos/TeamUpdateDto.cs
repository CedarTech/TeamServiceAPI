using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamServiceAPI.Dtos
{
    public class TeamUpdateDto
    {
        [Required]
        Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        string Name { get; set; }
        ICollection<MemberCreateDto> Members { get; set; }
    }

}