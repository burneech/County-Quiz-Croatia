using CountyQuizCroatia.ViewModels;
using CountyQuizCroatia.Services;
using StyletIoC;
using Stylet;

namespace CountyQuizCroatia
{
    public class Bootstrapper : Bootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            builder.Bind<ICountyService>().To<CountyService>().InSingletonScope();
            builder.Bind<IQuizManager>().To<QuizManager>().InSingletonScope();
        }
    }
}
