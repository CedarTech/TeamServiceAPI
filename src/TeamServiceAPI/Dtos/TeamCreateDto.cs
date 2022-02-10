using System;
using System.Collections.Generic;
namespace TeamServiceAPI.Dtos
{
    public class TeamCreateDto
    {
        Guid ID { get; set; }
        string Name { get; set; }
        ICollection<MemberCreateDto> Members { get; set; }
    }
}