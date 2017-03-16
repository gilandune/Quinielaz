using BusinessLogic.Extensions;
using QuinielazCore.Entidades;
using QuinielazCore.Usuarios;
using QuinielazServices.DataContracts.Usuarios.Request;
using QuinielazServices.DataContracts.Usuarios.Response;
using QuinielazServices.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QuinielazServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuarioService
    {
        public LoginResponse Login(LoginRequest Request)
        {
            LoginResponse Response = new LoginResponse();
            UsuariosController controller = new UsuariosController();
            Usuario entidad = new Usuario();
            string Token = string.Empty;
            Response.Success = controller.Logear(Request.Username, Request.Password, ref entidad, ref Token);
            Response.CurrentUser = entidad;
            Response.Token = Token;
            return Response;
        }

        public ActualizarUsuarioResponse ActualizarUsuario(ActualizarUsuarioRequest Request)
        {
            ActualizarUsuarioResponse Response = new ActualizarUsuarioResponse();
            if (Security.ValidateToken(Request.Token))
            {
                UsuariosController Controller = new UsuariosController();
                string Message = string.Empty;
                Response.Success = Controller.ActualizarUsuario(Request.Id, Request.Nombre, Request.Correo, Request.Password,Request.Usuario, ref Message);
                Response.Message = Message;
            }
            return Response;
        }

        public ActualizarUsuarioResponse AgregarUsuario(AgregarUsuarioRequest Request)
        {
            ActualizarUsuarioResponse Response = new ActualizarUsuarioResponse();
            if (Security.ValidateToken(Request.Token))
            {
                UsuariosController Controller = new UsuariosController();
                string Message = string.Empty;
                Response.Success = Controller.AgregarUsuario(Request.Nombre, Request.Correo, Request.Password, Request.Usuario, ref Message);
                Response.Message = Message;
            }
            return Response;
        }

        public ActualizarUsuarioResponse ActivarUsuario(AgregarUsuarioRequest Request)
        {
            ActualizarUsuarioResponse Response = new ActualizarUsuarioResponse();
            if (Security.ValidateToken(Request.Token))
            {
                UsuariosController Controller = new UsuariosController();
                string Message = string.Empty;
                Response.Success = Controller.ActivarUsuario(Request.Id, Request.Activo, ref Message);
                Response.Message = Message;
            }
            return Response;
        }
    }
}
