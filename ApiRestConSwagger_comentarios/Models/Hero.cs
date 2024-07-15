using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestConSwagger.Models
{
    //Relación 1:N
    //Hay muchos Heroes en una Home
    public class Hero
    {
        
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [DefaultValue (false)]
        public bool IsBad { get; set; }
        
        [Required]
        //Foreign Key
        public long HomeId { get; set; }

    }
}
