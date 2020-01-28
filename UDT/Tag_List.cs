using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada.UDT
{
    public partial class Installing_Tags
    {
        #region Real_type
        private Real_type Cam_pressure;
        private Real_type FV_presure;
        private Real_type Crio_pressure;
        private Real_type Crio_temperature;
        private Real_type K_RRG_1, K_RRG_2,K_RRG_3;
        private Real_type FB_RRG_1, FB_RRG_2, FB_RRG_3;
        private Real_type SP_PID_RRG, ManVal_PID_RRG,Mode_RRG;
        private Real_type Pne_press;
        private Real_type Cam_Temp;//
        private Real_type PreHeat_Temp_Sp;
        private Real_type HeatAssist_Temp_Sp;
        private Real_type PreHeat_Time_Sp;
        private Real_type HeatAssist_Time_Sp;
        private Real_type Driver_Speed;
        #endregion

        #region udtValve
        private udtValve SHV;
        private udtValve FVV_B;
        private udtValve FVV_S;
        private udtValve CPV;
        private udtValve BAV_3;
        #endregion

        #region Command_bit
        private udtCommandBit ShvAutoModeSwitchOn;
        private udtCommandBit ShvServiceModeSwitchOn;
        private udtCommandBit ShvOpen;
        private udtCommandBit Bav3AutoModeSwitchOn;
        private udtCommandBit Bav3ServiceModeSwitchOn;
        private udtCommandBit Bav3Open;
        private udtCommandBit FvvSAutoModeSwitchOn;
        private udtCommandBit FvvSServiceModeSwitchOn;
        private udtCommandBit FvvSOpen;
        private udtCommandBit FvvBAutoModeSwitchOn;
        private udtCommandBit FvvBServiceModeSwitchOn;
        private udtCommandBit FvvBOpen;
        private udtCommandBit CPVAutoModeSwitchOn;
        private udtCommandBit CPVServiceModeSwitchOn;
        private udtCommandBit CPVOpen;
        private udtCommandBit CrioAutoModeSwitchOn;
        private udtCommandBit CrioManStart;
        private udtCommandBit FvpAutoModeSwitchOn;
        private udtCommandBit FvpRemoteSwitchOn;
        private udtCommandBit FvpManualStart;
        private udtCommandBit CamHeatOpen;
        private udtCommandBit IONManStart;
        private udtCommandBit IONManStop;
        private udtCommandBit IONAuto;
        private udtCommandBit IONReset;
        private udtCommandBit ELIStart;
        private udtCommandBit ELIProcessComplete;
        private udtCommandBit PreHeat_Start;
        private udtCommandBit Heat_Assist;
        private udtCommandBit SSP_on;
        private udtCommandBit Shield_autoOn;
        private udtCommandBit Crio_Pump_Run, Cam_Prepare, Cam_opened, Crio_Pump_Turn_off, Day_End;
        private udtCommandBit Shield_open, Shield_close;
        private udtCommandBit Driver_Run;
        private udtCommandBit Open_Door, Water_Crio, HH_pne, LL_pne, Crio_Power_Failure, Qartz_Power_Failure, ELI_Power_Failure, WaterHeat_Power_Failure, FVP_Power_Failure, Ion_Power_Failure, Indexer_Power_Failure, SSP_Power_Failure, Heater_Power_Failure, ELI_Water_Failure, CRIO_Hight_Temp;
        private udtCommandBit Heat_Asssit_On,Pre_Heat_Done, Heat_Assist_Done;
        private udtCommandBit Start_Driver,Driver_Remote_Control;





        #endregion
        #region Crio
        private udtCrio Crio;
        #endregion
        #region FVP
        private udtFVP FVP;
        #endregion

        #region udtProcess
        private udtProcess Tech_Cam;
        #endregion
        private udtIONWrite Ion_SP { get; set; }
        private udtION Ion { get; set; }
    }
}
