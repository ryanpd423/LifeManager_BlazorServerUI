using System;
using Bunit;
using LifeManager_BlazorServerUI.Components;
using System.Linq;
using Xunit;
using LifeManager_BlazorServerUI.ViewModels;
using Moq;
using Microsoft.Extensions.DependencyInjection;

namespace LifeManager_BlazorServerUI_xUnit__bUnit
{
    public class CarWizardComponentTests : IClassFixture<CarWizardComponentFixture>
    {
        private readonly CarWizardComponentFixture _carWizardComponentFixture;

        public CarWizardComponentTests(CarWizardComponentFixture carWizardComponentFixture)
        {
            _carWizardComponentFixture = carWizardComponentFixture;
        }

        [Fact]
        public void it_should_do_something()
        {
            // Act
            var page = _carWizardComponentFixture.bUnitTestContext
                .RenderComponent<CarWizardComponent>();
            // var result = page.Find("div").ClassName(Xunit =>);

            // Assert

        }
    }

    public class CarWizardComponentFixture : TestContext
    {

        // Private Property Mocked Injected Dependencies
        private readonly Mock<ICarWizardViewModel> _mockCarWizardViewModel;

        // Public Property for bUnit Test Context
        public readonly TestContext bUnitTestContext;

        public CarWizardComponentFixture()
        {
            _mockCarWizardViewModel = new Mock<ICarWizardViewModel>();
            bUnitTestContext = new TestContext();
            bUnitTestContext.Services.AddSingleton(_mockCarWizardViewModel.Object);
        }
    }
}
