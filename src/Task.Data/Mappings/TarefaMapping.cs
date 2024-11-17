using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Business.Models;

namespace TaskManager.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

            builder.Property(t => t.Descricao)
                    .HasMaxLength(1000)
                    .HasColumnType("varchar(1000)");

            builder.Property(t => t.DataDeCriacao)
                    .IsRequired()
                    .HasColumnType("datetime");

            builder.Property(t => t.DataDeConclusao)
                    .HasColumnType("datetime");

            builder.Property(t => t.Status)
                    .IsRequired();

            builder.ToTable("Tarefas");
        }
    }
}
