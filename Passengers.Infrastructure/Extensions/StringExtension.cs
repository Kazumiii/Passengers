﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Extensions
{
 public static   class StringExtension
    {

        public static bool Empty(this string value)
       => string.IsNullOrWhiteSpace(value);

       
    }
}
