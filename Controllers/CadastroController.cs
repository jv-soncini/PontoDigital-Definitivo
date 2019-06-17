using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoDigital_Definitivo.Models;
using PontoDigital_Definitivo.Repositories;

namespace PontoDigital_Definitivo.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienterepository = new ClienteRepository ();
        public IActionResult Index(){
           
           @ViewData["Nomeview"] = "Cadastro";
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar (IFormCollection form) {
            ClienteModel cliente = new ClienteModel ();
            cliente.Nome = form["nome"];
            cliente.Email = form["email"];
            cliente.Telefone = form["telefone"];
            cliente.DataNascimento = DateTime.Parse (form["data-nascimento"]);
            cliente.Senha = form["senha"];

            clienterepository.RegistrarNoCSV(cliente);
            
            return RedirectToAction ("Login","Cliente");
        }
    }
}