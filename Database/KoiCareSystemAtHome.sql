CREATE DATABASE KoiCareSystemAtHome;
GO

USE KoiCareSystemAtHome;
GO

-- 1. Bảng Account (Lưu trữ thông tin đăng nhập)
CREATE TABLE [dbo].[Accounts] (
    [AccountID]    UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [Username]     NVARCHAR (100)   NOT NULL,
    [PasswordHash] NVARCHAR (255)   NOT NULL, -- Đổi tên và tăng độ dài cho hash
    [Email]        NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([AccountID] ASC),
    CONSTRAINT [UQ_Account_Username] UNIQUE ([Username]),
    CONSTRAINT [UQ_Account_Email] UNIQUE ([Email])
);

-- 2. Bảng UserProfile (Thông tin chi tiết người dùng - Đổi tên từ _User)
CREATE TABLE [dbo].[UserProfiles] (
    [UserID]    UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [AccountID] UNIQUEIDENTIFIER NOT NULL, -- Không nên để NULL
    [FullName]  NVARCHAR (100)   NOT NULL,
    [BirthDate] DATE             NULL,     -- Chuyển sang DATE nếu chỉ cần ngày sinh
    [Gender]    NVARCHAR (20)    NULL,
    [Role]      NVARCHAR (50)    DEFAULT ('User') NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_UserProfile_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([AccountID]) ON DELETE CASCADE,
    CONSTRAINT [UQ_UserProfile_AccountID] UNIQUE ([AccountID]) -- Ràng buộc 1-1
);

-- 3. Bảng Pond (Hồ cá)
CREATE TABLE [dbo].[Ponds] (
    [PondID]       UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [UserID]       UNIQUEIDENTIFIER NOT NULL,
    [PondName]     NVARCHAR (100)   NOT NULL,
    [ImageUrl]     NVARCHAR (MAX)   NULL,
    [Depth]        DECIMAL (18, 2)  DEFAULT (0) NOT NULL,
    [Volume]       DECIMAL (18, 2)  DEFAULT (0) NOT NULL,
    [DrainCount]   INT              DEFAULT (0) NOT NULL,
    [PumpCapacity] DECIMAL (18, 2)  DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_Ponds] PRIMARY KEY CLUSTERED ([PondID] ASC),
    CONSTRAINT [FK_Ponds_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserProfiles] ([UserID]) ON DELETE CASCADE
);

-- 4. Bảng KoiFish (Cá Koi)
CREATE TABLE [dbo].[KoiFishes] (
    [FishID]       UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [PondID]       UNIQUEIDENTIFIER NOT NULL,
    [FishName]     NVARCHAR (50)    NOT NULL,
    [ImageUrl]     NVARCHAR (MAX)   NULL,
    [BodyShape]    NVARCHAR (50)    NULL,
    [Age]          INT              NULL,
    [Size]         DECIMAL (18, 2)  NOT NULL, -- cm
    [Weight]       DECIMAL (18, 2)  NOT NULL, -- kg
    [Gender]       NVARCHAR (10)    NULL,
    [Breed]        NVARCHAR (50)    NULL,
    [Origin]       NVARCHAR (100)   NULL,
    [Price]        DECIMAL (18, 2)  NULL,
    [FishLocation] NVARCHAR (100)   NULL, -- Đổi từ INT sang NVARCHAR để mô tả vị trí
    CONSTRAINT [PK_KoiFishes] PRIMARY KEY CLUSTERED ([FishID] ASC),
    CONSTRAINT [FK_KoiFishes_Ponds] FOREIGN KEY ([PondID]) REFERENCES [dbo].[Ponds] ([PondID]) ON DELETE CASCADE
);

-- 5. Bảng WaterParameters (Thông số nước)
CREATE TABLE [dbo].[WaterParameters] (
    [ParameterID]     UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [PondID]          UNIQUEIDENTIFIER NOT NULL,
    [Temperature]     DECIMAL (5, 2)   NOT NULL,
    [SaltLevel]       DECIMAL (5, 2)   NOT NULL,
    [PH]              DECIMAL (4, 2)   NOT NULL,
    [Oxygen]          DECIMAL (5, 2)   NOT NULL,
    [Nitrite]         DECIMAL (5, 2)   NOT NULL, -- Sửa lỗi chính tả nitrie
    [Nitrate]         DECIMAL (5, 2)   NOT NULL,
    [Phosphate]       DECIMAL (5, 2)   NOT NULL, -- Sửa lỗi chính tả phospate
    [MeasurementTime] DATETIME         DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_WaterParameters] PRIMARY KEY CLUSTERED ([ParameterID] ASC),
    CONSTRAINT [FK_WaterParameters_Ponds] FOREIGN KEY ([PondID]) REFERENCES [dbo].[Ponds] ([PondID]) ON DELETE CASCADE
);

-- 6. Bảng FeedingSchedules (Lịch cho ăn)
CREATE TABLE [dbo].[FeedingSchedules] (
    [ScheduleID]         UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [FishID]             UNIQUEIDENTIFIER NOT NULL,
    [FeedingTime]        DATETIME         NOT NULL,
    [RequiredFoodAmount] DECIMAL (18, 2)  NOT NULL,
    [FoodType]           NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_FeedingSchedules] PRIMARY KEY CLUSTERED ([ScheduleID] ASC),
    CONSTRAINT [FK_FeedingSchedules_KoiFishes] FOREIGN KEY ([FishID]) REFERENCES [dbo].[KoiFishes] ([FishID]) ON DELETE CASCADE
);

-- 7. Bảng Products (Sản phẩm chăm sóc)
CREATE TABLE [dbo].[Products] (
    [ProductID]    UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [UserID]       UNIQUEIDENTIFIER NULL,
    [ProductName]  NVARCHAR (200)   NOT NULL,
    [ImageUrl]     NVARCHAR (MAX)   NULL,
    [Price]        DECIMAL (18, 2)  NOT NULL,
    [Description]  NVARCHAR (MAX)   NOT NULL, -- Đổi từ NTEXT sang NVARCHAR(MAX)
    [ProductType]  NVARCHAR (50)    NOT NULL,
    [CreatedDate]  DATETIME         DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Products_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserProfiles] ([UserID]) ON DELETE SET NULL
);

-- 8. Bảng News (Tin tức)
CREATE TABLE [dbo].[News] (
    [PostID]      UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [Author]      NVARCHAR (100)   NOT NULL,
    [Title]       NVARCHAR (255)   NOT NULL,
    [Content]     NVARCHAR (MAX)   NOT NULL,
    [PublishDate] DATETIME         DEFAULT (GETDATE()) NOT NULL,
    [ImageUrl]    NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED ([PostID] ASC)
);

-- 9. Bảng SaltCalculations (Tính toán muối)
CREATE TABLE [dbo].[SaltCalculations] (
    [CalculationID]      UNIQUEIDENTIFIER DEFAULT (NEWID()) NOT NULL,
    [PondID]             UNIQUEIDENTIFIER NOT NULL,
    [RequiredSaltAmount] DECIMAL (18, 2)  NULL,
    [CalculationTime]    DATETIME         DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_SaltCalculations] PRIMARY KEY CLUSTERED ([CalculationID] ASC),
    CONSTRAINT [FK_SaltCalculations_Ponds] FOREIGN KEY ([PondID]) REFERENCES [dbo].[Ponds] ([PondID]) ON DELETE CASCADE
);
GO

-- Tạo Index cho các khóa ngoại để tăng tốc độ truy vấn JOIN
CREATE INDEX IX_UserProfiles_AccountID ON UserProfiles(AccountID);
CREATE INDEX IX_Ponds_UserID ON Ponds(UserID);
CREATE INDEX IX_KoiFishes_PondID ON KoiFishes(PondID);
CREATE INDEX IX_WaterParameters_PondID ON WaterParameters(PondID);
GO