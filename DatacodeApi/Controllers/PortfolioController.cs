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
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _service;
        private readonly IWebHostEnvironment _env;

        public PortfolioController(IPortfolioService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Portfolio>> Get()
        {
            return _service.GetAllPortfolios().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Portfolio>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            Portfolio portfolio = await _service.GetPortfolioByIdAsync(id);

            if (portfolio == null)
                return NotFound();

            return portfolio;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PortfolioModel portfolioModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (portfolioModel.Photo == null)
            {
                return BadRequest();
            }

            if (!portfolioModel.Photo.IsImage())
            {
                return BadRequest();
            }

            if (!portfolioModel.Photo.LessThan(5))
            {
                return BadRequest();
            }

            Portfolio portfolio = new Portfolio
            {
                PortfolioCategoryId = portfolioModel.CategoryId,
                Title = portfolioModel.Title,
                Description = portfolioModel.Description
            };


            try
            {
                portfolio.Image = await portfolioModel.Photo.SaveAsync(_env.WebRootPath, "images", "portfolio");
                await _service.CreatePortfolioAsync(portfolio);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = portfolio.ID }, portfolio);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PortfolioModel portfolioModel)
        {
            Portfolio portfolioFromDb = await _service.GetPortfolioByIdAsync(id);

            if (portfolioFromDb == null)
                return NotFound();

            if (id != portfolioModel.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            portfolioFromDb.Description = portfolioModel.Description;
            portfolioFromDb.Title = portfolioModel.Title;

            try
            {
                if (portfolioModel.Photo != null)
                {
                    if (!portfolioModel.Photo.IsImage())
                    {
                        return BadRequest();
                    }

                    if (!portfolioModel.Photo.LessThan(6))
                    {
                        return BadRequest();
                    }

                    RemoveFile(_env.WebRootPath, "images", "portfolio", portfolioModel.Image);
                    portfolioFromDb.Image = await portfolioModel.Photo.SaveAsync(_env.WebRootPath, "images", "portfolio");
                }

                await _service.UpdatePortfolioAsync(id, portfolioFromDb);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = portfolioFromDb.ID }, portfolioFromDb);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Portfolio portfolio = await _service.GetPortfolioByIdAsync(id);

            if (portfolio == null)
                return BadRequest();

            try
            {
                RemoveFile(_env.WebRootPath, "images", "portfolio", portfolio.Image);
                await _service.DeletePortfolioAsync(portfolio);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
