using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Procss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> list = new List<string>();
        string path = "note.txt";
        public MainWindow()
        {
            InitializeComponent();
            ReadAsync();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            text1.Text += $"{text2.Text}\n";
            list.Add(text2.Text);
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(text1.Text);
            }
        }
        public async Task ReadAsync()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                text1.Text += text;
            }
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            string del = text2.Text;
            list.Remove(del);
            if (text2.Text==del)
            {
                text2.Text = "";
            }

        }
    }
}
