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

namespace PixImagesViewer
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

        private void open_rgb_wnd(object sender, RoutedEventArgs e)
        {
            var wnd = new rgb_wind();
            wnd.ShowDialog();
        }

        private void open_rgbd_wnd(object sender, RoutedEventArgs e)
        {
            var wnd = new rgbd_wind();
            wnd.ShowDialog();
        }

        private void open_abnormals_wnd(object sender, RoutedEventArgs e)
        {
            //var wnd = new abnormals_wind();
            //wnd.Show();
        }
    }
}
