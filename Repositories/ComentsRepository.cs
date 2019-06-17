using System.Collections.Generic;
using System.IO;
using PontoDigital_Definitivo.Models;

namespace PontoDigital_Definitivo.Repositories {
    public class ComentsRepository {
        private const string PATH = "DataBases/Comentarios.csv";
        List<Comentarios> ListaDeComents = new List<Comentarios>();
        public void RegistrarComents (Comentarios Coments) {

            if (File.Exists (PATH)) {
                Coments.Id = File.ReadAllLines (PATH).Length + 1;
            } else {
                Coments.Id = 1;
                File.Create(PATH).Close();
            }

            StreamWriter sw = new StreamWriter (PATH, true);

            sw.WriteLine ($"{Coments.Id};{Coments.Comentario};{Coments.Nome}");
            sw.Close ();
        }

        public List<Comentarios> ListarComents () {
            string[] coments = File.ReadAllLines (PATH);

            foreach (var item in coments) {
                if (item != null) {
                    string[] dados = item.Split (";");
                    var comnetarios = new Comentarios ();

                    comnetarios.Id = int.Parse (dados[0]);
                    comnetarios.Comentario = dados[1];
                    comnetarios.Nome = dados[2];
                    comnetarios.Condicao = dados[3];
                    

                    ListaDeComents.Add (comnetarios);
                }
            }
            return ListaDeComents;
        }

    }
}