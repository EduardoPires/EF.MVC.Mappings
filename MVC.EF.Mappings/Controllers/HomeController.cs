using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVC.EF.Mappings.Contexto;
using MVC.EF.Mappings.Models;

namespace MVC.EF.Mappings.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var rnd = new Random();

            // Pessoa
            var pessoa = new Pessoa()
            {
                DataCadastro = DateTime.Now,
                Ativo = true,
                NegarCredito = false
            };

            // Endereco PF de Pessoa
            var enderecoPF = new Endereco()
            {
                Logradouro = "Rua dos Moradores ",
                Bairro = "Centro",
                Cep = "321000" + rnd.Next(1, 13),
                Estado = "São Paulo",
                Cidade = "São Paulo",
                Numero = rnd.Next(1, 13).ToString(),
                Complemento = "Fundos"
            };

            // PF de Pessoa
            var pessoaFisica = new PessoaFisica()
            {
                Nome = "Nome " + rnd.Next(1, 13),
                Cpf = "321456987" + rnd.Next(1, 13),
                Pessoa = pessoa
            };

            // Endereco PJ 1 de Pessoa
            var enderecoPJ1 = new Endereco()
            {
                Logradouro = "Av. Paulista ",
                Bairro = "Bela Vista",
                Cep = "123000" + rnd.Next(1, 13),
                Estado = "São Paulo",
                Cidade = "São Paulo",
                Numero = rnd.Next(1, 13).ToString(),
                Complemento = "Frente"
            };

            // Endereco PJ 2 de Pessoa
            var enderecoPJ2 = new Endereco()
            {
                Logradouro = "Av. Paulista ",
                Bairro = "Bela Vista",
                Cep = "123000" + rnd.Next(1, 13),
                Estado = "São Paulo",
                Cidade = "São Paulo",
                Numero = rnd.Next(1, 13).ToString(),
                Complemento = "Frente"
            };

            // PJ 1 de Pessoa
            var pessoaJuridica1 = new PessoaJuridica()
            {
                RazaoSocial = "Empresa " + rnd.Next(1, 13),
                Cnpj = "986543210001" + rnd.Next(1, 13),
                Pessoa = pessoa
            };

            // PJ 2 de Pessoa
            var pessoaJuridica2 = new PessoaJuridica()
            {
                RazaoSocial = "Empresa " + rnd.Next(1, 13),
                Cnpj = "986543210001" + rnd.Next(1, 13),
                Pessoa = pessoa
            };

            // Instancia do Contexto do EF
            var contexto = new ApplicationDbContext();

            //#### INICIO SETUP de PF, PJ e Endereços ####

            // Adicionando EnderecoPF em PF
            pessoaFisica.EnderecoList.Add(enderecoPF);

            // Adicionando PF em Pessoa
            pessoa.PessoaFisica = pessoaFisica;

            // Adicionando EnderecoPJ1 em PJ1
            pessoaJuridica1.EnderecoList.Add(enderecoPJ1);

            // Adicionando EnderecoPJ2 em PJ2
            pessoaJuridica2.EnderecoList.Add(enderecoPJ2);

            // Adicionando PJ 1 em Pessoa
            pessoa.PessoaJuridicaList.Add(pessoaJuridica1);

            // Adicionando PJ 2 em Pessoa
            pessoa.PessoaJuridicaList.Add(pessoaJuridica2);

            //#### FIM SETUP de PF, PJ e Endereços ####

            // Adicionando Pessoa no Contexto
            contexto.Pessoa.Add(pessoa);

            // Salvando todas as inclusões
            contexto.SaveChanges();

            //try
            //{
            //    contexto.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    var sb = new StringBuilder();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }
            //}

            //var todosOsDados = contexto.Pessoa.ToList();

            var todosOsDados = contexto.Pessoa
                .Include(p => p.PessoaFisica)
                .Include(p => p.PessoaJuridicaList)
                .Include(p => p.PessoaJuridicaList.Select(c => c.EnderecoList))
                .Include(p => p.PessoaFisica.EnderecoList).ToList();

            return View(todosOsDados);
        }
    }
}