namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data_Access_Layer.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data_Access_Layer.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            /*for (int i = 1004; i < 1020; i++) {
                context.Employees.AddOrUpdate(new Models.Tables.Employee
                {
                    Name = "Employee-" + i,
                    Email = "Emp"+i+"gmail.com",
                    Password = Guid.NewGuid().ToString().Substring(0, 11),
                    Address= Guid.NewGuid().ToString().Substring(0,100),
                    date = Guid.NewGuid().ToString()
                });
                
            }*/
            Random random = new Random();
            for (int i = 1; i<=20; i++)
            {
                context.Posts.AddOrUpdate(new Models.Tables.Post
                {
                    Id = i,
                    Title = Guid.NewGuid().ToString().Substring(0, 5),
                    Description = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    PostedById = random.Next(2, 3),
                });
            }

            for (int i = 1; i <= 100; i++) {
                context.Comments.AddOrUpdate(new Models.Tables.Comment
                {
                    Id = i,
                    CommentText = Guid.NewGuid().ToString().Substring(0, 5),
                    PostId = random.Next(1,21),
                    date = DateTime.Now,
                    CommentedById = random.Next(2, 3),
                });
            }
        }
    }
}
