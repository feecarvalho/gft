using GFT.Application.Protocols;
using GTF.Presentation.Inputs;
using GTF.Presentation.Validators;
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
        public ActionResult<string> Post([FromBody] OrderMealRequest request)
        {
            try
            {
                var errors = OrderMealValidator.ValidateOrder(request);
                if (errors.Any()) 
                    return BadRequest(new { Error = string.Join(";", errors) });
                var useCaseResponse = _orderMealUseCase.Execute(request.Input);
                if (useCaseResponse.Errors.Any()) 
                    return BadRequest(new { Error = useCaseResponse.Errors });
                return Ok(new { Output = useCaseResponse.GetValue() });
            } catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred. {ex.Message}");
            }
        }
    }
}