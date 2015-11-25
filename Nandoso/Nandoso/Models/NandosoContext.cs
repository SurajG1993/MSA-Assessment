using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Nandoso.Models
{
    public class NandosoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<NandosoContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }

            protected override void Seed(NandosoContext context)
            {
                var Menu = new List<MenuModel>
                {
                    new MenuModel { itemName = "Quarter Chicken", itemPrice = 8.90f}
                };
                Menu.ForEach(s => context.MenuModels.AddOrUpdate(p => p.itemPrice, s));
                context.SaveChanges();

                var SpecialMenu = new List<SpecialModel>
                {
                    new SpecialModel { itemName = "Quarter Chicken", itemPrice = 7.90f}
                };
                SpecialMenu.ForEach(s => context.SpecialModels.AddOrUpdate(p => p.itemPrice, s));
                context.SaveChanges();

                var feedback = new List<ForumPost>
                {
                    new ForumPost { userName = "Suraj", post="The the quarter chicken is awesome !!!"},
                    new ForumPost { userName = "MSA-1", post="The Best flame grilled Resturant Ever :) "},
                    new ForumPost { userName = "MSA-2", post="The chicken was amazing"},
                };
                feedback.ForEach(s => context.ForumPosts.AddOrUpdate(p => p.post, s));
                context.SaveChanges();

                var ForumReply = new List<ForumReplies>
                {
                    new ForumReplies { userName = "Random", reply="I agree !!!!", postID=1},
                    new ForumReplies { userName = "Random", reply="Awsome Chicken indeed", postID=1},
                    new ForumReplies { userName = "Random", reply="Agreed", postID=2},
                    new ForumReplies { userName = "Random", reply="Right on", postID=2},
                    new ForumReplies { userName = "Random", reply="Amazing resturant", postID=3},
                    new ForumReplies { userName = "Random", reply="I agree !!!!", postID=3}
                };
                ForumReply.ForEach(s => context.ForumReplies.AddOrUpdate(p => p.reply, s));
                context.SaveChanges();

            }
        }

            public NandosoContext() : base("name=NandosoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoContext, MyConfiguration>());

        }

        public System.Data.Entity.DbSet<Nandoso.Models.MenuModel> MenuModels { get; set; }

        public System.Data.Entity.DbSet<Nandoso.Models.SpecialModel> SpecialModels { get; set; }

        public System.Data.Entity.DbSet<Nandoso.Models.ForumReplies> ForumReplies { get; set; }

        public System.Data.Entity.DbSet<Nandoso.Models.ForumPost> ForumPosts { get; set; }
    }
}