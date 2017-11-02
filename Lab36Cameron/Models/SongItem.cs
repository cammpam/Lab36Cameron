using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab36Cameron.Models
{
    public class SongItem
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public bool Audio { get; set; }
    }
}
