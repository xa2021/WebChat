using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat5.Identity.Models
{
    public class ChatUser:IdentityUser<Guid>
    {

       
        [StringLength(100)]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? NickName { get; set; }
    }
}
