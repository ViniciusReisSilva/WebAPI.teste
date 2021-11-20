using System;

namespace WebAPI.teste.Models
{
    public class Cliente
    {
        public int Id {get ; private set;}
        public string Nome { get; private set; }
        public DateTime Datanascimento { get; private set; }
        public double Salario { get; private set; }
        public string Sexo { get; private set;}

        public Cliente(int id, string nome, DateTime datanascimento, double salario, string sexo)
        {
            Id = id;
            Nome = nome;
            Datanascimento = datanascimento;
            Salario = salario;
            Sexo = sexo;
        }
    }
}