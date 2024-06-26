﻿using BudgetManagement.Application.DTOs.Outlay.Spent;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Infra.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.Outlay
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpentController(ISpentService spentService, IUserService userService) : ControllerBase
    {
        private readonly ISpentService _spentService = spentService;
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult> GetAll(int idUser)
        {
            var spentsDTO = await _spentService.GetAllAsync(idUser);

            return Ok(spentsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id, int idUser)
        {
            var spentDTO = await _spentService.GetAsync(id, idUser);

            if (spentDTO is null)
                return NotFound("Spent not found.");

            return Ok(spentDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(SpentPostDTO spentPostDTO)
        {
            var spent = await _spentService.Insert(spentPostDTO);

            if (spent is null)
                return BadRequest();

            return Ok("Spent Included!");
        }

        [HttpPut]
        public async Task<ActionResult> Update(SpentDTO spentDTO)
        {
            var spentDTOUpdated = await _spentService.Update(spentDTO);

            if (spentDTOUpdated is null)
                return BadRequest();

            return Ok("Spent Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var idUser = User.GetId();
            var user = await _userService.Get(idUser);

            if (!user.IsAdmin)
            {
                return Unauthorized("You don't have permission to exclude a Spent.");
            }

            var spent = await _spentService.GetAsync(id, idUser);

            if (spent is null)
                return NotFound("Spent not found.");

            await _spentService.Delete(id);

            return Ok(spent);
        }
    }
}
