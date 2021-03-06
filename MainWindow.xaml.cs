﻿using KVANT_Scada.Config;
using KVANT_Scada.Data;
using KVANT_Scada.UDT;
using S7.Net;
using System;
using System.Collections.Generic;
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
        private GUI.Window1 Shield;
        private GUI.Driver_Speed Driver_Speed;
        private RotateTransform rt;
        private udtIONWrite udtIONWrite;
        private Log_Sub_System.Log_Sub_System LSS;
        public int userPolicy = 0;
        public static users User;

        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        List<users> data;


        public MainWindow()
        {
           
            this.Topmost = true;
            InitializeComponent();

            real_Tag_Entitys = new Real_Tag_Entitys();
            data = new List<users>();
            LSS = new Log_Sub_System.Log_Sub_System(real_Tag_Entitys);
            foreach (users user in real_Tag_Entitys.users)
            {
                
                data.Add(user);
                
               
                
                
                


            }
            users_grid.ItemsSource = data;
            Dictionary<string, int> lRole = new Dictionary<string, int>();
            lRole.Add("Оператор", 0);
            lRole.Add("Технолог", 1);
            lRole.Add("Инженер", 2);
            Role.ItemsSource = lRole;
            Heat_Assist.IsChecked = Tags.get_Heat_Assist();
            




            plc = new Plc (CpuType.S71500, "192.168.1.122", 0, 1);
            on = new SolidColorBrush(Color.FromRgb( 0, 255, 0));
            off = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb( 221, 221, 221));
            
      

            dispatcherTimer = new DispatcherTimer();
           

            rt = new RotateTransform();
          






        }
        public void ConnectToPlc()
        {
            if (plc.IsConnected == false)
            {
                plc.Open();
                if (plc.IsConnected)
                {
                    Tags = new Installing_Tags(plc, real_Tag_Entitys);
                    dispatcherTimer.Interval = new System.TimeSpan(0, 0, 1);
                    dispatcherTimer.Tick += new EventHandler(Count);
                    dispatcherTimer.Start();

                }
           
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
            Cam_temp.Text = Tags.get_cam_temp().ToString();
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

            if(Tags.get_Crio_Pump_run())
            {
                lCrioPumpStart.Fill = on;
            }else
            {
                lCrioPumpStart.Fill = neutral;
            }
            if(Tags.get_Cam_Prepare())
            {
                lCamPrep.Fill = on;
            }
            else
            {
                lCamPrep.Fill = neutral;
            }
            if(Tags.get_Cam_open())
            {
                lCamOpen.Fill = on;
            }else
            {
                lCamOpen.Fill = neutral;
            }
            if(Tags.get_Day_End())
            {
                lDayEnd.Fill = on;
            }else
            {
                lDayEnd.Fill = neutral;
            }
            if(Tags.get_Crio_pump_turn_off())
            {
                lDayEnd_Copy.Fill = off;
            }else
            {
                lDayEnd_Copy.Fill = neutral;
            }
            if(Tags.get_Driver_Run())
            {
                lDriver_run.Fill = on;
            }else
            {
                lDriver_run.Fill = neutral;
            }
            if(Tags.get_Open_Door())
            {
                lOpenDoor.Fill = off;
            }else
            {
                lOpenDoor.Fill = neutral;
            }
            if(Tags.get_Water_Crio())
            {
                lWaterCrio.Fill = off;
            }else
            {
                lWaterCrio.Fill = neutral;
            }
            if(Tags.get_HH_pne())
            {
                lHH_pne.Fill = off;
            }
            else
            {
                lHH_pne.Fill = neutral;
            }
            if(Tags.get_LL_pne())
            {
                lLL_pne.Fill = off;
            }else
            {
                lLL_pne.Fill = neutral;
            }
            if(Tags.get_Crio_Power_Failure())
            {
                lCrioPowerFailure.Fill = off;
            }else
            {
                lCrioPowerFailure.Fill = neutral;

            }
            if(Tags.get_Qartz_Power_Failure())
            {
                lQartzPowerFailure.Fill = off;
            }
            else
            {
                lQartzPowerFailure.Fill = neutral;
            }
            if(Tags.get_ELI_Power_Failure())
            {
                lELIPowerFailure.Fill = off;
            }else
            {
                lELIPowerFailure.Fill = neutral;
            }
            if(Tags.get_WaterHEat_Power_Failure())
            {
                lWaterHEatPowerFailure.Fill = off;
            }
            else
            {
                lWaterHEatPowerFailure.Fill = neutral;

            }
            if(Tags.get_FVP_Power_Failure())
            {
                lFVPPowerFailure.Fill = off;
            }else
            {
                lFVPPowerFailure.Fill = neutral;
            }
            if(Tags.get_Ion_Power_Failure())
            {
                lIonPOwerFailure.Fill = off;
            }
            else
            {
                lIonPOwerFailure.Fill = neutral;

            }
            if(Tags.get_Indexer_Power_Failure())
            {
                lIndexerPowerFailure.Fill = off;
            }else
            {
                lIndexerPowerFailure.Fill = neutral;
            }
            if(Tags.get_SSP_Power_Failure())
            {
                lSSPPowerFailure.Fill = off;
            }else
            {
                lSSPPowerFailure.Fill = neutral;
            }
            if(Tags.get_Heater_Power_Failure())
            {
                lHeaterPowerFailure.Fill = off;
            }
            else
            {
                lHeaterPowerFailure.Fill = neutral;
            }
            if(Tags.get_ELI_Water_Failure())
            {
                lELIWaterFailure.Fill = off;
            }
            else
            {
                lELIWaterFailure.Fill = neutral;
            }
            if(Tags.get_CRIO_Hight_Temp())
            {
                lCRIOHightTempFailure.Fill = off;
            }
            else
            {
                lCRIOHightTempFailure.Fill = neutral;
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
            LSS.Add_to_LOG(User.Name, "Открытие камеры");
        }

        private void Stage_2_Open_Cam_Copy_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(5);
            LSS.Add_to_LOG(User.Name, "Закрытие смены");
        }

        private void Stage_2_Open_Cam_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(4);
            LSS.Add_to_LOG(User.Name, "Стоп Крионасоса");
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            ION_Screen.Visibility = Visibility.Visible;
            Heat.Visibility = Visibility.Hidden;
            Users1.Visibility = Visibility.Hidden;
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
            Users1.Visibility = Visibility.Hidden;
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
            LSS.Add_to_LOG(User.Name, "Значение флага нагрева при открытии = "+a.ToString());
        }

        private void Ion_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wIon = new GUI.ION(Tags);
            wIon.ShowDialog();
        }

        private void Start_process_Click(object sender, RoutedEventArgs e)
        {
            Tags.setELIStart(true);
            LSS.Add_to_LOG(User.Name, "Старт напыления");
        }

        private void Heat_Assist_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_Heat_Asssit((bool)Heat_Assist.IsChecked);
            LSS.Add_to_LOG(User.Name, "Значение флага нагрева при напылении = " + Heat_Assist.IsChecked.ToString());
        }

        private void Heat_cam_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_PreHeat_Start(true);
            LSS.Add_to_LOG(User.Name, "Прогрев камеры");
        }

        private void Heat_Scrn_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            ION_Screen.Visibility = Visibility.Hidden;
            Heat.Visibility = Visibility.Visible;
            Users1.Visibility = Visibility.Hidden;
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
           // Tags.set_PreHeat_Temp_SP((double)Convert.ToDouble(PreHeat_Temp_Sp.Text.Replace(".", ",")));
        }

        private void PreHeat_Time_Sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           // Tags.set_PreHeat_Time_sp((double)Convert.ToDouble(PreHeat_Time_Sp.Text.Replace(".", ",")));
        }

        private void HeatAssist_temp_sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           // Tags.set_PreHeat_Temp_SP((double)Convert.ToDouble(PreHeat_Temp_Sp.Text.Replace(".", ",")));
        }

        private void HeatAssist_Time_Sp_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           // Tags.set_PreHeat_Time_sp((double)Convert.ToDouble(PreHeat_Time_Sp.Text.Replace(".", ",")));
        }

        private void Start_SSP_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_SSP_on(true);
            LSS.Add_to_LOG(User.Name, "Запуск самовсасывающего насоса");
        }

        private void Stop_SSP_Click(object sender, RoutedEventArgs e)
        {
            Tags.set_SSP_on(false);
            LSS.Add_to_LOG(User.Name, "Остановка самовсасывающего насоса");
        }

        private void Circle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Driver_Speed = new GUI.Driver_Speed(Tags);
            Driver_Speed.ShowDialog();
        }

        private void Alarm_Click(object sender, RoutedEventArgs e)
        {
           
            try {
               string a= plc.Read("%IW80").ToString();
                 MessageBox.Show(a);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
            
           
        }

        private void Save_user_Click(object sender, RoutedEventArgs e)
        {
            users user = new users
            {
                Login = Login.Text,
                PassWord = User_Password.Password,
                Name = User_name.Text,
                Policy = Role.SelectedIndex
            };
            real_Tag_Entitys.users.Add(user);
            real_Tag_Entitys.SaveChanges();
            data.Add(user);
            users_grid.ItemsSource = data;
            users_grid.Items.Refresh();
            Login.Text = "";
            User_Password.Password = "";
            User_name.Text = "";
           
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Main.Visibility = Visibility.Hidden;
            ION_Screen.Visibility = Visibility.Hidden;
            Heat.Visibility = Visibility.Hidden;
            Users1.Visibility = Visibility.Visible;
        }

        private void ELI_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Shield = new GUI.Window1(Tags);
            Shield.ShowDialog();
        }

        private void Stage_0_Crio_Start_Click(object sender, RoutedEventArgs e)
        {
            int a = 1;
            Tags.Tech_Cam_PRocess(a);
            LSS.Add_to_LOG(User.Name, "Старт Крионасоса");
        }

        private void Stage_1_Prepare_Cam_Click(object sender, RoutedEventArgs e)
        {
            Tags.Tech_Cam_PRocess(2);
            LSS.Add_to_LOG(User.Name, "Откачка камеры");

        }
    }
}
