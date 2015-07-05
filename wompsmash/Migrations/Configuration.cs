namespace wompsmash.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wompsmash.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<wompsmash.DAL.WompSmashContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(wompsmash.DAL.WompSmashContext context)
        {
            var authors = new List<Author>
            {
                new Author{LastName="Bennett", FirstName="Jeremy", Email="jeremy186@hotmail.com", DateAdded=DateTime.Now},
                new Author{LastName="Walker", FirstName="Johnny", Email="johnny@johnny.com", DateAdded=DateTime.Now}

            };

            authors.ForEach(s => context.Author.AddOrUpdate(p=>p.LastName, s));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project{Title="WompSmash", Date=DateTime.Parse("2015-06-11"), Location="WompSmash", AuthorID=1},
                new Project{Title="Graph Data Structure", Date=DateTime.Parse("2014-05-05"), Location="GraphDataStructure", AuthorID=1}
            };

            projects.ForEach(s => context.Project.AddOrUpdate(p=>p.Title, s));
            context.SaveChanges();

            var blogPosts = new List<BlogPost>
            {
                new BlogPost{Title="The Beginning", PublishDate=DateTime.Parse("2015-06-05"), AuthorID=1},
                new BlogPost{Title="My Favourite Books", PublishDate=DateTime.Parse("2015-06-11"), AuthorID=1}
            };

            blogPosts.ForEach(s => context.BlogPost.AddOrUpdate(p=> p.Title, s));
            context.SaveChanges();

            context.Contacts.AddOrUpdate(p => p.Name,
                new Contact
                {
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "debra@example.com",
                    Twitter = "debra_example"
                },
                new Contact
                {
                    Name = "Johnnie Walker",
                    Address = "1234 stupid street",
                    City = "belgium",
                    State = "north america",
                    Zip = "1323",
                    Email = "johnny@walker.com",
                    Twitter = "johnny"
                }
                );
        }
    }
}
