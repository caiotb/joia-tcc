using joia_web_dotnet.Models;
using joia_web_dotnet_service;
using joia_web_dotnet_service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using X.PagedList;

namespace joia_web_dotnet.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IPecaService _pecaService;


        public HomeController(ILogger<HomeController> logger,
            IUsuarioService usuarioService,
            IPecaService pecaService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _pecaService = pecaService;
    }

        [AllowAnonymous]
        public IActionResult Login(bool erroLogin)
        {

            if (erroLogin)
            {
                ViewBag.Erro = "Usuário e/ou senha estão incorretos";
            }
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Home");
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Autenticacao(UserModel user)
        {
            var usuario = await _usuarioService.GetUsuario(user.NomeUsuario, user.Senha);

            if (usuario == null)
            {
                return RedirectToAction("Login", new { erroLogin = true });
            }
        
            await new LoginService().Login(HttpContext, usuario.FirstOrDefault().Key, usuario.FirstOrDefault().Value);

            return RedirectToAction("Home");
        }

        [Authorize]
        public async Task<IActionResult> Sair()
        {
            await new LoginService().Logoff(HttpContext);
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Home(int pagina = 1)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Login");
            var listaPecas = _pecaService.ListarPecas();
            List<PecaModel> listaPecaModel = new List<PecaModel>();
            foreach(var item in listaPecas)
            {
                var itemPecaModel = new PecaModel();
                itemPecaModel.Id = item.Id;
                itemPecaModel.Nome = item.Nome;
                itemPecaModel.Preco = $"{string.Format(new CultureInfo("pt-br", false), "{0:c0}", item.Preco)},00"; 
                itemPecaModel.Imagem = item.Imagens.ToList().FirstOrDefault().Url;
                listaPecaModel.Add(itemPecaModel);
            }
            PecaBuscaPagedList model = new PecaBuscaPagedList()
            {
                Peca = listaPecaModel.ToPagedList(pagina, 10),
                Busca = ""
            };
            return View(model);
        }


    }
}