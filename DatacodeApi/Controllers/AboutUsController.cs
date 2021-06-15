using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using static DatacodeApi.Extensions.IFormFileExtension;
using DatacodeApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace DatacodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {

        private readonly IAboutUsService _service;
        private readonly IWebHostEnvironment _env;

        public AboutUsController(IAboutUsService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AboutUs>> Get()
        {
            return _service.GetAllAboutUs().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AboutUs>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            AboutUs aboutUs = await _service.GetAboutUsByIdAsync(id);

            if (aboutUs == null)
                return NotFound();

            return aboutUs;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AboutModel aboutModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (aboutModel.Photo == null)
            {
                return BadRequest();
            }

            if (!aboutModel.Photo.IsImage())
            {
                return BadRequest();
            }

            if (!aboutModel.Photo.LessThan(5))
            {
                return BadRequest();
            }

            AboutUs aboutUs = new AboutUs
            {
                Title = aboutModel.Title,
                Description = aboutModel.Description
            };

            try
            {
                aboutUs.Image = await aboutModel.Photo.SaveAsync(_env.WebRootPath, "images", "about");
                await _service.CreateAboutAsync(aboutUs);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = aboutUs.ID }, aboutUs);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AboutModel aboutModel)
        {
            AboutUs aboutUsFromDb = await _service.GetAboutUsByIdAsync(id);

            if (aboutUsFromDb == null)
                return NotFound();

            if (id != aboutModel.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            aboutUsFromDb.Title = aboutModel.Title;
            aboutUsFromDb.Description = aboutModel.Description;

            try
            {
                if (aboutModel.Photo != null)
                {
                    if (!aboutModel.Photo.IsImage())
                    {
                        return BadRequest();
                    }

                    if (!aboutModel.Photo.LessThan(6))
                    {
                        return BadRequest();
                    }

                    RemoveFile(_env.WebRootPath, "images", "about", aboutUsFromDb.Image);

                    aboutUsFromDb.Image = await aboutModel.Photo.SaveAsync(_env.WebRootPath, "images", "about");
                }

                await _service.UpdateAboutUsAsync(id, aboutUsFromDb);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = aboutUsFromDb.ID }, aboutUsFromDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            AboutUs aboutUs = await _service.GetAboutUsByIdAsync(id);

            if (aboutUs == null)
                return BadRequest();

            try
            {
                RemoveFile(_env.WebRootPath, "images", "about", aboutUs.Image);
                await _service.DeleteAboutUsAsync(aboutUs);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
