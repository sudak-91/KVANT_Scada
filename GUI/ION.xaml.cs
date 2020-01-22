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
using KVANT_Scada.Data;

namespace KVANT_Scada.GUI
{
    /// <summary>
    /// Логика взаимодействия для SHV.xaml
    /// </summary>
    public partial class ION : Window
    {

        private Installing_Tags Tag;
        private SolidColorBrush on, off;
        private Log_Sub_System.Log_Sub_System Loger;
        private string name;


        public ION(Installing_Tags Tags, Log_Sub_System.Log_Sub_System root,string sName)
        {

            InitializeComponent();
            on = new SolidColorBrush(Color.FromArgb(100, 0, 255, 0));
            off = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
            Tag = Tags;
            this.Loger = root;
            name = sName;
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Update_GUI);
            dispatcherTimer.Start();


        }

        private void Ion_Command_Start_Click(object sender, RoutedEventArgs e)
        {
            Tag.setIONManStart(true);
            Loger.Add_to_LOG(name, "Запуск ИИ");

        }

        private void Ion_Command_Stop_Click(object sender, RoutedEventArgs e)
        {
            Tag.setIONManStop(true);
            Loger.Add_to_LOG(name, "Остановка ИИ");
        }

        private void Ion_Command_Reset_Click(object sender, RoutedEventArgs e)
        {
            Tag.setIONReset(true);
        }

        private void Ion_Command_automode_Click(object sender, RoutedEventArgs e)
        {
            if (Tag.getIONAuto())
            {
                Tag.setIONAutoMode(false);
            }
            else
            {
                Tag.setIONAutoMode(true);
            }
        }

        private void Save_K_Click(object sender, RoutedEventArgs e)
        {
            
            Tag.set_K_RRG((Convert.ToDouble(K_RRG__1.Text.Replace(".",","))), (Convert.ToDouble(K_RRG_2.Text.Replace(".", ","))), (Convert.ToDouble(K_RRG_3.Text.Replace(".", ","))));
        }

        private void PID_auto_Click(object sender, RoutedEventArgs e)
        {
            Tag.set_MODE_PID((double)3.0);
            Tag.set_SP_PID_RRG(Convert.ToDouble(RRG_SP.Text.Replace(".",",")));
        }

        private void Manual_RRG_Click(object sender, RoutedEventArgs e)
        {
            Tag.set_MODE_PID((double)4.0);
            Tag.set_ManVal_PID_RRG(Convert.ToDouble(RRG_ManVal.Text.Replace(".",",")));
           
        }

        public void Update_GUI(object sender, EventArgs e)
        {
            if (Tag.GetIonAutoMode())
            {
                Ion_Status_Automat_on.Fill = on;




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

                if (Tag.GetIonTurnOn())
                {
                    Ion_Status_Turn_On.Fill = on;
                }
                else
                {
                    Ion_Status_Turn_On.Fill = off;
                }

                if (Tag.GetIonFailure())
                {
                    Ion_Status_Failure.Fill = off;
                }
                else
                {
                    Ion_Status_Failure.Fill = null;
                }
                FB_RRG_1.Text = Tag.get_FB_RRG_1().ToString();
                FB_RRG_2.Text = Tag.get_FB_RRG_2().ToString();
                FB_RRG_3.Text = Tag.get_FB_RRG_3().ToString();






            }


        }
    }
}
