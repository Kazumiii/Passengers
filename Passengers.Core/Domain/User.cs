using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
 public   class User
    {
        //set must be protedted  beceause i want noneone modify my dates 

            //random signs on based on e.g time
            public Guid ID { get; protected set; }

        public string Email { get;  protected set; }

        public string UserName { get; protected set; }

        public string FullName { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public string Role { get; protected set; }

        public DateTime CreatedAt { get;protected set; }

        //constructor is protected to nonone create empty object and   
        //avoid troubles  with serialization process
        protected User()
        {

        }
       
        public User (Guid id,string email,string username,string password,string role,string salt)
        {
            ID = id;
            Email = email;
            UserName = username;
            Password = password;
            Role = role;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
            
private void SetEmail(string email)
        {
            if(String.IsNullOrEmpty(email))
            {
                throw new DomainException("Put the e-mail");
            }
            else
            {
                return;
            }

            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        private void SetPassword(string password)
        {
            if(String.IsNullOrEmpty(password))
            {
               throw new DomainException (ErrorCode.InvalidePassword,"Put the password");
            }
            else if(password.Length<5)
            {
                throw new DomainException(ErrorCode.InvalidePassword,"Password must by longer");
            }
            else if (password.Length>100)
            {
                throw new DomainException(ErrorCode.InvalidePassword,"Password must be shorter");
            }

            else if(Password==password)
            {
                return;
            }
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }


        private void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new DomainException(ErrorCode.InvalideRole, "Invalisd user's role");
            }
            else
                return;

            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        private void SetName(string name)
        {
            if(String.IsNullOrEmpty(name))
            {
                //we don't want to our errorCode was full write, it must get better format( e.g. camelCase or snakeCase...)
                //we don't want to our Exception use only message beceause it is useless
                //so we must pass errorCode
                throw new DomainException("Invalid user name","Put the user name");
            }
            else
            {
                return;
            }
            UserName= name;
            CreatedAt = DateTime.UtcNow;
        }
        //I'm gonna use above methods like vlaue object-i will crate  this object only single time and i will  never change it  

            }
}
