//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quanlycybergames.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class May
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public May()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
    
        public string ID_May { get; set; }
        public string TenMay { get; set; }
        public string TinhTrangMay { get; set; }
        public string ID_gia { get; set; }
        public Nullable<bool> HoatDong { get; set; }
    
        public virtual DonGia DonGia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
