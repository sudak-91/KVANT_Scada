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
    class udtION
    {
        private string name { get; set; }
        private Plc PLC {get;set;}
        private int DB { get; set; }
        private int DBB { get; set; }
        private Real_Tag_Entitys rte { get; set; }

        #region PUBLIC VAR
        //public double Anod_I_SP { get; set; }
        //public double Anod_U_SP { get; set; }
        //public double Anod_P_SP { get; set; }
        //public double Heat_I_SP { get; set; }
        //public double Heat_U_SP { get; set; }
        //public double Heat_P_SP { get; set; }
        public double Anod_I { get; set; }
        public double Anod_U { get; set; }
        public double Anod_P { get; set; }
        public double Heat_I { get; set; }
        public double Heat_U { get; set; }
        public double Heat_P { get; set; }
        public bool Auto_mode { get; set; }
        public bool Power_On { get; set; }
        public bool Turn_On { get; set; }
        public bool Interlock { get; set; }
        public bool Failure { get; set; }
        public bool Power_Failure { get; set; }
        public bool Temperature_Failure { get; set; }
        public bool Repeat_Failure { get; set; }
        public bool Filament_Failure { get; set; }
        public bool Turn_off { get; set; }
        public bool Emergancy_Stop { get; set; }
        public bool Power_Stop { get; set; }
        public bool Temperature_Stop { get; set; }
        public bool Other_Failure { get; set; }

        #endregion
        public udtION(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            if (this.rte.ion_read.Find(this.DB, this.DBB) == null)
            {
                try
                {
                    ion_read vion = new ion_read
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                    };
                    this.rte.ion_read.Add(vion);
                    this.rte.SaveChanges();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }
        }
        public void Read_type()
        {
            this.PLC.ReadClass(this, DB, DBB);
            try
            {
                ion_read ion_read = this.rte.ion_read.Find(this.DB, this.DBB);
                {

                    ion_read.Anod_I = this.Anod_I;
                    ion_read.Anod_U = this.Anod_U;
                    ion_read.Anod_P = this.Anod_P;
                    ion_read.Heat_I = this.Heat_I;
                    ion_read.Heat_P = this.Heat_P;
                    ion_read.Heat_P = this.Heat_U;
                    ion_read.Auto_mode = this.Auto_mode;
                    ion_read.Failure = this.Failure;
                    ion_read.Filament_Failure = this.Filament_Failure;
                    ion_read.Interlock = this.Interlock;
                    ion_read.Temperature_Failure = this.Temperature_Failure;
                    ion_read.Temperature_Stop = this.Temperature_Stop;
                    ion_read.Power_on = this.Power_On;
                    ion_read.Turn_On = this.Turn_On;
                    ion_read.Turn_Off = this.Turn_off;
                    ion_read.Repeat_Failure = this.Repeat_Failure;
                    ion_read.Power_Stop = this.Power_Stop;
                    ion_read.Other_Failure = this.Other_Failure;
                   


                   
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
