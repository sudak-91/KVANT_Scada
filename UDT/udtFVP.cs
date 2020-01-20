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
    class udtFVP
    {
        public bool bRemote { get; set; }
        public bool bAutoMode { get; set; }
        public bool bStart{ get; set; }
        public bool bManualStart { get; set; }
        public bool bPowerOn { get; set; }
        public bool bTurnOn { get; set; }
        public bool bBlock { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Plc PLC { get; set; }
        private string name { get; set; }
        private Real_Tag_Entitys rte { get; set; }

        public udtFVP(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            
            if (this.rte.fvp.Find(this.DB, this.DBB) == null)
            {
                try
                {
                    fvp vFVP = new fvp
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                        AutoMode = this.bAutoMode,
                        Block = this.bBlock,
                        ManualStart=this.bManualStart,
                        PowerOn=this.bPowerOn,
                        Remote=this.bRemote,
                        Start=this.bStart,
                        TurnOn=this.bTurnOn
                        


                    };

                    this.rte.fvp.Add(vFVP);
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
                fvp fvp = this.rte.fvp.Find(this.DB, this.DBB);
                {

                    fvp.AutoMode = this.bAutoMode;
                    fvp.Block = this.bBlock;
                    fvp.ManualStart = this.bManualStart;
                    fvp.PowerOn = this.bPowerOn;
                    fvp.Remote = this.bRemote;
                    fvp.Start = this.bStart;
                    fvp.TurnOn = this.bTurnOn;

                    
                }
                fvp_log f_l = new fvp_log
                {
                    AutoMode = this.bAutoMode,
                    Block = this.bBlock,
                    DateTime = System.DateTime.Now,
                    ManualStart = this.bManualStart,
                    name = this.name,
                    PowerOn = this.bPowerOn,
                    Remote = this.bRemote,
                    Start = this.bStart,
                    TurnOn = this.bTurnOn

                };
                this.rte.fvp_log.Add(f_l);
                this.rte.SaveChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
        }
    }
}
