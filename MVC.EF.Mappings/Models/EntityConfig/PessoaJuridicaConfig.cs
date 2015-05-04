using System.Data.Entity.ModelConfiguration;

namespace MVC.EF.Mappings.Models.EntityConfig
{
    public class PessoaJuridicaConfig : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfig()
        {
            HasKey(p => p.PessoaJuridicaId);

            Property(c => c.Cnpj)
                .HasMaxLength(14);

            Property(c => c.RazaoSocial)
                 .HasMaxLength(100);

            // MAPEAMENTO DE UM PARA MUITOS
            HasRequired(p => p.Pessoa)
                .WithMany(p => p.PessoaJuridicaList)
                .HasForeignKey(p => p.PessoaId);

            // MAPEAMENTO DE MUITOS PARA MUITOS
            HasMany(f => f.EnderecoList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaJuridicaId");
                    me.MapRightKey("EnderecoId");
                    me.ToTable("PessoaJuridicaEndereco");
                });
        }
    }
}
