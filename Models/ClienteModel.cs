using System;

namespace PontoDigital_Definitivo.Models {
    public class ClienteModel {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}