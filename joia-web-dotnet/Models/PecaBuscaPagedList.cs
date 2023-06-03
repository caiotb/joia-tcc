using X.PagedList;

namespace joia_web_dotnet.Models
{
    public class PecaBuscaPagedList
    {
        public IPagedList<joia_web_dotnet.Models.PecaModel> Peca { get; set; }
        public string Busca { get; set; }   
    }
}
