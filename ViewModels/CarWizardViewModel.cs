﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeManager_BlazorServerUI.Services;

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
    }

    public class CarWizardViewModel : ICarWizardViewModel
    {
        private readonly IPropertyService _propertyService;

        public CarWizardViewModel(IPropertyService propertyService)
        {
            // dependencies above this line
            _propertyService = propertyService;
            InitializeViewModel().GetAwaiter().GetResult();
        }

        public async Task InitializeViewModel()
        {
            await Task.Delay(0);
            // initialize here
            WizardSteps = new List<WizardStep>();
            WizardSteps.Add(new WizardStep() { Id = 1, StepName = "Step 1", StepNumber = 1 });
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
        }
    }
}
