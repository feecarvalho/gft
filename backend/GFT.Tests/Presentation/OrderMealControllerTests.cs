using GFT.Application.Protocols;
using GFT.Application.Results;
using GTF.Presentation.Controllers;
using Moq;

namespace GFT.Tests.Presentation;

public class OrderMealControllerTests
{
    public class SutTypes
    {
        public OrderMealController OrderMealController { get; set; }
        public OrderMealUseCaseStub OrderMealUseCaseStub { get; set; }
    }

    public class OrderMealUseCaseStub : IOrderMealUseCase
    {
        public UseCaseResult<string> Execute(string input)
        {
            return new UseCaseResult<string>("");
        }
    }

    public static IOrderMealUseCase MakeUseCaseStub()
    {
        return new OrderMealUseCaseStub();
    }

    public SutTypes MakeSut()
    {
        var useCase = new OrderMealUseCaseStub();
        var sut = new OrderMealController(useCase);

        return new SutTypes
        {
            OrderMealController = sut,
            OrderMealUseCaseStub = useCase
        };
    }
}
