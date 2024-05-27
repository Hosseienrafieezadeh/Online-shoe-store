using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261204)]
    public class _202405261204_PaymentMigration:Migration
    {
        public override void Up()
        {
            Create.Table("Payments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("PaymentMethod").AsString().NotNullable()
                .WithColumn("Amount").AsDecimal().NotNullable()
                .WithColumn("PaymentDate").AsDateTime().NotNullable()
                .WithColumn("OrderId").AsInt32().NotNullable().ForeignKey("Orders", "Id");

            // اضافه کردن unique constraint برای شناسه سفارش
            Create.UniqueConstraint("UC_OrderId")
                .OnTable("Payments").Column("OrderId");
        }

        public override void Down()
        {
            Delete.UniqueConstraint("UC_OrderId").FromTable("Payments");
            Delete.Table("Payments");
        }
    }
}
