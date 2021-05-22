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
    public class SystemDbSchemaController : ControllerBase
    {
        private readonly ISystemDbSchemaRepsitory _repo;

        public SystemDbSchemaController(ISystemDbSchemaRepsitory systemDbSchemaRepsitory)
        {
            this._repo = systemDbSchemaRepsitory;
        }

        [HttpGet("tableconfig")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<SystemTableConfig>> GetAllTableConfig()
        {
            return Ok(await _repo.FindAllTableConfig());
        }

        [HttpGet("columnconfig")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<SystemTableColumnConfig>> GetAllColumnConfig()
        {
            return Ok(await _repo.FindAllColumnConfig());
        }

        [HttpGet("foreignkeyconfig")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<SystemTableForeingKeyConfig>> GetAllForeignKeyConfig()
        {
            return Ok(await _repo.FindAllForeignKeyConfig());
        }
    }
}
