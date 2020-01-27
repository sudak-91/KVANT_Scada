

using KVANT_Scada.Data;
using S7.Net;

namespace KVANT_Scada.UDT
{
    public partial class  Installing_Tags
    {
        


         public Installing_Tags(Plc plc, Real_Tag_Entitys real_Tag_Entitys)
        {
            #region

            Cam_pressure = new Real_type(plc, 14,36,real_Tag_Entitys,"cam_pressure");
            FV_presure = new Real_type(plc, 14,22, real_Tag_Entitys, "FV_presure");
            Crio_pressure = new Real_type(plc, 14,8, real_Tag_Entitys, "Crio_presure");
            Crio_temperature = new Real_type(plc, 18, 16, real_Tag_Entitys,"Crio_temperature");
            K_RRG_1 = new Real_type(plc, 21, 92, real_Tag_Entitys, "K_RRG_1");
            K_RRG_2 = new Real_type(plc, 21, 96, real_Tag_Entitys, "K_RRG_2");
            K_RRG_3 = new Real_type(plc, 21, 100, real_Tag_Entitys, "K_RRG_3");
            FB_RRG_1 = new Real_type(plc, 21, 30, real_Tag_Entitys, "FB_RRG_1");
            FB_RRG_2 = new Real_type(plc, 21, 52, real_Tag_Entitys, "FB_RRG_2");
            FB_RRG_3 = new Real_type(plc, 21, 70, real_Tag_Entitys, "FB_RRG_3");
            SP_PID_RRG = new Real_type(plc, 39, 0, real_Tag_Entitys, "SP_PID_RRG");
            ManVal_PID_RRG = new Real_type(plc, 39, 4, real_Tag_Entitys, "ManVal_PID_RRG");
            Mode_RRG = new Real_type(plc, 39, 12, real_Tag_Entitys, "Mode_RRG");
            Pne_press = new Real_type(plc, 23, 0, real_Tag_Entitys, "Pne_Press");
            HeatAssist_Temp_Sp = new Real_type(plc, 46, 4, real_Tag_Entitys, "HeatAssist Temp Sp");
            PreHeat_Temp_Sp = new Real_type(plc, 46, 0, real_Tag_Entitys, "PreHeat_Temp_Sp");
            HeatAssist_Time_Sp = new Real_type(plc, 46, 12, real_Tag_Entitys, "HeatAssist_Time_Sp");
            PreHeat_Time_Sp = new Real_type(plc, 46, 8, real_Tag_Entitys, "PreHeat_Time_Sp");
            Cam_Temp = new Real_type(plc, 1, 534, real_Tag_Entitys, "Cam_Temp");
            Driver_Speed = new Real_type(plc, 37, 4, real_Tag_Entitys, "Driver_Speed");
            


            #endregion
            #region
            SHV = new udtValve(plc, 7, 28, real_Tag_Entitys, "SHV");
            FVV_S = new udtValve(plc, 7, 4, real_Tag_Entitys, "FVV_S");
            FVV_B = new udtValve(plc, 7, 10, real_Tag_Entitys, "FVV_B");
            CPV = new udtValve(plc, 7, 16, real_Tag_Entitys, "CPV");
            BAV_3 = new udtValve(plc, 7, 22, real_Tag_Entitys, "BAV_3");
            #endregion
            #region CommandBit
            ShvAutoModeSwitchOn = new udtCommandBit(plc, 7, 24, 1, real_Tag_Entitys, "SHV_automode_witch_on");
            ShvServiceModeSwitchOn = new udtCommandBit(plc, 7, 24, 0, real_Tag_Entitys, "SHV_servicemode_switch_on");
            ShvOpen = new udtCommandBit(plc, 7, 24, 2, real_Tag_Entitys, "SHV_open");

            Bav3AutoModeSwitchOn = new udtCommandBit(plc, 7, 18, 1, real_Tag_Entitys, "BAV_3_automode_witch_on");
            Bav3ServiceModeSwitchOn = new udtCommandBit(plc, 7, 18, 0, real_Tag_Entitys, "BAV_3_servicemode_switch_on");
            Bav3Open = new udtCommandBit(plc, 7, 18, 2, real_Tag_Entitys, "BAV_3_open");

            FvvSAutoModeSwitchOn = new udtCommandBit(plc, 7, 0, 1, real_Tag_Entitys, "FVV_S_automode_witch_on");
            FvvSServiceModeSwitchOn = new udtCommandBit(plc, 7, 0, 0, real_Tag_Entitys, "FVV_S_servicemode_switch_on");
            FvvSOpen = new udtCommandBit(plc, 7, 0, 2, real_Tag_Entitys, "FVV_S_open");

            FvvBAutoModeSwitchOn = new udtCommandBit(plc, 7, 6, 1, real_Tag_Entitys, "FVV_B_automode_witch_on");
            FvvBServiceModeSwitchOn = new udtCommandBit(plc, 7, 6, 0, real_Tag_Entitys, "FVV_B_servicemode_switch_on");
            FvvBOpen = new udtCommandBit(plc, 7, 6, 2, real_Tag_Entitys, "FVV_B_open");

            CPVAutoModeSwitchOn = new udtCommandBit(plc, 7, 12, 1, real_Tag_Entitys, "CPV_automode_witch_on");
            CPVServiceModeSwitchOn = new udtCommandBit(plc, 7, 12, 0, real_Tag_Entitys, "CPV_servicemode_switch_on");
            CPVOpen = new udtCommandBit(plc, 7, 12, 2, real_Tag_Entitys, "CPV_open");
            CrioAutoModeSwitchOn = new udtCommandBit(plc, 8, 0, 0, real_Tag_Entitys, "Crio_Auto_Mode_Switch_On");
            CrioManStart = new udtCommandBit(plc, 8, 0, 1, real_Tag_Entitys, "Crio_Manual_Start");

            FvpAutoModeSwitchOn = new udtCommandBit(plc, 22, 0, 1, real_Tag_Entitys, "FVP_Auto_Mode_Switch_On");
            FvpRemoteSwitchOn = new udtCommandBit(plc, 22, 0, 0, real_Tag_Entitys, "FVP_Remote_Switch_on");
            FvpManualStart = new udtCommandBit(plc, 22, 0, 3, real_Tag_Entitys, "FVP_Manual_Start");
            CamHeatOpen = new udtCommandBit(plc, 24, 44, 3, real_Tag_Entitys, "Cam_Heat_Open");
            IONManStart = new udtCommandBit(plc, 20, 30, 0, real_Tag_Entitys, "IonManStart");
            IONManStop = new udtCommandBit(plc, 20, 30, 1, real_Tag_Entitys, "IonManStop");
            IONAuto = new udtCommandBit(plc, 20, 30, 4, real_Tag_Entitys, "IonAutoMod");
            IONReset = new udtCommandBit(plc, 20, 30, 5, real_Tag_Entitys, "IonReset");
            ELIStart = new udtCommandBit(plc, 40, 0, 0, real_Tag_Entitys, "ELI Start");
            ELIProcessComplete = new udtCommandBit(plc, 3, 104, 4, real_Tag_Entitys, "ELI_Process_Complete");
            PreHeat_Start = new udtCommandBit(plc, 46, 28, 2, real_Tag_Entitys, "PreHeat_Start");
            Heat_Assist = new udtCommandBit(plc, 46, 28, 3, real_Tag_Entitys, "Heat_Assist");
            SSP_on = new udtCommandBit(plc, 4, 50, 0, real_Tag_Entitys, "SSP_on");
            Shield_autoOn = new udtCommandBit(plc, 38, 0, 1, real_Tag_Entitys, "Shield_AutoOn");
            Crio_Pump_Run = new udtCommandBit(plc, 24, 24, 2, real_Tag_Entitys, "Crio pump Run");
            Cam_Prepare = new udtCommandBit(plc, 24, 40, 1, real_Tag_Entitys, "Camera prepare");
            Cam_opened = new udtCommandBit(plc, 24, 44, 2, real_Tag_Entitys,"Cam_open");
            Crio_Pump_Turn_off = new udtCommandBit(plc, 24, 48, 2, real_Tag_Entitys, "Crio_Pump_Turn_Off");
            Day_End = new udtCommandBit(plc, 24, 50, 2, real_Tag_Entitys, "Day_End");
            Shield_open = new udtCommandBit(plc, 38, 0, 2, real_Tag_Entitys, "Shield_Open");
            Shield_close = new udtCommandBit(plc, 38, 0, 3, real_Tag_Entitys, "Shield_Close");
            Driver_Run = new udtCommandBit(plc, 37, 8, 0, real_Tag_Entitys, "Driver_run");
            Open_Door = new udtCommandBit(plc, 3,16,4,real_Tag_Entitys,"Open_Door");
            Water_Crio = new udtCommandBit(plc, 4, 78, 0, real_Tag_Entitys, "Water_Crio");
            HH_pne = new udtCommandBit(plc, 43, 0, 2, real_Tag_Entitys, "HH_pne");
            LL_pne = new udtCommandBit(plc, 43, 0, 3, real_Tag_Entitys, "LL_pne");
            Crio_Power_Failure = new udtCommandBit(plc, 43, 0, 4, real_Tag_Entitys, "Crio_Power_Failure");
            Qartz_Power_Failure = new udtCommandBit(plc, 43, 0, 5, real_Tag_Entitys, "Qartz_Power_Failure");
            ELI_Power_Failure = new udtCommandBit(plc, 43, 0, 6, real_Tag_Entitys, "ELI_Power_Failure");
            WaterHeat_Power_Failure = new udtCommandBit(plc, 43, 0, 7, real_Tag_Entitys, "WaterHeat_Power_Failure");
            FVP_Power_Failure = new udtCommandBit(plc, 43, 1, 0, real_Tag_Entitys, "FVP_Power_Failure");
            Ion_Power_Failure = new udtCommandBit(plc, 43, 1, 1, real_Tag_Entitys, "Ion_Power_Failure");
            Indexer_Power_Failure = new udtCommandBit(plc, 43, 1, 2, real_Tag_Entitys, "Indexer_Power_Failure");
            SSP_Power_Failure = new udtCommandBit(plc, 43, 1, 3, real_Tag_Entitys, "SSP_Power_Failure");
            Heater_Power_Failure = new udtCommandBit(plc, 43, 1, 4, real_Tag_Entitys, "Heater_Power_Failure");
            ELI_Water_Failure = new udtCommandBit(plc, 4, 82, 0, real_Tag_Entitys, "ELI_Water_Failure");
            CRIO_Hight_Temp = new udtCommandBit(plc, 43, 1, 6, real_Tag_Entitys, "CRIO_Hight_Temp");
            Pre_Heat_Done = new udtCommandBit(plc, 46, 28, 0, real_Tag_Entitys, "PreHeat_Done");
            Heat_Assist_Done = new udtCommandBit(plc, 46, 28, 1, real_Tag_Entitys, "Heat_Assist_Done");






            #endregion
            Crio = new udtCrio(plc, 8, 4, real_Tag_Entitys, "Crio");
            FVP = new udtFVP(plc, 22, 0, real_Tag_Entitys, "FVP");
            Tech_Cam = new udtProcess(plc, 24, 0, real_Tag_Entitys, "Tech_Cam");
          
            Ion_SP = new udtIONWrite(plc, 20, 32, real_Tag_Entitys, "ION_Write");
            Ion = new udtION(plc, 20, 56, real_Tag_Entitys, "ION");
        }
        public bool get_Heat_Assist_Done()
        {
            return Heat_Assist_Done.value;
        }
        public bool get_PreHeat_Done()
        {
            return Pre_Heat_Done.value;
        }
        public bool get_CRIO_Hight_Temp()
        {
            return CRIO_Hight_Temp.value;
        }
        public bool get_ELI_Water_Failure()
        {
            return ELI_Water_Failure.value;
        }
        public bool get_Heater_Power_Failure()
        {
            return Heater_Power_Failure.value;
        }
        public bool get_SSP_Power_Failure()
        {
            return SSP_Power_Failure.value;
        }
        public bool get_Indexer_Power_Failure()
        {
            return Indexer_Power_Failure.value;
        }
        public bool get_Ion_Power_Failure()
        {
            return Ion_Power_Failure.value;
        }
        public bool get_FVP_Power_Failure()
        {
            return FVP_Power_Failure.value;
        }
        public bool get_WaterHEat_Power_Failure()
        {
            return WaterHeat_Power_Failure.value;
        }
        public bool get_ELI_Power_Failure()
        {
            return ELI_Power_Failure.value;
        }
        public bool get_Qartz_Power_Failure()
        {
            return Qartz_Power_Failure.value;

        }
        public bool get_Crio_Power_Failure()
        {
            return Crio_Power_Failure.value;
        }
        public bool get_LL_pne()
        {
            return LL_pne.value;
        }
        public bool get_HH_pne()
        {
            return HH_pne.value;
        }
        public bool get_Water_Crio()
        {
            return Water_Crio.value;
        }
        public bool get_Open_Door()
        {
            return Open_Door.value;
        }
        public bool get_Driver_Run()
        {
            return Driver_Run.value;
        }
        public void set_Driver_Speed(double value)
        {
            Driver_Speed.Write_type(value);
        }
        public double get_Driver_Speed()
        {
            Driver_Speed.Read_type();
            return Driver_Speed.value;
        }
        public void set_Shield_open(bool value)
        {
            Shield_open.Write(value);
        }
        public void set_Shield_close(bool value)
            {
            Shield_close.Write(value);

        }
        public bool get_Crio_Pump_run()
        {
            return Crio_Pump_Run.value;
        }
        public bool get_Cam_Prepare()
        {
            return Cam_Prepare.value;
        }
        public bool get_Cam_open()
        {
            return Cam_opened.value;
        }
        public bool get_Crio_pump_turn_off()
        {
            return Crio_Pump_Turn_off.value;
        }
        public bool get_Day_End()
        {
            return Day_End.value;
        }

        public void set_Shield_Auto(bool value)
        {
            Shield_autoOn.Write(value);
        }
        public bool get_Shield_Auto()
        {
            return Shield_autoOn.value;
                
        }
        public void set_SSP_on(bool value)
        {
            SSP_on.Write(value);
        }
        public void set_HeatAssist_Temp_SP(double value)
        {
            HeatAssist_Temp_Sp.Write_type(value);
        }
        public void set_HeatAssist_time_Sp(double value)
        {
            HeatAssist_Time_Sp.Write_type(value);
        }
        public void set_PreHeat_Temp_SP(double value)
        {
            PreHeat_Temp_Sp.Write_type(value);
        }
        public void set_PreHeat_Time_sp(double value)
        {
            PreHeat_Time_Sp.Write_type(value);
        }
        public double get_HeatAssist_Temp_Sp()
        {
            HeatAssist_Temp_Sp.Read_type();
            return HeatAssist_Temp_Sp.value;
        }
        public double get_HeatAssist_Time_Sp()
        {
            HeatAssist_Time_Sp.Read_type();
            return HeatAssist_Time_Sp.value;
        }
        public double get_PreHeat_Temp_SP()
        {
            PreHeat_Temp_Sp.Read_type();
            return PreHeat_Temp_Sp.value;
        }
        public double get_PreHeat_Time_SP()
        {
            PreHeat_Time_Sp.Read_type();
            return PreHeat_Time_Sp.value;
        }
        public void set_PreHeat_Start(bool value)
        {
            PreHeat_Start.Write(value);
        }
        public bool get_PreHeat_Start()
        {
            return PreHeat_Start.value;
        }
        public void set_Heat_Asssit(bool value)
        {
            Heat_Assist.Write(value);
        }
        public void Update_Read()
        {

            Cam_pressure.Read_type();
            FV_presure.Read_type();
            Crio_pressure.Read_type();
            Crio_temperature.Read_type();
            SHV.Read_type();
            Crio.Read_type();
            FVP.Read_type();
            CPV.Read_type();
            BAV_3.Read_type();
            FVV_B.Read_type();
            FVV_S.Read_type();
            Ion.Read_type();
            ELIProcessComplete.Read();
            FB_RRG_1.Read_type();
            FB_RRG_2.Read_type();
            FB_RRG_3.Read_type();
            Pne_press.Read_type();
            Shield_autoOn.Read();
            Cam_Temp.Read_type();
            Crio_Pump_Run.Read();
            Crio_Pump_Turn_off.Read();
            Cam_Prepare.Read();
            Day_End.Read();
            Cam_opened.Read();
            Driver_Run.Read();
            Open_Door.Read();
            Water_Crio.Read();
            HH_pne.Read();
            LL_pne.Read();
            Crio_Power_Failure.Read();
            Qartz_Power_Failure.Read();
            ELI_Power_Failure.Read();
            WaterHeat_Power_Failure.Read();
            FVP_Power_Failure.Read();
            Ion_Power_Failure.Read();
            Indexer_Power_Failure.Read();
            SSP_Power_Failure.Read();
            Heater_Power_Failure.Read();
            ELI_Water_Failure.Read();
            CRIO_Hight_Temp.Read();
            Pre_Heat_Done.Read();
            Heat_Assist_Done.Read();








        }

        public bool get_Heat_Assist()
        {
            Heat_Assist.Read();
            return Heat_Assist.value;
        }
        public double get_cam_temp()
        {
            return Cam_Temp.value;
        }
        public double get_cam_pressure ()
        {
            return this.Cam_pressure.value;
        }
        public double get_Pne_Press()
        {
            return Pne_press.value;
        }
        public double get_crio_pressure ()
        {
            return this.Crio_pressure.value;
        }
        public double get_crio_temperature()
        {
            return this.Crio_temperature.value;
        }
        public double get_FV_pressure()
        {
            return this.FV_presure.value;
        }
         public bool get_SHV_opened()
        {
            return this.SHV.bOpened;
        }
        public bool get_SHV_closed()
        {
            return this.SHV.bClosed;
        }
        public bool get_SHV_automode()
        {
            return this.SHV.bAutoMode;
                
        }
    
        public bool get_Cam_Heat_Open()
        {
            return this.CamHeatOpen.value;
        } 
        public void set_Cam_Heat_Open(bool vl)
        {
            this.CamHeatOpen.Write(vl);
        }
        public bool get_SHV_blocked()
        {
            return this.SHV.bBlocked;
        }
        public bool get_SHV_service()
        {
            return this.SHV.bServiced;
        }
        public bool get_Process_compite()
        {
            return  this.ELIProcessComplete.value;
        }
        public void set_ELI_Start(bool value)
        {
            this.ELIStart.Write(value);
        }

         public void SHV_auto_mode_on(bool value)
        {
            this.ShvAutoModeSwitchOn.Write(value);
        }
        public void SHV_service_mode_on(bool value)
        {
            this.ShvServiceModeSwitchOn.Write(value);
        }
        public void SHV_open(bool value)
        {
            this.ShvOpen.Write(value);

        }
        public void setELIStart(bool value)
        {
            this.ELIStart.Write(value);
        }

        #region BAV_3
        public bool get_BAV_3_opened()
        {
            return this.BAV_3.bOpened;
        }
        public bool get_BAV_3_closed()
        {
            return this.BAV_3.bClosed;
        }
        public bool get_BAV_3_automode()
        {
            return this.BAV_3.bAutoMode;

        }
        public bool get_BAV_3_blocked()
        {
            return this.BAV_3.bBlocked;
        }
        public bool get_BAV_3_service()
        {
            return this.BAV_3.bServiced;
        }
        public void BAV_3_auto_mode_on(bool value)
        {
            this.Bav3AutoModeSwitchOn.Write(value);
        }
        public void BAV_3_service_mode_on(bool value)
        {
            this.Bav3ServiceModeSwitchOn.Write(value);
        }
        public void BAV_3_open(bool value)
        {
            this.Bav3Open.Write(value);

        }
        #endregion
        #region FVV_S
        public bool get_FVV_S_opened()
        {
            return this.FVV_S.bOpened;
        }
        public bool get_FVV_S_closed()
        {
            return this.FVV_S.bClosed;
        }
        public bool get_FVV_S_automode()
        {
            return this.FVV_S.bAutoMode;

        }
        public bool get_FVV_S_blocked()
        {
            return this.FVV_S.bBlocked;
        }
        public bool get_FVV_S_service()
        {
            return this.FVV_S.bServiced;
        }
        public void FVV_S_auto_mode_on(bool value)
        {
            this.FvvSAutoModeSwitchOn.Write(value);
        }
        public void FVV_S_service_mode_on(bool value)
        {
            this.FvvSServiceModeSwitchOn.Write(value);
        }
        public void FVV_S_open(bool value)
        {
            this.FvvSOpen.Write(value);

        }

        #endregion

        #region #FVV_B
        public bool get_FVV_B_opened()
        {
            return this.FVV_B.bOpened;
        }
        public bool get_FVV_B_closed()
        {
            return this.FVV_B.bClosed;
        }
        public bool get_FVV_B_automode()
        {
            return this.FVV_B.bAutoMode;

        }
        public bool get_FVV_B_blocked()
        {
            return this.FVV_B.bBlocked;
        }
        public bool get_FVV_B_service()
        {
            return this.FVV_B.bServiced;
        }
        public void FVV_B_auto_mode_on(bool value)
        {
            this.FvvBAutoModeSwitchOn.Write(value);
        }
        public void FVV_B_service_mode_on(bool value)
        {
            this.FvvBServiceModeSwitchOn.Write(value);
        }
        public void FVV_B_open(bool value)
        {
            this.FvvBOpen.Write(value);

        }
        #endregion
        #region CPV
        public bool get_CPV_opened()
        {
            return this.CPV.bOpened;
        }
        public bool get_CPV_closed()
        {
            return this.CPV.bClosed;
        }
        public bool get_CPV_automode()
        {
            return this.CPV.bAutoMode;

        }
        public bool get_CPV_blocked()
        {
            return this.CPV.bBlocked;
        }
        public bool get_CPV_service()
        {
            return this.CPV.bServiced;
        }
        public void CPV_auto_mode_on(bool value)
        {
            this.CPVAutoModeSwitchOn.Write(value);
        }
        public void CPV_service_mode_on(bool value)
        {
            this.CPVServiceModeSwitchOn.Write(value);
        }
        public void CPV_open(bool value)
        {
            this.CPVOpen.Write(value);

        }

        #endregion

        #region CRIO
        public bool get_Crio_Power_On()
        {
            return this.Crio.bPowerOn;
        }
        public bool get_Crio_Turn_on()
        {
            return this.Crio.bTurnOn;

        }
        public bool get_Crio_AutoMode()
        {
            return this.Crio.bAutoMode;

        }
        public bool get_Crio_Blocked()
        {
            return this.Crio.bBlocked;
        }
        public bool get_Crio_Error()
        {
            return this.Crio.bError;
        }
        public void Crio_auto_mode_on(bool value)
        {
            this.CrioAutoModeSwitchOn.Write(value);
        }
        public void Crio_manual_start(bool value)
        {
            this.CrioManStart.Write(value);
        }
        public void setIONManStart(bool value)
        {
            this.IONManStart.Write(value);
                
                
            
        }
        public void setIONManStop(bool value)
        {
            this.IONManStop.Write(value);
        }
        public void setIONAutoMode(bool value)
        {
            this.IONAuto.Write(value);
        }
        public void setIONReset(bool value)
        {
            this.IONReset.Write(value);
        }
        public bool getIONAuto()
        {
            return this.IONAuto.value;
        }
        #endregion

        #region FVP
        /*
         
       

       
               private udtCommandBit FvpAutoModeSwitchOn;
        private udtCommandBit FvpRemoteSwitchOn;
        private udtCommandBit FvpManualStart;
         */
         public bool get_FVP_Remote()
        {
            return this.FVP.bRemote;
        }
        public bool get_FVP_AutoMode()
        {
            return this.FVP.bAutoMode;
        }
        public bool get_FVP_Power_On()
        {
            return this.FVP.bPowerOn;
        }
        public bool get_FVP_Turn_On()
        {
            return this.FVP.bTurnOn;
        }
        public bool get_FVP_Block()
        {
            return this.FVP.bBlock;
        }
        public void FVP_Auto_mode(bool value)
        {
            this.FvpAutoModeSwitchOn.Write(value);
        }
        public void FVP_remote(bool value)
        {
            this.FvpRemoteSwitchOn.Write(value);
        }
        public void FVP_Manual_Start(bool value)
        {
            this.FvpManualStart.Write(value);
        }

        #endregion
        public void Tech_Cam_PRocess(int value)
        {
            this.Tech_Cam.Write(value);
        }
        public void WriteToDbISp(double i, double u, double p, double hi, double hu, double hp)
        {
            this.Ion_SP.Anod_I_SP = i;
            this.Ion_SP.Anod_U_SP = u;
            this.Ion_SP.Anod_P_SP = p;
            this.Ion_SP.Heat_I_SP = hi;
            this.Ion_SP.Heat_U_SP = hu;
            this.Ion_SP.Heat_P_SP = hp;
            this.Ion_SP.WriteToDB();
            
        }
        public void GetInitValue()
        {
            this.Ion_SP.ReadFromDB();
            
        }
        public string GetAnodISp()
        {
            return this.Ion_SP.Anod_I_SP.ToString();
        }
        public string GetAnodUSp()
        {
            return this.Ion_SP.Anod_U_SP.ToString();
        }
        public string GetAnodPSp()
        {
            return this.Ion_SP.Anod_P_SP.ToString();
        }
        public string GetHeatISp()
        {
            return this.Ion_SP.Heat_I_SP.ToString();
        }
        public string GetHeatUSp()
        {
            string a = this.Ion_SP.Heat_U_SP.ToString();
            return a;
        }
        public string GetHeatPSp()
        {
            return this.Ion_SP.Heat_P_SP.ToString();
        }
        public string GetAnodI()
        {
            return this.Ion.Anod_I.ToString();
        }
        public string GetAnodU()
        {
            return this.Ion.Anod_U.ToString();
        }
        public string GetAnodP()
        {
            return this.Ion.Anod_P.ToString();
        }
        public string GetHeatI()
        {
            return this.Ion.Heat_I.ToString();
        }
        public string GetHeatU()
        {
            return this.Ion.Heat_U.ToString();
        }
        public string GetHeatP()
        {
            return this.Ion.Heat_P.ToString();
        }
        public bool GetIonPowerOn()
        {
            return this.Ion.Power_On;
        }
        public bool GetIonTurnOn()
        {
            return this.Ion.Turn_On;
        }
        public bool GetIonFailure()
        {
            return this.Ion.Failure;

        }
        public bool GetIonAutoMode()
        {
            return this.Ion.Auto_mode;
        }





        public double get_FB_RRG_1()
        {
            return FB_RRG_1.value;
        }
        public double get_FB_RRG_2()
        {
            return FB_RRG_2.value;
        }
        public double get_FB_RRG_3()
        {
            return FB_RRG_3.value;
        }
        public double get_K_RRG_1()
        {
            return K_RRG_1.value;
        }
        public double get_K_RRG_2()
        {
            return K_RRG_2.value;
        }
        public double get_K_RRG_3()
        {
            return K_RRG_3.value;
        }
        public void set_K_RRG(double v1, double v2, double v3)
        {
            this.K_RRG_1.Write_type(v1);
            this.K_RRG_2.Write_type(v2);
            this.K_RRG_3.Write_type(v3);
        }
        public void set_SP_PID_RRG(double value)
        {
            SP_PID_RRG.Write_type(value);
        }
        public void set_ManVal_PID_RRG(double value)
        {
            ManVal_PID_RRG.Write_type(value);
        }
        public void set_MODE_PID (double value)
        {
            Mode_RRG.Write_type(value);
        }
    }



}