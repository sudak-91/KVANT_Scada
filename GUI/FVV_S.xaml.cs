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
    public partial class FVV_S : Window
    {
       
       private  Installing_Tags Tag;
       private SolidColorBrush on, off;
        public FVV_S(Installing_Tags Tags)
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

        private void FVV_S_Command_automode_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_FVV_S_automode())
            {
                Tag.FVV_S_auto_mode_on(false);
            }
            else
            {
                Tag.FVV_S_auto_mode_on(true);

            }

        }

        private void FVV_S_Command_Service_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_FVV_S_service())
            {
                Tag.FVV_S_service_mode_on(false);
            }
            else
            {
                Tag.FVV_S_service_mode_on(true);

            }

        }

        private void FVV_S_Command_Open_Click(object sender, RoutedEventArgs e)
        {
            Tag.FVV_S_open(true);
        }

        private void FVV_S_Command_Closed_Click(object sender, RoutedEventArgs e)
        {
            Tag.FVV_S_open(false); 
        }

        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.get_FVV_S_automode())
            {
                FVV_S_Status_Automat_on.Fill = on;
                FVV_S_Command_Closed.IsEnabled = false;
                FVV_S_Command_Open.IsEnabled = false;
                FVV_S_Command_automode.Background = on;


            }
            else
            {
                FVV_S_Status_Automat_on.Fill = off;
                FVV_S_Command_Closed.IsEnabled = true;
                FVV_S_Command_Open.IsEnabled = true;
                FVV_S_Command_automode.Background = null;
            }


            if (Tag.get_FVV_S_closed())
            {
                FVV_S_Status_Closed.Fill = on;

            }
            else
            {
                FVV_S_Status_Closed.Fill = off;
            }

            if(Tag.get_FVV_S_opened())
            {
                FVV_S_Status_Opened.Fill = on;
            }
            else
            {
                FVV_S_Status_Opened.Fill = off;
            }

            if(Tag.get_FVV_S_blocked())
            {
                FVV_S_Status_Blocked.Fill = off;
            }
            else
            {
                FVV_S_Status_Blocked.Fill = null;
            }




            
        }


    }
}
