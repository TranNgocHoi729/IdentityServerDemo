using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Permission
    {
        public string Id { get; set; }

        public string PermissionName { get; set; }

        public string PermissionCode { get; set; }

        public int PermissionOrder { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public Status Status { get; set; }

        public string Description { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
