using GFT.Application.UseCases;
using GTF.Presentation.Inputs;
using GTF.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GTF.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderMealController : ControllerBase
    {
        [HttpPost]
        public ActionResult<OrderMealResponse> Post([FromBody] OrderMealRequest request)
        {
            var useCase = new OrderMealUseCase();
            var useCaseResponse = useCase.Execute(request.Input);
            if (useCaseResponse.Errors.Any())
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}