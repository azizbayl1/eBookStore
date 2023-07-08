using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.DTOs.UserRolesDTO
{
    public class UserRolesDTO
    {
        public int UserId { get; set; }

        [Required]
        public List<int> RoleIds { get; set; }
    }
}
