using System.Data.Entity.ModelConfiguration;

namespace MVC.EF.Mappings.Models.EntityConfig
{
    public class PessoaFisicaConfig : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfig()
        {
            HasKey(p => p.PessoaFisicaId);

            Property(c => c.Cpf)
                .HasMaxLength(11);

            Property(c => c.Nome)
                .HasMaxLength(100);

            // MAPEAMENTO DE UM PARA UM
            HasRequired(p => p.Pessoa)
                .WithRequiredPrincipal(p => p.PessoaFisica);

            // MAPEAMENTO DE MUITOS PARA MUITOS
            HasMany(f => f.EnderecoList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaFisicaId");
                    me.MapRightKey("EnderecoId");
                    me.ToTable("PessoaFisicaEndereco");
                });
        }
    }
}
