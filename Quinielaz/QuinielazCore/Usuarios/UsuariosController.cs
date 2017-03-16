using BusinessLogic.Extensions;
using QuinielazCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuinielazCore.Usuarios
{
    public class UsuariosController
    {
        private quinielazdbEntities QuinielazDB;

        /// <summary>
        /// Permite logear a un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="User"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        public bool Logear(string user, string password, ref Usuario User, ref string Token)
        {
            bool Success = false;
            try
            {
                using (QuinielazDB = new quinielazdbEntities())
                {
                    if (QuinielazDB.tbl_usuarios.Any(u => u.vchUsuario == user && u.vchPassword == password && u.bitActivo))
                    {
                        var _usr = (from em in QuinielazDB.tbl_usuarios
                                    where em.bitActivo == true && em.vchUsuario == user && em.vchPassword == password
                                    select new
                                    {
                                        Id = em.intUsuarioID,
                                        Nombre = em.vchNombre ?? "",
                                        _email = em.vchEmail ?? "",
                                        bitActivo = em.bitActivo,
                                        usuario = em.vchUsuario,
                                        pass = em.vchPassword
                                    }).First();
                        if (Success = _usr.Id > 0 ? true : false)
                        {
                            User.Id = _usr.Id;
                            User.Nombre = _usr.Nombre;
                            User.Correo = _usr._email;
                            User.Activo = _usr.bitActivo;
                            User.UserName = _usr.usuario;
                            Token = Security.Encrypt(_usr.Id + "|" + user + "|" + password);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Log.EscribeLog("Error en UsuariosController.Logear: " + exc.Message);
            }
            return Success;
        }

        /// <summary>
        /// Permite agregar un usuario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="usuario"></param>
        /// <param name="OutMessage"></param>
        /// <returns></returns>
        public bool AgregarUsuario(string nombre, string email, string password, string usuario, ref string OutMessage)
        {
            bool Exito = false;
            try
            {
                QuinielazDB = new quinielazdbEntities();
                var Correos = (from registro in QuinielazDB.tbl_usuarios
                               where registro.vchEmail == email
                               select registro).ToList();
                if (Correos.Count > 0)
                {
                    OutMessage = "El usuario que deseas dar de alta ya está asociado a otro usuario";
                    Exito = false;
                }
                else
                {
                    tbl_usuarios _usuario = new tbl_usuarios();
                    _usuario.vchNombre = nombre;
                    _usuario.vchEmail = email;
                    _usuario.vchPassword = password;
                    _usuario.vchUsuario = usuario;
                    _usuario.datFecha = DateTime.Today;
                    _usuario.bitActivo = true;
                    QuinielazDB.tbl_usuarios.Add(_usuario);
                    QuinielazDB.SaveChanges();
                    OutMessage = "Se agregó correctamente el usuario";
                    Exito = true;
                }
                QuinielazDB.Dispose();
            }
            catch (Exception exc)
            {
                OutMessage = "Error en el sistema: " + exc.Message;
                Log.EscribeLog("Error en UsuariosController.AagregarUsuario(" + nombre + "): " + exc.Message);
            }
            return Exito;
        }

        /// <summary>
        /// Permite acutalizar la información del usuario.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="nombre"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="usuario"></param>
        /// <param name="OutMessage"></param>
        /// <returns></returns>
        public bool ActualizarUsuario(int Id, string nombre, string email, string password, string usuario, ref string OutMessage)
        {
            bool Actualizado = false;
            try
            {
                QuinielazDB = new quinielazdbEntities();
                tbl_usuarios _usuario = QuinielazDB.tbl_usuarios.First(i => i.intUsuarioID == Id);
                _usuario.vchNombre = nombre;
                _usuario.vchEmail = email;
                _usuario.vchPassword = password;
                _usuario.vchUsuario = usuario;
                _usuario.datFecha = DateTime.Today;
                _usuario.bitActivo = true;
                QuinielazDB.SaveChanges();
                OutMessage = "La actualización se ha efectuado correctamente";
                Actualizado = true;

                QuinielazDB.Dispose();
            }
            catch (Exception exc)
            {
                OutMessage = "Error en el sistema: " + exc.Message;
                Log.EscribeLog("Error en UsuariosController.ActualizarUsuario(" + Id + "): " + exc.Message);
            }
            return Actualizado;
        }

        /// <summary>
        /// Permite activar o desactivar el usuario.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="bitActivo"></param>
        /// <param name="OutMessage"></param>
        /// <returns></returns>
        public bool ActivarUsuario(int Id, bool bitActivo, ref string OutMessage)
        {
            bool Actualizado = false;
            try
            {
                QuinielazDB = new quinielazdbEntities();
                tbl_usuarios _usuario = QuinielazDB.tbl_usuarios.First(i => i.intUsuarioID == Id);
                _usuario.bitActivo = bitActivo;
                _usuario.datFecha = DateTime.Today;
                QuinielazDB.SaveChanges();
                OutMessage = "La actualización se ha efectuado correctamente";
                Actualizado = true;
                QuinielazDB.Dispose();
            }
            catch (Exception exc)
            {
                OutMessage = "Error en el sistema: " + exc.Message;
                Log.EscribeLog("Error en UsuariosController.ActivarUsuario(" + Id + "): " + exc.Message);
            }
            return Actualizado;
        }
    }
}
