using KVANT_Scada.Config;
using KVANT_Scada.Data;
using KVANT_Scada.UDT;
using S7.Net;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private Real_Tag_Entitys real_Tag_Entitys;
        private SolidColorBrush on, off, neutral;
        private GUI.SHV wSHV;
        private GUI.BAV_3 wBAV_3;
        private GUI.CPV wCPV;
        private GUI.FVV_S wFVV_S;
        private GUI.FVV_B wFVV_B;
        private GUI.Crio wCrio;
        private GUI.FVP wFVP;
        private GUI.ION wIon;
        private RotateTransform rt;
        private udtIONWrite udtIONWrite;
        public int userPolicy = 0;
        public static users User;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;


        public MainWindow()
        {
           
            this.Topmost = true;
            InitializeComponent();

            real_Tag_Entitys = new Real_Tag_Entitys();
            
           
            plc = new Plc (CpuType.S71500, "192.168.1.122", 0, 1);
            on = new SolidColorBrush(Color.FromRgb( 0, 255, 0));
            off = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb( 221, 221, 221));
            
      

            dispatcherTimer = new DispatcherTimer();
           

            rt = new RotateTransform();
          






        }
        public void ConnectToPlc()
        {
            plc.Open();
            if (plc.IsConnected)
            {
                Tags = new Installing_Tags(plc, real_Tag_Entitys);
                dispatcherTimer.Interval = new System.TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Count);
                dispatcherTimer.Start();

            }
            else
            {
                
            }

        }
        public  void Count(object sender, EventArgs e)

        {
            Tags.Update_Read();
            Main_pressure.Text = Tags.get_cam_pressure().ToString("E1") + "mbar";
            Crio_pressure.Text = Tags.get_crio_pressure().ToString("E1")+ "mbar";
            Crio_temperature.Text = Tags.get_crio_temperature().ToString("F1")+"K";
            txtbox_FV_pressure.Text = Tags.get_FV_pressure().ToString("E1") + "mbar";
            Pne_press.Text = Tags.get_Pne_Press().ToString("F1") + "bar";
            Anod_I.Text = Tags.GetAnodI();
            Anod_U.Text = Tags.GetAnodU();
            Anod_P.Text = Tags.GetAnodP();
            Heat_I.Text = Tags.GetHeatI();
            Heat_U.Text = Tags.GetHeatU();
            Heat_P.Text = Tags.GetHeatP();
            if(User.Policy!=0)
            {
                control_toolbar.IsEnabled = true;
            }else
            {
                control_toolbar.IsEnabled = false;
            }
            
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

            if(Tags.get_Process_compite())
            {
                Process_complite.Fill = on;
            }
            else
            {
                Process_complite.Fill = neutral;
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

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            ION_Screen.Visibility = Visibility.Visible;
            Heat.Visibility = Visibility.Hidden;
            Tags.GetInitValue();
            Anod_I_SP.Text = Tags.GetAnodISp();
            Anod_U_SP.Text = Tags.GetAnodUSp();
            Anod_P_SP.Text = Tags.GetAnodPSp();
            Heat_I_SP.Text = Tags.GetHeatISp();
            Heat_U_SP.Text = Tags.GetHeatUSp();
            Heat_P_SP.Text = Tags.GetHeatPSp();

        }

        private void Anod_I_SP_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            
        }

        private void TextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void btnMainScreen_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            ION_Screen.Visibility = Visibility.Hidden;
            Heat.Visibility = Visibility.Hidden;
        }

 

        private void Anod_I_SP_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Rest_Cliker_Click(object sender, RoutedEventArgs e)
        {
            //double k = Convert.ToDouble(Anod_I_SP.Text.ToString());
            string i =  Anod_I_SP.Text.Replace('.', ',');
            string u =  Anod_U_SP.Text.Replace('.', ',');
            string p = Anod_P_SP.Text.Replace('.', ',');
            string hi = Heat_I_SP.Text.Replace('.', ',');
            string hu = Heat_U_SP.Text.Replace('.', ',');
            string hp = Heat_P_SP.Text.Replace('.', ',');

            double di = Convert.ToDouble(i);
            double du = Convert.ToDouble(u);
            double dp = Convert.ToDouble(p);
            double dhi = Convert.ToDouble(hi);
            double dhu = Convert.ToDouble(hu);
            double dhp = Convert.ToDouble(hp);
            
            Tags.WriteToDbISp(di,du,dp,dhi,dhu,dhp);
           
        }

        private void Screens_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
          
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Main_Screen_Initialized(object sender, EventArgs e)
        {
            
        }

        private void Main_Screen_Loaded(object sender, RoutedEventArgs e)
        {
            GUI.auth.auth_form af = new GUI.auth.auth_form(real_Tag_Entitys,this);
            af.Topmost = true;
            af.Show();
           


        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool a = (bool)Heat_open_cam.IsChecked;
            Tags.set_Cam_Heat_Open(a);
        }

        private void Ion_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wIon = new GUI.ION(Tags);
            wIon.ShowDialog();
        }

        private void Start_process_Click(object sender, RoutedEventArgs e)
        {
            Tags.setELIStart(true);
        }

        private void Heat_Assist_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_Heat_Asssit((bool)Heat_Assist.IsChecked);
        }

        private void Heat_cam_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_PreHeat_Start(true);
        }

        private void Heat_Scrn_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            ION_Screen.Visibility = Visibility.Hidden;
            Heat.Visibility = Visibility.Visible;
            HeatAssist_temp_sp.Text = Tags.get_HeatAssist_Temp_Sp().ToString();
            HeatAssist_Time_Sp.Text = Tags.get_HeatAssist_Time_Sp().ToString();
            PreHeat_Time_Sp.Text = Tags.get_PreHeat_Time_SP().ToString();
            PreHeat_Temp_Sp.Text = Tags.get_PreHeat_Temp_SP().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_HeatAssist_Temp_SP((double)(Convert.ToDouble(HeatAssist_temp_sp.Text.Replace(".", ","))));
            Tags.set_HeatAssist_time_Sp((double)Convert.ToDouble(HeatAssist_Time_Sp.Text.Replace(".", ",")));
            Tags.set_PreHeat_Temp_SP((double)Convert.ToDouble(PreHeat_Temp_Sp.Text.Replace(".", ",")));
            Tags.set_PreHeat_Time_sp((double)Convert.ToDouble(PreHeat_Time_Sp.Text.Replace(".", ",")));
        }

        private void PreHeat_Temp_Sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Tags.set_PreHeat_Temp_SP((double)Convert.ToDouble(PreHeat_Temp_Sp.Text.Replace(".", ",")));
        }

        private void PreHeat_Time_Sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Tags.set_PreHeat_Time_sp((double)Convert.ToDouble(PreHeat_Time_Sp.Text.Replace(".", ",")));
        }

        private void HeatAssist_temp_sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Tags.set_PreHeat_Temp_SP((double)Convert.ToDouble(PreHeat_Temp_Sp.Text.Replace(".", ",")));
        }

        private void HeatAssist_Time_Sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Tags.set_PreHeat_Time_sp((double)Convert.ToDouble(PreHeat_Time_Sp.Text.Replace(".", ",")));
        }

        private void Start_SSP_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_SSP_on(true);
        }

        private void Stop_SSP_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_SSP_on(false);
        }

        private void Circle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

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
