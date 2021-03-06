﻿using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using photo_render.Api;
using photo_render.Api.Filters;
using Image = System.Windows.Controls.Image;

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


        //метод используется для отрисовки анимации(хотя мб он и не нужен)
        private void InputZoneDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //input_image.Source = new BitmapImage(new Uri("167 - 1670134_ - png - clipart.png")); почему-то не работает. Че-то со ссылкой.
                e.Effects = DragDropEffects.Copy;
                 
            }
        }

        //метод используется для замены картинки интерфейса(плюсик)
        private void InputZoneDropDragLeave(object sender, DragEventArgs e)
        {
            //input_image.Source = new BitmapImage(new Uri("167 - 1670134_ - png - clipart.png")); тож самое
        }

        //метод используется отвечает за копирование объекта в Image
        private void InputZoneDragEnter(object sender, DragEventArgs e)
        {
            var inputImage = (string[]) e.Data.GetData(DataFormats.FileDrop);
            try
            {
                image.Source = new BitmapImage(new Uri(inputImage[0]));
                _path = inputImage[0];
                listBox.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
        
        private void Field_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                var contextMenu = image.ContextMenu;
                contextMenu.PlacementTarget = image;
                contextMenu.IsOpen = true;
            }

            var itemsContMenu =  image.ContextMenu.Items;
            ((MenuItem) itemsContMenu[0]).IsEnabled = image.Source != null;
        }
        
        private void Copy_OnClick(object sender, RoutedEventArgs e) 
            => Clipboard.SetImage((BitmapSource) image.Source);

        private void Paste_OnClick(object sender, RoutedEventArgs e)
        {
            image.Source = Clipboard.GetImage();
            if(image.Source != null)
                listBox.IsEnabled = true;
        }
        
        //Action методы фильтров
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

        private void BlueShift_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new BlueShiftFilter(), _path);
        }

        private void BlurFilter_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new BlurFilter(), _path);
        }

        private void CannyEdge_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new CannyEdgeFilter(), _path);
        }

        private void ContrastStretch_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new ContrastStretchFilter(), _path);
        }

        private void Grayscale_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new GrayscaleFilter(), _path);
        }

        private void Negative_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new NegativeFilter(), _path);
        }

        private void Normalize_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new NormalizeFilter(), _path);
        }

        private void OilPaint_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new OilPaintFilter(), _path);
        }

        private void Posterize_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new PosterizeFilter(), _path);
        }

        private void SepiaTone_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new SepiaToneFilter(), _path);
        }

        private void Sharpen_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new SharpenFilter(), _path);
        }

        private void Solarize_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new SolarizeFilter(), _path);
        }

        private void WaveletDenoise_Click(object sender, RoutedEventArgs e)
        {
            image.Source = _render.Render(new WaveletDenoiseFilter(), _path);
        }
    }
}