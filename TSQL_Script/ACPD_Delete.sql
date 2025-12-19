USE [BackendExamHub]
GO

/****** Object:  StoredProcedure [dbo].[ACPD_Delete]    Script Date: 2025/12/19 下午 05:44:45 ******/

/****** Object:  StoredProcedure [dbo].[ACPD_Delete]    Script Date: 2025/12/19 下午 05:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- 刪除舊的預存程式
if OBJECT_ID('dbo.ACPD_Delete') IS NOT NULL
	DROP PROCEDURE [dbo].[ACPD_Delete]
GO


-- 建立 刪除所屬中文名稱的用戶資料 的預存程式
CREATE PROCEDURE [dbo].[ACPD_Delete] 
	@name nvarchar(60)	-- 中文名稱
AS
BEGIN
	Delete from [MyOffice_ACPD]  where [ACPD_Cname] = @name;
END
GO


