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
    
    public partial class Comments
    {
        public int id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public string CommentText { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Courses Courses { get; set; }
        public virtual UserDB UserDB { get; set; }
    }
}
