﻿using AutoMapper;
using Crud.Api.Model.Dto;
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
    }
}