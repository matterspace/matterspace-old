using Matterspace.Model.Entities;

namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Matterspace.Model.MatterspaceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Matterspace.Model.MatterspaceDbContext context)
        {
#if DEBUG
            // Deletes all data, from all tables, except for __MigrationHistory
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");

            context.Products.Add(new Product()
            {
                Name = "matterspace",
                DisplayName = "Matterspace",
                ShortDescription = "Customer Service & Customer Support are best when automated",
                WebsiteUrl = "http://matterspace.io"
            });

            context.SaveChanges();
#endif
        }
    }
}
