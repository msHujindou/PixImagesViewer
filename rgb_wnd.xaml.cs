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
    /// Interaction logic for rgb_wind.xaml
    /// </summary>
    public partial class rgb_wind : Window
    {
        public rgb_wind()
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
                this.img_seg.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].seg_name));
            }
        }

        class normal_rgb
        {
            public string base_name { get; set; }
            public string seg_name { get; set; }
            public string folder { get; set; }
            public string judge { get; set; }
        }

        List<normal_rgb> lst = new List<normal_rgb>();
        int current_idx = -1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<normal_rgb> tmpres = null;
                try
                {
                    string fileName = "normal_rgb.json";
                    string jsonString = File.ReadAllText(fileName);
                    tmpres = JsonSerializer.Deserialize<List<normal_rgb>>(jsonString);
                }
                catch
                {

                }

                var folders = Directory.GetDirectories("normal_rgb");
                foreach (var f in folders)
                {
                    var tmp = new normal_rgb();
                    tmp.folder = f;
                    var files = Directory.GetFiles(f);
                    foreach (var tmpf in files)
                    {
                        if (tmpf.ToLower().Contains("seg"))
                        {
                            tmp.seg_name = tmpf;
                        }
                        else
                        {
                            tmp.base_name = tmpf;
                        }
                    }
                    var tmpjd = tmpres?.FirstOrDefault(r => r.folder == tmp.folder && r.base_name == tmp.base_name);
                    tmp.judge = tmpjd?.judge;
                    lst.Add(tmp);
                }
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
                this.img_seg.Source = new BitmapImage(new Uri("C:\\Users\\Admin\\Desktop\\pysrcs\\piximage\\" + lst[current_idx].seg_name));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("请问您是否要保存刚刚标注的信息到 normal_rgb.json , 如果此文件已经存在 , 会覆盖掉它。", "退出前是否保存标注文件", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                string fileName = "normal_rgb.json";
                string jsonString = JsonSerializer.Serialize(lst);
                File.WriteAllText(fileName, jsonString);
            }
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
