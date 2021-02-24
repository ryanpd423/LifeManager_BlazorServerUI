using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeManager_BlazorServerUI.Services;
using LifeManager_BlazorServerUI.Wrappers;

namespace LifeManager_BlazorServerUI.ViewModels
{
    public interface ICarWizardViewModel
    {
        List<WizardStep> WizardSteps { get; set; }
        WizardStep ActiveStep { get; set; }
        Task GoToNextStep();
        Task GoToPreviousStep();
        Task HandleSubmit();
        List<Car> Cars { get; set; }
        public Car SelectedVehicle { get; set; }
        Task HandleVehicleSelect(Car selectedVehicle);
    }

    public class CarWizardViewModel : ICarWizardViewModel
    {
        private readonly IPropertyService _propertyService;
        private readonly IHttpClientWrapper _httpClientWrapper;

        public CarWizardViewModel(IPropertyService propertyService,
            IHttpClientWrapper httpClientWrapper)
        {
            // dependencies above this line
            _propertyService = propertyService;
            _httpClientWrapper = httpClientWrapper;
            InitializeViewModel().GetAwaiter().GetResult();
        }

        public async Task InitializeViewModel()
        {
            await Task.Delay(0);
            // initialize here
            WizardSteps = new List<WizardStep>();
            WizardSteps.Add(new WizardStep() { Id = 1, StepName = "Select Vehicle", StepNumber = 1 });
            WizardSteps.Add(new WizardStep() { Id = 2, StepName = "Step 2", StepNumber = 2 });
            WizardSteps.Add(new WizardStep() { Id = 3, StepName = "Step 3", StepNumber = 3 });
            WizardSteps.Add(new WizardStep() { Id = 4, StepName = "Step 4", StepNumber = 4 });
            ActiveStep = WizardSteps.FirstOrDefault(x => x.StepNumber == 1);
            Cars = new List<Car>(); // Was breaking if I didn't init this prop first...Weird...
            Cars = await _propertyService.GetCars();
        }

        public List<WizardStep> WizardSteps { get; set; }
        public WizardStep ActiveStep { get; set; }
        public List<Car> Cars { get; set; }
        public Car SelectedVehicle { get; set; }

        public async Task GoToNextStep()
        {
            await Task.Delay(0);
            if (ActiveStep.StepNumber >= 1 && ActiveStep.StepNumber < WizardSteps.Count)
            {
                ActiveStep = WizardSteps[ActiveStep.StepNumber];
            }
        }

        public async Task GoToPreviousStep()
        {
            await Task.Delay(0);
            if (ActiveStep.StepNumber > 1 && ActiveStep.StepNumber <= WizardSteps.Count)
            {
                ActiveStep = WizardSteps[ActiveStep.StepNumber - 2];
            }
        }

        public async Task HandleSubmit()
        {
            await Task.Delay(0);
            System.Diagnostics.Debug.WriteLine("✅ You just submitted your form! 🤙");
            //var foo = await _httpClientWrapper.GetAsync("https://localhost:3001/weatherforecast");
            //System.Diagnostics.Debug.WriteLine(foo);
        }

        public async Task HandleVehicleSelect(Car selectedVehicle)
        {
            await Task.Delay(0);
            SelectedVehicle = selectedVehicle;
            System.Diagnostics.Debug.WriteLine($"✅ You just selected the {selectedVehicle.Make} 🚗");
        }
    }
}
