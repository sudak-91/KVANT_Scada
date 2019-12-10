

using S7.Net;

namespace KVANT_Scada.UDT
{
    public class Installing_Tags
    {
        private Real_type Cam_pressure; 
        private Real_type FV_presure;
        private Real_type Crio_pressure;
        private Real_type Crio_temperature;

         public Installing_Tags(Plc plc)
        {
            Cam_pressure = new Real_type(plc, 14,36);
            FV_presure = new Real_type(plc, 14,22);
            Crio_pressure = new Real_type(plc, 14,8);
            Crio_temperature = new Real_type(plc, 18, 16);

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
        
        public  void Update_Read()
        {

            Cam_pressure.Read_type();      
            FV_presure.Read_type();
            Crio_pressure.Read_type();
            Crio_temperature.Read_type();


        }

    }
   
    

}