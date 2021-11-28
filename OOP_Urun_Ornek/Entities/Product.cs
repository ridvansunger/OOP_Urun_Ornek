using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Urun_Ornek
{
    public class Product


    {

        public int Id { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public enum Products
        {
            Bilgisayar,
            TV,
            MüzikKutusu,
            Masa,
            Sandalye,
            Telefon,
            Kalem,
            Ütü,
            Mouse,
            Kitaplık,
            Klavye,

        }

    }
}
