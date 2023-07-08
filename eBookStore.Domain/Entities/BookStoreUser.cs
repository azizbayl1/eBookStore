using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Domain.Entities
{
    public class BookStoreUser : IdentityUser<int> 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public DateTime DateOfBirth { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}