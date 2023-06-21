﻿--TẠO DB
GO
CREATE DATABASE QUANLYSTCOOPFOOD
SET DATEFORMAT DMY;
--DROP DATABASE QUANLYSTCOOPFOOD
GO
USE QUANLYSTCOOPFOOD
-------------------------------------------------TẠO BẢNG
GO
--Tạo bảng accout
create table [ACCOUNT] (USERNAME VARCHAR(50) PRIMARY KEY, PASSWORD VARCHAR(50), PERMISSION varchar(20))
go
--1. TẠO BẢNG KHACHHANG
CREATE TABLE [KHACHHANG] (MAKH NVARCHAR(10) NOT NULL, HOKH NVARCHAR(30) NOT NULL, TENKH NVARCHAR(10) NOT NULL, SDT NVARCHAR(15) NOT NULL,
						  DCHI NVARCHAR(200) NOT NULL, DIEM INT NOT NULL, LOAIKH NVARCHAR(10) NULL)

GO
--2. TẠO BẢNG NHANVIEN
CREATE TABLE [NHANVIEN] (MANV NVARCHAR(10) NOT NULL, HONV NVARCHAR(30) NOT NULL, TENNV NVARCHAR(10) NOT NULL, NGSINH DATE NOT NULL, 
						 PHAI NVARCHAR(10) NOT NULL, DCHI NVARCHAR(200) NOT NULL, SDT NVARCHAR(15) NOT NULL, CMND NVARCHAR(9) NOT NULL)

GO
--3. TẠO BẢNG NHACUNGCAP
CREATE TABLE [NHACUNGCAP] (MANCC NVARCHAR(10) NOT NULL, TENNCC NVARCHAR(200) NOT NULL, 
						   DCHI NVARCHAR(200) NOT NULL, SDT NVARCHAR(15) NOT NULL, EMAIL NVARCHAR(50) NULL)
GO
--4. TẠO BẢNG HANGHOA
CREATE TABLE [HANGHOA] (MAHH NVARCHAR(10) NOT NULL, MANCC NVARCHAR(10) NOT NULL,TENHH NVARCHAR(100) NOT NULL, LOAIHH NVARCHAR(40) NOT NULL, 
						SOLUONG INT NOT NULL, DONGIA INT NOT NULL, NGAYSX DATE NOT NULL, HANSD DATE NOT NULL)

GO
--5. TẠO BẢNG HDCHITIET
CREATE TABLE [HDCHITIET] (MAHD NVARCHAR(10) NOT NULL, MAHH NVARCHAR(10) NOT NULL, 
					   SOLUONG INT NOT NULL, TONGTIENHH INT NOT NULL)

GO
--6. TẠO BẢNG HOADON
CREATE TABLE [HOADON] (MAHD NVARCHAR(10) NOT NULL, NGAYLAP DATE NOT NULL, PTTHANHTOAN NVARCHAR(15) NOT NULL, 
					   MANV NVARCHAR(10) NOT NULL, MAKH NVARCHAR(10) NOT NULL, TIENKHACHTRA INT NULL,
					   TONGTIEN INT NULL, TIENTHUA INT NULL)

-------------------------------------------------TẠO CHỨC NĂNG CHO CỘT TỰ ĐỘNG TÍNH TOÁN

-- KHACHHANG
GO
CREATE FUNCTION [dbo].FUNC_KHACHHANG_COMPUTED_LOAIKH(@DIEM INT)
RETURNS NVARCHAR(10)
WITH SCHEMABINDING AS
BEGIN
	DECLARE @LOAIKH NVARCHAR(10);
    IF @DIEM < 500
	BEGIN
		SET @LOAIKH = N'THƯỜNG'
	END
	ELSE IF @DIEM < 1000
	BEGIN
		SET @LOAIKH = N'VIP1'
	END
	ELSE IF @DIEM < 5000
	BEGIN
		SET @LOAIKH = N'VIP2'
	END
	ELSE IF @DIEM < 15000
	BEGIN
		SET @LOAIKH = N'VIP3'
	END
	ELSE IF @DIEM < 30000
	BEGIN
		SET @LOAIKH = N'VIP4'
	END
	ELSE
	BEGIN
		SET @LOAIKH = N'VIP5'
	END
	RETURN @LOAIKH;
END


GO
ALTER TABLE [KHACHHANG] DROP COLUMN LOAIKH
ALTER TABLE [KHACHHANG] ADD LOAIKH AS [dbo].FUNC_KHACHHANG_COMPUTED_LOAIKH(DIEM) PERSISTED

-- HDCHITIET
GO
CREATE FUNCTION [dbo].FUNC_HDCHITIET_COMPUTED_TONGTIENHH(@MAHH NVARCHAR(10), @SOLUONG INT)
RETURNS INT
BEGIN
    RETURN (SELECT TOP 1 DONGIA FROM [dbo].[HANGHOA] WHERE MAHH = @MAHH) * @SOLUONG;
END

GO
ALTER TABLE [HDCHITIET] DROP COLUMN TONGTIENHH
ALTER TABLE [HDCHITIET] ADD TONGTIENHH AS [dbo].FUNC_HDCHITIET_COMPUTED_TONGTIENHH(MAHH, SOLUONG)

-- HOADON
GO
CREATE FUNCTION [dbo].FUNC_HOADON_COMPUTED_TONGTIEN(@MAHD NVARCHAR(10))
RETURNS INT
WITH SCHEMABINDING AS
BEGIN
    RETURN (SELECT SUM(TONGTIENHH) FROM [dbo].[HDCHITIET] WHERE MAHD = @MAHD);
END

GO
ALTER TABLE [HOADON] DROP COLUMN TONGTIEN
ALTER TABLE [HOADON] ADD TONGTIEN AS [dbo].FUNC_HOADON_COMPUTED_TONGTIEN(MAHD) --PERSISTED

-- HOADON TIENTHUA
GO
CREATE FUNCTION [dbo].FUNC_HOADON_COMPUTED_TIENTHUA(@MAHD NVARCHAR(10), @TIENKHACHTRA INT)
RETURNS INT
WITH SCHEMABINDING AS -- WITH SCHEMABINDING , RETURNS NULL ON NULL input AS
BEGIN
	DECLARE @TONGTIEN INT;
	DECLARE @TIENTHUA INT;
	SET @TONGTIEN = (SELECT SUM(TONGTIENHH) FROM [dbo].[HDCHITIET] WHERE MAHD = @MAHD)

    IF @TIENKHACHTRA > @TONGTIEN
	BEGIN
		SET @TIENTHUA = @TIENKHACHTRA - @TONGTIEN
	END
	ELSE
	BEGIN
		SET @TIENTHUA = 0
	END
    RETURN @TIENTHUA;
END

GO
ALTER TABLE [HOADON] DROP COLUMN TIENTHUA
ALTER TABLE [HOADON] ADD TIENTHUA AS [dbo].FUNC_HOADON_COMPUTED_TIENTHUA(MAHD, TIENKHACHTRA) --PERSISTED
-------------------------------------------------RÀNG BUỘC TOÀN VẸN
-------------------------------------------------KHÓA CHÍNH
--1. BẢNG KHACHHANG
GO
ALTER TABLE [KHACHHANG] ADD CONSTRAINT PK_KHACHHANG PRIMARY KEY (MAKH)
--2. BẢNG NHANVIEN
GO
ALTER TABLE [NHANVIEN] ADD CONSTRAINT PK_NHANVIEN PRIMARY KEY (MANV)
--3. BẢNG HOADON
GO
ALTER TABLE [HOADON] ADD CONSTRAINT PK_HOADON PRIMARY KEY (MAHD)

--4. BẢNG HANGHOA
GO
ALTER TABLE [HANGHOA] ADD CONSTRAINT PK_HANGHOA PRIMARY KEY (MAHH)
--5. BẢNG NHACUNGCAP
GO
ALTER TABLE [NHACUNGCAP] ADD CONSTRAINT PK_NHACUNGCAP PRIMARY KEY (MANCC)

-------------------------------------------------KHÓA NGOẠI
--1.BẢNG HOADON
GO
ALTER TABLE [HOADON] ADD CONSTRAINT FK_HD_KH FOREIGN KEY (MAKH) REFERENCES [KHACHHANG](MAKH)

GO
ALTER TABLE [HOADON] ADD CONSTRAINT FK_HD_NV FOREIGN KEY (MANV) REFERENCES [NHANVIEN](MANV)
--2. BẢNG CHITIETHOADON
GO
ALTER TABLE [HDCHITIET] ADD CONSTRAINT FK_CTHD_HD FOREIGN KEY (MAHD) REFERENCES [HOADON](MAHD)
GO
ALTER TABLE [HDCHITIET] ADD CONSTRAINT FK_CTHP_HH FOREIGN KEY (MAHH) REFERENCES [HANGHOA](MAHH)
--2. BẢNG NHACUNGCAP
GO
ALTER TABLE [HANGHOA] ADD CONSTRAINT FK_HH_NCC FOREIGN KEY (MANCC) REFERENCES [NHACUNGCAP](MANCC)

-------------------------------------------------MIỀN GIÁ TRỊ
GO
ALTER TABLE [NHANVIEN] ADD CHECK (PHAI = N'NAM' OR PHAI = N'NỮ')
GO
ALTER TABLE [NHANVIEN] ADD CHECK (2022-YEAR(NGSINH) >= 18)
GO
ALTER TABLE [HANGHOA] ADD CHECK (NGAYSX < HANSD)
--GO

---------------------------------INSERT DATA-------------------------------------------------------------------
-------------------------------------------------KHACHHANG
GO
INSERT INTO [KHACHHANG] VALUES(N'KH00',N'NGUYỄN VĂN', N'GIÁP',N'0864611705',N'486, Đ.Phan Bội Châu, P.Phú Cường, TP.Thủ Dầu Một, Tỉnh Bình Dương',875)
GO
INSERT INTO [KHACHHANG] VALUES(N'KH01',N'TRƯƠNG HOÀNG', N'DƯƠNG',N'0365435355',N'208, Đ.Dương Đình Nghệ, P.Phú Thọ, TP.Thủ Dầu Một, Tỉnh Bình Dương',6742)
GO
INSERT INTO [KHACHHANG] VALUES(N'KH02',N'LÊ TRUNG', N'DUY',N'0366514728',N'313, Đ.Võ Nguyên Giáp, P.Hiệp An, TP.Thủ Dầu Một, Tỉnh Bình Dương',27781)
GO
INSERT INTO [KHACHHANG] VALUES(N'KH03',N'TRỊNH MINH', N'PHÚC',N'0365951012',N'45, Đ.Duy Tân, P.Tương Bình Hiệp, TP.Thủ Dầu Một, Tỉnh Bình Dương',25753)
GO
INSERT INTO [KHACHHANG] VALUES(N'KH04',N'TRẦN HOÀNG', N'ĐẠO',N'0324252846',N'231, Đ.Nguyễn Trung Trực, P.Tân An, TP.Thủ Dầu Một, Tỉnh Bình Dương',35836)

-------------------------------------------------NHANVIEN

GO
INSERT INTO [NHANVIEN] VALUES(N'NV00',N'NGUYỄN THỊ NHƯ',N'QUỲNH',N'22/08/1998',N'NỮ',N'332, Đ.Nguyễn Du, P.Phú Hòa, TP.Thủ Dầu Một, Tỉnh Bình Dương',N'0921378908',N'384738685')
GO
INSERT INTO [NHANVIEN] VALUES(N'NV01',N'LÊ HOÀNG',N'QUÂN',N'28/11/2000',N'NAM',N'14, Đ.Trần Nguyên Hãn, P.Tân An, TP.Thủ Dầu Một, Tỉnh Bình Dương',N'0362645574',N'030920015')
GO
INSERT INTO [NHANVIEN] VALUES(N'NV02',N'ĐINH VĂN',N'PHƯỢNG',N'22/05/1996',N'NAM',N'392, Đ.Xóm Vôi, P.12, Q.5, TP.Hồ Chí Minh',N'0924802218',N'310219006')
GO
INSERT INTO [NHANVIEN] VALUES(N'NV03',N'NGUYỄN VĂN',N'THANH',N'19/06/1992',N'NAM',N'72, Đ.Tô Hiệu, P.Tân An, TP.Thủ Dầu Một, Tỉnh Bình Dương',N'0363775677',N'176840781')
GO
INSERT INTO [NHANVIEN] VALUES(N'NV04',N'NGUYỄN XUÂN',N'SANG',N'26/09/1991',N'NAM',N'403, Đ.Tân Phước, P.Phú Cường, TP.Thủ Dầu Một, Tỉnh Bình Dương',N'0363977273',N'368493179')

-------------------------------------------------NHACUNGCAP
GO
INSERT INTO [NHACUNGCAP] VALUES(N'NCC00',N'Bích Chi Food - Công Ty Cổ Phần Thực Phẩm Bích Chi',N'45X1, Đường Nguyễn Sinh Sắc, Phường 2, Sa Đéc, Đồng Tháp',N'02773861910',N'thaipham@bichchi.com.vn')
GO
INSERT INTO [NHACUNGCAP] VALUES(N'NCC01',N'Thiên Hương Food - Công Ty Cổ Phần Thực Phẩm Thiên Hương',N'1 Lê Đức Thọ, Tân Thới Hiệp, Quận 12, Thành phố Hồ Chí Minh',N'02837171425',N'contact@thienhuongfood.com.vn')
GO
INSERT INTO [NHACUNGCAP] VALUES(N'NCC02',N'Công Ty TNHH Thực Phẩm Dân Ôn',N'2JJH+PQ6, Đường Lê Chí Dân, Xã Tân Hiệp, Phường Phú Tân, Thị Xã Thủ Dầu Một, Hiệp Thành, Thủ Dầu Một, Bình Dương',N'02743830388',N'info@danonfoods.com')
GO
INSERT INTO [NHACUNGCAP] VALUES(N'NCC03',N'Công Ty TNHH Sản Xuất - Thương Mại - Xuất Nhập Khẩu Ngọc Liên',N'2/245 Dương Công Khi, ấp Tân Lập, Hóc Môn, Thành phố Hồ Chí Minh',N'02838124934',N'ngoclien@ngoclienfood.com')
GO
INSERT INTO [NHACUNGCAP] VALUES(N'NCC04',N'Tổng Công Ty Rau Quả, Nông Sản - Công Ty Cổ Phần',N'Tầng 12 - Tòa nhà VINAFOR - 127 Lò Đúc - P. Đống Mác - Q. Hai Bà Trưng - Hà Nội',N'2438523063',N'vegetexcovn@vegetexcovn.com.vn')

-------------------------------------------------SANPHAM
GO
INSERT INTO [HANGHOA] VALUES(N'HH00',N'NCC00',N'Bít tết đùi bò Úc mát Pacow vỉ 250g',N'THITCACLOAI',231,118000,'27/06/2022','13/08/2022')
GO
INSERT INTO [HANGHOA] VALUES(N'HH01',N'NCC01',N'Cánh gà nhập khẩu đông lạnh khay 500g',N'THITCACLOAI',99,40500,'20/06/2022','07/08/2022')
GO
INSERT INTO [HANGHOA] VALUES(N'HH02',N'NCC02',N'Hộp 10 trứng gà tươi 4KFarm',N'TRUNG',282,33000,'14/02/2022','25/02/2022')
GO
INSERT INTO [HANGHOA] VALUES(N'HH03',N'NCC03',N'Hành tím túi 300g',N'RAUSACH',184,18000,'18/02/2022','24/02/2022')
GO
INSERT INTO [HANGHOA] VALUES(N'HH04',N'NCC04',N'Dưa leo baby 500g (8-10 trái)',N'CU',181,18000,'20/03/2022','27/03/2022')


-------------------------------------------------HOADON VÀ HDCHITIET
GO
INSERT INTO [HOADON] VALUES(N'HD00','22/07/2022', N'TIỀN MẶT', N'NV00', N'KH00', 250000)
GO
INSERT INTO [HDCHITIET] VALUES(N'HD00',N'HH00', 2)

select*
from nhanvien
INSERT INTO [ACCOUNT] VALUES ('admin', 'admin', '0')
go
INSERT INTO [ACCOUNT] VALUES ('nhanvien', 'nhanvien', '1')
go
INSERT INTO [ACCOUNT] VALUES ('ad', 'ad', '0')


------------------------------------------------------PROCEDURE--------------------------------------------------
---------------------------------------------------PROCEDURE BANG KHACHHANG
--THÊM KHÁCH HÀNG
GO
CREATE PROC sp_ThemKH(@MAKH NVARCHAR(10), @HOKH NVARCHAR(30), @TENKH NVARCHAR(10), @SDT NVARCHAR(15),
						  @DCHI NVARCHAR(200), @DIEM INT)
AS
INSERT INTO [KHACHHANG](MAKH,HOKH,TENKH,SDT,DCHI,DIEM) VALUES (@MAKH,@HOKH,@TENKH,@SDT,@DCHI,@DIEM)
--XÓA KHÁCH HÀNG
GO
CREATE PROC sp_XoaKH(@MAKH NVARCHAR(10))
AS
	DELETE [KHACHHANG]
	WHERE MAKH=@MAKH
--SỬA KHÁCH HÀNG
GO
CREATE PROC sp_SuaKH(@MAKH NVARCHAR(10), @HOKH NVARCHAR(30), @TENKH NVARCHAR(10), @SDT NVARCHAR(15),
						  @DCHI NVARCHAR(200), @DIEM INT)
AS
	UPDATE [KHACHHANG]
	SET HOKH=@HOKH,TENKH=@TENKH,SDT=@SDT,DCHI=@DCHI,DIEM=@DIEM
	WHERE MAKH=@MAKH
--LẤY DANH SÁCH KHÁCH HÀNG
GO
CREATE PROC sp_LayDSKH
AS 
	SELECT * FROM [KHACHHANG]

---------------------------------------------------PROCEDURE BẢNG NHANVIEN
--THÊM NHANVIEN
GO
CREATE PROC sp_THEMNV(@MANV NVARCHAR(10), @HONV NVARCHAR(30), @TENNV NVARCHAR(10), @NGSINH DATE, 
						 @PHAI NVARCHAR(10), @DCHI NVARCHAR(200), @SDT NVARCHAR(15), @CMND NVARCHAR(9))
AS
INSERT INTO [NHANVIEN](MANV,HONV,TENNV,NGSINH,PHAI,DCHI,SDT,CMND) VALUES (@MANV,@HONV,@TENNV,@NGSINH,@PHAI,@DCHI,@SDT,@CMND)
--XÓA NHÂN VIÊN
GO
CREATE PROC sp_XOANV(@MANV NVARCHAR(10))
AS
	DELETE
	FROM [NHANVIEN]
	WHERE MANV=@MANV
--SỬA NHANVIEN
GO
CREATE PROC sp_SUANV(@MANV NVARCHAR(10), @HONV NVARCHAR(30), @TENNV NVARCHAR(10), @NGSINH DATE, 
						 @PHAI NVARCHAR(10), @DCHI NVARCHAR(200), @SDT NVARCHAR(15), @CMND NVARCHAR(9))
AS
	UPDATE [NHANVIEN]
	SET HONV=@HONV,TENNV=@TENNV, NGSINH=@NGSINH,PHAI=@PHAI,DCHI=@DCHI,SDT=@SDT,CMND=@CMND
	WHERE MANV=@MANV
--LẤY DANH SÁCH NHANVIEN
GO
CREATE PROC sp_LAYDSNV
AS
	SELECT * FROM [NHANVIEN]

---------------------------------------------------PROCEDURE BẢNG NHACUNGCAP
--THÊM NHÀ CUNG CẤP
GO
CREATE PROC sp_ThemNCC(@MANCC NVARCHAR(10), @TENNCC NVARCHAR(200), @DCHI NVARCHAR(200), @SDT NVARCHAR(15), @EMAIL NVARCHAR(50))
AS
	INSERT INTO [NHACUNGCAP] (MANCC,TENNCC,DCHI,SDT,EMAIL) VALUES (@MANCC,@TENNCC,@DCHI,@SDT,@EMAIL)
--XÓA NHÀ CUNG CẤP
GO
CREATE PROC sp_XOANCC(@MANCC NVARCHAR(10))
AS
	DELETE [NHACUNGCAP]
	WHERE MANCC=@MANCC

--SỬA NHÀ CUNG CẤP
GO
CREATE PROC sp_SuaNCC(@MANCC NVARCHAR(10), @TENNCC NVARCHAR(200), @DCHI NVARCHAR(200), @SDT NVARCHAR(15), @EMAIL NVARCHAR(50))
AS
	UPDATE [NHACUNGCAP]
	SET TENNCC=@TENNCC,DCHI=@DCHI,SDT=@SDT,EMAIL=@EMAIL
	WHERE MANCC=@MANCC

--LẤY NHÀ CUNG CẤP
GO
CREATE PROC sp_LayNCC
AS 
	SELECT * FROM [NHACUNGCAP]
---------------------------------------------------PROCEDURE BẢNG HÀNG HÓA
--THÊM HANGHOA
GO
CREATE PROC sp_THEMHH(@MAHH NVARCHAR(10), @MANCC NVARCHAR(10),@TENHH NVARCHAR(100), @LOAIHH NVARCHAR(40), 
						@SOLUONG INT, @DONGIA INT, @NGAYSX DATE, @HANSD DATE)
AS
	INSERT INTO [HANGHOA](MAHH,MANCC,TENHH,LOAIHH,SOLUONG,DONGIA,NGAYSX,HANSD)
		VALUES (@MAHH,@MANCC,@TENHH,@LOAIHH,@SOLUONG,@DONGIA,@NGAYSX,@HANSD)

--XÓA HANGHOA
GO
CREATE PROC sp_XOAHH(@MAHH NVARCHAR(10))
AS
	DELETE [HANGHOA]
	WHERE MAHH=@MAHH
--SỬA HANGHOA
GO
CREATE PROC sp_SUAHH(@MAHH NVARCHAR(10), @MANCC NVARCHAR(10),@TENHH NVARCHAR(100), @LOAIHH NVARCHAR(40), 
						@SOLUONG INT, @DONGIA INT, @NGAYSX DATE, @HANSD DATE)
AS
	UPDATE [HANGHOA]
	SET MANCC=@MANCC, TENHH=@TENHH,LOAIHH=@LOAIHH, SOLUONG=@SOLUONG,DONGIA=@DONGIA,NGAYSX=@NGAYSX,HANSD=@HANSD
	WHERE MAHH=@MAHH
--LẤY DANH SÁCH HANGHOA
GO
CREATE PROC sp_LAYDSHH
AS SELECT * FROM [HANGHOA]
---------------------------------------------------PROCEDURE BẢNG HÓA ĐƠN
--THÊM HÓA ĐƠN
GO
CREATE PROC sp_THEMHD(@MAHD NVARCHAR(10), @NGAYLAP DATE, @PTTHANHTOAN NVARCHAR(15), 
					   @MANV NVARCHAR(10), @MAKH NVARCHAR(10), @TIENKHACHTRA INT)
AS
	INSERT INTO [HOADON](MAHD,NGAYLAP,PTTHANHTOAN,MANV,MAKH,TIENKHACHTRA) VALUES (@MAHD,@NGAYLAP,@PTTHANHTOAN,@MANV,@MAKH,@TIENKHACHTRA)
--XÓA HÓA ĐƠN
-- DROP PROC sp_XOAHD
GO
CREATE PROC sp_XOAHD(@MAHD NVARCHAR(10))
AS
	DELETE [HDCHITIET] WHERE MAHD=@MAHD
	DELETE [HOADON] WHERE MAHD=@MAHD
--SỬA HÓA ĐƠN
GO
CREATE PROC sp_SUAHD(@MAHD NVARCHAR(10), @NGAYLAP DATE, @PTTHANHTOAN NVARCHAR(15), 
					   @MANV NVARCHAR(10), @MAKH NVARCHAR(10), @TIENKHACHTRA INT)
AS
	UPDATE [HOADON]
	SET NGAYLAP=@NGAYLAP, PTTHANHTOAN=@PTTHANHTOAN, MANV=@MANV,MAKH=@MAKH, TIENKHACHTRA=@TIENKHACHTRA
	WHERE MAHD=@MAHD
--LẤY DANH SÁCH HÓA ĐƠN
GO
CREATE PROC sp_LAYDSHD
AS
	SELECT * FROM [HOADON]

---------------------------------------------------PROCEDURE BẢNG HÓA ĐƠN CHI TIẾT
--THÊM HÓA ĐƠN CHI TIẾT
--DROP PROC sp_THEMHDCT	
GO
CREATE PROC sp_THEMHDCT(@MAHD NVARCHAR(10), @MAHH NVARCHAR(10), @SOLUONG INT)
AS
	IF EXISTS (SELECT 1 FROM [HDCHITIET] WHERE MAHD = @MAHD AND MAHH = @MAHH)
		BEGIN
			UPDATE [HDCHITIET] SET SOLUONG = SOLUONG + @SOLUONG WHERE MAHD = @MAHD AND MAHH = @MAHH
		END
	ELSE
	BEGIN
		INSERT INTO [HDCHITIET](MAHD,MAHH,SOLUONG) VALUES (@MAHD,@MAHH,@SOLUONG)
	END

	DROP PROC sp_THEMHDCT

--XÓA HÓA ĐƠN CHI TIẾT
--drop proc sp_XOAHDCT
GO
CREATE PROC sp_XOAHDCT(@MAHD NVARCHAR(10), @MAHH NVARCHAR(10))
AS
	DELETE [HDCHITIET]
	WHERE MAHD=@MAHD AND MAHH = @MAHH
--SỬA HDCHITIET
--drop proc sp_SUAHDCT
GO
CREATE PROC sp_SUAHDCT(@MAHD NVARCHAR(10), @MAHH NVARCHAR(10), @SOLUONG INT)
AS
	UPDATE [HDCHITIET]
	SET MAHH=@MAHH, SOLUONG=@SOLUONG
	WHERE MAHD=@MAHD AND MAHH = @MAHH

--LẤY DANH SÁCH HÓA ĐƠN CHI TIẾT
GO
CREATE PROC sp_LAYDSHDCT
AS
	SELECT hdct.MAHD, MAHH, SOLUONG, TONGTIENHH FROM [HDCHITIET] hdct, [HOADON] hd where hdct.MAHD = hd.MAHD

GO
CREATE PROC sp_LAYHDCT(@MAHD NVARCHAR(10))
AS
	SELECT  MAHD, MAHH, SOLUONG, TONGTIENHH FROM [HDCHITIET] WHERE @MAHD=MAHD

--GO
--CREATE PROC sp_LAYHDCT2(@MAHD NVARCHAR(10), @MAHH NVARCHAR(10))
--AS
--	SELECT  MAHD, hdct.MAHH, hh.TENHH, hh.DONGIA,hdct.SOLUONG, TONGTIENHH FROM [HDCHITIET] hdct, [HANGHOA] hh 
--	WHERE @MAHD=MAHD AND @MAHH= hh.MAHH
GO
CREATE PROC sp_LAYTHONGTINHH(@MAHH NVARCHAR(10))
AS
	SELECT TENHH, DONGIA FROM [HANGHOA] WHERE @MAHH=MAHH

--DROP PROC sp_LAYHDCT
--GO
--exec sp_ThemKH N'KH001',N'TRƯƠNG HOÀNG MINH', N'DƯƠNG',N'0365435355',N'208, Đ.Dương Đình Nghệ, P.Phú Thọ, TP.Thủ Dầu Một, Tỉnh Bình Dương',6742
GO
exec sp_LAYDSHD
--exec sp_LAYDSHDCT
exec sp_LAYDSHH
exec sp_LayDSKH
exec sp_LAYDSNV
exec sp_LayNCC
GO
exec sp_LAYHDCT @MAHD = N'HD00';

exec sp_LAYTHONGTINHH @MAHH=N'HH00';
GO
CREATE PROC sp_LOGIN(@USERNAME VARCHAR(50), @PASSWORD VARCHAR(50))
AS
SELECT*
FROM [ACCOUNT]
WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD
GO


select* from HOADON
select* from HDCHITIET

GO
CREATE PROC sp_LAYDSHDCT_TRONG_HOADON(@MAHD NVARCHAR(10))
AS
	SELECT HDCT.MAHD, HDCT.MAHH, TENHH, HDCT.SOLUONG, DONGIA, TONGTIENHH
	FROM HDCHITIET HDCT, HOADON, HANGHOA
	WHERE @MAHD=HDCT.MAHD

--drop proc sp_LAYDSHDCT_TRONG_HOADON
exec sp_LAYDSHDCT_TRONG_HOADON 'HD00'
exec sp_THEMHDCT N'HD00',N'HH00',2
exec sp_THEMHDCT N'HD01',N'HH00',10
EXEC sp_XOAHDCT N'HD00'


----CRYSTAL REPORT----
----RP HOA DON
----Lay danh sach HOA DON
GO
CREATE PROC sp_LayDSHoaDon(@MAHD NVARCHAR(10))
AS
SELECT * 
FROM HOADON
WHERE MAHD=@MAHD


GO
CREATE PROC sp_HoaDon(@MAHD NVARCHAR(10))
AS
SELECT * 
FROM HOADON hd, KHACHHANG kh, NHANVIEN nv, HANGHOA hh, NHACUNGCAP ncc, HDCHITIET hdct
WHERE hd.MAHD=@MAHD and hd.MAHD = hdct.MAHD and nv.MANV = hd.MANV and kh.MAKH = hd.MAKH and hh.MAHH = hdct.MAHH and ncc.MANCC = hh.MANCC


----RP HANG HOA
----Lay danh sach hang hoa
GO
CREATE PROC sp_LayDSHangHoa
as
SELECT *
FROM HANGHOA

----Lay danh sach hang hoa bang ma
GO
CREATE PROC sp_LayHangHoaBangMa(@MAHH NVARCHAR(10))
as
SELECT *
FROM HANGHOA
WHERE MAHH=@MAHH


----Lay hang hoa voi nha ncc
GO
CREATE PROC sp_HangHoaRP (@MAHH NVARCHAR(10))
as
SELECT *
FROM HANGHOA hh, NHACUNGCAP ncc
WHERE MAHH=@MAHH and ncc.MANCC = hh.MANCC


----RP NHA CUNG CAP
----Lay danh sach nha cung cap
GO
CREATE PROC sp_LayDSNCC
AS
SELECT *
FROM NHACUNGCAP

----Lay nha cung cap bang ma
GO
CREATE PROC sp_LayNCCBangMa(@MANCC NVARCHAR(10))
AS
SELECT *
FROM NHACUNGCAP
WHERE MANCC=@MANCC


----RP NHAN VIEN
----Lay danh sach nhan vien
GO
CREATE PROC sp_LayDSNhanVien
AS
SELECT *
FROM NHANVIEN

----Lay nhan vien bang ma
GO
CREATE PROC sp_LayNhanVienBangMa(@MANV NVARCHAR(10))
AS
SELECT *
FROM NHANVIEN
WHERE MANV=@MANV


----RP KHACH HANG
----Lay danh sach Khach hang
GO
CREATE PROC sp_LayDSKhachHang
AS
SELECT *
FROM KHACHHANG

----Lay khach hang bang ma
GO
CREATE PROC sp_LayKhachHangBangMa(@MAKH NVARCHAR(10))
AS
SELECT *
FROM KHACHHANG
WHERE MAKH=@MAKH

go
EXEC sp_LayKhachHangBangMa 'KH00'
exec sp_LayDSKhachHang
EXEC sp_LayNhanVienBangMa 'NV00'
EXEC sp_LayDSNhanVien
EXEC sp_LayNCCBangMa 'NCC00'
EXEC sp_LayDSNCC
exec sp_HangHoaRP 'HH00'
exec sp_LayHangHoaBangMa 'HH00'
EXEC sp_LayDSHoaDon 'HD00'
EXEC sp_HoaDon 'HD00'
exec sp_LayDSHangHoa