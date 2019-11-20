namespace WebAppMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bb9d633d-04b0-476e-9057-fe99558472c3', N'guest@webappmovie.com', 0, N'AIgy79hxxoTtm56kZiJKN3pcokDw/nakW5we8WFTPx5CDKTc5bSf56Ej+Arjbx1oXw==', N'b262981e-68f9-495f-8e1a-48edf0afb6e3', NULL, 0, 0, NULL, 1, 0, N'guest@webappmovie.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cdfeb6e1-2432-4bfb-8d69-d97f3910c131', N'admin@webappmovie.com', 0, N'AOcSW6j8qqPML0qqrfdeTHwCjbzsyG3jOyHk8kr2DmGIGESEzP1uc+uA+WzOboi3DA==', N'44f9b7e5-d976-4063-8687-2780978a1f6c', NULL, 0, 0, NULL, 1, 0, N'admin@webappmovie.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7add59e3-4c34-4c58-b637-7386589cb5d1', N'CanManageCustomers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb9d633d-04b0-476e-9057-fe99558472c3', N'7add59e3-4c34-4c58-b637-7386589cb5d1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cdfeb6e1-2432-4bfb-8d69-d97f3910c131', N'7add59e3-4c34-4c58-b637-7386589cb5d1')

");
        } 
        
        public override void Down()
        {
        }
    }
}
