namespace GFT.Application.Protocols
{
    public interface IUseCase<out Result, in Input>: IUseCase where Result : IUseCaseResult
    {
        public Result Execute(Input input);
    }
    public interface IUseCase<out Result> : IUseCase where Result : IUseCaseResult
    {
        public Result Execute();
    }

    public interface IUseCase { }
}
