//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaijinSchool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeletedCourses
    {
        public int id { get; set; }
        public Nullable<int> idCourse { get; set; }
        public Nullable<System.DateTime> DateOfDeleting { get; set; }
    
        public virtual Courses Courses { get; set; }
    }
}
