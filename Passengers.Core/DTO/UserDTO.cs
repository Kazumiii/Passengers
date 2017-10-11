using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.DTO
{
    //this class stores  flat object' s user 
    //I want to have only flat object to have no metohds which can disturbs my API
    //flat object are very useful for safety reasons- i don't want to return full information 
    //about object e.g i don't want return methods and so on  
    //flat objet can be send where i want and i can do with it whatever  i want
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
