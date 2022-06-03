using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoInicialBackEnd.Models
{
    public class ModCuenta
    {
        public int ID_Cliente{ get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public string SaldoInicial { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
    }
}
