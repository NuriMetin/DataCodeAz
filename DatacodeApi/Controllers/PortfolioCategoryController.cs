using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace DatacodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PortfolioCategoryController : ControllerBase
    {
        private readonly IPortfolioCategoryService _service;
        public PortfolioCategoryController(IPortfolioCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PortfolioCategory>> Get()
        {
            return _service.GetAllPortfolios().ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioCategory>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            PortfolioCategory category = await _service.GetPortfolioByIdAsync(id);

            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PortfolioCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _service.CreatePortfolioAsync(category);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = category.ID }, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PortfolioCategory category)
        {
            PortfolioCategory categoryFromDb = await _service.GetPortfolioByIdAsync(id);

            if (categoryFromDb == null)
                return NotFound();

            if (id != category.ID)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _service.UpdatePortfolioAsync(id, category);
            }

            catch
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = category.ID }, category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            PortfolioCategory category = await _service.GetPortfolioByIdAsync(id);

            if (category == null)
                return BadRequest();

            try
            {
                await _service.DeletePortfolioAsync(category);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
