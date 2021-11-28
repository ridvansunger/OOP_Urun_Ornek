using OOP_Urun_Ornek.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Urun_Ornek.DAL
{
    public class ProductRepository
    {

        /// <summary>
        /// urun ekleme
        /// </summary>
        /// <param name="item"></param>
        public void Add(Product item)
        {
            item.Id = (++ProductDataBaseFakedb.ProductTableId);
            ProductDataBaseFakedb.products.Add(item);
        }

        /// <summary>
        /// urun güncelleme
        /// </summary>
        /// <param name="item"></param>
        /// 

        //Girilen ürün bilgieri güncellenebilir.Geliştirilecek.
        public void Update(Product item)
        {
            var dbItem = FindById(item.Id);

            if (dbItem != null)
            {
                dbItem.ProductName = item.ProductName;
                dbItem.Price = item.Price;
                dbItem.Quantity = item.Quantity;

            }
        }

        /// <summary>
        /// id gönder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product FindById(int id)
        {

            Product product = ProductDataBaseFakedb.products.FirstOrDefault(t0 => t0.Id == id);
            return product;
        }

        /// <summary>
        /// listeyi gönder
        /// </summary>
        /// <returns></returns>
        public List<Product> Get()
        {

            return ProductDataBaseFakedb.products;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var dbItem = FindById(id);
            if (dbItem != null)
            {
                ProductDataBaseFakedb.products.Remove(dbItem);
            }
        }







    }
}
