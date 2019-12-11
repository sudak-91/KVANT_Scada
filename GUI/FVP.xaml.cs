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
    /// Логика взаимодействия для FVP.xaml
    /// </summary>
    public partial class FVP : Window
    {
        private Installing_Tags Tag;
        private SolidColorBrush on, off, neutral;

     








        private void FVP_Start_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Tag.FVP_Manual_Start(true);
        }

        private void FVP_Stop_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Tag.FVP_Manual_Start(false);
        }

        private void FVP_Remote1_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if (Tag.get_FVP_Remote())
            {
                Tag.FVP_remote(false);
            }
            else
            {
                Tag.FVP_remote(true);


            }

        }

        private void FVP_AutoMode_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            if (Tag.get_FVP_AutoMode())
            {
                Tag.FVP_Auto_mode(false);
            }
            else
            {
                Tag.FVP_Auto_mode(true);


            }

        }

        public FVP(Installing_Tags Tags)
        {
            InitializeComponent();
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
            if (Tag.get_FVP_AutoMode())
            {
                FVP_Auto_Mode.Fill = on;
                FVP_Start.IsEnabled = false;
                FVP_Stop.IsEnabled = false;
                FVP_AutoMode.Background = on;


            }
            else
            {
                FVP_Auto_Mode.Fill = off;
                FVP_Start.IsEnabled = true;
                FVP_Stop.IsEnabled = true;
                FVP_AutoMode.Background = neutral;
            }


            if (Tag.get_FVP_Block())
            {
                FVP_Block.Fill = off;

            }
            else
            {
                FVP_Block.Fill = neutral;
            }

            if (Tag.get_FVP_Power_On())
            {
                FVP_Power_On.Fill = on;
            }
            else
            {
                FVP_Power_On.Fill = off;
            }

            if (Tag.get_FVP_Turn_On())
            {
                FVP_Turn_On.Fill = on;
            }
            else
            {
                FVP_Turn_On.Fill = neutral;
            }
            if (Tag.get_FVP_Remote())
            {
                FVP_Remote.Fill = on;
            }
            else
            {
                FVP_Remote.Fill = neutral;
            }





        }
    }
}
