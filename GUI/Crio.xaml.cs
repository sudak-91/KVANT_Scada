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
    /// Логика взаимодействия для Crio.xaml
    /// </summary>
    public partial class Crio : Window
    {
        private Installing_Tags Tag;
        private SolidColorBrush on, off,neutral;

        private void Crio_AutoModeSwitchOn_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_Crio_AutoMode())
            {
                Tag.Crio_auto_mode_on(false);
            }
            else
            {
                Tag.Crio_auto_mode_on(true);


            }
        }

        private void Crio_Start_Click(object sender, RoutedEventArgs e)
        {
            Tag.Crio_manual_start(true);
        }

        private void Crio_Stop_Click(object sender, RoutedEventArgs e)
        {
            Tag.Crio_manual_start(false);
        }

        public Crio(Installing_Tags Tags)
        {
            InitializeComponent();
            on = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            off = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            neutral = new SolidColorBrush(Color.FromArgb(100, 221, 221, 221));
            Tag = Tags;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Update_GUI);
            dispatcherTimer.Start();

        }
        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.get_Crio_AutoMode())
            {
                Crio_AutoMode.Fill = on;
                Crio_Start.IsEnabled = false;
                Crio_Stop.IsEnabled = false;
                Crio_AutoModeSwitchOn.Background = on;


            }
            else
            {
                Crio_AutoMode.Fill = off;
                Crio_Start.IsEnabled = true;
                Crio_Stop.IsEnabled = true;
                Crio_AutoModeSwitchOn.Background = neutral;
            }


            if (Tag.get_Crio_Blocked())
            {
                Crio_Blocked.Fill = on;

            }
            else
            {
                Crio_Blocked.Fill = off;
            }

            if (Tag.get_Crio_Power_On())
            {
                Crio_Power_On.Fill = on;
            }
            else
            {
                Crio_Power_On.Fill = off;
            }

            if (Tag.get_Crio_Turn_on())
            {
                Crio_Turn_on.Fill = on;
            }
            else
            {
                Crio_Turn_on.Fill = neutral;
            }
            if (Tag.get_Crio_Error())
            {
                Crio_Error.Fill = off;
            }
            else
            {
                Crio_Error.Fill = on;
            }





        }


    }

    
}
