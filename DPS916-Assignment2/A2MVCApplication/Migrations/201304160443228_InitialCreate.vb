Imports System
Imports System.Data.Entity.Migrations

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AddressBooks",
                Function(c) New With
                    {
                        .AddressBookId = c.Int(nullable := False, identity := True),
                        .AddressBookName = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.AddressBookId)
            
            CreateTable(
                "dbo.Records",
                Function(c) New With
                    {
                        .RecordId = c.Int(nullable := False, identity := True),
                        .AddressBookId = c.Int(nullable := False),
                        .UserName = c.String(nullable := False),
                        .Notes = c.String()
                    }) _
                .PrimaryKey(Function(t) t.RecordId) _
                .ForeignKey("dbo.AddressBooks", Function(t) t.AddressBookId, cascadeDelete := True) _
                .Index(Function(t) t.AddressBookId)
            
            CreateTable(
                "dbo.CellPhoneNumbers",
                Function(c) New With
                    {
                        .CellPhoneId = c.Int(nullable := False, identity := True),
                        .RecordId = c.Int(nullable := False),
                        .Text = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.CellPhoneId) _
                .ForeignKey("dbo.Records", Function(t) t.RecordId, cascadeDelete := True) _
                .Index(Function(t) t.RecordId)
            
            CreateTable(
                "dbo.PhoneNumbers",
                Function(c) New With
                    {
                        .PhoneNumberId = c.Int(nullable := False, identity := True),
                        .RecordId = c.Int(nullable := False),
                        .Text = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.PhoneNumberId) _
                .ForeignKey("dbo.Records", Function(t) t.RecordId, cascadeDelete := True) _
                .Index(Function(t) t.RecordId)
            
            CreateTable(
                "dbo.Emails",
                Function(c) New With
                    {
                        .EmailId = c.Int(nullable := False, identity := True),
                        .RecordId = c.Int(nullable := False),
                        .Text = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.EmailId) _
                .ForeignKey("dbo.Records", Function(t) t.RecordId, cascadeDelete := True) _
                .Index(Function(t) t.RecordId)
            
            CreateTable(
                "dbo.Addresses",
                Function(c) New With
                    {
                        .AddressId = c.Int(nullable := False, identity := True),
                        .RecordId = c.Int(nullable := False),
                        .Text = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.AddressId) _
                .ForeignKey("dbo.Records", Function(t) t.RecordId, cascadeDelete := True) _
                .Index(Function(t) t.RecordId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropIndex("dbo.Addresses", New String() { "RecordId" })
            DropIndex("dbo.Emails", New String() { "RecordId" })
            DropIndex("dbo.PhoneNumbers", New String() { "RecordId" })
            DropIndex("dbo.CellPhoneNumbers", New String() { "RecordId" })
            DropIndex("dbo.Records", New String() { "AddressBookId" })
            DropForeignKey("dbo.Addresses", "RecordId", "dbo.Records")
            DropForeignKey("dbo.Emails", "RecordId", "dbo.Records")
            DropForeignKey("dbo.PhoneNumbers", "RecordId", "dbo.Records")
            DropForeignKey("dbo.CellPhoneNumbers", "RecordId", "dbo.Records")
            DropForeignKey("dbo.Records", "AddressBookId", "dbo.AddressBooks")
            DropTable("dbo.Addresses")
            DropTable("dbo.Emails")
            DropTable("dbo.PhoneNumbers")
            DropTable("dbo.CellPhoneNumbers")
            DropTable("dbo.Records")
            DropTable("dbo.AddressBooks")
        End Sub
    End Class
End Namespace
