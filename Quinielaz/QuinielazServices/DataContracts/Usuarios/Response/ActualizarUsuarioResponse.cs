using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuinielazServices.DataContracts.Usuarios.Response
{
    public class ActualizarUsuarioResponse
    {
        public ActualizarUsuarioResponse()
        {
            Success = false;
            Message = string.Empty;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}