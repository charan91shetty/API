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
    public class PurchaseController : ControllerBase
    {
        public readonly IPurchaseRepository _purchaseRepository;
        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PurchaseMembership([FromBody] PurchaseOrderModel purchaseOrderModel)
        {
            var responseObject = _purchaseRepository.PurchaseMembership(purchaseOrderModel);
            if ((responseObject == null))
            {
                return NotFound("Please contact administrator");
            }

            return Ok(responseObject.Result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAddressDetails([FromBody] AddressModel addressModel)
        {

            var responseObject = _purchaseRepository.CreateAddress2User(addressModel);
            if ((responseObject == null))
            {
                return NotFound("Please contact administrator");
            }

            return Ok("address created. Id:" +responseObject.Result.Id);
        }


    }
}
