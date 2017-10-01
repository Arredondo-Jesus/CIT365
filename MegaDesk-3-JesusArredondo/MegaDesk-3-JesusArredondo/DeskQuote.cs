using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MegaDesk_3_JesusArredondo
{
    class DeskQuote
    {
        private DateTime date;
        private string clientName;
        private int rushDays;
        private int price;

        public DateTime getDate() {
            return this.date;
        }

        public void setDate(DateTime date)
        {
            this.date = DateTime.Today;
        }

        public string getClientName() {
            return this.clientName;
        }

        public void setClientName(string name) {
            this.clientName = name;
        }

        public int getRushDays() {
            return this.rushDays;
        }

        public void setRushDays(int rushDays) {
            this.rushDays = rushDays;
        }

        public int getPrice() {
            return this.price;
        }

        public void setPrice(int price) {
            this.price = price;
        }

        public void calculatePrice(Desk desk, AddQuote addQuote) {
        
            int basePrice = 200;
            int deskSurface = desk.getDeskDepth() * desk.getDeskWidth();
            int drawersPrice = desk.getDrawers() * 50;
            int rushDays = this.getRushDays();
            int extraSurfacePrice = 0;
            int rushDaysPrice = 0;
            int materialPrice = 0;

            if (deskSurface > 1000) {
                extraSurfacePrice = deskSurface - 1000;
            }


            switch (addQuote.getMaterial()) {
                case "Oak": materialPrice = (int)Desk.Materials.Oak; break;
                case "Laminate": materialPrice = (int)Desk.Materials.Laminate; break;
                case "Pine": materialPrice = (int)Desk.Materials.Pine; break;
                case "Rossewood": materialPrice = (int)Desk.Materials.Rossewood; break;
                case "Veneer": materialPrice = (int)Desk.Materials.Veneer; break;
                default: materialPrice = 0; break;
            }

            if (deskSurface > 0 && deskSurface < 1000)
            {
                switch (rushDays) {
                    case 3: rushDaysPrice = 60; break;
                    case 5: rushDaysPrice = 40; break; 
                    case 7: rushDaysPrice = 30; break;
                    default: rushDaysPrice = 0; break;
                }
            }
            else if (deskSurface >= 1000 && deskSurface <= 2000)
            {
                switch (rushDays)
                {
                    case 3: rushDaysPrice = 70; break;
                    case 5: rushDaysPrice = 50; break;
                    case 7: rushDaysPrice = 35; break;
                    default: rushDaysPrice = 0; break;
                }
            }
            else {
                switch (rushDays)
                {
                    case 3: rushDaysPrice = 80; break;
                    case 5: rushDaysPrice = 60; break;
                    case 7: rushDaysPrice = 40; break;
                    default: rushDaysPrice = 0; break;
                }
            }

            this.setPrice(basePrice + extraSurfacePrice + drawersPrice + rushDaysPrice + materialPrice);
        }

        public void saveQuote(AddQuote addQuote)
        {
            Desk desk = new Desk();
          
            desk.setDeskWidth(addQuote.getDeskWidth());
            desk.setDeskDepth(addQuote.getDeskDepth());
            desk.setSize(addQuote.getDeskDepth() * addQuote.getDeskWidth());

            desk.setDrawers(addQuote.getDeskDrawers());
            addQuote.setSize(desk.getSize());
            addQuote.setDate(this.getDate());
            
            this.setClientName(addQuote.getClientName());
            this.setRushDays(addQuote.getRushDays());

            this.calculatePrice(desk, addQuote);
            this.setDate(this.date);
            addQuote.setPrice(this.getPrice());


            string name = this.getClientName();
            string date = this.getDate().ToString();
            string width = desk.getDeskWidth().ToString();
            string depth = desk.getDeskDepth().ToString();
            string drawwers = desk.getDrawers().ToString();
            string rushDays = this.getRushDays().ToString();
            string price = this.getPrice().ToString();
            string size = desk.getSize().ToString();

            try
            {
                StreamReader streamReader = new StreamReader("Quotes.txt");
                if (streamReader.ReadLine() == null)
                {
                    streamReader.Close();
                    StreamWriter streamWriter1 = new StreamWriter("Quotes.txt", append: true);
                    string header = "Name,Date,Rush Days,Desk With, Desk Depth,Desk Drawers,Price";
                    streamWriter1.WriteLine(header);
                    streamWriter1.Close();
                }
                else
                {
                    streamReader.Close();
                }

                StreamWriter streamWriter = new StreamWriter("Quotes.txt", append: true);
                string content = name + "," + date + "," + rushDays + "," + width + "," + depth + "," + drawwers + ","
                    + price;
                streamWriter.WriteLine(content);
                streamWriter.Close();

            }
            catch (IOException e) {
                if (e.Source != null) {
                    System.Windows.Forms.MessageBox.Show("An error has occur while trying to open the file");
                }
            }

        }
    }
}
