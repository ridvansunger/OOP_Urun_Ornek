using OOP_Urun_Ornek.Core;
using OOP_Urun_Ornek.DAL;
using OOP_Urun_Ornek.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OOP_Urun_Ornek.Product;

namespace OOP_Urun_Ornek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductRepository productRepository;


        private void Form1_Load(object sender, EventArgs e)
        {
            productRepository = new ProductRepository();
            FillForm();
        }

        private void FillForm()
        {
            string[] urunListem = Enum.GetNames(typeof(Products));
            cmbUrunler.Items.AddRange(urunListem);
            cmbUrunler.SelectedIndex = 0;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = cmbUrunler.SelectedItem.ToString();

                if (nuAdet.Value == 0)
                {
                    MessageBox.Show("Lütfen Adet giriniz.");
                    return;
                }
                else
                {
                    product.Quantity = nuAdet.Value;
                }


                if (nuFiyat.Value == 0)
                {
                    MessageBox.Show("Lütfen Fiyat Giriniz.");
                    return;
                }
                else
                {
                    product.Price = (nuFiyat.Value) * (product.Quantity);
                }



                if (product.Id == 0)
                {
                    productRepository.Add(product);

                }
                else
                {
                    productRepository.Update(product);
                }

                RefreshProduct();

                Utility.ShowSuccessMessage(ConstMessages.RecordSuccessMessage);


                FormClear();

                ToplamFiyatGüncelle();
                UrunAdetGüncelle();


            }
            catch (Exception ex)
            {

                Utility.ShowErrorMessage(ex.Message);
            }

        }

        private void UrunAdetGüncelle()
        {
            decimal toplamAdet = grdProduct.Rows.Cast<DataGridViewRow>().Sum(row => Convert.ToDecimal(row.Cells[3].Value));

            lblQuantity.Text = $"{toplamAdet.ToString()} Adet";
        }

        private void ToplamFiyatGüncelle()
        {

            decimal toplamFiyat = grdProduct.Rows.Cast<DataGridViewRow>().Sum(row => Convert.ToDecimal(row.Cells[2].Value));

            lblToplamFiyat.Text = $"{toplamFiyat.ToString()} TL";
        }

        private void FormClear()
        {
            cmbUrunler.SelectedIndex = 0;
            nuAdet.Value = 0M;
            nuFiyat.Value = 0M;
        }

        private void RefreshProduct()
        {
            grdProduct.DataSource = null;
            grdProduct.DataSource = productRepository.Get();

            GridProductColumnVisibility();
        }

        private void GridProductColumnVisibility()
        {
            //kapatılacak olan kolon
            grdProduct.Columns["Id"].Visible = false;


            //header text bilgisi değişenler
            grdProduct.Columns["ProductName"].HeaderText = "Ürün Adı";
            grdProduct.Columns["Price"].HeaderText = "Ürün Fiyatı";
            grdProduct.Columns["Quantity"].HeaderText = " Ürün Miktarı";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {

                if (grdProduct.SelectedRows.Count > 0)
                {
                    var result = Utility.ShowDialogResultInformationMessage(ConstMessages.RecordDeleteQuestionMessage);

                    if (result == DialogResult.OK)
                    {
                        var items = grdProduct.DataSource as List<Product>;
                        int index = grdProduct.SelectedRows[0].Index;
                        var item = items[index];

                        if (item != null)
                        {
                            productRepository.Delete(item.Id);
                            Utility.ShowSuccessMessage(ConstMessages.RecordDeleteQuestionMessage);

                        }
                    }
                }

                RefreshProduct();
                ToplamFiyatGüncelle();
                UrunAdetGüncelle();
            }
            catch (Exception ex)
            {

                Utility.ShowErrorMessage(ex.Message);
            }
            
        }

        private void btnSiparişiTamamla_Click(object sender, EventArgs e)
        {
            DialogResult result = Utility.ShowDialogFinishOrderMessage(ConstMessages.RecordFinishOrderMessage);
            if(result==DialogResult.OK)
            {
                RefreshProduct();
                ToplamFiyatGüncelle();
                UrunAdetGüncelle();

                MessageBox.Show($"Siparişiniz alındı. \n Sipariş Özetiniz: \n Sipariş Toplam Fiyat ={lblToplamFiyat.Text.ToString()} \n Sipariş Toplam Adet ={lblQuantity.Text.ToString()} \n şeklindedir.");


                EkranıTemizle();
            }

            else
            {
                MessageBox.Show("Siparişiniz tamamlanmadı");
            }

        }
        private void EkranıTemizle()
        {
            cmbUrunler.SelectedIndex = 0;
            nuAdet.Value = 0;
            nuFiyat.Value = 0;
            lblQuantity.Text = "0 Adet";
            lblToplamFiyat.Text = "0 TL";
            grdProduct.DataSource = null;
        }
    }
}
