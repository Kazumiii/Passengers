using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.DTO
{
    //this class stores  flat object' s user 
    //I want to have only flat objects to have no metohds which can disturbs my API
    //flat objects are very useful for safety reasons- i don't want to return full information 
    //about objects e.g i don't want return methods and so on 
    //that's  exactly why DTO are returns form repository 
 
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
