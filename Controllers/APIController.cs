using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Views.API
{
    [ApiController]
    [Route("API")]
    public class APIController : ControllerBase
    {
        [HttpPost("ApiSelect")]
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

        [HttpPost("ApiInsert")]
        public IActionResult ApiInsert([FromBody] DBClass data)
        {
            bool success = false;
            success = new DBManager().UserInsert(data.name, data.phone, data.address, data.sex);

            if (success)
                return Ok(new { status = "success", message = "資料已新增" });
            else
                return BadRequest(new { status = "failure", message = "資料新增失敗" });
        }

        [HttpPut("ApiUpdate")]
        public IActionResult ApiUpdate([FromBody] DBClass data)
        {
            bool success = false;
            success = new DBManager().UserUpdate(data.oldName, data.newName);

            if (success)
                return Ok(new { status = "success", message = "資料已更新" });
            else
                return BadRequest(new { status = "failure", message = "資料更新失敗" });
        }

        [HttpDelete("ApiDelete")]
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
