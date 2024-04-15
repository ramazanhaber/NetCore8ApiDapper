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
            _connection = connections.DefaultConnection; // ilk veri tabanı1
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
        [Route("GetAllAsync2")]
        public async Task<IActionResult> GetAllAsync2()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync2();
            return Ok(notlarler);
        }

        [HttpPost]
        [Route("GetAllAsync3")]
        public async Task<IActionResult> GetAllAsync3()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync3();
            return Ok(notlarler);
        }


        [HttpPost]
        [Route("GetAllAsync4")]
        public async Task<IActionResult> GetAllAsync4()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync4();
            return Ok(notlarler);
        }

        [HttpPost]
        [Route("GetAllAsync5")]
        public async Task<IActionResult> GetAllAsync5()
        {
            var notlarler = await unitOfWork.Notlar.GetAllAsync5();
            return Ok(notlarler);
        }

    }
}
