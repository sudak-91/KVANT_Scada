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
    public partial class ION : Window
    {
       
       private  Installing_Tags Tag;
       private SolidColorBrush on, off;
        public ION(Installing_Tags Tags)
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

        private void Ion_Command_Start_Click(object sender, RoutedEventArgs e)
        {
            Tag.setIONManStart(true);
        }

        private void Ion_Command_Stop_Click(object sender, RoutedEventArgs e)
        {
            Tag.setIONManStop(true);
        }

        private void Ion_Command_Reset_Click(object sender, RoutedEventArgs e)
        {
            Tag.setIONReset(true);
        }

        private void Ion_Command_automode_Click(object sender, RoutedEventArgs e)
        {
            if(Tag.getIONAuto())
            {
                Tag.setIONAutoMode(false);
            }
            else
            {
                Tag.setIONAutoMode(true);
            }
        }

        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.GetIonAutoMode())
            {
                Ion_Status_Automat_on.Fill= on;
               
               


            }
            else
            {
                Ion_Status_Automat_on.Fill = off;
              


            if (Tag.GetIonPowerOn())
            {
                Ion_Status_Power_On.Fill = on;

            }
            else
            {
                    Ion_Status_Power_On.Fill = off;
            }

            if(Tag.GetIonTurnOn())
            {
                Ion_Status_Turn_On.Fill = on;
            }
            else
            {
                    Ion_Status_Turn_On.Fill = off;
            }

            if(Tag.GetIonFailure())
            {
                Ion_Status_Failure.Fill = off;
            }
            else
            {
                    Ion_Status_Failure.Fill = null;
            }




            
        }


    }
}
