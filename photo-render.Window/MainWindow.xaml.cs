using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using photo_render.Api;
using photo_render.Api.Filters;

namespace photo_render.Window
{
    public partial class MainWindow
    {
        private readonly PhotoRender _render = PhotoRender.GetInstance();
        private string _path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadImage_Click(object sender, EventArgs e)
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
                listBox.IsEnabled = true;
            }
        }

        private void ShadeFilter_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new ShadeFilter(_path));
        }
        
        private void EdgeFilter_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new EdgeFilter(_path));
        }
        
        private void UnSharpFilter_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new UnSharpFilter(_path));
        }
        
        private void SaveImageAs_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri(_path));
            FileStorage.RemoveUnusedTrash();
        }

        private void Close_App(object sender, RoutedEventArgs e)
        {
            FileStorage.RemoveTrash();
        }
    }
}