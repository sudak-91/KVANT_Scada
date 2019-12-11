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
    }
}
