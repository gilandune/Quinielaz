﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielazServices.DataContracts.Usuarios.Request
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}