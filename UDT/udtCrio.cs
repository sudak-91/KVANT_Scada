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
    class udtCrio
    {
        public bool bPowerOn { get; set; }
        public bool bBlocked { get; set; }
        public bool bTurnOn { get; set; }
        public bool bAutoMode { get; set; }
        public bool bError{ get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Plc PLC { get; set; }
        private string name { get; set; }
        private Real_Tag_Entitys rte { get; set; }

        public udtCrio(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            if (this.rte.crio.Find(this.DB, this.DBB) == null)
            {
                try
                {
                    crio vCrio = new crio
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                        AutoMode = this.bAutoMode,
                        Blocked = this.bBlocked,
                        Error = this.bError,
                        PowerOn = this.bPowerOn,
                        TurnOn = this.bTurnOn
                        

                    };

                    this.rte.crio.Add(vCrio);
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
                crio crio = this.rte.crio.Find(this.DB, this.DBB);
                {

                    crio.AutoMode = this.bAutoMode;
                    crio.Blocked = this.bBlocked;
                    crio.Error = this.bError;
                    crio.PowerOn = this.bPowerOn;
                    crio.TurnOn = this.bTurnOn;

                    this.rte.SaveChanges();
                }
                crio_log c_l = new crio_log
                {
                    AutoMode = this.bAutoMode,
                    Blocked = this.bBlocked,
                    DateTime = System.DateTime.Now,
                    Error = this.bError,
                    name = this.name,
                    PowerOn = this.bPowerOn,
                    TurnOn = this.bTurnOn
                };
                this.rte.crio_log.Add(c_l);
                this.rte.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
        }
    }
}
