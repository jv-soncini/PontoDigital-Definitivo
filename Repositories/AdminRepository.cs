using System;
using System.Collections.Generic;
using System.IO;
using PontoDigital_Definitivo.Models;

namespace PontoDigital_Definitivo.Repositories {
    public class AdminRepository {
        private const string PATH = "DataBases/RegistroADM.csv";
        List<AdminModel> ListaDeAdmin = new List<AdminModel> ();

        public List<AdminModel> ListarAdmin () {
            string[] Usuarios = File.ReadAllLines (PATH);

            foreach (var item in Usuarios) {
                if (item != null) {
                    string[] dados = item.Split (";");
                    var usuario = new AdminModel ();

                    usuario.Id = int.Parse (dados[0]);
                    usuario.Nome = dados[1];
                    usuario.Email = dados[2];
                    usuario.Telefone = dados[3];
                    usuario.Senha = dados[4];
                    usuario.DataNascimento = DateTime.Parse (dados[5]);
                    usuario.Type = dados[6];

                    ListaDeAdmin.Add (usuario);
                }
            }
            return ListaDeAdmin;
        }
    }
}