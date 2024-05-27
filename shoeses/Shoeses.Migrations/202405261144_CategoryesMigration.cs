using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261144)]
    public class _202405261144_CategoryesMigration:Migration
    {
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();

            // ایجاد کلید خارجی برای محصولات
            //Create.ForeignKey("FK_Products_Categories_Id")
            //    .FromTable("Products").ForeignColumn("CategoryId")
            //    .ToTable("Categories").PrimaryColumn("Id")
            //    .OnDeleteOrUpdate(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Categories");
        }
    }
}
