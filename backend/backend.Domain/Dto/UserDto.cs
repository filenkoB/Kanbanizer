using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Dto
{
    public class UserDto : EntityDto
    {
        public string Fullname { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}
