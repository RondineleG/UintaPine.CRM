﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UintaPine.CRM.Logic.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UintaPine.CRM.Model.Shared;
using UintaPine.CRM.Model.Database;
using UintaPine.CRM.Model.Shared.Requests;
using UintaPine.CRM.Model.Server;

namespace UintaPine.CRM.Api.Controllers
{
    public class CompanyController : ControllerBase
    {
        private UserLogic _userLogic { get; set; }
        private CompanyLogic _companyLogic { get; set; }
        public CompanyController(UserLogic userlogic, CompanyLogic companyLogic)
        {
            _userLogic = userlogic;
            _companyLogic = companyLogic;
        }

        [Route("api/v1/company")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCompany([FromBody]CreateCompany model)
        {
            User user = await _userLogic.GetUserByIdAsync(User.Identity.Name);
            
            //TODO: Field validation

            Company result = await _companyLogic.CreateCompanyAsync(model.Name, user.Id);
            if (result == null)
                return BadRequest("A company is already associated with this user");

            return Ok(result.ToSharedResponseCompany());
        }

        [Route("api/v1/company/user/{userId}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCompaniesByUser(string userId)
        {
            User user = await _userLogic.GetUserByIdAsync(User.Identity.Name);
            if (user.Id != userId)
                return BadRequest("Unauthorized User");

            var result = await _companyLogic.GetCompaniesByUser(user.Id);

            return Ok(result.Select(c => c.ToSharedResponseCompany()).ToList());
        }

        [Route("api/v1/company/{companyId}/tag")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTagByCompanyId([FromBody]CreateTag model, string companyId)
        {
            User user = await _userLogic.GetUserByIdAsync(User.Identity.Name);

            //TODO: Validation

            await _companyLogic.CreateTag(companyId, model.Name, model.BackgroundColor, model.FontColor);

            return Ok();
        }

        [Route("api/v1/company/{companyId}/tag/{tagId}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteTagByCompanyIdTagId(string companyId, string tagId)
        {
            User user = await _userLogic.GetUserByIdAsync(User.Identity.Name);

            await _companyLogic.DeleteTag(companyId, tagId);

            return Ok();
        }
    }
}