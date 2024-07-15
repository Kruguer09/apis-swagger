using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPIJoseAFerreRic
{
    class ClasesJSON
    {
        public class ClaseJson
        {
            public List<Empleado> Users { get; set; }
        }

        public class Empleado
        {
            public string dni { get; set; }
            public string nombre { get; set; }
            public string direccion { get; set; }
            public string sexo { get; set; }
            public int empresaId { get; set; }
        }

    }
}
