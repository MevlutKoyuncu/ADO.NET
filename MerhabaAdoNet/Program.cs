using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MerhabaAdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Ado İle Veri Çekme - Kategori Sayısını Çekelim

            ////1 - Bağlantı
            //SqlConnection baglanti = new SqlConnection();

            ////2 - Bağlantı Yolu
            //baglanti.ConnectionString = @"Data Source=DESKTOP-LBVEF6F;Initial Catalog=NORTHWND; Integrated Security=True;";

            ////3 - Komut
            //SqlCommand komut = new SqlCommand();
            //komut.Connection = baglanti;

            ////4 - Komut Metni
            //komut.CommandText = "SELECT COUNT(*) FROM Categories";

            ////5 - Bağlantı Aç
            //baglanti.Open();

            ////6 - Sorgu Çalıştır
            //int sayi = (int)komut.ExecuteScalar();

            ////7 - Bağlantı Kapat
            //baglanti.Close();

            //Console.WriteLine("Kategori Sayısı = " + sayi);

            #endregion

            #region Üstteki sorguyu azıcık kısaltalım

            //SqlConnection baglanti = new SqlConnection(@"Data Source= .; Initial Catalog= NORTHWND; Integrated Security=True");

            //SqlCommand komut = baglanti.CreateCommand();

            //komut.CommandText = "SELECT COUNT(*) FROM Products";

            //baglanti.Open();

            //int sayi = Convert.ToInt32(komut.ExecuteScalar());
            //Console.WriteLine("Ürün sayısı = " + sayi);

            //baglanti.Close();


            #endregion

            #region Kategori ekleyelim

            //Console.WriteLine("NORTHWIND'A VERİTABANINA HOŞGELDİNİZ");
            //Console.WriteLine("*************************************");
            //Console.WriteLine("Kategori Adı = ");
            //string isim = Console.ReadLine();
            //Console.WriteLine("Açıklama = ");
            //string aciklama = Console.ReadLine();

            //SqlConnection baglanti = new SqlConnection(@"Data Source= .; Initial Catalog= NORTHWND; Integrated Security=True");

            //SqlCommand komut = baglanti.CreateCommand();
            //komut.CommandText = "INSERT INTO Categories(CategoryName, Description) VALUES ('"+isim+"','"+aciklama+"')";

            //baglanti.Open();
            //komut.ExecuteNonQuery();
            //baglanti.Close();



            #endregion

            #region Kategorileri Listeleyelim

            //SqlConnection baglanti = new SqlConnection(@"Data Source= .; Initial Catalog= NORTHWND; Integrated Security=True");
            //SqlCommand komut = baglanti.CreateCommand();
            //komut.CommandText = "SELECT CategoryID, CategoryName, Description FROM Categories";
            //baglanti.Open();
            //SqlDataReader okuyucu = komut.ExecuteReader();
            //while (okuyucu.Read())//Read komutu okunmamaış satır var ise true döndürür.
            //{
            //    int id = okuyucu.GetInt32(0);
            //    string isim = okuyucu.GetString(1);
            //    string aciklama = "";
            //    if(!okuyucu.IsDBNull(2))
            //    {
            //        aciklama = okuyucu.GetString(2);
            //    }
            //    else
            //    {
            //        aciklama = "Açıklamaya gerek yok";
            //    }

            //    Console.WriteLine($"{id}) {isim} - {aciklama}");
            //}
            //baglanti.Close();


            #endregion

            #region Kategorideki ürünler

            SqlConnection baglanti = new SqlConnection(@"Data Source= .; Initial Catalog= NORTHWND; Integrated Security=True");
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = "SELECT CategoryID, CategoryName, Description FROM Categories";
            baglanti.Open();
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())//Read komutu okunmamaış satır var ise true döndürür.
            {
                int id = okuyucu.GetInt32(0);
                string isim = okuyucu.GetString(1);
                string aciklama = "";
                if (!okuyucu.IsDBNull(2))
                {
                    aciklama = okuyucu.GetString(2);
                }
                else
                {
                    aciklama = "Açıklamaya gerek yok";
                }

                Console.WriteLine($"{id}) {isim} - {aciklama}");
            }
            baglanti.Close();

            Console.WriteLine("Lütfen ürünlerini listelemek istediğiniz kategorinin numarasını giriniz");
            string katno = Console.ReadLine();
          
            SqlConnection baglanti2 = new SqlConnection(@"Data Source= .; Initial Catalog= NORTHWND; Integrated Security=True");
            SqlCommand komut2 = baglanti2.CreateCommand();

            komut2.CommandText = "SELECT ProductID,ProductName, UnitPrice, UnitsInStock FROM Products WHERE CategoryID=" + katno; //OR 1=1-- SQL INJECTION
            baglanti2.Open();
            SqlDataReader okuyucu2 = komut2.ExecuteReader();

            while (okuyucu2.Read())
            {
                int id = okuyucu2.GetInt32(0);
                string isim = okuyucu2.GetString(1);
                decimal fiyat = okuyucu2.GetDecimal(2);
                short stok = okuyucu2.GetInt16(3);
                Console.WriteLine($"{id}) {isim} \t{stok} \t{fiyat}TL");
            }
            #endregion

        }
    }
}
