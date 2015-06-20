using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wompsmash.Models;

namespace wompsmash.DAL
{
    public class WompSmashInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<WompSmashContext>
    {
        
        protected override void Seed(WompSmashContext context)
        {
            
            var authors = new List<Author>
            {
                new Author{LastName="Bennett", FirstName="Jeremy", Email="jeremy186@hotmail.com", DateAdded=DateTime.Now},
                new Author{LastName="Walker", FirstName="Johnny", Email="johnny@johnny.com", DateAdded=DateTime.Now}

            };

            authors.ForEach(s=>context.Author.Add(s));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project{Title="WompSmash", Date=DateTime.Parse("2015-06-11"), Location="WompSmash", AuthorID=1},
                new Project{Title="Graph Data Structure", Date=DateTime.Parse("2014-05-05"), Location="GraphDataStructure", AuthorID=1}
            };

            projects.ForEach(s => context.Project.Add(s));
            context.SaveChanges();

            var blogPosts = new List<BlogPost>
            {
                new BlogPost{Title="The Beginning", PublishDate=DateTime.Parse("2015-06-05"), AuthorID=1},
                new BlogPost{Title="My Favourite Books", PublishDate=DateTime.Parse("2015-06-11"), AuthorID=1}
            };

            blogPosts.ForEach(s=> context.BlogPost.Add(s));
            context.SaveChanges();
        }
        
    }
}
