﻿using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Helpers;
using TwinPics.Resources;
using Windows.Foundation;
using TwinPics.Controllers;

namespace TwinPics
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }
             
                ApplicationView.GetForCurrentView().TitleBar.ButtonBackgroundColor = Colors.Transparent;
                CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

                ThemeManager.UpdateTheme(new ThemeListener().CurrentTheme);
                new ThemeListener().ThemeChanged += App_ThemeChanged;

              

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(Views.MainPage), e.Arguments);
                }

                Window.Current.Activate();
            }
           

        }

        void App_ThemeChanged(ThemeListener sender)
        {
            ThemeManager.UpdateTheme(sender.CurrentTheme);
            AppController.instance.Theme.Change();
        }
       
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
    }
}
