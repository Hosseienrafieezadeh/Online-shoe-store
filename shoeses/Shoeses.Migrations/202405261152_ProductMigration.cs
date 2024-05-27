using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261152)]
    public class _202405261152_ProductMigration :Migration
    {
        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("CategoryId").AsInt32().NotNullable()
                .WithColumn("PromotionId").AsInt32().NotNullable();

            Create.ForeignKey("FK_Products_Categories_CategoryId")
                .FromTable("Products").ForeignColumn("CategoryId")
                .ToTable("Categories").PrimaryColumn("Id");

            Create.ForeignKey("FK_Products_Promotions_PromotionId")
                .FromTable("Products").ForeignColumn("PromotionId")
                .ToTable("Promotions").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Products_Categories_CategoryId").OnTable("Products");
            Delete.ForeignKey("FK_Products_Promotions_PromotionId").OnTable("Products");
            Delete.Table("Products");
        }
    }
}
