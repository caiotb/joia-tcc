using joia_web_dotnet_domain.Entities;
using joia_web_dotnet_infra;
using joia_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_service
{
    public class PecaService : IPecaService
    {

        private readonly joiaDbContext _dbContext;
        public PecaService(joiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Peca> ListarPecas()
        {
            var dbSet = _dbContext.Pecas.Include(x=> x.Imagens).Include(y => y.Metal);
            foreach(var item in dbSet)
            {
                item.Preco = item.Metal.PrecoPorGrama * item.Peso;
            }
            return dbSet.OrderBy(x => x.Id).ToList();  
        }
    }
}
