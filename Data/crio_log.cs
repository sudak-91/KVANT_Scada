//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KVANT_Scada.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class crio_log
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<bool> PowerOn { get; set; }
        public Nullable<bool> Blocked { get; set; }
        public Nullable<bool> TurnOn { get; set; }
        public Nullable<bool> AutoMode { get; set; }
        public Nullable<bool> Error { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    }
}
