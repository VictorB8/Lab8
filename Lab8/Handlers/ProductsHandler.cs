using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab8.Handlers
{
    public class ProductsHandler
    {
        private SqlConnection conexion;
        private string rutaConexion;

        public ProductsHandler()
        {
            rutaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            conexion = new SqlConnection(rutaConexion);
        }

        private DataTable crearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }
        public IEnumerable<Products> GetAll()
        {
            IEnumerable<Products> productsList;
            List<Products> products = new List<Products>();
            string consulta = "SELECT * FROM Products ";
            DataTable tablaResultado = crearTablaConsulta(consulta);

            foreach (DataRow columna in tablaResultado.Rows)
            {
                products.Add(
                    new Products
                    {
                        id = Convert.ToInt32(columna["id"]),
                        quantity = Convert.ToInt32(columna["quantity"]),
                        name = Convert.ToString(columna["name"]),
                        price = Convert.ToDecimal(columna["price"])
                    });
            }
            productsList = products;
            return productsList;

        }
    }
}