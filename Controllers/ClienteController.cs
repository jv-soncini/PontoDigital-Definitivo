using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital_Definitivo.Models;
using PontoDigital_Definitivo.Repositories;
using PontoDigital_Definitivo.ViewModel;

namespace PontoDigital_Definitivo.Controllers {
    public class ClienteController : Controller {

        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_CLIENTE = "_CLIENTE";
        private const string SESSION_ADMIN = "_ADMIN";
        ComentsRepository comentsrepository = new ComentsRepository ();
        ClienteRepository clienterepository = new ClienteRepository ();
        AdminRepository adminrepository = new AdminRepository ();
        ClienteModel cliente = new ClienteModel ();

        ComentariosViewModel comentarios = new ComentariosViewModel ();

        public IActionResult Login () {

            return View ();
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form) {

            var usuario = form["email"];
            var senha = form["senha"];

            var clienterecuperado = clienterepository.ListarUsuarios ();

            foreach (var item in clienterecuperado) {

                if (usuario.Equals (item.Email) && senha.Equals (item.Senha)) {

                    HttpContext.Session.SetString (SESSION_EMAIL, usuario);
                    HttpContext.Session.SetString (SESSION_CLIENTE, item.Nome);

                    System.Console.WriteLine (usuario);
                    System.Console.WriteLine (senha);

                    break;
                } else if (usuario.Equals ("Cesar@gmail.com") && senha.Equals ("senha123")) {
                    HttpContext.Session.SetString (SESSION_EMAIL, usuario);
                    HttpContext.Session.SetString (SESSION_ADMIN, "robert");

                    System.Console.WriteLine (usuario);
                    System.Console.WriteLine (senha);
                    System.Console.WriteLine (item.Senha);
                    System.Console.WriteLine (item.Email);

                } else {
                    return View ();

                }

            }

            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Logout () {
            HttpContext.Session.Remove (SESSION_EMAIL);
            HttpContext.Session.Remove (SESSION_CLIENTE);
            HttpContext.Session.Remove (SESSION_ADMIN);
            HttpContext.Session.Clear ();

            return RedirectToAction ("Index", "Home");

        }

        public IActionResult Comentar () {

            var listaRecuperada = comentsrepository.ListarComents ();

            ComentariosViewModel cornomentarios = new ComentariosViewModel ();

            cornomentarios.Comentarios = listaRecuperada;

            return View (cornomentarios);
        }

        [HttpPost]
        public IActionResult Comentar (IFormCollection form) {

            Comentarios comentarios = new Comentarios ();
            comentarios.Nome = form["normie"];
            comentarios.Comentario = form["textarial"];

            comentsrepository.RegistrarComents (comentarios);

            return RedirectToAction ("Index", "Home");
        }

        public IActionResult Aprovar () {

            var listaDeComents = comentsrepository.ListarComents ();

            foreach (var item in listaDeComents) {
                item.Condicao = "aprovado";

            }

            return View ("Index", "Home");
        }

        public IActionResult Oq () {
            return View ();
        }
        public IActionResult QuemSms () {
            return View ();
        }
        public IActionResult Pacotes(){
            return View();
        }

    }

}