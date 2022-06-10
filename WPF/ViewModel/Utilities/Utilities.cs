using Domain.Entities;
using Domain.Entities.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace WPF.ViewModel.Utilities
{
    public static class Utilities
    {
        public static byte[] GetImage()
        {
            byte[] image = null;
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Archivo de imagen|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == true && openFileDialog.FileNames.Length == 1)
            {
                try
                {
                    Stream stream;
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            image = new byte[stream.Length];
                            stream.Read(image, 0, (int)stream.Length);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede subir la imagen " + ex.Message);
                }
            }
            return image;
        }


        public static string GetName(this bool status) => status ? "Activo" : "Inactivo";

        public static DateTime PlusOneYear(this DateTime element) => element.AddYears(1);

        public static IEnumerable<Type> ToEnumerable<Type>(this ObservableCollection<TransactionDetailView> listing)
            where Type : TransactionDetail, new() =>
            listing.Select(item => new Type()
            {
                IdStock = item.IdStock,
                Quantity = item.Quantity,
                Price = item.Price,
                Total = item.Total
            });
    }
}
