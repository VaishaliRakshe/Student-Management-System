namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chenge : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentRegistrations", "Stu_imagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentRegistrations", "Stu_imagePath", c => c.String(nullable: false));
        }
    }
}
