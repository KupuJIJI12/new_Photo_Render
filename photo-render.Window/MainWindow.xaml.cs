using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using photo_render.Api.Bitmap;
using photo_render.Api.Filters;

namespace photo_render.Window
{
    public partial class MainWindow
    {
        private Bitmap Bitmap { get; set; }
        private PhotoRender _render = PhotoRender.GetInstance();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                FileName = "",
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                originalImage.Source = new BitmapImage(new Uri(dlg.FileName));
                filteredImage.Source = null;
            }
        }
        
        private void Grayscale_Click(object sender, RoutedEventArgs e)
        {
            CreateBitmap();
            var filter = new GrayScaleFilter(Bitmap.LoadPixels());
            filteredImage.Source = _render.Render(filter).ToBitmapSource();
        }

        private void CreateBitmap()
        {
            if (Bitmap is null)
                Bitmap = originalImage.ToBitmap();
        }
    }
}