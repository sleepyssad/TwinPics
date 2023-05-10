using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinPics.Contracts.Services
{
    public interface IThemeService
    {
        event EventHandler Changed;
        void Change();
    }
}
