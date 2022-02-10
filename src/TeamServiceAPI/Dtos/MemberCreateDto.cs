using System;

namespace TeamServiceAPI.Dtos
{
    public class MemberCreateDto
    {
        Guid ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}