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
    class udtProcess
    {
        public int value { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Plc PLC { get; set; }
        private string name { get; set; }
        private Real_Tag_Entitys rte { get; set; }
        public udtProcess(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            if (this.rte.process.Find(this.DB, this.DBB) == null)
            {
                try
                {
                    process vProcess = new process
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                    };

                    this.rte.process.Add(vProcess);
                    this.rte.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }
        }
        public void Write(int value)
        {
            PLC.Write(DataType.DataBlock,this.DB,this.DBB,value);
            //if (this.rte.process.Find(this.DB, this.DBB) == null)
            //{
            //    try
            //    {
            //        process vProcess = new process
            //        {
            //           value =(short)value,
            //        };

            //        this.rte.process.Add(vProcess);
            //        this.rte.SaveChanges();

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.InnerException.ToString());
            //    }
            //}
        }

    }
}
