using System;
using System.Collections.Generic;

namespace UmpiringApi.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public int? RoleID { get; set; }

        public virtual TblRole TblRole { get; set; }
    }
}
