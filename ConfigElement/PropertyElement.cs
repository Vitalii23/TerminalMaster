using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Toner.ConfigElement
{
    class PropertyElement
    {
        int lengthMax;

        public void SetTextBoxMaxLength(int lengthMax)
        {
            this.lengthMax = lengthMax;
        }

        public int GetTextBoxMaxLength()
        {
            return lengthMax;
        }
    }
}
