using GFT.Application.Protocols;
using GTF.Presentation.Inputs;
using GTF.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GTF.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderMealController : ControllerBase
    {
        private readonly IOrderMealUseCase _orderMealUseCase;

        public OrderMealController(IOrderMealUseCase orderMealUseCase)
        {
            _orderMealUseCase = orderMealUseCase;
        }

        [HttpPost]
        public ActionResult<OrderMealResponse> Post([FromBody] OrderMealRequest request)
        {
            try
            {
                var useCaseResponse = _orderMealUseCase.Execute(request.Input);
                if (useCaseResponse.Errors.Any())
                {
                    return BadRequest(useCaseResponse.Errors);
                }

                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred. {ex.Message}");
            }
        }
    }
}