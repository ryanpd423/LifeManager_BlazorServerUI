using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LifeManager_BlazorServerUI.Services;
using LifeManager_BlazorServerUI.Models;
using LifeManager_BlazorServerUI.Wrappers;
using Newtonsoft.Json;

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
        Car SelectedVehicle { get; set; }
        Task HandleVehicleSelect(Car selectedVehicle);
        bool AddCarModalIsVisible { get; set; }
        Task AddCarModalHandler();
        Task OpenModal();
        Task CloseModal();
        Task<List<Car>> GetCars();
    }

    public class CarWizardViewModel : ICarWizardViewModel
    {
        private readonly IPropertyService _propertyService;
        private readonly HttpClient _http;

        public CarWizardViewModel(IPropertyService propertyService,
            HttpClient http)
        {
            // dependencies above this line
            _propertyService = propertyService;
            InitializeViewModel().GetAwaiter().GetResult();
        }

        // TODO: Figure out why I can't init Cars via http in this ViewModel
        public async Task InitializeViewModel()
        {
            await Task.Delay(0);
            //Cars = await GetCars();
            // initialize here
            WizardSteps = new List<WizardStep>();
            WizardSteps.Add(new WizardStep() { Id = 1, StepName = "Select Vehicle", StepNumber = 1 });
            WizardSteps.Add(new WizardStep() { Id = 2, StepName = "Step 2", StepNumber = 2 });
            WizardSteps.Add(new WizardStep() { Id = 3, StepName = "Step 3", StepNumber = 3 });
            WizardSteps.Add(new WizardStep() { Id = 4, StepName = "Step 4", StepNumber = 4 });
            ActiveStep = WizardSteps.FirstOrDefault(x => x.StepNumber == 1);
            Cars = new List<Car>(); // Was breaking if I didn't init this prop first...Weird...
            AddCarModalIsVisible = false;
        }

        public List<WizardStep> WizardSteps { get; set; }
        public WizardStep ActiveStep { get; set; }
        public List<Car> Cars { get; set; }
        public Car SelectedVehicle { get; set; }
        public bool AddCarModalIsVisible { get; set; }

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

        // TODO: figure this out here before you use the Property Service for GET/POST
        public async Task HandleSubmit()
        {
            await Task.Delay(0);
            System.Diagnostics.Debug.WriteLine("✅ You just submitted your form! 🤙");
            // This works here but not when the view is initializing...
            //var httpClient = new HttpClient();
            //var Cars = await httpClient.GetFromJsonAsync<List<Car>>("https://localhost:3001/propertyservice");
            //var foo = Cars;
        }

        public async Task HandleVehicleSelect(Car selectedVehicle)
        {
            await Task.Delay(0);
            SelectedVehicle = selectedVehicle;
            System.Diagnostics.Debug.WriteLine($"✅ You just selected the {selectedVehicle.Make} 🚗");
        }

        public async Task AddCarModalHandler()
        {
            await Task.Delay(0);
            AddCarModalIsVisible = !AddCarModalIsVisible;
        }

        public async Task OpenModal()
        {
            await Task.Delay(0);
            AddCarModalIsVisible = true;
        }

        public async Task CloseModal()
        {
            await Task.Delay(0);
            AddCarModalIsVisible = false;
        }

        public async Task<List<Car>> GetCars()
        {
            return await _propertyService.GetCars();
        }
    }
}
