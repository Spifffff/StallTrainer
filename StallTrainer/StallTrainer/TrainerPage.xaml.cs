using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StallTrainer
{
    [DesignTimeVisible(false)]
    public partial class TrainerPage : ContentPage
    {
        private bool IsRunning;
        public TrainerPage()
        {
            InitializeComponent();
            IsRunning = false;
        }

        private void HandSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //limit slider to whole numbers
            Slider slider = (Slider)sender;
            StepifySlider(slider);

            //display selected setting
            string hands = CompareDoubles(slider.Value, 0) ? "single" :
                CompareDoubles(slider.Value, 1) ? "double, alternating" :
                "double, randomised";
            handLabel.Text = $"Hands: {hands}";
        }

        private void IntervalSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //limit slider to whole numbers
            Slider slider = (Slider)sender;
            StepifySlider(slider);
        }

        private bool CompareDoubles(double valueOne, double valueTwo) => Math.Abs(valueOne - valueTwo) <= 0.1;

        private void StepifySlider(Slider slider, int precision = 0)
        {
            slider.Value = Math.Round(slider.Value, precision);
        }

        private void startStopButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsRunning = !IsRunning;
            if (IsRunning)
            {
                startStopButton.Text = "Stop";
                button.BorderColor = Color.Red;
                //TODO: handle start timer
            }
            else
            {
                startStopButton.Text = "Start";
                button.BorderColor = Color.LightGreen;
                //TODO: handle stop timer
            }
        }
    }
}
