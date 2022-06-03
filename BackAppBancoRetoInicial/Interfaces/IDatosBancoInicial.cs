using BancoInicialBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoInicialBackEnd.Interfaces
{
    public interface IDatosBancoInicial
    {
        /// <summary>
        /// Interfaz para insertar el usuario y la clave
        /// </summary>
        /// <param name="oUsuario"></param>
        public void InsertarUsario(ModPersonas oUsuario);
        /// <summary>
        /// Verificar Usuario
        /// </summary>
        /// <param name="oUsuario"></param>
        public bool VerificarNombre(ModPersonas oUsuario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oUsuario"></param>
        /// <returns></returns>
        public void IngresarCuentas(ModCuenta oUsuario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMovimientos"></param>
        public void IngresarMovimientos(ModMovimientos oMovimientos);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPersonas"></param>
        public void UpdateRegistro(ModPersonas oPersonas);

        public void EliminarCuentas(string Cliente);

        public List<ModCuenta> DatosCuenta();
    }
}
