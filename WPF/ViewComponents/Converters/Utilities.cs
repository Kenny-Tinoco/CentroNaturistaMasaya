using Microsoft.Win32;
using System;
using System.Windows;

namespace WPF.ViewComponents.Converters
{
    public static class Utilities
    {
        public static byte[] GetImage()
        {
            byte[] image = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo de imagen|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == true && openFileDialog.FileNames.Length == 1)
            {
                try
                {
                    System.IO.Stream stream;
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

        public static DateTime PlusOneYear(this DateTime element) => new DateTime(element.Year + 1, element.Month, element.Day);
    }
}
