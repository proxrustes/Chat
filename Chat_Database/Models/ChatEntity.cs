using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Models
{
    public class ChatEntity : IHasKey
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string chatName { get; set; }
        public ICollection<UserEntity> users { get; set; }
    }
}
