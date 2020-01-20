using KVANT_Scada.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KVANT_Scada.Log_Sub_System
{
    class Log_Sub_System
    {
        private Real_Tag_Entitys kvantDB { get; set; }
        public action_log action_Log;



        public Log_Sub_System(Real_Tag_Entitys real_Tag_Entitys)
        {
            kvantDB = real_Tag_Entitys;
            
        }
        public void Add_to_LOG(string name, string action)
        {
            action_Log = new action_log
            {
                Name = name,
                Action = action,
                DateTime = System.DateTime.Now
            };
        this.kvantDB.action_log.Add(action_Log);
            this.kvantDB.SaveChanges();
           




            



        }
    }
}
