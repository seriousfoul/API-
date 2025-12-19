USE [BackendExamHub]
GO

/****** Object:  StoredProcedure [dbo].[ACPD_Update]    Script Date: 2025/12/19 下午 05:50:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- 刪除舊的預存程式
if OBJECT_ID('dbo.ACPD_Update') IS NOT NULL
	DROP PROCEDURE [dbo].[ACPD_Update]
GO

-- 建立 修改中文名稱查詢用戶資料 的預存程式
CREATE PROCEDURE [dbo].[ACPD_Update] 
	@oldName nvarchar(60),	-- 舊中文名稱
	@newName nvarchar(60)	-- 新中文名稱
AS
BEGIN
	Update [MyOffice_ACPD] set [ACPD_Cname] = @newName  where [ACPD_Cname] = @oldName;
END
GO