using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Models
{
    public class UserEntity : IHasKey
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string userName { get; set; }

    }
}
