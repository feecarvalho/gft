using GFT.Application.Protocols;
using GFT.Application.Results;
using GTF.Presentation.Controllers;
using GTF.Presentation.Inputs;
using Microsoft.AspNetCore.Mvc;
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

    [Fact]
    public void Should_Return_400_If_Empty_Input()
    {
        var sut = MakeSut();
        var request = new OrderMealRequest
        {
            Input = ""
        };
        var result = sut.OrderMealController.Post(request);
        var httpResult = result.Result as ObjectResult;

        Assert.Equal(400, httpResult?.StatusCode);
    }


    [Fact]
    public void Should_Return_400_If_Invalid_Day_Time_Was_Provided()
    {
        var sut = MakeSut();
        var request = new OrderMealRequest
        {
            Input = "afternoon,1,2,3,4"
        };
        var result = sut.OrderMealController.Post(request);
        var httpResult = result.Result as ObjectResult;

        Assert.Equal(400, httpResult?.StatusCode);
        Assert.Equal("Day time must be 'morning' or 'night'", httpResult?.Value);
    }


    [Fact]
    public void Should_Call_OrderMealUseCase_With_Correct_OrderInput()
    {
        var useCaseMock = new Mock<IOrderMealUseCase>();
        var sut = new OrderMealController(useCaseMock.Object);
        var request = new OrderMealRequest
        {
            Input = "morning,1,2,3,3,3,3,3",
        };
        var result = sut.Post(request);
        var httpResult = result.Result as ObjectResult;
        useCaseMock.Verify(m => m.Execute(It.Is<string>(o => o == "morning,1,2,3,3,3,3,3")), request.Input);
    }
}
