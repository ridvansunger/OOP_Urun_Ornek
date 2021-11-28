using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Urun_Ornek.Helper
{
    public class Utility
    {
        private readonly static string appName="Sipariş Ekranı";


        /// <summary>
        /// hatalar için
        /// </summary>
        /// <param name="message"></param>
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// başarılı eylemler
        /// </summary>
        /// <param name="message"></param>
        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// soru sormak için
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowDialogResultInformationMessage(string message)
        {
            DialogResult result = MessageBox.Show(message, appName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }


        /// <summary>
        /// Sipairişi bitirme mesajı
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult ShowDialogFinishOrderMessage(string message)
        {
            DialogResult result = MessageBox.Show(message, appName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }




    }
}
