﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielazServices.DataContracts.Usuarios.Request
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}