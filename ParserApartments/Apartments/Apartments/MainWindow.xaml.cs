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

namespace Apartments
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            var page = new DownloadPage();
            foreach (var i in page.Bucha)
            {
                Box.Text = i.ToString();
            }
            
            
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "\n Произошла сортировка";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "\n Данные сохранены в EXEL файл";
        }
    }
}
