using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_JesusArredondo
{
    class Desk
    {
        private int width;
        private int depth;
        private int drawers;
        public enum Materials {
            Oak = 200,
            Laminate = 100,
            Pine = 50,
            Rossewood = 300,
            Veneer = 150
        };

        private int size;

        public int getDeskWidth() {
            return this.width;
        }

        public void setDeskWidth(int width) {
            this.width = width;
        }

        public int getDeskDepth() {
            return this.depth;
        }

        public void setDeskDepth(int depth) {
            this.depth = depth;
        }

        public int getDrawers() {
            return this.drawers;
        }

        public void setDrawers(int drawers) {
            this.drawers = drawers;
        }

        public int getSize() {
            return this.size;
        }

        public void setSize(int size) {
            this.size = size;
        }
    }
}
