using System;
using System.Collections.Generic;
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
using System.Drawing;
using System.IO;
using Microsoft.Win32;



namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            


        }
        /* THIS IS FOR THE GET FILES IN DIRECTORY WITH 1 SAME EXTENSION (FILTER) */
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Only get files that begin with the letter "c."
                this.Title = "Clicked";
                string[] dirs = Directory.GetFiles(@"C:\Users\danielnguyen\Desktop", "*.png");
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                   // MessageBox.Show(dir);  // pop up messages
                    textBox.Text += dir +  "\n"; //displays text in the Textbox
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }


        /* THIS IS FOR THE GET FILES IN DIRECTORY WITH MULTIPLE DIFFERENT EXTENSIONS (FILTERS) */

        private void bOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
        
            DirectoryInfo folder = new DirectoryInfo(@"C:\Users\danielnguyen\Desktop");

            FileInfo[] fiArr = folder.GetFiles("*.*");

            var files = from a in fiArr
                        where a.ToString().EndsWith(".txt") || a.ToString().EndsWith(".png")
                        select a;

            foreach (var filename in files)
            {
                text23.Text = text23.Text + filename + "'\n'";
            }

        }

        /* THIS IS FOR THE PICTURE, IMPORT PICTURE USING THE OPEN FILE DIALOG TO LOCATE PICTURE */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog f = new OpenFileDialog();
            f.Title = "Select pix";
            f.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +"JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +"Portable Network Graphic (*.png)|*.png";
            if (f.ShowDialog() == true)
            {
                pictureBox.Source = new BitmapImage(new Uri(f.FileName));
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string[] file1 = File.ReadAllLines(@"C:\Users\danielnguyen\Desktop\text1.txt"); // read all the lines in the text files
            string[] file2 = File.ReadAllLines(@"C:\Users\danielnguyen\Desktop\text2.txt");
            // create a text3 file
            using (StreamWriter writer = File.CreateText(@"C:\Users\danielnguyen\Desktop\text3.txt"))
            {
                int lineNum = 0; // initialize, starting at lineNum 0
                while(lineNum < file1.Length || lineNum < file2.Length) // as long line is not greater than the length of file 1 or file 3
                {
                    if (lineNum < file1.Length)
                    {
                        mergeBox.Text = (file1[lineNum]); // show in the text box
                        writer.WriteLine(file1[lineNum]); // write to the text3 file 
                    }
                    if (lineNum < file2.Length)
                    {
                        mergeBox.Text = (file2[lineNum]);// show in the text box
                        writer.WriteLine(file2[lineNum]);// write to the text3 file 
                    }
                    lineNum++; // go to next line?
                }
            }
        }

       
    }
}
