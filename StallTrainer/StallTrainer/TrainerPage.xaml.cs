using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;

namespace StallTrainer
{
    [DesignTimeVisible(false)]
    public partial class TrainerPage : ContentPage
    {
        private bool IsRunning;
        private List<ISimpleAudioPlayer> audio;

        public TrainerPage()
        {
            InitializeComponent();
            IsRunning = false;

            audio = new List<ISimpleAudioPlayer>();
            for (int i = 0; i < + 6; i++)
            {
                audio.Add(CrossSimpleAudioPlayer.CreateSimpleAudioPlayer());
            }

            audio[0].Load("up.mp3");
            audio[1].Load("down.mp3");
            audio[2].Load("top.mp3");
            audio[3].Load("bottom.mp3");
            audio[4].Load("left.mp3");
            audio[5].Load("right.mp3");
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

        private void StartStopButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsRunning = !IsRunning;
            if (IsRunning)
            {
                startStopButton.Text = "Stop";
                button.BorderColor = Color.Red;
                Device.StartTimer(TimeSpan.FromSeconds(intervalSlider.Value), () =>
                {
                    PlaySound();
                    return IsRunning;
                });
            }
            else
            {
                startStopButton.Text = "Start";
                button.BorderColor = Color.LightGreen;
            }
        }

        private void PlaySound()
        {
            audio[0].Play();
            //TODO: randomize sounds
        }
    }
}
