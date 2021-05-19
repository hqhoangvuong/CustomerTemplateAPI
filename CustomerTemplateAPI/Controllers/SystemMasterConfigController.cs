using CustomerTemplateAPI.Commons;
using CustomerTemplateAPI.Models;
using CustomerTemplateAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemMasterConfigController : ControllerBase
    {
        private readonly ISystemMasterConfigRepository _repo;

        public SystemMasterConfigController(ISystemMasterConfigRepository systemMasterConfigRepository)
        {
            this._repo = systemMasterConfigRepository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IEnumerable<SystemMasterConfig> Get()
        {
            return _repo.FindAll();
        }

        [HttpGet("configname")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<SystemMasterConfig>> GetByConfigName(string configName)
        {
            var result = await _repo.FindByName(configName);

            if (result == null)
            {
                return CheckData<SystemMasterConfig>.ItemNotFound(configName);
            }

            return Ok(result);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<SystemMasterConfig>> Put([FromBody] SystemMasterConfig updatedItem)
        {
            var exsited = await _repo.FindById(updatedItem.Id).ConfigureAwait(true);

            if (exsited == null)
            {
                return CheckData<SystemMasterConfig>.ItemNotFound(updatedItem.Id);
            }

            var updatedResult = await _repo.Modify(updatedItem);
            return Ok(updatedResult);
        }
    }
}
