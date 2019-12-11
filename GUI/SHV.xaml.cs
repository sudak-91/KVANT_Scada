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
    /// Логика взаимодействия для SHV.xaml
    /// </summary>
    public partial class SHV : Window
    {
       
       private  Installing_Tags Tag;
       private SolidColorBrush on, off;
        public SHV(Installing_Tags Tags)
        {
           
                InitializeComponent();
            on = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            off = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            Tag = Tags;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Update_GUI);
            dispatcherTimer.Start();
           

        }

        private void SHV_Command_automode_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_SHV_automode())
            {
                Tag.SHV_auto_mode_on(false);
            }else
            {
                Tag.SHV_auto_mode_on(true);
                

            }

        }

        private void SHV_Command_Service_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_SHV_service())
            {
                Tag.SHV_service_mode_on(false);
            }
            else
            {
                Tag.SHV_service_mode_on(true);

            }

        }

        private void SHV_Command_Open_Click(object sender, RoutedEventArgs e)
        {
            Tag.SHV_open(true);
        }

        private void SHV_Command_Closed_Click(object sender, RoutedEventArgs e)
        {
            Tag.SHV_open(false);
        }

        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.get_SHV_automode())
            {
                SHV_Status_Automat_on.Fill = on;
                SHV_Command_Closed.IsEnabled = false;
                SHV_Command_Open.IsEnabled = false;
                SHV_Command_automode.Background = on;


            }
            else
            {
                SHV_Status_Automat_on.Fill = off;
                SHV_Command_Closed.IsEnabled = true;
                SHV_Command_Open.IsEnabled = true;
                SHV_Command_automode.Background = null;
            }


            if (Tag.get_SHV_closed())
            {
                SHV_Status_Closed.Fill = on;

            }
            else
            {
                SHV_Status_Closed.Fill = off;
            }

            if(Tag.get_SHV_opened())
            {
                SHV_Status_Opened.Fill = on;
            }
            else
            {
                SHV_Status_Opened.Fill = off;
            }

            if(Tag.get_SHV_blocked())
            {
                SHV_Status_Blocked.Fill = off;
            }
            else
            {
                SHV_Status_Blocked.Fill = null;
            }




            
        }


    }
}
