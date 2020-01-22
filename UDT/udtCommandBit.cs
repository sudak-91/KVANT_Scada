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

    class udtCommandBit
    {
        public bool value { get; set; }
        private int DB { get; set; }
        private int DBB { get; set; }
        private int DBX { get; set; }
        private Plc PLC { get; set; }
        private string name { get; set; }
        private Real_Tag_Entitys rte { get; set; }

        public udtCommandBit(Plc plc, int DB, int DBB, int DBX, Real_Tag_Entitys rte, string name)
        {
            this.PLC = plc;
            this.DB = DB;
            this.DBB = DBB;
            this.DBX = DBX;
            this.name = name;
            this.rte = rte;
            if (this.rte.command_bit.Find(this.DB, this.DBB,this.DBX) == null)
            {
                try
                {
                    command_bit vCommandBit = new command_bit
                    {
                        name = this.name,
                        DB = this.DB,
                        DBB = this.DBB,
                        DBX = this.DBX
                    };

                    this.rte.command_bit.Add(vCommandBit);
                    this.rte.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }
        }
        public void Write(bool value)
        {
            PLC.WriteBit(DataType.DataBlock, this.DB, this.DBB, this.DBX, value);
            command_bit vCommandBit = this.rte.command_bit.Find(this.DB, this.DBB, this.DBX);
            vCommandBit.Value = value;
            this.rte.SaveChanges();
           
        }
        public bool Read()
        {
            try
            {
                command_bit vCommandBit = this.rte.command_bit.Find(this.DB, this.DBB, this.DBX);
                vCommandBit.Value = (bool)this.PLC.Read(DataType.DataBlock, this.DB, this.DBB, VarType.Bit, 1,(byte)this.DBX);

                this.rte.SaveChanges();
                this.value = (bool)vCommandBit.Value;
                return  this.value;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
                return false;
            }
        }

    }
}
