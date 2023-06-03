using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_domain.Enums
{
    public enum TipoTransacao : byte
    {
        Venda = 1,
        CompraProprio = 2,
        CompraConsignado = 3
    }
}
