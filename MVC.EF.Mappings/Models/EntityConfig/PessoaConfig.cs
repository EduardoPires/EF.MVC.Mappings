using System.Data.Entity.ModelConfiguration;

namespace MVC.EF.Mappings.Models.EntityConfig
{
    public class PessoaConfig : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfig()
        {
            HasKey(p => p.PessoaId);

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            Property(p => p.NegarCredito)
                .IsRequired();

        }
    }
}