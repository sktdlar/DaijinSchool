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
    
    public partial class ShoppingCartItem
    {
        public int id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ShoppingCartId { get; set; }
        public Nullable<int> CountOfItem { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
