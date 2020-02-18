using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StallTrainer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TrainerPage : ContentPage
    {
        public TrainerPage()
        {
            InitializeComponent();
        }

        private void HandSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //limit slider to three values
            Slider slider = (Slider)sender;
            slider.Value = Math.Round(e.NewValue);

            //display selected setting
            string hands = CompareDoubles(slider.Value, 0) ? "single" :
                CompareDoubles(slider.Value, 1) ? "double, alternating" :
                "double, randomised";
            handLabel.Text = $"Hands: {hands}";
        }

        private bool CompareDoubles(double valueOne, double valueTwo) => Math.Abs(valueOne - valueTwo) <= 0.1;
    }
}
