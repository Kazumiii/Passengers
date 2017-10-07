using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Services
{
 public   interface IEncrypt
    {
        string GetSalt(string value);

        string GetHash(string value, string salt);

    }
}
