using System;

namespace TeamServiceAPI.Dtos
{
    public class MemberReadDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
