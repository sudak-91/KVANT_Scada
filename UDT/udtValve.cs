using KVANT_Scada.Config;
using KVANT_Scada.Data;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KVANT_Scada.UDT
{
    class udtValve
    {
        public bool bAutoMode { get; set; }
        public bool bOpened { get; set; }
        public bool bClosed { get; set; }
        public bool bOpening { get; set; }
        public bool bClosing { get; set; }
        public bool bBlocked { get; set; }
        public bool bServiced { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Plc PLC { get; set; }
        private string name { get; set; }
        private Real_Tag_Entitys rte { get; set; }

        public udtValve(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            if (this.rte.valves.Find(this.DB, this.DBB) == null)
            {
                try
                {
                    valves vValve = new valves
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                    };

                    this.rte.valves.Add(vValve);
                    this.rte.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }

        }
        public void Read_type()
        {
            this.PLC.ReadClass(this, this.DB, this.DBB);
            try
            {
                valves valve = this.rte.valves.Find(this.DB, this.DBB);
                {
                    
                    valve.Opened = this.bOpened;
                    valve.Closed = this.bClosed;
                    valve.Opening = this.bOpening;
                    valve.Closing = this.bClosing;
                    valve.Blocked = this.bBlocked;
                    valve.Serviced = this.bServiced;
                    valve_log vl = new valve_log
                    {
                        name = this.name,
                        opened = this.bOpened,
                        closed = this.bClosed,
                        block = this.bBlocked,
                        TIME = System.DateTime.Now
                    };
                    rte.valve_log.Add(vl);
                    this.rte.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
        }
    }
}
