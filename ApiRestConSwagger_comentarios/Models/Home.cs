using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestConSwagger.Models
{
    public class Home
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }
        public int People { get; set; }

        //Propiedad navegacional
        public List<Hero> Heroes { get; set; }
    }
}
