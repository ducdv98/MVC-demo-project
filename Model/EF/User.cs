using System.ComponentModel;

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [DisplayName("Tên đăng nhập")]
        [StringLength(50)]
        public string UserName { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(32)]
        public string Password { get; set; }

        [DisplayName("Họ và tên")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Địa chỉ")]
        [StringLength(50)]
        public string Address { get; set; }

        [DisplayName("E-mail")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [DisplayName("Kích hoạt")]
        public bool Status { get; set; }
    }
}
