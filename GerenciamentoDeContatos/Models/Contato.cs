﻿using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeContatos.Models
{
	public class Contato
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do contato")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }

        public Contato()
        {
            
        }

        public Contato(string nome, string sobrenome, string email, string telefone)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
        }
    }
}
