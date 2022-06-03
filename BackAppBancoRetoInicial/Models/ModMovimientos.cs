using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoInicialBackEnd.Models
{
    public class ModMovimientos
    {
        public string NumeroCuenta{ get; set; }
        public string Tipo { get; set; }
        public string SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string Movimiento { get; set; }
        public string SaldoDisponible { get; set; }
    }
}
