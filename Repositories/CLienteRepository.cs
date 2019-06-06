using System.IO;
using PontoDigital_Definitivo.Models;

namespace PontoDigital_Definitivo.Repositories
{
    public class CLienteRepository
    {
        private const string PATH = "DataBase/Registro.csv";
        public void RegistrarNoCSV (ClienteModel ClienteRegistro) {

            if (File.Exists (PATH)) {
                ClienteRegistro.Id = File.ReadAllLines (PATH).Length + 1;
            } else {
                ClienteRegistro.Id = 1;
            }

            StreamWriter sw = new StreamWriter (PATH, true);

            sw.WriteLine ($"{ClienteRegistro.Id};{ClienteRegistro.Nome};{ClienteRegistro.Email};{ClienteRegistro.Telefone};{ClienteRegistro.Senha};{ClienteRegistro.DataNascimento}");
            sw.Close ();
        }
    }
}