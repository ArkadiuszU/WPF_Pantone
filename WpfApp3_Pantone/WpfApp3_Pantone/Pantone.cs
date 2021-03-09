using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace WpfApp3_Pantone
{
    public class Pantone
    {
        public Pantone()
        {
         // RGBColor=  Conversion(RGB);
        }

        private string name;
        private string cmyk;
        private string hex;
        private string rgb;
        private string url;
        private string thsv;
        private Color rgbcolor;
        public Color RGBColor
        {
            get { return rgbcolor; }
            set { rgbcolor = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Hex
        {
            get { return hex; }
            set { hex = value; }
        }
        public string CMYK
        {
            get { return cmyk; }
            set { cmyk = value; }
        }
        public string RGB
        {
            get { return rgb; }
            set { rgb = value; }
        }
        public string URL
        {
            get { return url; }
            set { url = value; }
        }
        public string THSV
        {
            get { return thsv; }
            set { thsv = value; }
        }
        public void Conversion()
        {
            string rgb = RGB;
            Color newColor = new Color();
            byte r = 0, g = 0, b = 0;
            r = Convert.ToByte(rgb.Split(',')[0]);
            g = Convert.ToByte(rgb.Split(',')[1]);
            b = Convert.ToByte(rgb.Split(',')[2]);
            newColor = Color.FromArgb(255, r, g, b);
            rgbcolor = newColor;
        }
    }
}
