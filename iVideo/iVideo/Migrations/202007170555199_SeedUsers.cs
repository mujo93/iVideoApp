namespace iVideo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'87d75239-c58a-4205-9df3-b28d8319a45e', N'mchdbyrk@gmail.com', 0, N'AEMEqVn8Ao3CVfBlxNFWTfrHR0weofHZC+xJNeZXKGpbuI4diL4n2Op3743QNuIhxQ==', N'e44d21fe-189e-466f-8967-c6bc987f7efe', NULL, 0, 0, NULL, 1, 0, N'mchdbyrk@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8f5d0fd2-2ea5-4a23-a96f-1b92f3a7e07f', N'guest@ivideoapp.com', 0, N'AHPShF3Mq/cPDXZYtZYeZQhBjtR0Uv69BYqYVmqK66o+P7Hb2s89+tA4ALO1QA8dCA==', N'51ff194b-580d-4894-b4b5-31ffbb424243', NULL, 0, 0, NULL, 1, 0, N'guest@ivideoapp.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'86a9eb36-6310-41cd-8e6a-f776f39f9a7d', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f5d0fd2-2ea5-4a23-a96f-1b92f3a7e07f', N'86a9eb36-6310-41cd-8e6a-f776f39f9a7d')
");
          
        }
        
        public override void Down()
        {
        }
    }
}
