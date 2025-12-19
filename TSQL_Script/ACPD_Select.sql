USE [BackendExamHub]
GO

/****** Object:  StoredProcedure [dbo].[ACPD_Select]    Script Date: 2025/12/19 下午 05:42:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- 刪除舊的預存程式
if OBJECT_ID('dbo.ACPD_Select') IS NOT NULL
	DROP PROCEDURE [dbo].[ACPD_Select]
GO


-- 建立 以中文名稱查詢用戶資料 的預存程式
CREATE PROCEDURE [dbo].[ACPD_Select] 
	@name nvarchar(60)	-- 中文名稱
AS
BEGIN
	SELECT * from [MyOffice_ACPD] where [ACPD_Cname] like N'%'+@name+'%';
END
GO