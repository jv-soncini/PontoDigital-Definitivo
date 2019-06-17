using System;
using System.Collections.Generic;
using System.IO;
using PontoDigital_Definitivo.Models;

namespace PontoDigital_Definitivo.Repositories {
    public class ClienteRepository {

        List<ClienteModel> ListaDeUsuarios = new List<ClienteModel> ();

        private const string PATH = "DataBases/Registro.csv";
        public void RegistrarNoCSV (ClienteModel ClienteRegistro) {

            if (File.Exists (PATH)) {
                ClienteRegistro.Id = File.ReadAllLines (PATH).Length + 1;
            } else {
                ClienteRegistro.Id = 1;
            }

            StreamWriter sw = new StreamWriter (PATH, true);

            sw.WriteLine ($"{ClienteRegistro.Id};{ClienteRegistro.Nome};{ClienteRegistro.Email};{ClienteRegistro.Telefone};{ClienteRegistro.Senha};{ClienteRegistro.DataNascimento.ToShortDateString()}");
            sw.Close ();
        }

        public List<ClienteModel> ListarUsuarios () {
            string[] Usuarios = File.ReadAllLines (PATH);

            foreach (var item in Usuarios) {
                if (item != null) {
                    string[] dados = item.Split (";");
                    var usuario = new ClienteModel ();

                    usuario.Id = int.Parse (dados[0]);
                    usuario.Nome = dados[1];
                    usuario.Email = dados[2];
                    usuario.Telefone = dados[3];
                    usuario.Senha = dados[4];
                    usuario.DataNascimento = DateTime.Parse (dados[5]);

                    ListaDeUsuarios.Add (usuario);
                }
            }
            return ListaDeUsuarios;
        }
    }
}