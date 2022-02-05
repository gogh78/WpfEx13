using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Microsoft.Win32;
using System.IO;

namespace WpfEx13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int themStyle = 1;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void styleDark_Click(object sender, RoutedEventArgs e)
        {
            themStyle = 2;
            Uri uri = new Uri("DarkThem.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void styleLight_Click(object sender, RoutedEventArgs e)
        {
            themStyle = 1;
            Uri uri = new Uri("LightThem.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void ComboBox_SelectionFontName(object sender, SelectionChangedEventArgs e)
        //{
        //    string fName = (sender as ComboBox).SelectedItem.ToString();
        //    if (textBox != null)
        //    {
        //        textBox.FontFamily = new FontFamily(fName);
        //    }
        //}

        //private void ComboBox_SelectionFontSize(object sender, SelectionChangedEventArgs e)
        //{
        //    string fontSize = (sender as ComboBox).SelectedItem.ToString();
        //    if (textBox != null)
        //    {
        //        textBox.FontSize = Convert.ToDouble(fontSize);
        //    }
        //}


        bool Bold = false;
        private void Button_Bold(object sender, RoutedEventArgs e)
        {
            if (!Bold)
            {
                textBox.FontWeight = FontWeights.Bold;
                Bold = true;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
                Bold = false;
            }
        }

        bool Italic = false;
        private void Button_Italic(object sender, RoutedEventArgs e)
        {
            if (!Italic)
            {
                textBox.FontStyle = FontStyles.Italic;
                Italic = true;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
                Italic = false;
            }
        }

        bool Underline = false;
        private void Button_Underline(object sender, RoutedEventArgs e)
        {
            if (!Underline)
            {
                textBox.TextDecorations = TextDecorations.Underline;
                Underline = true;
            }
            else
            {
                textBox.TextDecorations = null;
                Underline = false;
            }
        }

        private void RadioButton_Checked_Black(object sender, RoutedEventArgs e)
        {
            RadioButton textBlack = (RadioButton)sender;
            Border textColor = textBlack.Content as Border;
            if (textBox != null)
            {
                if (themStyle == 1)
                {
                    if (textColor != null)
                    {
                        textColor.Background = Brushes.Black;
                    }
                    textBox.Foreground = Brushes.Black;
                }
                if (themStyle == 2)
                {
                    if (textColor != null)
                    {
                        textColor.Background = Brushes.White;
                    }
                    textBox.Foreground = Brushes.White;
                }
            }
        }

        private void RadioButton_Checked_Red(object sender, RoutedEventArgs e)
        {
            RadioButton textRed = (RadioButton)sender;
            Border textColor = textRed.Content as Border;
            if (textBox != null)
            {
                if (textColor != null)
                {
                    textColor.Background = Brushes.Red;
                }
                textBox.Foreground = Brushes.Red;
            }
        }


    }
}
