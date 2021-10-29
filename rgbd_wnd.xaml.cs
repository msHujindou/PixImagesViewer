using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PixImagesViewer
{
    /// <summary>
    /// Interaction logic for rgbd_wind.xaml
    /// </summary>
    public partial class rgbd_wind : Window
    {
        public rgbd_wind()
        {
            InitializeComponent();
        }

        private void view_next(object sender, MouseButtonEventArgs e)
        {
            if (current_idx < lst.Count - 1)
            {
                current_idx++;
                if (r1.Content.Equals(lst[current_idx].judge))
                {
                    r1.IsChecked = true;
                }
                else
                {
                    r1.IsChecked = false;
                }
                if (r2.Content.Equals(lst[current_idx].judge))
                {
                    r2.IsChecked = true;
                }
                else
                {
                    r2.IsChecked = false;
                }
                if (r3.Content.Equals(lst[current_idx].judge))
                {
                    r3.IsChecked = true;
                }
                else
                {
                    r3.IsChecked = false;
                }
                this.img_base.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].base_name));
                this.img_depth.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].depth_name));
                this.img_matte.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].matte_name));
            }
        }

        class normal_rgb
        {
            public string base_name { get; set; }
            public string depth_name { get; set; }
            public string matte_name { get; set; }
            public string folder { get; set; }
            public string judge { get; set; }
        }

        List<normal_rgb> lst = new List<normal_rgb>();
        int current_idx = -1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var folders = Directory.GetDirectories("normal_rgbd");
                foreach (var f in folders)
                {
                    var tmp = new normal_rgb();
                    tmp.folder = f;
                    var files = Directory.GetFiles(f);
                    foreach (var tmpf in files)
                    {
                        if (tmpf.ToLower().Contains("dep"))
                        {
                            tmp.depth_name = tmpf;
                        }
                        else if (tmpf.ToLower().Contains("mat"))
                        {
                            tmp.matte_name = tmpf;
                        }
                        else
                        {
                            tmp.base_name = tmpf;
                        }
                    }
                    lst.Add(tmp);
                }
                Console.WriteLine(folders);
            }
            catch
            {

            }
        }

        private void goto_previous(object sender, RoutedEventArgs e)
        {
            if (current_idx > 0)
            {
                current_idx--;
                if (r1.Content.Equals(lst[current_idx].judge))
                {
                    r1.IsChecked = true;
                }
                else
                {
                    r1.IsChecked = false;
                }
                if (r2.Content.Equals(lst[current_idx].judge))
                {
                    r2.IsChecked = true;
                }
                else
                {
                    r2.IsChecked = false;
                }
                if (r3.Content.Equals(lst[current_idx].judge))
                {
                    r3.IsChecked = true;
                }
                else
                {
                    r3.IsChecked = false;
                }
                this.img_base.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].base_name));
                this.img_depth.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].depth_name));
                this.img_matte.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].matte_name));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = "normal_rgb.json";
            string jsonString = JsonSerializer.Serialize(lst);
            File.WriteAllText(fileName, jsonString);
        }

        private void set_judge(object sender, RoutedEventArgs e)
        {
            if (current_idx < 0)
                return;
            var rd = sender as RadioButton;
            if (rd != null)
            {
                lst[current_idx].judge = rd.Content.ToString();
            }
        }
    }
}
