using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital_Definitivo.Repositories;
using PontoDigital_Definitivo.ViewModel;

namespace PontoDigitalCSharp.Controllers {
    public class HomeController : Controller {

        ComentsRepository comentsrepository = new ComentsRepository ();
        ClienteRepository clienteRepository = new ClienteRepository();


        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";
        private const string SESSION_ADMIN = "_ADMIN";
        public IActionResult Index () {

            ViewData["User"] = HttpContext.Session.GetString (SESSION_EMAIL);
            ViewData["Admin"] = HttpContext.Session.GetString (SESSION_ADMIN);
            ViewData["NomeView"] = "Home";

            var listaRecuperada = comentsrepository.ListarComents();
            var ListaDeUsers = clienteRepository.ListarUsuarios();

                ComentariosViewModel cornomentarios = new ComentariosViewModel();
                    

                cornomentarios.Comentarios = listaRecuperada;
                cornomentarios.Clientes = ListaDeUsers;
            return View (cornomentarios);
        }

        public IActionResult ListarRegistro()
        {
            var ListaDeUsers = clienteRepository.ListarUsuarios();

            ComentariosViewModel Admin = new ComentariosViewModel();
            
            Admin.Clientes = ListaDeUsers;


            return View(Admin);
        }

        public IActionResult ListarComents()
        {
            ComentariosViewModel cornomentarios = new ComentariosViewModel();
            
            var listaComents = comentsrepository.ListarComents();

            cornomentarios.Comentarios = listaComents;

            return View(cornomentarios);
        }
    }
}