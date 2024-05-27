using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Shoeses.Entitis.ShoppingCarts;

namespace Shoeses.Migrations
{
    [Migration(202405261147)]
    public class _202405261147_ShopingCartMigration:Migration
    {
        public override void Up()
        {
            Create.Table("ShoppingCarts")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsString().NotNullable();

            Create.ForeignKey("FK_ShoppingCarts_AspNetUsers_UserId")
                .FromTable("ShoppingCarts").ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id");

            Create.UniqueConstraint("UC_ShoppingCarts_UserId")
                .OnTable("ShoppingCarts")
                .Column("UserId");
        }

        public override void Down()
        {
            Delete.UniqueConstraint("UC_ShoppingCarts_UserId").FromTable("ShoppingCarts");
            Delete.ForeignKey("FK_ShoppingCarts_AspNetUsers_UserId").OnTable("ShoppingCarts");
            Delete.Table("ShoppingCarts");
        }
    }
}
