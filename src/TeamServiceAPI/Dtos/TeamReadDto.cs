using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TeamServiceAPI.Dtos
{
    public class TeamReadDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<MemberReadDto> Members { get; set; }
    }
}