using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261150)]
   public class _202405261150_PromotionMigration:Migration
    {
        public override void Up()
        {
            Create.Table("Promotions")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("DiscountPercentage").AsDecimal().NotNullable()
                .WithColumn("StartDate").AsDateTime().NotNullable()
                .WithColumn("EndDate").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Promotions");
        }
    }
}
