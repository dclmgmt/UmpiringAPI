using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UmpiringApi.Models
{
    public partial class TblRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
