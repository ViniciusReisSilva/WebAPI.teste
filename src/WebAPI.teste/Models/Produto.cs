using System;

namespace WebAPI.teste.Models
{
    public class Produto
    {
        public int Id { get; private set; }
        public String Nome { get; private set; }
        public Double Preco { get; private set; }
        public String Descricao { get; private set; }

        public Produto(int id, String nome, Double preco, String descricao)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
        }
    }
}