using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada.UDT
{
    class Real_type
    {
        public double value { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Plc PLC { get; set; }


        public Real_type(Plc plc, int DB, int DBB)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;

        }
        public void Read_type()
        {
            this.PLC.ReadClass(this, this.DB, this.DBB);
        }
        public void Write_type(float value)
        {
            //this.PLC.Write(this.path, value);
        }
    }
}
