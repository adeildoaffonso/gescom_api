using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GESCOM_API.Models
{

    public partial class ctx_gescom : DbContext
    {
        public ctx_gescom()
            : base("name=modelo_gescom")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<agenciador_tb> agenciador_tb { get; set; }
        public virtual DbSet<corretor_tb> corretor_tb { get; set; }
        public virtual DbSet<cotacao_tb> cotacao_tb { get; set; }
        public virtual DbSet<pessoa_tb> pessoa_tb { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<proposta_parcela_tb> proposta_parcela_tb { get; set; }
        public virtual DbSet<proposta_tb> proposta_tb { get; set; }
        public virtual DbSet<ramo_tb> ramo_tb { get; set; }
        public virtual DbSet<recibo_agenciamento_detalhe_tb> recibo_agenciamento_detalhe_tb { get; set; }
        public virtual DbSet<recibo_comissao_detalhe_tb> recibo_comissao_detalhe_tb { get; set; }
        public virtual DbSet<recibo_comissao_tb> recibo_comissao_tb { get; set; }
        public virtual DbSet<segurado_tb> segurado_tb { get; set; }
        public virtual DbSet<seguradora_tb> seguradora_tb { get; set; }
        public virtual DbSet<dados_bancarios_tb> dados_bancarios_tb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<agenciador_tb>()
                .HasMany(e => e.recibo_agenciamento_detalhe_tb)
                .WithRequired(e => e.agenciador_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<corretor_tb>()
                .Property(e => e.codigo_susep)
                .IsUnicode(false);

            modelBuilder.Entity<corretor_tb>()
                .HasMany(e => e.cotacao_tb)
                .WithRequired(e => e.corretor_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<corretor_tb>()
                .HasMany(e => e.recibo_comissao_detalhe_tb)
                .WithRequired(e => e.corretor_tb)
                .HasForeignKey(e => e.corretor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<corretor_tb>()
                .HasMany(e => e.recibo_comissao_detalhe_tb1)
                .WithRequired(e => e.corretor_tb1)
                .HasForeignKey(e => e.corretor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cotacao_tb>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<cotacao_tb>()
                .Property(e => e.premio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<cotacao_tb>()
                .HasMany(e => e.proposta_tb)
                .WithRequired(e => e.cotacao_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa_tb>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<pessoa_tb>()
                .Property(e => e.cpf_cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<pessoa_tb>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<pessoa_tb>()
                .HasMany(e => e.corretor_tb)
                .WithRequired(e => e.pessoa_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa_tb>()
                .HasOptional(e => e.dados_bancarios_tb)
                .WithRequired(e => e.pessoa_tb);

            modelBuilder.Entity<pessoa_tb>()
                .HasMany(e => e.segurado_tb)
                .WithRequired(e => e.pessoa_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa_tb>()
                .HasMany(e => e.agenciador_tb)
                .WithRequired(e => e.pessoa_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa_tb>()
                .HasMany(e => e.seguradora_tb)
                .WithRequired(e => e.pessoa_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proposta_tb>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<proposta_tb>()
                .HasMany(e => e.proposta_parcela_tb)
                .WithRequired(e => e.proposta_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proposta_tb>()
                .HasMany(e => e.recibo_comissao_tb)
                .WithRequired(e => e.proposta_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ramo_tb>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<ramo_tb>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<ramo_tb>()
                .HasMany(e => e.cotacao_tb)
                .WithRequired(e => e.ramo_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<recibo_comissao_tb>()
                .HasMany(e => e.recibo_agenciamento_detalhe_tb)
                .WithRequired(e => e.recibo_comissao_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<recibo_comissao_tb>()
                .HasMany(e => e.recibo_comissao_detalhe_tb)
                .WithRequired(e => e.recibo_comissao_tb)
                .HasForeignKey(e => e.recibo_comissao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<recibo_comissao_tb>()
                .HasMany(e => e.recibo_comissao_detalhe_tb1)
                .WithRequired(e => e.recibo_comissao_tb1)
                .HasForeignKey(e => e.recibo_comissao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<segurado_tb>()
                .HasMany(e => e.cotacao_tb)
                .WithRequired(e => e.segurado_tb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<seguradora_tb>()
                .HasMany(e => e.cotacao_tb)
                .WithRequired(e => e.seguradora_tb)
                .WillCascadeOnDelete(false);
        }
    }
}
