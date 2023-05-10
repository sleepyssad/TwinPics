using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinPics.Contracts.Services;
using TwinPics.Services;
using TwinPics.Views.Controls;

namespace TwinPics.Controllers
{
    internal class AppController
    {
        private static object m_lock = new object();
        private static AppController _instance;
        public static AppController instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (m_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppController();
                        }
                    }
                }
                return _instance;
            }
        }

        public IModalWindowService ModalWindow;

        public IThemeService Theme;

        public AppController()
        {
            ModalWindow = new ModalWindowService();
            Theme = new ThemeService();
        }

    }
}
