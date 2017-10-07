using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.DTO
{
    //this class stores  flat object' s user 
    //I want to have only flat object to have no metohds which can disturbs my API 
    //flat objet can be send where i want i can do wtih it whatever  i want
public    class UserDTO
    {
        public Guid ID { get;  set; }

        public string Email { get; set; }

        public string UserName { get;  set; }

        public string FullName { get; set; }

       public string Role { get; set; }

        public DateTime CreatedAt { get;set; }
    }
}
