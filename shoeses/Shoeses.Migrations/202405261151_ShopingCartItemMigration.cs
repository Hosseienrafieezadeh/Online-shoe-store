using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261151)]
    public class _202405261151_ShopingCartItemMigration:Migration
    {
        public override void Up()
        {
            Create.Table("ShoppingCartItems")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Quantity").AsInt32().NotNullable()
                .WithColumn("ShoppingCartId").AsInt32().NotNullable().ForeignKey("ShoppingCarts", "Id");
        }

        public override void Down()
        {
            Delete.Table("ShoppingCartItems");
        }
    }
}
