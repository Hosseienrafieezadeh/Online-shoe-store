using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shoeses.Migrations
{
    [Migration(202405261215)]
    public class _202405261215_ReviewsMigration :Migration
    {
        public override void Up()
        {
            Create.Table("Reviews")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsString().NotNullable().ForeignKey("AspNetUsers", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable().ForeignKey("Products", "Id")
                .WithColumn("Rating").AsInt32().NotNullable()
                .WithColumn("Comment").AsString().NotNullable()
                .WithColumn("ReviewDate").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Reviews");
        }
    }
}
