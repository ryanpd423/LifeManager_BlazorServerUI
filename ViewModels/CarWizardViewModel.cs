using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeManager_BlazorServerUI.ViewModels
{
    public interface ICarWizardViewModel
    {
        List<WizardStep> WizardSteps { get; set; }
        WizardStep ActiveStep { get; set; }
        Task GoToNextStep();
        Task GoToPreviousStep();
        Task HandleSubmit();
    }

    public class CarWizardViewModel : ICarWizardViewModel
    {
        public CarWizardViewModel()
        {
            // dependencies above this line
            InitializeViewModel().GetAwaiter().GetResult();
        }

        public async Task InitializeViewModel()
        {
            await Task.Delay(0);
            // initialize here
            WizardSteps = new List<WizardStep>();
            WizardSteps.Add(new WizardStep() { Id = "1", StepName = "Step 1", StepNumber = 1 });
            WizardSteps.Add(new WizardStep() { Id = "2", StepName = "Step 2", StepNumber = 2 });
            WizardSteps.Add(new WizardStep() { Id = "3", StepName = "Step 3", StepNumber = 3 });
            WizardSteps.Add(new WizardStep() { Id = "4", StepName = "Step 4", StepNumber = 4 });
            ActiveStep = WizardSteps.FirstOrDefault(x => x.StepNumber == 1);
        }

        public List<WizardStep> WizardSteps { get; set; }
        public WizardStep ActiveStep { get; set; }

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
            System.Diagnostics.Debug.WriteLine("Yo just submitted your form");
        }
    }
}
