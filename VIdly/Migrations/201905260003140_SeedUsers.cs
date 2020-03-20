namespace VIdly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68b6ec5d-869d-44e3-a0c7-5658ff522602', N'user@vidly.com', 0, N'AKZQoIqJQsnHrd5K/jzejeB2nOZqE3GEW7MqZQEBXB9NyhPrYUBGRst+w3kGipcxrQ==', N'433e11d0-dfce-4a94-8a59-395874a83205', NULL, 0, 0, NULL, 1, 0, N'user@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a9b7d467-2f7c-477c-bc21-e65ccba5d02a', N'admin@vidly.com', 0, N'AAEdugAMMJxTpmNX0ryRjpMCHKDDPVLG044JodOUCZeh+3XA+wLW/NM27MOoto8lVg==', N'c9878173-3176-4d1a-a065-1cc6546b6a0e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1cc35d1a-651f-444a-9374-d2ff3d7a17b5', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a9b7d467-2f7c-477c-bc21-e65ccba5d02a', N'1cc35d1a-651f-444a-9374-d2ff3d7a17b5')

");
        }
        
        public override void Down()
        {
        }
    }
}
