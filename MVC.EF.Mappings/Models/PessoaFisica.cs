using System;
using System.Collections.Generic;

namespace MVC.EF.Mappings.Models
{
    public class PessoaFisica
    {
        public PessoaFisica()
        {
            PessoaFisicaId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
        }

        public Guid PessoaFisicaId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
    }
}