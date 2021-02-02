using System;
using System.Drawing;
using System.IO;
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
        private string _path;
        private static bool _isChanged = false;
       // DirectoryInfo dirImages; 
        
        public MainWindow()
        {
            InitializeComponent();
           // dirImages = new DirectoryInfo("~\\Images");
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
                image.Source = new BitmapImage(new Uri(dlg.FileName));
                _path = dlg.FileName;
            }
        }
        
        private void ShadeFilter_Click(object sender, RoutedEventArgs e)
        {
            if (_isChanged)
            {
                
                File.Delete("~\\Images\\");
                //_isChanged = false;
            }
            image.Source = new BitmapImage(new Uri(_render.Render(new ShadeFilter(_path))));
            _isChanged = true;

        }
        
        private void EdgeFilter_Click(object sender, RoutedEventArgs e)
        {
            if (_isChanged)
            {
                
                File.Delete("~\\Images\\");
                //_isChanged = false;
            }
            image.Source = new BitmapImage(new Uri(_render.Render(new EdgeFilter(_path))));
            _isChanged = true;

        }

        private void SaveImageAs_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}