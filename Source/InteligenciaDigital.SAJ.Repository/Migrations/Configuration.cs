using InteligenciaDigital.SAJ.FakeObjects;

namespace InteligenciaDigital.SAJ.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InteligenciaDigital.SAJ.Repository.Entity.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InteligenciaDigital.SAJ.Repository.Entity.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ServidoresTef.Add(ServidorTEFFakes.servidorTEF1);
            context.ServidoresTef.Add(ServidorTEFFakes.servidorTEF2);
            context.ServidoresTef.Add(ServidorTEFFakes.servidorTEF3);
            context.SaveChanges();
        }
    }
}
