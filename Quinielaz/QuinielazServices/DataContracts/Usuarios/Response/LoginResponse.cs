using QuinielazCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielazServices.DataContracts.Usuarios.Response
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            CurrentUser = new Usuario();
            Token = string.Empty;
            Success = false;
        }
        public Usuario CurrentUser { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
    }
}