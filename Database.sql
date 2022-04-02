create database IceCreamManage
go

use IceCreamManage
go

create table TableFood
(
	id int identity primary key,
	Name nvarchar (100) not null,
	Status nvarchar (100) not null default N'Empty'
)
go
create table Account
(
	UserName nvarchar(100) primary key,
	DisplayName nvarchar(100) not null,
	Password nvarchar(1000) not null default 0,
	Password2 nvarchar(1000) not null default 0,
	Type nvarchar(100) not null default N'Guest',
	Sex nvarchar(10) NULL,
	Age int not NULL,
	Number nvarchar(12) NULL,
	Email nvarchar(100) NULL,
	Addresss nvarchar(100) NULL
)
go

create table FoodCategory
(
	id int identity primary key,
	Name nvarchar(100) not null
)
go

create table Food
(
	id int identity primary key,
	Name nvarchar(100) not null,
	idCategory int not null,
	Price float not null,
	DescriptionFood nvarchar(1000) null,
	foreign key (idCategory) references dbo.FoodCategory(id)	
)
go

create table Bill
(
	id int identity primary key,
	DateCheckIn date not null default getdate(),
	DateCheckOut date,
	idTable int not null,
	Status int not null default 0,
	foreign key (idTable) references dbo.TableFood(id)
)
go

create table BillInfo
(
	 id int identity primary key,
	 idBill int not null,
	 idFood int not null,
	 count int not null default 0,
	 foreign key (idBill) references dbo.Bill(id),
	 foreign key (idFood) references dbo.Food(id)
)
go

/*select * from Bill
SELECT * from Account
select * from Food
select * from FoodCategory
select * from BillInfo
Select * from TableFood*/
insert into Account values 
	(N'Huong',N'Nguyễn Trần Hương',N'1',N'2',N'Admin',N'Male',19,'0562321402',N'huong123@gmail.com',N'Nhà Trắng, Hòa Kỳ, USA'),
	(N'Khang',N'Khang',N'1',N'2',N'Staff',N'Male',19,'0997755452',N'khang456@gmail.com',N'Tòa Chủ Tịch, Hà Nội, Việt Nam'),
	(N'Phong',N'Phong',N'1',N'2',N'Staff',N'Male',19,'09778822153',N'phong789@gmail.com',N'Tòa Thử Tướng, Hà Nội, Việt Nam'),
	(N'Phuc',N'Phan Huỳnh Phúc',N'1',N'2',N'Staff',N'Male',19,'0977840555',N'php.hcmue@outlook.com',N'Cầu Chữ Y, Quận 5, TP.CHM, Việt Nam')
go

insert into FoodCategory values
	(N'Kem Hàn Quốc'),
	(N'Kem MERINO'),
	(N'Kem GELATO'),
	(N'Nước uống')
go

insert into Food values
	(N'Kem bánh con cá vị socola',1,30000,N'Xuất sứ Hàn Quốc'),
	(N'Kem bánh con cá vị đậu đỏ',1,30000,N'Xuất sứ Hàn Quốc'),
	(N'Kem MELONA vị chuối',1,25000,N'Nguồn Nguyên Liệu thiên nhiên 100%'),
	(N'Kem MELONA vị dâu',1,25000,N'Những trái dâu thơm ngon được nhập khẩu trực tiếp từ Hàn Quốc'),
	(N'Kem MELONA vị xoài',1,25000,N'Nguyên liệu 100% từ thiên nhiên'),
	(N'Kem ốc quế vani socola',2,20000,N'Kem vị socola Italia'),
	(N'Kem ốc quế vani dâu',2,20000,N'Kem dâu nugồn gốc từ Đà Lạt'),
	(N'Kem que khoai môn',2,12000,N'Vị Khoai môn ngọt nhen'),
	(N'Kem đậu xanh',2,12000,N'Đầu xanh nhập từ nguồn nguyên liệu chuẩn VietGAP'),
	(N'Kem đậu đỏ',2,12000,N'Vị dâu thơm ngon'),
	(N'Kem GELATO mè đen',3,25000,N'Vị mè đen'),
	(N'Kem GELATO trà xanh',3,25000,N'Vị trà xanh'),
	(N'Kem GELATO socola',3,25000,N'Vị Socola'),
	(N'Kem GELATO vanilla',3,20000,N'Vị Vanilla'),
	(N'Trà sữa trà xanh',4,12000,N'Pha kiểu truyền thông'),
	(N'Trà sữa khoai môn',4,12000,N'Vị khoai môn'),
	(N'Trà sữa bạc hà',4,12000,N'Trà sửa kết hợp với lá bạc hà tươi mới'),
	(N'Trà sữa dâu',4,12000,N'Vị dâu Đà Lạt'),
	(N'Trà sữa việt quất',4,12000,N'Được kết hợp với những trái việt quất Nhật Bản'),
	(N'Nước ngọt',4,15000,N'Nước CocaCola')
go

create proc USP_Login
@username nvarchar(100) , @password nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @username AND Password = @password
END
GO

DECLARE @i INT = 1
WHILE @i <= 20
BEGIN
	insert into TableFood (name)values (N'Table ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
go


Create proc USP_GetTableList
AS
BEGIN
	SELECT * FROM TableFood
END
GO

create proc USP_GetUnCheckBillIDByTableID
@idTable int
AS
BEGIN
	SELECT * FROM Bill WHERE idTable = @idTable AND Status = 0
END
GO


create proc USP_GetListBillInfo
@idBill int
AS
BEGIN
	SELECT * FROM BillInfo WHERE idBill = @idBill
END
GO

create proc USP_GetListMenuByTable
@idTable int
AS
BEGIN
	SELECT Food.Name, BillInfo.count, Food.Price, Food.Price*BillInfo.count AS TotalPrice
	FROM Food, Bill, BillInfo
	WHERE BillInfo.idBill = Bill.id 
		AND BillInfo.idFood = Food.id
		AND Bill.Status = 0
		AND Bill.idTable = @idTable
END
GO
ALTER TABLE dbo.Bill
ADD discount INT
go
UPDATE dbo.Bill SET discount = 0
GO

create proc USP_InsertBill
@idTable int
AS
BEGIN
	insert into Bill (
				DateCheckIn,
				DateCheckOut,
				idTable,
				Status,
				discount
			)
			values
		(GETDATE(),NULL,@idTable,0,0)
END
GO

Create proc USP_InsertBillInfo
@idBill int, @idFood int, @count int
AS
BEGIN
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1

	SELECT @isExitsBillInfo = id, @foodCount = COUNT
	FROM BillInfo
	WHERE idBill = @idBill 
		AND idFood = @idFood 

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @count
		IF (@newCount > 0)
			UPDATE BillInfo SET count = @count WHERE idBill = @idBill AND idFood = @idFood
		ELSE
			DELETE BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		DECLARE @newCount1 INT = @count
		if(@newCount1 >0)
		INSERT INTO BillInfo VALUES
		(@idBill, @idFood, @count)
	END
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
ON BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted
	DECLARE @idTable INT
	DECLARE @count INT
	SELECT @count = count FROM inserted
	SELECT @idTable = idTable FROM Bill WHERE id = @idBill AND Status = 0 AND @count > 0
	UPDATE TableFood SET Status = N'Busy' WHERE id = @idTable
END
GO
CREATE TRIGGER UTG_UpdateBill
ON Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = id FROM inserted
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM Bill WHERE id = @idBill
	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM Bill WHERE idTable = @idTable AND Status = 0
	IF(@count = 0)
		UPDATE TableFood SET Status = N'Empty' WHERE id = @idTable
END
GO

CREATE PROC USP_ForgotPassWord 
@userName2 NVARCHAR(100), @newPassword2 NVARCHAR(100), @Password2 NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass1 INT = 0
	
	SELECT @isRightPass1 = COUNT(*) FROM dbo.Account WHERE USERName = @userName2 AND Password2 = @Password2
	
	IF (@isRightPass1 = 1)
	BEGIN
		UPDATE dbo.Account SET PassWord = @newPassword2 WHERE UserName = @userName2
	END
END
GO
CREATE PROC USP_ChangePassWord 
@userName1 NVARCHAR(100), @password1 NVARCHAR(100), @newPassword1 NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass1 INT = 0
	
	SELECT @isRightPass1 = COUNT(*) FROM dbo.Account WHERE USERName = @userName1 AND PassWord = @password1
	
	IF (@isRightPass1 = 1)
	BEGIN
		UPDATE dbo.Account SET PassWord = @newPassword1 WHERE UserName = @userName1
	END
END
GO
CREATE PROC USP_ChangePassWord2 
@userName2 NVARCHAR(100), @password2 NVARCHAR(100), @newPassword2 NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass1 INT = 0
	
	SELECT @isRightPass1 = COUNT(*) FROM dbo.Account WHERE USERName = @userName2 AND PassWord2 = @password2
	
	IF (@isRightPass1 = 1)
	BEGIN
		UPDATE dbo.Account SET PassWord2 = @newPassword2 WHERE UserName = @userName2
	END
END
GO
create PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100),@sex NVARCHAR(100),@age int,@number NVARCHAR(100),@email NVARCHAR(100),@address NVARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName, Sex = @sex, Age = @age, Number = @number, Email = @email , Addresss = @address WHERE UserName = @userName
		END		
END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable
END
GO

ALTER TABLE dbo.Bill ADD totalPrice FLOAT
GO

create PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT t.Name as [Table], b.totalPrice as [Total Price], DateCheckIn as [Date in], DateCheckOut as [Date out]
	FROM dbo.Bill as b ,dbo.TableFood as t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.Status = 1 AND t.id = b.idTable
	END
GO


CREATE PROC USP_SwitchTable
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable1
END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] 
( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000)
AS 
BEGIN 

IF @strInput IS NULL RETURN @strInput 
IF @strInput = '' RETURN @strInput 

DECLARE @RT NVARCHAR(4000) 
DECLARE @SIGN_CHARS NCHAR(136) 
DECLARE @UNSIGN_CHARS NCHAR (136) 

SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 

DECLARE @COUNTER int 
DECLARE @COUNTER1 int 

SET @COUNTER = 1 
WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN SET @COUNTER1 = 1 
WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
	BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
		BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
			ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK 
			END SET @COUNTER1 = @COUNTER1 +1 
		END SET @COUNTER = @COUNTER +1 
	END SET @strInput = replace(@strInput,' ','-') RETURN @strInput 
END
GO

