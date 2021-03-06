﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielazServices.DataContracts.Usuarios.Request
{
    public class ActualizarUsuarioRequest
    {
        public ActualizarUsuarioRequest()
        {
            Token = string.Empty;
            Id = 0;
            Password = string.Empty;
            Correo = string.Empty;
            Nombre = string.Empty;
            Usuario = string.Empty;
        }
        public string Token { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
    }
}