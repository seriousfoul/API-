using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Views.API
{

    [ApiController]
    [Route("API")]
    [Produces("application/json")]
    public class APIController : ControllerBase
    {
        /// <summary> SQL的查詢功能  </summary>
        /// <param data="DBNameInClass">
        ///     @name varchar(60)	-- 中文名稱
        /// </param>
        /// <returns> 查詢資料庫用戶的名稱 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiSelect{
        ///     "name": "約翰"
        /// }
        /// </remarks>
        /// <response code="200">查詢成功</response>
        /// <response code="400">資料庫沒有資料</response>
        [HttpPost("ApiSelect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiSelect([FromBody] DBNameInClass data)
        {
            bool success = false;
            List<DBSelectOutClass> selectData = new DBManager().UserSelect(data);

            if (selectData != null)
                success = true;

            var result = new
            {
                status = "success",
                Order = selectData
            };
            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.Default
            });

            if (success)
                return Content(json, "application/json", Encoding.UTF8);
            else
                return BadRequest(new { status = "failure", message = "資料取得失敗" });
        }


        /// <summary> SQL的新增功能  </summary>
        /// <param data="DBInsertInClass">
        ///     @Cname nvarchar(60),		-- 中文名稱
        ///     @Ename nvarchar(40),		-- 英文名稱
        ///     @Sname nvarchar(40),		-- 簡稱
        ///     @Email nvarchar(60),		-- 信箱
        ///     @LoginID nvarchar(30),		-- 登入帳號
        ///     @LoginPWD nvarchar(60),		-- 登入密碼
        ///     @CreaterName nvarchar(40)   -- 建立者的中文名稱
        /// </param>
        /// <returns> 新增資料庫用戶 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiInsert{
        ///     "cName" : "瑪莉",
        ///     "eName": "Mary",
        ///     "sName": "Mary",
        ///     "eMail": "Mary@Mary.com",
        ///     "loginID": "Mary",
        ///     "loginPWD": "Mary",
        ///     "createrName": "簡文翊"
        /// }
        /// </remarks>
        /// <response code="201">新增成功</response>
        /// <response code="400">資料庫無法新增</response>
        [HttpPost("ApiInsert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiInsert([FromBody] DBInsertInClass data)
        {
            bool success = false;
            success = new DBManager().UserInsert(data);

            if (success)
                return Ok(new { status = "success", message = "資料已新增" });
            else
                return BadRequest(new { status = "failure", message = "資料新增失敗" });
        }

        /// <summary> SQL的修改功能  </summary>
        /// <param data="DBUpdateInClass">
        ///     @OldName nvarchar(60),
        ///     @NewName nvarchar(60)
        /// </param>
        /// <returns> 修改資料庫用戶的名稱 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiUpdate{
        ///     "oldName": "約翰",
        ///     "newName": "約翰尼"
        /// }
        /// </remarks>
        /// <response code="200">修改成功</response>
        /// <response code="400">用戶名稱修改失敗</response>
        [HttpPut("ApiUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiUpdate([FromBody] DBUpdateInClass data)
        {
            bool success = false;
            success = new DBManager().UserUpdate(data);

            if (success)
                return Ok(new { status = "success", message = "資料已更新" });
            else
                return BadRequest(new { status = "failure", message = "資料更新失敗" });
        }

        /// <summary> SQL的刪除功能  </summary>
        /// <param data="DBNameInClass">
        ///     "name" nvarchar(40)
        /// </param>
        /// <returns> 刪除資料庫用戶 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiDelete{
        ///     "name": "約翰"
        /// }
        /// </remarks>
        /// <response code="200">刪除成功</response>
        /// <response code="400">用戶名稱修改失敗</response>
        [HttpDelete("ApiDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiDelete([FromBody] DBNameInClass data)
        {
            bool success = false;
            success = new DBManager().UserDelete(data);

            if (success)
                return Ok(new { status = "success", message = "資料已刪除" });
            else
                return BadRequest(new { status = "failure", message = "資料刪除失敗" });
        }
    }   
}
