using Microsoft.Toolkit.Uwp.UI.Helpers;
using System.IO;
using System;
using TwinPics.Resources;
using TwinPics.ViewModels;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;

namespace TwinPics.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ImageTest_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            WriteableBitmap bitmap = new WriteableBitmap(200, 240);
            StorageFile storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Logo200x200.png"));


            using (IRandomAccessStream fileStream = await storageFile.OpenAsync(FileAccessMode.Read))
            {
                bitmap.SetSource(fileStream);
                // Получите массив пикселей изображения
                byte[] pixelBuffer = bitmap.PixelBuffer.ToArray();

                // Задайте белый цвет для каждого пикселя
                for (int i = 0; i < pixelBuffer.Length; i += 4)
                {
                    var R = pixelBuffer[i + 2];
                    var G = pixelBuffer[i + 1];
                    var B = pixelBuffer[i + 0];
                    var A = pixelBuffer[i + 3];

                    if (R != 0 || G != 0 || B != 0)
                    {
                        pixelBuffer[i + 2] = 255;
                        pixelBuffer[i + 1] = 0;
                        pixelBuffer[i + 0] = 0;
                    }

                    byte r = pixelBuffer[i];
                    byte g = pixelBuffer[i + 1];
                    byte b = pixelBuffer[i + 2];

                    // Получение значений пикселей, расположенных непосредственно над, под, слева и справа от текущего пикселя
                    byte r1 = (i > bitmap.PixelWidth * 4) ? pixelBuffer[i - bitmap.PixelWidth * 4] : r;
                    byte g1 = (i > bitmap.PixelWidth * 4) ? pixelBuffer[i - bitmap.PixelWidth * 4 + 1] : g;
                    byte b1 = (i > bitmap.PixelWidth * 4) ? pixelBuffer[i - bitmap.PixelWidth * 4 + 2] : b;

                    byte r2 = (i < (bitmap.PixelWidth - 1) * 4) ? pixelBuffer[i + 4] : r;
                    byte g2 = (i < (bitmap.PixelWidth - 1) * 4) ? pixelBuffer[i + 5] : g;
                    byte b2 = (i < (bitmap.PixelWidth - 1) * 4) ? pixelBuffer[i + 6] : b;

                    byte r3 = (i % (bitmap.PixelWidth * 4) > 3) ? pixelBuffer[i - 4] : r;
                    byte g3 = (i % (bitmap.PixelWidth * 4) > 3) ? pixelBuffer[i - 3] : g;
                    byte b3 = (i % (bitmap.PixelWidth * 4) > 3) ? pixelBuffer[i - 2] : b;

                   // byte r4 = (i % (bitmap.PixelWidth * 4) < (bitmap.PixelWidth - 1) * 4) ? pixelBuffer[i + 8] : r;
                  //  byte g4 = (i % (bitmap.PixelWidth * 4) < (bitmap.PixelWidth - 1) * 4) ? pixelBuffer[i + 9] : g;
                   // byte b4 = (i % (bitmap.PixelWidth * 4) < (bitmap.PixelWidth - 1) * 4) ? pixelBuffer[i + 10] : b;

                    // Вычисление среднего значения цветовых компонент
                    byte avgR = (byte)((r + r1 + r2 + r3) / 5);
                    byte avgG = (byte)((g + g1 + g2 + g3) / 5);
                    byte avgB = (byte)((b + b1 + b2 + b3) / 5);

                    // Присвоение новому массиву сглаженных пикселей среднее значение цветовых компонент
                    pixelBuffer[i] = avgR;
                    pixelBuffer[i + 1] = avgG;
                    pixelBuffer[i + 2] = avgB;
                    pixelBuffer[i + 3] = 255;

                }

                // Запишите измененный массив пикселей обратно в изображение
                using (Stream stream = bitmap.PixelBuffer.AsStream())
                {
                    stream.Write(pixelBuffer, 0, pixelBuffer.Length);
                    stream.Flush();
                }

                // Отобразите измененное изображение
                
                ImageTest.Source = bitmap;
            }
              
        }
    }
}
