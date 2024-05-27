using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261209)]
   public class _202405261209_ProductsImageMigration:Migration
    {
        public override void Up()
        {
            Create.Table("ProductImages")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ImageUrl").AsString().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable().ForeignKey("Products", "Id");

            // اضافه کردن unique constraint برای شناسه محصول
            Create.UniqueConstraint("UC_ProductId")
                .OnTable("ProductImages").Column("ProductId");
        }

        public override void Down()
        {
            Delete.UniqueConstraint("UC_ProductId").FromTable("ProductImages");
            Delete.Table("ProductImages");
        }
    }
}
