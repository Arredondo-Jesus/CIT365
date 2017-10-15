using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glazer_Calculation
{
    class GlazerCalculator
    {
        public int width { set; get; }
        public int height { set; get; }
        public double woodLegth { set; get; }
        public double glassArea { set; get; }
        public int quantity { set; get; }
        public string color { set; get; }

        public double calcWoodLength(MainPage mainPage) {
            int width = this.width = mainPage.getWidth();
            int height = this.height = mainPage.getHeight();

            double woodLength = 2 * (width * height) * 3.25;
      
            return woodLength;
        }

        public double calcGlassArea(MainPage mainPage)
        {
            int width = this.width = mainPage.getWidth();
            int height = this.height = mainPage.getHeight();

            double glassAarea = 2 * (width * height);

            return glassAarea;
        }
    }
}
