﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quanlycybergams.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            this.DonHangs = new HashSet<DonHang>();
            this.HoaDons = new HashSet<HoaDon>();
            this.ThanhToanDVs = new HashSet<ThanhToanDV>();
        }

        [Display(Name = "ID Khách Hàng")]
        [Required(ErrorMessage = "Không được để trống")]
        public string ID_KhachHang { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        [Required(ErrorMessage = "Không được để trống")]
        public string TenKhachHang { get; set; }
        [Display(Name = "Số Diện Thoại")]
        public string SDT { get; set; }
        [Display(Name = "Giới tính")]
        public Nullable<bool> GioiTinh { get; set; }
        [Display(Name = "Thời Gian Gia Nhập")]
        [Required(ErrorMessage = "Không được để trống")]
        public Nullable<System.DateTime> ThoiGianGiaNhap { get; set; }
        [Display(Name = "Loại Khách Hàng")]
        [Required(ErrorMessage = "Không được để trống")]
        public string LoaiKhachHang { get; set; }
        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Không được để trống")]
        public string TenDN { get; set; }
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Matkhau { get; set; }
        [Display(Name = "Giá Máy")]
        public Nullable<decimal> GiaMay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToanDV> ThanhToanDVs { get; set; }
    }
}
