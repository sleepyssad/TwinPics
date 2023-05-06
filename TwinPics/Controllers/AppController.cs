using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinPics.Controllers
{
    public class AppController
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

        public static event EventHandler OnThemeChanged;
        public static void CallThemeChanged(object value, EventArgs e)
        {
            if (OnThemeChanged != null)
            {
                OnThemeChanged(value, e);
            }
        }
    }
}
