using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global.Domain.Model;
using Global.Domain.Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Global.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ClubController : ControllerBase
    {
        public readonly IClubRepository _clubRepository;
        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddClub([FromBody] ClubModel clubModel)
        {

            var responseObject = await _clubRepository.CreateClub(clubModel);
            if ((responseObject < 0))
            {
                return NoContent();
            }
            
            return Ok("club created, Club Id:" + responseObject);
        }
    }
}
