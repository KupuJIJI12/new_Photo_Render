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
            image.Source = _render.Render(new ShadeFilter(), _path);
        }
        
        private void EdgeFilter_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new EdgeFilter(), _path);
        }
        
        private void UnSharpFilter_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new UnSharpFilter(), _path);
        }
        
        /*сохранение фотографии на компьютер
         реализация будет сделано кем-либо в Api*/
        private void SaveImageAs_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        /*применение фильтра
         при применении оригинальным изображением станет новое, отфильтрованное
         при этом, должен быть вызван метод RemoveUnusedTrash(), чтобы освободиться от мусора*/
        private void Apply_Click(object sender, RoutedEventArgs e)
        {

        }

        /*сброс фильтров и возврат к оригинальному изображению
         при сбросе все временные файлы(кроме последнего, см. комментарии) удаляются
         однако особенность, что последнее фильтрованное фото остается, может сыграть на руку и помочь в реализации
            метода 'вернуться к предыдущему варианту'*/
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri(_path));
            FileStorage.RemoveUnusedTrash();
        }

        /*метод, который по идее вызывается при закрытии приложения, но что-то работает не так*/
        private void Close_App(object sender, RoutedEventArgs e)
        {
            FileStorage.RemoveTrash();
        }


        private void input_zone_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //input_image.Source = new BitmapImage(new Uri("167 - 1670134_ - png - clipart.png")); почему-то не работает. Че-то со ссылкой.
                e.Effects = DragDropEffects.Copy;
                 
            }
        }

        private void input_zone_DragLeave(object sender, DragEventArgs e)
        {
            //input_image.Source = new BitmapImage(new Uri("167 - 1670134_ - png - clipart.png")); тож самое
        }

        private void input_zone_DragEnter(object sender, DragEventArgs e)
        {
            var inputImage = (string[]) e.Data.GetData(DataFormats.FileDrop);
            try
            {
                image.Source = new BitmapImage(new Uri(inputImage[0]));
                listBox.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}