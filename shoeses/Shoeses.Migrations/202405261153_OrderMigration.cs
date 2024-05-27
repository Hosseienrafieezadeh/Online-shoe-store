using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261153)]
    public class _202405261153_OrderMigration:Migration
    {
        public override void Up()
        {
            Create.Table("Orders")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("OrderDate").AsDateTime().NotNullable()
                .WithColumn("TotalAmount").AsDecimal().NotNullable()
                .WithColumn("OrderStatus").AsString().NotNullable()
                .WithColumn("UserId").AsString().NotNullable()
                .WithColumn("ShippingAddressId").AsInt32().NotNullable()
                .WithColumn("ShoppingCartId").AsInt32().NotNullable(); // Added ShoppingCartId

            // ایجاد کلید خارجی برای UserId
            Create.ForeignKey("FK_Orders_AspNetUsers_UserId")
                .FromTable("Orders").ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id");

            // ایجاد کلید خارجی برای ShippingAddressId
            Create.ForeignKey("FK_Orders_Addresses_ShippingAddressId")
                .FromTable("Orders").ForeignColumn("ShippingAddressId")
                .ToTable("Addresses").PrimaryColumn("Id");

            // ایجاد کلید خارجی برای ShoppingCartId
            Create.ForeignKey("FK_Orders_ShoppingCarts_ShoppingCartId")
                .FromTable("Orders").ForeignColumn("ShoppingCartId")
                .ToTable("ShoppingCarts").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Orders_AspNetUsers_UserId").OnTable("Orders");
            Delete.ForeignKey("FK_Orders_Addresses_ShippingAddressId").OnTable("Orders");
            Delete.ForeignKey("FK_Orders_ShoppingCarts_ShoppingCartId").OnTable("Orders");
            Delete.Table("Orders");
        }
    }
}
