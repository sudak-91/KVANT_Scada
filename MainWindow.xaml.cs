using KVANT_Scada.Data;
using KVANT_Scada.UDT;
using S7.Net;
using System;
using System.Windows;
using System.Windows.Threading;
using UDT_DLL;



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
        private Real_Tag_Entitys real_Tag_Entitys;
        private GUI.SHV wSHV;
        private GUI.BAV_3 wBAV_3;
        private GUI.CPV wCPV;
        private GUI.FVV_S wFVV_S;
        private GUI.FVV_B wFVV_B;
        private GUI.Crio wCrio;
        private GUI.FVP wFVP;
        public MainWindow()
        {
            this.Topmost = true;
            InitializeComponent();
            real_Tag_Entitys = new Real_Tag_Entitys();
           
            plc = new Plc (CpuType.S71500, "192.168.1.122", 0, 1);
            plc.Open();
            if (plc.IsConnected)
            {
                Tags = new Installing_Tags(plc, real_Tag_Entitys);
                
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

        private void Crio_pump_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wCrio = new GUI.Crio(Tags);
            wCrio.ShowDialog();
            
        }

        private void BAV_3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wBAV_3 = new GUI.BAV_3(Tags);
            wBAV_3.ShowDialog();

        }

        private void CPV_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wCPV = new GUI.CPV(Tags);
            wCPV.ShowDialog();

        }

        private void FVV_S_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wFVV_S = new GUI.FVV_S(Tags);
            wFVV_S.ShowDialog();

        }

        private void FVV_B_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wFVV_B = new GUI.FVV_B(Tags);
            wFVV_B.ShowDialog();

        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wSHV = new GUI.SHV(Tags);
            wSHV.ShowDialog();
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wFVP = new GUI.FVP(Tags);
            wFVP.ShowDialog();

        }

        private void Stage_0_Crio_Start_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(1);
        }
    }
}
