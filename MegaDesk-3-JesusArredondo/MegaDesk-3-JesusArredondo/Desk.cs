using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_JesusArredondo
{
    class Desk
    {
        private float width;
        private float deph;
        private int drawers;
        private enum Materials { }

        public float getWidth() {
            return this.width;
        }

        public void setWidth(float width) {
            this.width = width;
        }

        public float getDeph() {
            return this.deph;
        }

        public void setDeph(float deph) {
            this.deph = deph;
        }

        public int getDrawers() {
            return this.drawers;
        }

        public void setDrawers(int drawers) {
            this.drawers = drawers;
        }

    }
}
