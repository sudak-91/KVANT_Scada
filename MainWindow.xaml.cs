using KVANT_Scada.Config;
using KVANT_Scada.UDT;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace KVANT_Scada
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// '

    /// 
   
    public partial class MainWindow : Window
    {
        private Plc plc;
        private Installing_Tags Tags;
        public MainWindow()
        {
            InitializeComponent();
            plc = new Plc (CpuType.S71500, "192.168.1.122", 0, 1);
            plc.Open();
            if (plc.IsConnected)
            {
                Tags = new Installing_Tags(plc);
                
            }
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new System.TimeSpan(0,0,1);
            dispatcherTimer.Tick += new EventHandler(Count);
            dispatcherTimer.Start();


            


        }
        public  void Count(object sender, EventArgs e)

        {
            Tags.Update_Read();
            Main_pressure.Text = Tags.get_cam_pressure().ToString("E1") + "mbar";
            Crio_pressure.Text = Tags.get_crio_pressure().ToString("E1")+ "mbar";
            Crio_temperature.Text = Tags.get_crio_temperature().ToString("F1")+"K";






        }
    }
}
