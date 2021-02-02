using System;
using Bunit;
using LifeManager_BlazorServerUI.Components;
using System.Linq;
using Xunit;
using LifeManager_BlazorServerUI.ViewModels;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using LifeManager_BlazorServerUI.Services;

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
        public void it_should_render_four_divs_one_for_each_progress_bar_item()
        {
            // Act
            var page = _carWizardComponentFixture.bUnitTestContext
                .RenderComponent<CarWizardComponent>();
            var result = page.FindAll("div").Where(x => x.ClassName.Contains("card-wizard__progress-area__progress-item"));

            // Assert
            Assert.Equal(4, result.Count());
        }
    }

    public class CarWizardComponentFixture : TestContext
    {

        // Private Property Mocked Injected Dependencies
        private readonly Mock<ICarWizardViewModel> _mockCarWizardViewModel;
        private readonly List<WizardStep> wizardSteps;
        private readonly WizardStep activeStep;
        private readonly List<Car> cars;

        // Public Property for bUnit Test Context
        public readonly TestContext bUnitTestContext;

        public CarWizardComponentFixture()
        {
            wizardSteps = WizardSteps_Setup_Test_Helper();
            cars = Cars_Setup_Test_Helper();
            _mockCarWizardViewModel = new Mock<ICarWizardViewModel>();
            _mockCarWizardViewModel.Setup(x => x.WizardSteps).Returns(wizardSteps);
            _mockCarWizardViewModel.Setup(x => x.ActiveStep)
                .Returns(wizardSteps.FirstOrDefault());
            _mockCarWizardViewModel.Setup(x => x.Cars).Returns(cars);
            bUnitTestContext = new TestContext();
            bUnitTestContext.Services.AddSingleton(_mockCarWizardViewModel.Object);
        }

        private List<Car> Cars_Setup_Test_Helper()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Insurance = "Statefarm",
                    Make = "Chevy",
                    Mileage = 100000,
                    Model = "Tahoe",
                    Name = "Heavy",
                    Year = 2018,
                    Type = CarType.Truck
                },
                new Car()
                {
                    Id = 1,
                    Insurance = "Statefarm",
                    Make = "Chevy",
                    Mileage = 100000,
                    Model = "Sorento",
                    Name = "Ria",
                    Year = 2016,
                    Type = CarType.SUV
                }
            };
        }

        private List<WizardStep> WizardSteps_Setup_Test_Helper()
        {
            return new List<WizardStep>()
            {
                new WizardStep()
                {
                    Id = 1,
                    Active = false,
                    Completed = false,
                    StepNumber = 1,
                    StepName = "Step 1"
                },
                new WizardStep()
                {
                    Id = 2,
                    Active = false,
                    Completed = false,
                    StepNumber = 2,
                    StepName = "Step 2"
                },
                new WizardStep()
                {
                    Id = 3,
                    Active = false,
                    Completed = false,
                    StepNumber = 4,
                    StepName = "Step 4"
                },
                new WizardStep()
                {
                    Id = 4,
                    Active = false,
                    Completed = false,
                    StepNumber = 4,
                    StepName = "Step 4"
                }
            };
        }
    }
}
