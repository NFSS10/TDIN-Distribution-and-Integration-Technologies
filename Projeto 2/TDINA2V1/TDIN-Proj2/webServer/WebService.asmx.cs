using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace webServer
{
    /// <summary>
    /// Descrição resumida de WebService
    /// </summary>
    [WebService(Namespace = "http://tdinweb.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        TicketsService client = new TicketsService();

        [WebMethod]
        public string HelloWorld()
        {
            return client.HelloWorld();
        }

        [WebMethod]
        public string Test(string texto)
        {
            return "(Envias-te o texto: "+ client.HelloWorld() + " " +client.Test(texto)+ ")";
        }

    }
}
