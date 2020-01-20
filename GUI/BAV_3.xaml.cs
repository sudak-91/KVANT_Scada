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
using KVANT_Scada.Log_Sub_System;

namespace KVANT_Scada.GUI
{
    /// <summary>
    /// Логика взаимодействия для SHV.xaml
    /// </summary>
    public partial class BAV_3 : Window
    {
       
       private  Installing_Tags Tag;
       private SolidColorBrush on, off;
        
        
        public BAV_3(Installing_Tags Tags)
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

        private void BAV_3_Command_automode_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_BAV_3_automode())
            {
                Tag.BAV_3_auto_mode_on(false);
            }
            else
            {
                Tag.BAV_3_auto_mode_on(true);

            }

        }

        private void BAV_3_Command_Service_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.get_BAV_3_service())
            {
                Tag.BAV_3_service_mode_on(false);
            }
            else
            {
                Tag.BAV_3_service_mode_on(true);

            }

        }

        private void BAV_3_Command_Open_Click(object sender, RoutedEventArgs e)
        {
            Tag.BAV_3_open(true);
            
        }

        private void BAV_3_Command_Closed_Click(object sender, RoutedEventArgs e)
        {
            Tag.BAV_3_open(false); 
        }

        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.get_BAV_3_automode())
            {
                BAV_3_Status_Automat_on.Fill = on;
                BAV_3_Command_Closed.IsEnabled = false;
                BAV_3_Command_Open.IsEnabled = false;
                BAV_3_Command_automode.Background = on;


            }
            else
            {
                BAV_3_Status_Automat_on.Fill = off;
                BAV_3_Command_Closed.IsEnabled = true;
                BAV_3_Command_Open.IsEnabled = true;
                BAV_3_Command_automode.Background = null;
            }


            if (Tag.get_BAV_3_closed())
            {
                BAV_3_Status_Closed.Fill = on;

            }
            else
            {
                BAV_3_Status_Closed.Fill = off;
            }

            if(Tag.get_BAV_3_opened())
            {
                BAV_3_Status_Opened.Fill = on;
            }
            else
            {
                BAV_3_Status_Opened.Fill = off;
            }

            if(Tag.get_BAV_3_blocked())
            {
                BAV_3_Status_Blocked.Fill = off;
            }
            else
            {
                BAV_3_Status_Blocked.Fill = null;
            }




            
        }


    }
}
