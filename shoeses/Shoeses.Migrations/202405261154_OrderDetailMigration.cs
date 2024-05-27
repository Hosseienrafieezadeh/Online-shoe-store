using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261154)]
    public class _202405261154_OrderDetailMigration:Migration
    {
        public override void Up()
        {
            Create.Table("OrderDetails")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Quantity").AsInt32().NotNullable()
                .WithColumn("UnitPrice").AsDecimal().NotNullable()
                .WithColumn("OrderId").AsInt32().NotNullable()
                .ForeignKey("FK_OrderDetails_Orders_OrderId", "Orders", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_OrderDetails_Products_ProductId", "Products", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_OrderDetails_Orders_OrderId").OnTable("OrderDetails");
            Delete.ForeignKey("FK_OrderDetails_Products_ProductId").OnTable("OrderDetails");
            Delete.Table("OrderDetails");
        }
    }
}
