﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TwinPics.Controllers;
using TwinPics.Views.Controls;
using TwinPics.Views.Pages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TwinPics.Views.Components
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Footer : Page
    {
        public Footer()
        {
            this.InitializeComponent();
        }
        

        private void Button_OnTapped(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Auto, Title = "Hello world", Subtitle = "This text and bla bla bla bla bla", Content = new PrimaryPage(), });
        }

        private void Button_OnTapped_1(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Medium, Title = "Hello world", Content=this });
        }

        private void Button_OnTapped_2(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Medium, Subtitle = "This text and bla bla bla bla bla" });
        }

        private void Button_OnTapped_3(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Medium, IsVisibleHeader = false });
        }

        private void Button_OnTapped_4(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Width, Width=300 });
        }

        private void Button_OnTapped_5(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Percent, WidthPercent=8 });
        }

        private void Button_OnTapped_6(object sender, EventArgs e)
        {
            AppController.instance.ModalWindow.Open(new ModalWindowProps { Size = ModalWindowSize.Percent, WidthPercent = 5, MinWidth=300, MaxWidth=600 }) ;
        }

        private void Button_OnTapped_7(object sender, EventArgs e)
        {

        }
    }
}
