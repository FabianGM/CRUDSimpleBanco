using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BancoInicialBackEnd.Interfaces;
using BancoInicialBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoInicialBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BancoInicialController : ControllerBase
    {
        //private readonly ILogger<ParqueaderoController> _logger;
        private readonly IDatosBancoInicial _Service;
        /// <summary>
        /// Constructor para Inyección de dependencias
        /// </summary>
        /// <param name="oNombre"></param>
        public BancoInicialController(IDatosBancoInicial oNombre)
        {
            _Service = oNombre;
        }

        /// <summary>
        /// Registra Nombre y clave
        /// Verbo Post: /BancoInicial/Register
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public IActionResult Register([FromBody] ModPersonas oUser)
        {
            _Service.InsertarUsario(oUser);
            return Ok(oUser);
        }

        /// <summary>
        ///  Actualizar Usuario
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        [HttpPut("UpdateRegistro")]
        public IActionResult UpdateDatos([FromBody] ModPersonas oUser)
        {
            _Service.UpdateRegistro(oUser);
            return Ok(oUser);
        }

        // <summary>
        /// envia los datos del login
        /// Verbo Post: /BancoInicial/Login
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult DatosUser([FromBody] ModPersonas oUser)
        {
            bool VerificarUser=_Service.VerificarNombre(oUser);
            if (VerificarUser)
            {
                return Ok(oUser);
            }
            else
            {
                oUser.Nombre = "no";
                oUser.Clave = "no";
                return Ok("Acceso Denegado");
            }
            
        }

        /// <summary>
        ///  Ingresar Cuentas
        /// </summary>
        /// <param name="oTransporte"></param>
        /// <returns></returns>
        [HttpPost("IngresarCuentas")]
        public IActionResult IngresarCuenta([FromBody] ModCuenta oCuenta)
        {
            _Service.IngresarCuentas(oCuenta);
            return Ok(oCuenta);
        }


        /// <summary>
        /// Ingresar Movimientos
        /// </summary>
        /// <param name="oCuenta"></param>
        /// <returns></returns>
        [HttpPost("IngresarMovimientos")]
        public IActionResult IngresarMovimientos([FromBody] ModMovimientos oMovimientos)
        {
            _Service.IngresarMovimientos(oMovimientos);
            return Ok(oMovimientos);
        }
        

      
        [HttpDelete("EliminarCuenta/{Cliente}")]
        public IActionResult EliminarCuentas(string Cliente)
        {
            ModCuenta oCuenta = new ModCuenta();
            _Service.EliminarCuentas(Cliente);
            return Ok(oCuenta);
        }

        /// <summary>
        /// muestra los datos
        /// verbo: get
        /// </summary>
        /// <returns></returns>
        [HttpGet("DatosCuentas")]
        public IActionResult MuestraDeDatos()
        {
            return Ok(_Service.DatosCuenta());
        }

       
    }
}
