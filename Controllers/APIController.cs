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
        /// <param name="select"></param>
        /// <returns> 查詢資料庫用戶的名稱 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiSelect{
        /// "userId": 0,
        /// "name": "john",
        /// "oldName": "",
        /// "newName": "",
        /// "phone": "",
        /// "address": "",
        /// "sex": 0
        /// }
        /// </remarks>
        /// <response code="200">查詢成功</response>
        /// <response code="400">資料庫沒有資料</response>
        [HttpPost("ApiSelect")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiSelect([FromBody] DBClass data)
        {
            bool success = false;
            List<DBClass> selectData = new DBManager().UserSelect(data.name);

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
        /// <param name="insert"></param>
        /// <returns> 新增資料庫用戶 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiInsert{
        /// "userId": 0,
        /// "name": "john",
        /// "oldName": "",
        /// "newName": "",
        /// "phone": "0987654321",
        /// "address": "aaaaaaaaaaaaaaa",
        /// "sex": 0
        /// }
        /// </remarks>
        /// <response code="201">新增成功</response>
        /// <response code="400">資料庫無法新增</response>
        [HttpPost("ApiInsert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiInsert([FromBody] DBClass data)
        {
            bool success = false;
            success = new DBManager().UserInsert(data.name, data.phone, data.address, data.sex);

            if (success)
                return Ok(new { status = "success", message = "資料已新增" });
            else
                return BadRequest(new { status = "failure", message = "資料新增失敗" });
        }

        /// <summary> SQL的修改功能  </summary>
        /// <param name="update"></param>
        /// <returns> 修改資料庫用戶的名稱 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiUpdate{
        /// "userId": 0,
        /// "name": "",
        /// "oldName": "john",
        /// "newName": "mary",
        /// "phone": "",
        /// "address": "",
        /// "sex": 0
        /// }
        /// </remarks>
        /// <response code="200">修改成功</response>
        /// <response code="400">用戶名稱修改失敗</response>
        [HttpPut("ApiUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiUpdate([FromBody] DBClass data)
        {
            bool success = false;
            success = new DBManager().UserUpdate(data.oldName, data.newName);

            if (success)
                return Ok(new { status = "success", message = "資料已更新" });
            else
                return BadRequest(new { status = "failure", message = "資料更新失敗" });
        }

        /// <summary> SQL的刪除功能  </summary>
        /// <param name="delete"></param>
        /// <returns> 刪除資料庫用戶 </returns>
        /// <remarks>
        /// 範例為：
        /// POST /API/ApiDelete{
        /// "userId": 0,
        /// "name": "john",
        /// "oldName": "",
        /// "newName": "",
        /// "phone": "",
        /// "address": "",
        /// "sex": 0
        /// }
        /// </remarks>
        /// <response code="200">刪除成功</response>
        /// <response code="400">用戶名稱修改失敗</response>
        [HttpDelete("ApiDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ApiDelete([FromBody] DBClass data)
        {
            bool success = false;
            success = new DBManager().UserDelete(data.name);

            if (success)
                return Ok(new { status = "success", message = "資料已刪除" });
            else
                return BadRequest(new { status = "failure", message = "資料刪除失敗" });
        }
    }   
}
