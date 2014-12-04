using System;
using System.Collections.Generic;

namespace MVC.EF.Mappings.Models
{
    public class PessoaJuridica
    {
        public PessoaJuridica()
        {
            PessoaJuridicaId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
        }

        public Guid PessoaJuridicaId { get; set; }
        
        public string Cnpj { get; set; }
        
        public string RazaoSocial { get; set; }

        public Guid PessoaId { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        
        public virtual ICollection<Endereco> EnderecoList { get; set; }
    }
}