using KVANT_Scada.Data;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KVANT_Scada.UDT
{
    class Real_type
    {
        public double value { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private Plc PLC { get; set; }
        private string name { get; set; }
        private Real_Tag_Entitys rte { get; set; }



        public Real_type(Plc plc, int DB, int DBB, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.name = name;
            this.rte = rte;
            if (this.rte.real.Find(this.DB, this.DBB)==null)
                {
                try
                {
                    real real_tag = new real
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                    };

                    this.rte.real.Add(real_tag);
                    this.rte.SaveChanges();

                } catch (Exception ex)
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
                real real_tag = this.rte.real.Find(this.DB, this.DBB);
                {
                    real_tag.Value = this.value;
                    real_log rl = new real_log
                    {
                        name = real_tag.name,
                        value = (float)real_tag.Value,
                        TIME = DateTime.Now,
                    };
                    rte.real_log.Add(rl);
                    this.rte.SaveChanges();
                }
                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());

            }
        }
        public void Write_type(double value)
        {
            this.PLC.Write(DataType.DataBlock, this.DB, this.DBB, value);
            real real_tag = rte.real.Find(this.DB, this.DBB);
            real_tag.Value = value;
            rte.SaveChanges();
            this.value = value;
           
        }
    }
}
