using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelos
{
    public class RespostaCashback
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        public decimal Valor { get; set; }
    }
}
