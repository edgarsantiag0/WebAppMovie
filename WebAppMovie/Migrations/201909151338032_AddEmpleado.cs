namespace WebAppMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpleado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(),
                        FechaIngreso = c.DateTime(nullable: false),
                        Cargo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleados");
        }
    }
}
