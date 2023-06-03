using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_service.Interfaces
{
    public interface IUsuarioService
    {
        Task<Dictionary<string, string>> GetUsuario(string nomeUsuario, string senha);
    }
}
