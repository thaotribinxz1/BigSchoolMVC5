namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sualai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "LectureId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LectureId");
            AddForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "Lecture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Lecture", c => c.String(nullable: false));
            DropForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LectureId" });
            DropColumn("dbo.Courses", "LectureId");
        }
    }
}
