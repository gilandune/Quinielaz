using QuinielazServices.DataContracts.Usuarios.Request;
using QuinielazServices.DataContracts.Usuarios.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuinielazServices.ServiceContracts
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        [WebInvoke]
        LoginResponse Login(LoginRequest Request);
    }
}
