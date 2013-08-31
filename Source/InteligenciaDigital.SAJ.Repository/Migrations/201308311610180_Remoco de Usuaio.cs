namespace InteligenciaDigital.SAJ.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemocodeUsuaio : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Logs");
            DropTable("dbo.Usuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                        SenhaRepetida = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RequestInfo = c.String(),
                        RequestJson = c.String(),
                        ResponseJson = c.String(),
                        TempoRequisicao = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
