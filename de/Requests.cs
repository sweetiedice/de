//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace de
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requests
    {
        public int RequestID { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public Nullable<int> RequestEquipment { get; set; }
        public Nullable<int> RequestTypeMalfunctions { get; set; }
        public string RequestDescriptionProblems { get; set; }
        public Nullable<int> RequestClient { get; set; }
        public Nullable<int> RequestStage { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual TypeMalfunctions TypeMalfunctions { get; set; }
    }
}
