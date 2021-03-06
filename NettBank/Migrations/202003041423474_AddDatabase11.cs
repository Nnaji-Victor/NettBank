namespace NettBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        ComparisonRate = c.Double(nullable: false),
                        RepaymentFrequency = c.String(nullable: false),
                        MaxDuration = c.Int(nullable: false),
                        MaxAmount = c.Long(nullable: false),
                        MinAmount = c.Long(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Catch = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanTypeLoanCompanies",
                c => new
                    {
                        LoanTypeId = c.Int(nullable: false),
                        LoanCompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanTypeId, t.LoanCompanyId })
                .ForeignKey("dbo.LoanCompanies", t => t.LoanCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .Index(t => t.LoanTypeId)
                .Index(t => t.LoanCompanyId);
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanTypeLoanCompany1",
                c => new
                    {
                        LoanType_Id = c.Int(nullable: false),
                        LoanCompany_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoanType_Id, t.LoanCompany_Id })
                .ForeignKey("dbo.LoanTypes", t => t.LoanType_Id, cascadeDelete: true)
                .ForeignKey("dbo.LoanCompanies", t => t.LoanCompany_Id, cascadeDelete: true)
                .Index(t => t.LoanType_Id)
                .Index(t => t.LoanCompany_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompany1", "LoanCompany_Id", "dbo.LoanCompanies");
            DropForeignKey("dbo.LoanTypeLoanCompany1", "LoanType_Id", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanTypeLoanCompanies", "LoanCompanyId", "dbo.LoanCompanies");
            DropIndex("dbo.LoanTypeLoanCompany1", new[] { "LoanCompany_Id" });
            DropIndex("dbo.LoanTypeLoanCompany1", new[] { "LoanType_Id" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanCompanyId" });
            DropIndex("dbo.LoanTypeLoanCompanies", new[] { "LoanTypeId" });
            DropTable("dbo.LoanTypeLoanCompany1");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanTypeLoanCompanies");
            DropTable("dbo.LoanCompanies");
        }
    }
}
