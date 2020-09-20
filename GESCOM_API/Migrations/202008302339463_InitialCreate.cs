namespace GESCOM_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agenciador_tb",
                c => new
                    {
                        agenciador_id = c.Int(nullable: false, identity: true),
                        pessoa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.agenciador_id)
                .ForeignKey("dbo.pessoa_tb", t => t.pessoa_id)
                .Index(t => t.pessoa_id);
            
            CreateTable(
                "dbo.pessoa_tb",
                c => new
                    {
                        pessoa_id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 45, unicode: false),
                        cpf_cnpj = c.String(nullable: false, maxLength: 15, unicode: false),
                        tipo_pessoa = c.Int(),
                        email = c.String(maxLength: 75, unicode: false),
                    })
                .PrimaryKey(t => t.pessoa_id);
            
            CreateTable(
                "dbo.corretor_tb",
                c => new
                    {
                        corretor_id = c.Int(nullable: false, identity: true),
                        pessoa_id = c.Int(nullable: false),
                        codigo_susep = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.corretor_id)
                .ForeignKey("dbo.pessoa_tb", t => t.pessoa_id)
                .Index(t => t.pessoa_id);
            
            CreateTable(
                "dbo.cotacao_tb",
                c => new
                    {
                        cotacao_id = c.Int(nullable: false, identity: true),
                        segurado_id = c.Int(nullable: false),
                        ramo_id = c.Int(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 50, unicode: false),
                        premio = c.Decimal(nullable: false, precision: 18, scale: 0),
                        data_inicio_vigencia = c.DateTime(nullable: false),
                        data_fim_vigencia = c.DateTime(nullable: false),
                        data_cotacao = c.DateTime(nullable: false),
                        corretor_id = c.Int(nullable: false),
                        seguradora_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cotacao_id)
                .ForeignKey("dbo.ramo_tb", t => t.ramo_id)
                .ForeignKey("dbo.segurado_tb", t => t.segurado_id)
                .ForeignKey("dbo.seguradora_tb", t => t.seguradora_id)
                .ForeignKey("dbo.corretor_tb", t => t.corretor_id)
                .Index(t => t.segurado_id)
                .Index(t => t.ramo_id)
                .Index(t => t.corretor_id)
                .Index(t => t.seguradora_id);
            
            CreateTable(
                "dbo.proposta_tb",
                c => new
                    {
                        proposta_id = c.Int(nullable: false, identity: true),
                        cotacao_id = c.Int(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 45, unicode: false),
                        data_proposta = c.DateTime(nullable: false),
                        data_emissao = c.DateTime(nullable: false),
                        parcelamento = c.Int(nullable: false),
                        premio_liquido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        agenciamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.proposta_id)
                .ForeignKey("dbo.cotacao_tb", t => t.cotacao_id)
                .Index(t => t.cotacao_id);
            
            CreateTable(
                "dbo.proposta_parcela_tb",
                c => new
                    {
                        proposta_parcela_id = c.Int(nullable: false, identity: true),
                        proposta_id = c.Int(nullable: false),
                        numero_parcela = c.Int(nullable: false),
                        data_vencimento = c.DateTime(nullable: false),
                        premio_liquido = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.proposta_parcela_id)
                .ForeignKey("dbo.proposta_tb", t => t.proposta_id)
                .Index(t => t.proposta_id);
            
            CreateTable(
                "dbo.recibo_comissao_tb",
                c => new
                    {
                        recibo_comissao_id = c.Int(nullable: false, identity: true),
                        proposta_id = c.Int(nullable: false),
                        valor_bruto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        valor_liquido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        percentual_comissao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        percentual_imposto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.recibo_comissao_id)
                .ForeignKey("dbo.proposta_tb", t => t.proposta_id)
                .Index(t => t.proposta_id);
            
            CreateTable(
                "dbo.recibo_agenciamento_detalhe_tb",
                c => new
                    {
                        recibo_agenciamento_detalhe_id = c.Int(nullable: false, identity: true),
                        recibo_comissao_id = c.Int(nullable: false),
                        agenciador_id = c.Int(nullable: false),
                        data_pagamento = c.DateTime(nullable: false),
                        valor_pagamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        percentual_comissao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status_pagamento = c.Int(),
                    })
                .PrimaryKey(t => t.recibo_agenciamento_detalhe_id)
                .ForeignKey("dbo.recibo_comissao_tb", t => t.recibo_comissao_id)
                .ForeignKey("dbo.agenciador_tb", t => t.agenciador_id)
                .Index(t => t.recibo_comissao_id)
                .Index(t => t.agenciador_id);
            
            CreateTable(
                "dbo.recibo_comissao_detalhe_tb",
                c => new
                    {
                        recibo_comissao_detalhe_id = c.Int(nullable: false, identity: true),
                        recibo_comissao_id = c.Int(nullable: false),
                        corretor_id = c.Int(nullable: false),
                        data_pagamento = c.DateTime(nullable: false),
                        valor_pagamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        percentual_comissao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status_pagamento = c.Int(),
                        recibo_comissao_tb1_recibo_comissao_id = c.Int(),
                    })
                .PrimaryKey(t => t.recibo_comissao_detalhe_id)
                .ForeignKey("dbo.recibo_comissao_tb", t => t.recibo_comissao_tb1_recibo_comissao_id)
                .ForeignKey("dbo.recibo_comissao_tb", t => t.recibo_comissao_id)
                .ForeignKey("dbo.corretor_tb", t => t.corretor_id)
                .Index(t => t.recibo_comissao_id)
                .Index(t => t.corretor_id)
                .Index(t => t.recibo_comissao_tb1_recibo_comissao_id);
            
            CreateTable(
                "dbo.ramo_tb",
                c => new
                    {
                        ramo_id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 10, unicode: false),
                        descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ramo_id);
            
            CreateTable(
                "dbo.segurado_tb",
                c => new
                    {
                        segurado_id = c.Int(nullable: false, identity: true),
                        pessoa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.segurado_id)
                .ForeignKey("dbo.pessoa_tb", t => t.pessoa_id)
                .Index(t => t.pessoa_id);
            
            CreateTable(
                "dbo.seguradora_tb",
                c => new
                    {
                        seguradora_id = c.Int(nullable: false, identity: true),
                        pessoa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.seguradora_id)
                .ForeignKey("dbo.pessoa_tb", t => t.pessoa_id)
                .Index(t => t.pessoa_id);
            
            CreateTable(
                "dbo.dados_bancarios_tb",
                c => new
                    {
                        dados_bancarios_id = c.Int(nullable: false),
                        codigo_banco = c.Long(),
                        codigo_agencia = c.Long(),
                        conta_corrente = c.Long(),
                        pessoa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dados_bancarios_id)
                .ForeignKey("dbo.pessoa_tb", t => t.dados_bancarios_id)
                .Index(t => t.dados_bancarios_id);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        cpf_cnpj = c.String(),
                        Tipo_Pessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.recibo_agenciamento_detalhe_tb", "agenciador_id", "dbo.agenciador_tb");
            DropForeignKey("dbo.seguradora_tb", "pessoa_id", "dbo.pessoa_tb");
            DropForeignKey("dbo.segurado_tb", "pessoa_id", "dbo.pessoa_tb");
            DropForeignKey("dbo.dados_bancarios_tb", "dados_bancarios_id", "dbo.pessoa_tb");
            DropForeignKey("dbo.corretor_tb", "pessoa_id", "dbo.pessoa_tb");
            DropForeignKey("dbo.recibo_comissao_detalhe_tb", "corretor_id", "dbo.corretor_tb");
            DropForeignKey("dbo.cotacao_tb", "corretor_id", "dbo.corretor_tb");
            DropForeignKey("dbo.cotacao_tb", "seguradora_id", "dbo.seguradora_tb");
            DropForeignKey("dbo.cotacao_tb", "segurado_id", "dbo.segurado_tb");
            DropForeignKey("dbo.cotacao_tb", "ramo_id", "dbo.ramo_tb");
            DropForeignKey("dbo.proposta_tb", "cotacao_id", "dbo.cotacao_tb");
            DropForeignKey("dbo.recibo_comissao_tb", "proposta_id", "dbo.proposta_tb");
            DropForeignKey("dbo.recibo_comissao_detalhe_tb", "recibo_comissao_id", "dbo.recibo_comissao_tb");
            DropForeignKey("dbo.recibo_comissao_detalhe_tb", "recibo_comissao_tb1_recibo_comissao_id", "dbo.recibo_comissao_tb");
            DropForeignKey("dbo.recibo_agenciamento_detalhe_tb", "recibo_comissao_id", "dbo.recibo_comissao_tb");
            DropForeignKey("dbo.proposta_parcela_tb", "proposta_id", "dbo.proposta_tb");
            DropForeignKey("dbo.agenciador_tb", "pessoa_id", "dbo.pessoa_tb");
            DropIndex("dbo.dados_bancarios_tb", new[] { "dados_bancarios_id" });
            DropIndex("dbo.seguradora_tb", new[] { "pessoa_id" });
            DropIndex("dbo.segurado_tb", new[] { "pessoa_id" });
            DropIndex("dbo.recibo_comissao_detalhe_tb", new[] { "recibo_comissao_tb1_recibo_comissao_id" });
            DropIndex("dbo.recibo_comissao_detalhe_tb", new[] { "corretor_id" });
            DropIndex("dbo.recibo_comissao_detalhe_tb", new[] { "recibo_comissao_id" });
            DropIndex("dbo.recibo_agenciamento_detalhe_tb", new[] { "agenciador_id" });
            DropIndex("dbo.recibo_agenciamento_detalhe_tb", new[] { "recibo_comissao_id" });
            DropIndex("dbo.recibo_comissao_tb", new[] { "proposta_id" });
            DropIndex("dbo.proposta_parcela_tb", new[] { "proposta_id" });
            DropIndex("dbo.proposta_tb", new[] { "cotacao_id" });
            DropIndex("dbo.cotacao_tb", new[] { "seguradora_id" });
            DropIndex("dbo.cotacao_tb", new[] { "corretor_id" });
            DropIndex("dbo.cotacao_tb", new[] { "ramo_id" });
            DropIndex("dbo.cotacao_tb", new[] { "segurado_id" });
            DropIndex("dbo.corretor_tb", new[] { "pessoa_id" });
            DropIndex("dbo.agenciador_tb", new[] { "pessoa_id" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.dados_bancarios_tb");
            DropTable("dbo.seguradora_tb");
            DropTable("dbo.segurado_tb");
            DropTable("dbo.ramo_tb");
            DropTable("dbo.recibo_comissao_detalhe_tb");
            DropTable("dbo.recibo_agenciamento_detalhe_tb");
            DropTable("dbo.recibo_comissao_tb");
            DropTable("dbo.proposta_parcela_tb");
            DropTable("dbo.proposta_tb");
            DropTable("dbo.cotacao_tb");
            DropTable("dbo.corretor_tb");
            DropTable("dbo.pessoa_tb");
            DropTable("dbo.agenciador_tb");
        }
    }
}
