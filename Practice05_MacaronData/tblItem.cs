//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practice05_MacaronData
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblItem()
        {
            this.tblOrderItems = new HashSet<tblOrderItem>();
        }
    
        public int itemID { get; set; }
        public string itemCategory { get; set; }
        public string itemName { get; set; }
        public Nullable<decimal> itemPPrice { get; set; }
        public Nullable<decimal> itemRPrice { get; set; }
        public string itemNote { get; set; }
        public string itemImage { get; set; }
        public Nullable<int> itemQty { get; set; }
        public Nullable<System.DateTime> itemRegisterDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderItem> tblOrderItems { get; set; }
    }
}
