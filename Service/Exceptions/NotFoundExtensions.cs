﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class NotFoundExtensions(string message) : Exception(message)
    {
    }
}
