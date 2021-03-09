using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3_Pantone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Pantone> Pantones = new List<Pantone>();
        public MainWindow()
        {
            ReadData();
            
            this.DataContext = Pantones;
            InitializeComponent();
            this.PantonesComboBox.SelectedIndex=1;
        }
        private static Color Conversion (string rgb)
        {
            Color newColor = new Color();
            byte r=0, g=0, b = 0;
            r = Convert.ToByte(rgb.Split(',')[0]);
            g = Convert.ToByte(rgb.Split(',')[1]);
            b = Convert.ToByte(rgb.Split(',')[2]);
            newColor = Color.FromArgb(255, r, g, b);
            return newColor;
        }
        public static void ReadData()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("PantoneU"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                       // Console.WriteLine(line.);
                        int tempLenght = line.Split('|').Length;
                        string[] temp = new string[tempLenght];
                        temp = line.Split('|');
                        int temp3Lenght = temp[3].Split(';').Length;
                        string[] temp3 = new string[temp3Lenght];
                        temp3 = temp[3].Split(';');
                        string pantone = temp[1];
                        string url = temp[2];
                        //Dekodowanie kolorow
                        //hex - line.Split('|')[3].Split(',')[1]
                        string hex = temp3[1].Split('=')[1];
                        //RGB - line.Split('|')[3].Split(',')[2]
                        string rgb = temp3[2].Split('=')[1];
                        //CMYK - line.Split('|')[3].Split(',')[3]
                        string cmyk = temp3[3].Split('=')[1];
                        //THSV - line.Split('|')[3].Split(',')[t]
                        string thsv = temp3[4].Split('=')[1];
                        Pantone newPantone = new Pantone() { Name = pantone, URL = url, Hex = hex, RGB = rgb, CMYK = cmyk, THSV = thsv };
                        newPantone.Conversion();    
                        Pantones.Add(newPantone);
                       
                    }
                }
                //foreach (var item in Pantones)
                //{
                //    Console.WriteLine(item.Name);
                //}
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
   
   

}
