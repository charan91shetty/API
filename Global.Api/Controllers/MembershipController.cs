using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global.Domain.Model;
using Global.Domain.Repository;
using Global.Domain.Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Global.Api.Controllers
{
   
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class MembershipController : ControllerBase
    {
        private IMembershipRepository _membershipRepository { get; set; }
        public MembershipController(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }


        [HttpGet]
        [Authorize]
        [Route("GetAllMembershipType")]
        public async Task<IActionResult> GetAllMembershipType()
        {
            var allTypes = await _membershipRepository.GetAllMembershipAsync();
            return Ok(allTypes);
        }

        [HttpGet]
        [Authorize]
        [Route("GetMembershipTypeById/{id}")]
        public async Task<IActionResult> GetMembershipById([FromRoute]int id)
        {
            var allBooks = await _membershipRepository.GetMembershipByIdsAsync(id);
            return Ok(allBooks);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateMembership")]
        public async Task<IActionResult> CreateMembership([FromBody] MembershipModel membershipModel)
        {
            var recordData = await _membershipRepository.AddMemberAsync(membershipModel);
            return Ok(recordData);
        }













    }
}
