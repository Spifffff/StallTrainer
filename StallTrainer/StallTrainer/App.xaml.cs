﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StallTrainer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TrainerPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
