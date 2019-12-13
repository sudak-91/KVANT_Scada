using KVANT_Scada.Data;
using KVANT_Scada.UDT;
using S7.Net;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private SolidColorBrush on, off, neutral;
        private GUI.SHV wSHV;
        private GUI.BAV_3 wBAV_3;
        private GUI.CPV wCPV;
        private GUI.FVV_S wFVV_S;
        private GUI.FVV_B wFVV_B;
        private GUI.Crio wCrio;
        private GUI.FVP wFVP;
        private RotateTransform rt;
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
            on = new SolidColorBrush(Color.FromRgb( 0, 255, 0));
            off = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb( 221, 221, 221));

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new System.TimeSpan(0,0,1);
            dispatcherTimer.Tick += new EventHandler(Count);
            dispatcherTimer.Start();

            rt = new RotateTransform();
          






        }
        public  void Count(object sender, EventArgs e)

        {
            Tags.Update_Read();
            Main_pressure.Text = Tags.get_cam_pressure().ToString("E1") + "mbar";
            Crio_pressure.Text = Tags.get_crio_pressure().ToString("E1")+ "mbar";
            Crio_temperature.Text = Tags.get_crio_temperature().ToString("F1")+"K";

            if(Tags.get_CPV_opened())
            {
                CPV_opened.Fill = on;
            }
            else
            {
                CPV_opened.Fill = neutral;
            }

            if(Tags.get_FVV_S_opened())
            {
                FVV_S_opened.Fill = on;
            }
            else
            {
                FVV_S_opened.Fill = neutral;
            }
            if(Tags.get_FVV_B_opened())
            {
                FVV_B_opened.Fill = on;
            }
            else
            {
                FVV_B_opened.Fill = neutral;
            }
            if(Tags.get_BAV_3_opened())
            {
                BAV_3_opened.Fill = on;
            }
            else
            {
                BAV_3_opened.Fill = neutral;
            }
            if(Tags.get_SHV_opened())
            {
                SHV_opened.Fill = on;
            }
            else
            {
                SHV_opened.Fill = neutral;
            }
            if(Tags.get_Crio_Turn_on())
            {
                Crio_Turn_On.Fill = on;
            }
            else
            {
                Crio_Turn_On.Fill = neutral;
            }


            //rt.Angle += 25.0;
            //Circle.RenderTransform = rt;



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

        private void Stage_2_Open_Cam_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(3);
        }

        private void Stage_2_Open_Cam_Copy_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(5);
        }

        private void Stage_2_Open_Cam_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(4);
        }

        private void Stage_0_Crio_Start_Click(object sender, RoutedEventArgs e)
        {
            int a = 1;
            Tags.Tech_Cam_PRocess(a);
        }

        private void Stage_1_Prepare_Cam_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(2);

        }
    }
}
