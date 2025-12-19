USE [BackendExamHub]
GO

/****** Object:  StoredProcedure [dbo].[ACPD_Insert]    Script Date: 2025/12/19 下午 05:40:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- 刪除舊的預存程式
if OBJECT_ID('dbo.ACPD_Insert') IS NOT NULL
	DROP PROCEDURE [dbo].[ACPD_Insert]
GO

-- 建立 新增用戶資料 的預存程式
CREATE Procedure [dbo].[ACPD_Insert](
	@Cname nvarchar(60),		-- 中文名稱
	@Ename nvarchar(40),		-- 英文名稱
	@Sname nvarchar(40),		-- 簡稱
	@Email nvarchar(60),		-- 信箱
	@LoginID nvarchar(30),		-- 登入帳號
	@LoginPWD nvarchar(60),		-- 登入密碼
	@CreaterName nvarchar(40)	-- 建立者的中文名稱
	)
as
begin
	Declare @SID nvarchar(20) -- 設定帳戶的SID

	-- 執行預存程式NEWSID
	begin
		Exec [dbo].[NEWSID] @TableName = 'MyOffice_ACPD',   @ReturnSID = @SID OUTPUT;	-- 新的SID 給 @SID
	end;	

	-- 搜尋建立者的SID
	Declare @CreaterID nvarchar(20);
	select @CreaterID = [ACPD_SID] from MyOffice_ACPD where ACPD_Cname = @CreaterName;  -- 使用建立者的中文名稱來搜尋他的SID

	-- 執行新增用戶資料
	insert into [MyOffice_ACPD] (
		ACPD_SID, ACPD_Cname, ACPD_Ename, ACPD_Sname, ACPD_Email, ACPD_LoginID, ACPD_LoginPWD, ACPD_NowID, ACPD_UPDID
		) 
	values (@SID, @Cname, @Ename, @Sname, @Email, @LoginID, @LoginPWD, @CreaterID, @CreaterID);
end;
GO


