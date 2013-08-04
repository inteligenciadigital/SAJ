namespace InteligenciaDigital.SAJ.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoServidorTEF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServidorTEFs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        EnderecoIP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServidorTEFs");
        }
    }
}
