using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Database.Models
{
    public interface IHasKey
    {
        public int id { get; set; }
    }
}
