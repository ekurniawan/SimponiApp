﻿using SimponiApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimponiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Application.Current.Properties["alumni"] = null;
            //init
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new RestaurantPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
