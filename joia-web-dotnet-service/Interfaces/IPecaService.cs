using joia_web_dotnet_domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_service.Interfaces
{
    public interface IPecaService
    {
        List<Peca> ListarPecas();
    }
}
