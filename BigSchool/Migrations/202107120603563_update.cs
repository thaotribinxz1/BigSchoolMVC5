namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "Followee_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_FollowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_Followee_Id", newName: "IX_FolloweeId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            DropColumn("dbo.Followings", "FollowedId");
            DropColumn("dbo.Followings", "foloweedId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "foloweedId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Followings", "FollowedId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowedId", "foloweedId" });
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_Followee_Id");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "Followee_Id");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "Follower_Id");
        }
    }
}
