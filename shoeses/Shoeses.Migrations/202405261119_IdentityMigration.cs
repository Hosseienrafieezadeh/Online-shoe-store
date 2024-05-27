using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;


namespace Shoeses.Migrations
{
    [Migration(202405261119)]
    public class _202405261119_IdentityMigration: Migration
    {
        public override void Up()
        {
            Create.Table("AspNetUsers")
                .WithColumn("Id").AsString().PrimaryKey()
                .WithColumn("UserName").AsString(256).NotNullable().Unique()
                .WithColumn("NormalizedUserName").AsString(256).NotNullable()
                .WithColumn("Email").AsString(256).NotNullable()
                .WithColumn("NormalizedEmail").AsString(256).NotNullable()
                .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                .WithColumn("PasswordHash").AsString().NotNullable()
                .WithColumn("SecurityStamp").AsString().Nullable()
                .WithColumn("ConcurrencyStamp").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
                .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                .WithColumn("LockoutEnd").AsDateTimeOffset().Nullable()
                .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("FirstName").AsString().Nullable()
                .WithColumn("LastName").AsString().Nullable();
            //Create.ForeignKey("FK_AspNetUsers_Addresses")
            //    .FromTable("Addresses").ForeignColumn("UserId")
            //    .ToTable("AspNetUsers").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(Rule.Cascade);

            //Create.ForeignKey("FK_AspNetUsers_Orders")
            //    .FromTable("Orders").ForeignColumn("UserId")
            //    .ToTable("AspNetUsers").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(Rule.Cascade);

            //Create.ForeignKey("FK_AspNetUsers_Reviews")
            //    .FromTable("Reviews").ForeignColumn("UserId")
            //    .ToTable("AspNetUsers").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(Rule.Cascade);

            //Create.ForeignKey("FK_AspNetUsers_ShoppingCarts")
            //    .FromTable("ShoppingCarts").ForeignColumn("UserId")
            //    .ToTable("AspNetUsers").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(Rule.Cascade);
            Create.Table("AspNetRoles")
                .WithColumn("Id").AsString().PrimaryKey()
                .WithColumn("Name").AsString(256).NotNullable().Unique()
                .WithColumn("NormalizedName").AsString(256).NotNullable();

            Create.Table("AspNetUserRoles")
                .WithColumn("UserId").AsString().NotNullable().ForeignKey("AspNetUsers", "Id")
                .WithColumn("RoleId").AsString().NotNullable().ForeignKey("AspNetRoles", "Id")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity();

            Create.Table("AspNetUserLogins")
                .WithColumn("LoginProvider").AsString().NotNullable()
                .WithColumn("ProviderKey").AsString().NotNullable()
                .WithColumn("ProviderDisplayName").AsString().Nullable()
                .WithColumn("UserId").AsString().NotNullable().ForeignKey("AspNetUsers", "Id");

            Create.Table("AspNetUserTokens")
                .WithColumn("UserId").AsString().NotNullable().ForeignKey("AspNetUsers", "Id")
                .WithColumn("LoginProvider").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Value").AsString().NotNullable();

            Create.Table("AspNetUserClaims")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsString().NotNullable().ForeignKey("AspNetUsers", "Id")
                .WithColumn("ClaimType").AsString().Nullable()
                .WithColumn("ClaimValue").AsString().Nullable();

      
        }

        public override void Down()
        {
            Delete.Table("AspNetUserTokens");
            Delete.Table("AspNetUserClaims");
            Delete.Table("AspNetUserLogins");
            Delete.Table("AspNetUserRoles");
            Delete.Table("AspNetRoles");
            Delete.Table("AspNetUsers");
            //Delete.ForeignKey("FK_AspNetUsers_Addresses");
            //Delete.ForeignKey("FK_AspNetUsers_Orders");
            //Delete.ForeignKey("FK_AspNetUsers_Reviews");
            //Delete.ForeignKey("FK_AspNetUsers_ShoppingCarts");
        }
    }
}
