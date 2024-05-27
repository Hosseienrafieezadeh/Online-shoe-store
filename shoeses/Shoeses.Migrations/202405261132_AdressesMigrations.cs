using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261132)]
    public class _202405261132_AdressesMigrations:Migration
    {
        public override void Up()
        {
            Create.Table("Addresses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Street").AsString(100).NotNullable()
                .WithColumn("City").AsString(50).NotNullable()
                .WithColumn("State").AsString(50).NotNullable()
                .WithColumn("PostalCode").AsString(20).NotNullable()
                .WithColumn("Country").AsString(20).NotNullable()
                .WithColumn("IsBillingAddress").AsBoolean().NotNullable()
                .WithColumn("IsShippingAddress").AsBoolean().NotNullable()
                .WithColumn("UserId").AsString().NotNullable()
                .ForeignKey("FK_Addresses_AspNetUsers_UserId", "AspNetUsers", "Id");


        }

        public override void Down()
        {
            Delete.Table("Addresses");
        }
    }
}
