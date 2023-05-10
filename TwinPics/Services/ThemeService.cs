using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinPics.Contracts.Services;

namespace TwinPics.Services
{
    internal class ThemeService : IThemeService
    {
        public event EventHandler Changed;

        public void Change()
        {
            Changed.Invoke(null, EventArgs.Empty);
        }
    }
}
