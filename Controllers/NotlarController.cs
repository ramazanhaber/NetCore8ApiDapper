using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore8ApiDapper.Helper;
using NetCore8ApiDapper.Interfaces;
using NetCore8ApiDapper.Models;
using System.Data;

namespace NetCore8ApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotlarController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDbConnection _connection;


        public NotlarController(DatabaseConnections connections, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _connection = connections.DefaultConnection; // ilk veri tabanı

        }

        [HttpGet]
        [Route("GetNotlar")]
        public async Task<ActionResult<IEnumerable<Notlar>>> GetNotlar()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync();
            return Ok(notlarler);
        }

        [HttpPost]
        [Route("AddNotlar")]
        public async Task<IActionResult> AddNotlar(Notlar notlar)
        {
            await unitOfWork.Notlar.AddAsync(notlar);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateNotlar")]
        public async Task<IActionResult> UpdateNotlar(Notlar notlar)
        {
            await unitOfWork.Notlar.UpdateAsync(notlar);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteNotlar")]
        public async Task<IActionResult> DeleteNotlar(int id)
        {
            var result = await unitOfWork.Notlar.DeleteAsync(id);
            return result ? Ok() : NotFound();
        }


        [HttpPost]
        [Route("notlarilistele")]
        public async Task<IActionResult> notlarilistele()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync2();
            return Ok(notlarler);
        }

        [HttpPost]
        [Route("notlarilistele2")]
        public async Task<IActionResult> notlarilistele2()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync3();
            return Ok(notlarler);
        }

    }
}
