using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel.Shared.ControllerBases;
using Travel.Shared.Dtos;

namespace Travel.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public IActionResult Payment()
        {
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
