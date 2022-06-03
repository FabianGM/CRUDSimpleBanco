using BancoInicialBackEnd;
using BancoInicialBackEnd.Interfaces;
using BancoInicialBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ParqueaderoBackEnd.Servicios
{
    /// <summary>
    /// Servicios para la conexión con la base de datos
    /// </summary>
    public class SrvoDatosBancoInicial: IDatosBancoInicial
    {
        const string cadenaConexion = "Data Source=BancoInicial.db;Version=3;New=True;Compress=True;";
        private SQLiteCommand sql_cmd;
        private string txtQuery;
        SQLiteConnection sql_con = new SQLiteConnection(cadenaConexion);
        /// <summary>
        /// Insertar un usuario en la base de datos
        /// </summary>
        /// <param name="oUsuario"></param>
        public void InsertarUsario(ModPersonas oUsuario)
        {
            try
            {
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                txtQuery = "insert into Cliente (Nombres, Direccion, Telefono, Clave, Estado) values ('" + oUsuario.Nombre + "','" + oUsuario.Direccion + "','" + oUsuario.Telefono + "','" + oUsuario.Clave + "','" + oUsuario.Estado + "');";
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// verificar un usuario existente en la base de datos
        /// </summary>
        /// <param name="oUsuario"></param>
        /// <returns></returns>
        public bool VerificarNombre(ModPersonas oUsuario)
        {
            try
            {
                sql_con.Open();
                string stm = "SELECT * FROM Cliente";
                using var cmd = new SQLiteCommand(stm, sql_con);
                using SQLiteDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    if (oUsuario.Nombre == rdr.GetString(1) && oUsuario.Clave == rdr.GetString(4))
                    {
                        Console.WriteLine("acceso autorizado");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCuenta"></param>
        public void IngresarCuentas(ModCuenta oCuenta)
        {
            try
            {
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                txtQuery = "insert into Cuentas (ID_Cliente, NumeroCuenta, Tipo, SaldoInicial, Estado, Cliente) values ('" + oCuenta.ID_Cliente + "','" + oCuenta.NumeroCuenta + "','" + oCuenta.Tipo + "','" + oCuenta.SaldoInicial + "','" + oCuenta.Estado + "','" + oCuenta.Nombre + "');";
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMovimientos"></param>
        public void IngresarMovimientos(ModMovimientos oMovimientos)
        {
            try
            {
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                txtQuery = "insert into MovimientoInicial (NumeroCuenta,Tipo, SaldoInicial, Estado, Movimiento, SaldoDisponible) values ('" + oMovimientos.NumeroCuenta + "','" + oMovimientos.Tipo + "','" + oMovimientos.SaldoInicial + "','" + oMovimientos.Estado + "','" + oMovimientos.Movimiento + "','" + oMovimientos.SaldoDisponible + "');";
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oMovimientos"></param>
        public void UpdateRegistro(ModPersonas oPersonas)
        {
            try
            {
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                txtQuery = "update Cliente set Telefono='"+ oPersonas.Telefono + "' where Nombres ='"+ oPersonas.Nombre + "'";
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
      

        public void EliminarCuentas(string Cliente)
        {
            try
            {
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                txtQuery = "delete from Cuentas where ID_Cliente ='" + Cliente + "'";
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        /// <summary>
        /// muestra los datos del parqueadero
        /// </summary>
        /// <returns></returns>
        public List<ModCuenta> DatosCuenta()
        {
            List<ModCuenta> oDatosSO = new List<ModCuenta>();
            ModCuenta oDatosMod;
            sql_con.Open();
            string stm = "SELECT * FROM Cuentas";
            using var cmd = new SQLiteCommand(stm, sql_con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                oDatosMod = new ModCuenta();
                oDatosMod.ID_Cliente = rdr.GetInt32(1);
                oDatosMod.NumeroCuenta = rdr.GetString(2);
                oDatosMod.Tipo = rdr.GetString(3);
                oDatosMod.SaldoInicial = rdr.GetString(4);
                oDatosMod.Estado = rdr.GetString(5);
                oDatosMod.Nombre = rdr.GetString(6);
                oDatosSO.Add(oDatosMod);
            }
          
            return oDatosSO;
        }
        public void EliminarTransporte(string Placa)
        {
            throw new NotImplementedException();
        }
    }
}
