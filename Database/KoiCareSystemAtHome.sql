Create database KoiCareSystemAtHome
go

use KoiCareSystemAtHome
go

-- Tạo bảng Account
CREATE TABLE [dbo].[Account] (
    [AccountID]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Username]     NVARCHAR (100)   NOT NULL,
    [passWorkHash] NVARCHAR (100)   NOT NULL,
    [email]        NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK__Account__349DA586BD287530] PRIMARY KEY CLUSTERED ([AccountID] ASC)
);

-- Tạo bảng _User
CREATE TABLE [dbo].[_User] (
    [UserId]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [AccountId] UNIQUEIDENTIFIER NULL,
    [fullName]  NVARCHAR (50)    NOT NULL,
    [birthDate] DATETIME         NOT NULL,
    [gender]    NVARCHAR (10)    NOT NULL,
    [_Role]     NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK___User__1788CC4C0FA9730F] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK___User__AccountId__29572725] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountID])
);

-- Tạo bảng Pond
CREATE TABLE [dbo].[Pond] (
    [PondID]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NULL,
    [NamePond]     NVARCHAR (50)    NOT NULL,
    [imagePond]    NVARCHAR (MAX)   DEFAULT (N'') NOT NULL,
    [depth]        FLOAT (53)       DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [volume]       FLOAT (53)       DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [drainCount]   INT              DEFAULT ((0)) NOT NULL,
    [pumpCapacity] FLOAT (53)       DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    CONSTRAINT [PK__Pond__D18BF854BF5D6EE2] PRIMARY KEY CLUSTERED ([PondID] ASC),
    CONSTRAINT [FK_Pond_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[_User] ([UserId]) ON DELETE CASCADE
);

-- Tạo bảng _Product
CREATE TABLE [dbo].[_Product] (
    [productID]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NULL,
    [productName]  NVARCHAR (100)   NOT NULL,
    [imageProduct] NVARCHAR (MAX)   NOT NULL,
    [price]        FLOAT (53)       NOT NULL,
    [desciption]   NTEXT            NOT NULL,
    [productType]  NVARCHAR (50)    NOT NULL,
    [datePlace]    DATETIME         NOT NULL,
    CONSTRAINT [PK___Product__2D10D14A9E48844F] PRIMARY KEY CLUSTERED ([productID] ASC),
    CONSTRAINT [FK_Product_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[_User] ([UserId]) ON DELETE CASCADE
);


-- Tạo bảng KoiFish
CREATE TABLE [dbo].[KoiFish] (
    [fishID]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PondID]       UNIQUEIDENTIFIER NULL,
    [nameFish]     NVARCHAR (20)    NOT NULL,
    [imageFish]    NVARCHAR (MAX)   NOT NULL,
    [bodyShape]    NVARCHAR (30)    NOT NULL,
    [ageFish]      INT              NOT NULL,
    [size]         FLOAT (53)       NOT NULL,
    [weightFish]   FLOAT (53)       NOT NULL,
    [gender]       NVARCHAR (10)    NOT NULL,
    [breed]        NVARCHAR (50)    NOT NULL,
    [origin]       NVARCHAR (100)   NOT NULL,
    [price]        FLOAT (53)       NOT NULL,
    [fishLocation] INT              NOT NULL,
    CONSTRAINT [PK__KoiFish__5222DA39EDB1C1CB] PRIMARY KEY CLUSTERED ([fishID] ASC),
    CONSTRAINT [FK_KoiFish_PondID] FOREIGN KEY ([PondID]) REFERENCES [dbo].[Pond] ([PondID]) ON DELETE CASCADE
);

-- Tạo bảng FeedingSchedule
CREATE TABLE [dbo].[FeedingSchedule] (
    [feeding_ScheduleID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [fishID]             UNIQUEIDENTIFIER NULL,
    [feedingTime]        DATETIME         NOT NULL,
    [requiredFoodAmount] FLOAT (53)       NOT NULL,
    [foodType]           NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK__FeedingS__1B08C845646F4CF3] PRIMARY KEY CLUSTERED ([feeding_ScheduleID] ASC),
    CONSTRAINT [FK_FeedingSchedule_KoiFish_FishId] FOREIGN KEY ([fishID]) REFERENCES [dbo].[KoiFish] ([fishID]) ON DELETE CASCADE
);

-- Tạo bảng News
CREATE TABLE [dbo].[News] (
    [postID]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [author]      NVARCHAR (50)    NOT NULL,
    [title]       NVARCHAR (MAX)   NULL,
    [content]     NTEXT            NOT NULL,
    [publishDate] DATETIME         NOT NULL,
    [ImageUrl]    NVARCHAR (255)   NULL,
    CONSTRAINT [PK__News__DD0C73BA141E91D1] PRIMARY KEY CLUSTERED ([postID] ASC)
);



-- Tạo bảng SaltCalculation
CREATE TABLE [dbo].[SaltCalculation] (
    [salt_CalculationID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PondID]             UNIQUEIDENTIFIER NULL,
    [requiredSaltAmount] FLOAT (53)       NULL,
    [calculationTime]    DATETIME         NOT NULL,
    CONSTRAINT [PK__SaltCalc__69E08378212B7F83] PRIMARY KEY CLUSTERED ([salt_CalculationID] ASC),
    CONSTRAINT [FK_SaltCalculation_Pond_PondId] FOREIGN KEY ([PondID]) REFERENCES [dbo].[Pond] ([PondID]) ON DELETE CASCADE
);

-- Tạo bảng WaterParameter
CREATE TABLE [dbo].[WaterParameter] (
    [WaterParameterID] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [PondID]           UNIQUEIDENTIFIER NULL,
    [temperature]      FLOAT (53)       NOT NULL,
    [saltLevel]        FLOAT (53)       NOT NULL,
    [pH]               FLOAT (53)       NOT NULL,
    [oxygen]           FLOAT (53)       NOT NULL,
    [nitrie]           FLOAT (53)       NOT NULL,
    [nitrate]          FLOAT (53)       NOT NULL,
    [phospate]         FLOAT (53)       NOT NULL,
    [measurementTime]  DATETIME         NOT NULL,
    CONSTRAINT [PK__WaterPar__5D1C0C72B31FBE7E] PRIMARY KEY CLUSTERED ([WaterParameterID] ASC),
    CONSTRAINT [FK_WaterParameter_Pond_PondId] FOREIGN KEY ([PondID]) REFERENCES [dbo].[Pond] ([PondID]) ON DELETE CASCADE
);
