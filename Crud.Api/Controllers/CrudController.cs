using AutoMapper;
using Crud.Api.Model.Dto;
using Crud.Api.Validators;
using Crud.Core;
using Crud.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly IPluginService _pluginService;
        private readonly IMapper _mapper;
        public CrudController(IPluginService pluginService, IMapper mapper)
        {
            _pluginService = pluginService;
            _mapper = mapper;

        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PluginDto>>> GetAllPlugins()
        {
            var plugins = await _pluginService.GetAllWithProject();
            var mappedPlugins = _mapper.Map<IEnumerable<PluginDao>, IEnumerable<PluginDto>>(plugins);

            return Ok(mappedPlugins);
        }
        [HttpGet("id")]
        public async Task<ActionResult<PluginDto>> GetPluginById(int id)
        {
            var plugin = await _pluginService.GetPluginById(id);
            var mappedPlugin = _mapper.Map<PluginDao, PluginDto>(plugin);
            return Ok(mappedPlugin);
        }
        [HttpPost("")]
        public async Task<ActionResult<PluginDto>> CreatePlugin([FromBody] SavePluginDto savePluginResource)
        {
            var validator = new SavePluginResourceValidator();
            var validationResult = await validator.ValidateAsync(savePluginResource);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var pluginToCreate = _mapper.Map<SavePluginDto, PluginDao>(savePluginResource);
            var createdPlugin = await _pluginService.CreatePlugin(pluginToCreate);
            var plugin = await _pluginService.GetPluginById(createdPlugin.Id);
            var pluginResource = _mapper.Map<PluginDao, PluginDto>(plugin);

            return Ok(pluginResource);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PluginDto>> UpdatePlugin(int id, [FromBody] SavePluginDto savePluginDto)
        {
            var validator = new SavePluginResourceValidator();
            var validationResult = await validator.ValidateAsync(savePluginDto);

            bool requestIsInvalid = id == 0 || !validationResult.IsValid ? true : false;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var pluginToBeUpdated = await _pluginService.GetPluginById(id);
            if (pluginToBeUpdated == null)
                return NotFound();

            var plugin = _mapper.Map<SavePluginDto, PluginDao>(savePluginDto);

            await _pluginService.UpdatePlugin(pluginToBeUpdated, plugin);

            var updatedPlugin = await _pluginService.GetPluginById(id);
            var mappedPlugin = _mapper.Map<PluginDao, PluginDto>(updatedPlugin);

            return Ok(mappedPlugin);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlugin(int id)
        {
            if (id == 0)
                return BadRequest();

            var pluginToDelete = _pluginService.GetPluginById(id);
            if (pluginToDelete == null)
                return NotFound();

            await _pluginService.DeletePlugin(pluginToDelete.Result);

            return NoContent();
        }
    }
}
