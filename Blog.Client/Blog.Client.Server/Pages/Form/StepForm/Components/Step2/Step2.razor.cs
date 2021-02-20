using Blog.Client.Server.Models;
using Microsoft.AspNetCore.Components;

namespace Blog.Client.Server.Pages.Form
{
    public partial class Step2
    {
        private readonly StepFormModel _model = new StepFormModel();

        [CascadingParameter] public StepForm StepForm { get; set; }

        public void OnValidateForm()
        {
            StepForm.Next();
        }

        public void Preview()
        {
            StepForm.Prev();
        }
    }
}