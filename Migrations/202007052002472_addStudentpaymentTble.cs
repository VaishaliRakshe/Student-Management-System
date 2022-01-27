namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentpaymentTble : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentPayments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idCard_No = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Father_Name = c.String(nullable: false),
                        Mother_Name = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Phone_No = c.String(nullable: false),
                        Semester = c.String(nullable: false),
                        Amount = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentPayments");
        }
    }
}
