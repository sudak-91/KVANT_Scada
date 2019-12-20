//using KVANT_Scada.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace KVANT_Scada.Log_Sub_System
//{
//    class Log_Sub_System
//    {
//        private Real_Tag_Entitys kvantDB { get; set; }
//        public valve_log vl;
        


//        public Log_Sub_System(Real_Tag_Entitys real_Tag_Entitys)
//        {
//            kvantDB = real_Tag_Entitys;
//            vl = new valve_log();
//        }
//        public void Add_to_LOG()
//        {
//            //var vValve = from g in kvantDB.valves select g ;
//            foreach (valves valvess in kvantDB.valves)
//            {
//                try
//                {
//                    vl.name = valvess.name;
//                    vl.closed = valvess.Closed;
//                    vl.opened = valvess.Opened;
//                    vl.TIME = System.DateTime.Now;
//                    kvantDB.valve_log.Add(vl);
//                    kvantDB.SaveChanges();
                   
                    
//                }catch (Exception ex)
//                {
//                    MessageBox.Show(ex.InnerException.ToString());
//                }



                
//            }



//        }
//    }
//}
