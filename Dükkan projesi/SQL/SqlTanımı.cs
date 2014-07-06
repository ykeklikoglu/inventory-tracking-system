using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class SqlTanımı
    {
        public SqlConnection BaglantiAl()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString =@"Data Source=Keklikoğlu-PC;Initial Catalog=Projem;User ID=sa;
            Password=123;Integrated Security=True";
            baglanti.Open();

            return baglanti;
        }
    }
}