using KVANT_Scada.UDT;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KVANT_Scada.GUI
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Installing_Tags tags;
        private SolidColorBrush on, off;
        public Window1(Installing_Tags installing_Tags)
        {
            InitializeComponent();
            tags = installing_Tags;
            on = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            off = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Update_GUI);
            dispatcherTimer.Start();
        }

        private void Shield_Auto_On_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Shield_Auto(true);
        }

        private void Shield_Auto_OFF_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Shield_Auto(false);
        }

        private void Shield_Open_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Shield_open(true);
        }

        private void Shield_close_Click(object sender, RoutedEventArgs e)
        {
            tags.set_Shield_close(true);
        }

        private void Update_GUI(object sender, EventArgs e)
        {
            if (tags.get_Shield_Auto())
            {
                Shield_Auto_ind.Fill = on;
            }
            else
            {
                Shield_Auto_ind.Fill = off;
            }
        }


    }
}
