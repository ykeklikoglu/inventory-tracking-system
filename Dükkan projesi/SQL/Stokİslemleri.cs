using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class Stokİslemleri
    {
        public static SQL.SqlTanımı bag = new SQL.SqlTanımı();
        public static String StoklarıGuncelleByID(int UrunId, int StokIstanbul, int StokHasköy, int StokEsenboga, int StokCubuk)
        {
            #region
            /// <summary>
            /// Stoklar bu method ile Güncellenir.
            /// İstanbuLCadStok
            /// HasköyStok
            /// EsenbogaStok
            /// CubukStok
            /// nekadar=(+/-) x
            /// </summary>
            /// <returns></returns>
            #endregion Fonksiyon Yardım..

            Model.Urun urunum = SQL.UrunServis.GetUrunByID(UrunId.ToString());
            SqlConnection baglanti = bag.BaglantiAl();
            SqlCommand Komut = baglanti.CreateCommand();
            string query = @"UPDATE Urun
                    SET İstanbuLCadStok=@StokIstanbul,HasköyStok=@StokHasköy,EsenbogaStok=@StokEsenboga,CubukStok=@StokCubuk
                    WHERE UrunID=@ID";
            Komut.CommandText = query;
            SqlParameter Id = new SqlParameter("@ID", SqlDbType.Int);
            Id.Value = UrunId;
            SqlParameter Sı = new SqlParameter("@StokIstanbul", SqlDbType.Int);
            Sı.Value = urunum.Stokİstcad - StokIstanbul;
            SqlParameter Hs = new SqlParameter("@StokHasköy", SqlDbType.Int);
            Hs.Value = urunum.StokHasköy - StokHasköy;
            SqlParameter Es = new SqlParameter("@StokEsenboga", SqlDbType.Int);
            Es.Value = urunum.StokEsenboga - StokEsenboga;
            SqlParameter Cs = new SqlParameter("@StokCubuk", SqlDbType.Int);
            Cs.Value = urunum.StokCubuk - StokCubuk;
            Komut.Parameters.Add(Id);
            Komut.Parameters.Add(Sı);
            Komut.Parameters.Add(Hs);
            Komut.Parameters.Add(Es);
            Komut.Parameters.Add(Cs);
            SqlDataReader reader = Komut.ExecuteReader();
            return ("Stok Güncelleme Basarılı.");
        }
    }
}