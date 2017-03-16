using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuinielazCore.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Activo = false;
            UserName = string.Empty;
            Correo = string.Empty;
            Password = string.Empty;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
    }
}
