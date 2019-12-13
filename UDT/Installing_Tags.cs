

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





            #endregion
            Crio = new udtCrio(plc, 8, 4, real_Tag_Entitys, "Crio");
            FVP = new udtFVP(plc, 22, 0, real_Tag_Entitys, "FVP");
            Tech_Cam = new udtProcess(plc, 24, 0, real_Tag_Entitys, "Tech_Cam");
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



        }


        public double get_cam_pressure ()
        {
            return this.Cam_pressure.value;
        }
        public double get_crio_pressure ()
        {
            return this.Crio_pressure.value;
        }
        public double get_crio_temperature()
        {
            return this.Crio_temperature.value;
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
        public bool get_SHV_blocked()
        {
            return this.SHV.bBlocked;
        }
        public bool get_SHV_service()
        {
            return this.SHV.bServiced;
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


    }



}