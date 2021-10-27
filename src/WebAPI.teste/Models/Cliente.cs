using System;

namespace WebAPI.teste.Models
{
    public class Cliente
    {
        public int Id {get ; private set;}
        public String Nome { get; private set; }
        public DateTime Datanascimento { get; private set; }
        public String Endereco { get; private set; }

        public Cliente(int id, string nome, DateTime datanascimento, String endereco)
        {
            Id = id;
            Nome = nome;
            Datanascimento = datanascimento;
            Endereco = endereco;
        }
    }
}