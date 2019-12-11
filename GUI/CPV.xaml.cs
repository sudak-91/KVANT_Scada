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
    public partial class CPV : Window
    {
       
       private  Installing_Tags Tag;
       private SolidColorBrush on, off;
        public CPV(Installing_Tags Tags)
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

        private void CPV_Command_automode_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_CPV_automode())
            {
                Tag.CPV_auto_mode_on(false);
            }
            else
            {
                Tag.CPV_auto_mode_on(true);

            }

        }

        private void CPV_Command_Service_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_CPV_service())
            {
                Tag.CPV_service_mode_on(false);
            }
            else
            {
                Tag.CPV_service_mode_on(true);

            }

        }

        private void CPV_Command_Open_Click(object sender, RoutedEventArgs e)
        {
            Tag.CPV_open(true);
        }

        private void CPV_Command_Closed_Click(object sender, RoutedEventArgs e)
        {
            Tag.CPV_open(false); 
        }

        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.get_CPV_automode())
            {
                CPV_Status_Automat_on.Fill = on;
                CPV_Command_Closed.IsEnabled = false;
                CPV_Command_Open.IsEnabled = false;
                CPV_Command_automode.Background = on;


            }
            else
            {
                CPV_Status_Automat_on.Fill = off;
                CPV_Command_Closed.IsEnabled = true;
                CPV_Command_Open.IsEnabled = true;
                CPV_Command_automode.Background = null;
            }


            if (Tag.get_CPV_closed())
            {
                CPV_Status_Closed.Fill = on;

            }
            else
            {
                CPV_Status_Closed.Fill = off;
            }

            if(Tag.get_CPV_opened())
            {
                CPV_Status_Opened.Fill = on;
            }
            else
            {
                CPV_Status_Opened.Fill = off;
            }

            if(Tag.get_CPV_blocked())
            {
                CPV_Status_Blocked.Fill = off;
            }
            else
            {
                CPV_Status_Blocked.Fill = null;
            }




            
        }


    }
}
