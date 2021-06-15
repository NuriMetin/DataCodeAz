using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entites;
using DatacodeApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using static DatacodeApi.Extensions.IFormFileExtension;

namespace DatacodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _service;
        private readonly IWebHostEnvironment _env;

        public BannerController(IBannerService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Banner>> Get()
        {
            return _service.GetAllBanners().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            Banner banner = await _service.GetBannerByIdAsync(id);

            if (banner == null)
                return NotFound();

            return banner;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BannerModel bannerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (bannerModel.Photo == null)
            {
                return BadRequest();
            }

            if (!bannerModel.Photo.IsImage())
            {
                return BadRequest();
            }

            if (!bannerModel.Photo.LessThan(5))
            {
                return BadRequest();
            }

            Banner banner = new Banner
            {
                Title = bannerModel.Title,
                Description = bannerModel.Description
            };

            try
            {
                banner.Image = await bannerModel.Photo.SaveAsync(_env.WebRootPath, "images", "banner");
                await _service.CreateBannerAsync(banner);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = banner.ID }, banner);
        }

        // PUT api/<BannerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BannerModel bannerModel)
        {
            Banner bannerFromDb = await _service.GetBannerByIdAsync(id);

            if (bannerFromDb == null)
                return NotFound();

            if (id != bannerModel.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            bannerFromDb.Title = bannerModel.Title;
            bannerFromDb.Description = bannerModel.Description;

            try
            {
                if (bannerModel.Photo != null)
                {
                    if (!bannerModel.Photo.IsImage())
                    {
                        return BadRequest();
                    }

                    if (!bannerModel.Photo.LessThan(6))
                    {
                        return BadRequest();
                    }

                    RemoveFile(_env.WebRootPath, "images", "banner", bannerFromDb.Image);

                    bannerFromDb.Image = await bannerModel.Photo.SaveAsync(_env.WebRootPath, "images", "banner");
                }

                await _service.UpdateBannerAsync(id, bannerFromDb);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = bannerFromDb.ID }, bannerFromDb);
        }

        // DELETE api/<BannerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Banner banner = await _service.GetBannerByIdAsync(id);

            if (banner == null)
                return BadRequest();

            try
            {
                RemoveFile(_env.WebRootPath, "images", "banner", banner.Image);
                await _service.DeleteBannerAsync(banner);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
