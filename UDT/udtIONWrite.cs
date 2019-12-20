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
    class udtIONWrite
    {
   

        #region PUBLIC VAR
        public double Anod_I_SP { get; set; }
        public double Anod_U_SP { get; set; }
        public double Anod_P_SP { get; set; }
        public double Heat_I_SP { get; set; }
        public double Heat_U_SP { get; set; }
        public double Heat_P_SP { get; set; }
        #endregion
        private string name { get; set; }
        private Plc PLC { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Real_Tag_Entitys rte { get; set; }
        public udtIONWrite(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            if (this.rte.ion_sp.Find(this.DB, this.DBB) == null)
            {
                try
                {
                    ion_sp vion = new ion_sp
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                    };
                    this.rte.ion_sp.Add(vion);
                    this.rte.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }

        }
        public void Write_type()
        {
            ion_sp ion_sp = this.rte.ion_sp.Find(this.DB, this.DBB);
            this.Anod_I_SP = (double)ion_sp.Anod_I_SP;
            this.Anod_P_SP = (double)ion_sp.Anod_P_SP;
            this.Anod_U_SP = (double)ion_sp.Anod_U_SP;
            this.Heat_I_SP = (double)ion_sp.Heat_I_SP;
            this.Heat_P_SP = (double)ion_sp.Heat_P_SP;
            this.Heat_U_SP = (double)ion_sp.Heat_U_SP;
            this.PLC.WriteClass(this, this.DB, this.DBB);
        }
        public void WriteToDB()
        {
            ion_sp ion_sp = this.rte.ion_sp.Find(this.DB, this.DBB);
            ion_sp.Anod_I_SP = this.Anod_I_SP;
            ion_sp.Anod_U_SP = this.Anod_U_SP;
            ion_sp.Anod_P_SP = this.Anod_P_SP;
            ion_sp.Heat_I_SP = this.Heat_I_SP;
            ion_sp.Heat_U_SP = this.Heat_U_SP;
            ion_sp.Heat_P_SP = this.Heat_P_SP;
            rte.SaveChanges();
        }
        public void ReadFromDB()
        {
            ion_sp ion_sp = this.rte.ion_sp.Find(this.DB, this.DBB);
            this.Anod_I_SP = (double)ion_sp.Anod_I_SP;
            this.Anod_U_SP = (double)ion_sp.Anod_U_SP;
            this.Anod_P_SP = (double)ion_sp.Anod_P_SP;
            this.Heat_I_SP = (double)ion_sp.Heat_I_SP;
            this.Heat_U_SP = (double)ion_sp.Heat_U_SP;
            this.Heat_P_SP = (double)ion_sp.Heat_P_SP;
            

        }
          
    }
}
