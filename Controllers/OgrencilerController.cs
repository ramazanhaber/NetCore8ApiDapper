using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore8ApiDapper.Interfaces;
using NetCore8ApiDapper.Models;

namespace NetCore8ApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrencilerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OgrencilerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetOgrenciler")]
        public async Task<ActionResult<IEnumerable<Ogrenciler>>> GetOgrenciler()
        {
            var ogrenciler = await unitOfWork.Ogrenciler.GetAllAsync();
            return Ok(ogrenciler);
        }

        [HttpPost]
        [Route("AddOgrenci")]
        public async Task<IActionResult> AddOgrenci(Ogrenciler ogrenci)
        {
            await unitOfWork.Ogrenciler.AddAsync(ogrenci);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateOgrenci")]
        public async Task<IActionResult> UpdateOgrenci(Ogrenciler ogrenci)
        {
            await unitOfWork.Ogrenciler.UpdateAsync(ogrenci);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteOgrenci")]
        public async Task<IActionResult> DeleteOgrenci(int id)
        {
            var result = await unitOfWork.Ogrenciler.DeleteAsync(id);
            return result ? Ok() : NotFound();
        }

    }
}
