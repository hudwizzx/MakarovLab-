using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessFile_Click(object sender, RoutedEventArgs e)
        {
            string inputFilePath = InputFilePathTextBox.Text;
            bool removePunctuation = RemovePunctuationCheckBox.IsChecked ?? false;
            int minWordLength = int.Parse(MinWordLengthTextBox.Text);

            string text = File.ReadAllText(inputFilePath);
            text = RemoveShortWords(text, minWordLength);
            if (removePunctuation)
            {
                text = RemovePunctuation(text);
            }

            // Указываем путь для сохранения измененного текста
            string outputFilePath = @"G:\MakarovLab1\Output.txt";
            File.WriteAllText(outputFilePath, text);

            MessageBox.Show("File processed successfully and saved to " + outputFilePath);
        }

        private string RemoveShortWords(string text, int minLength)
        {
            return string.Join(" ", text.Split(' ').Where(word => word.Length >= minLength));
        }

        private string RemovePunctuation(string text)
        {
            return Regex.Replace(text, @"[^\w\s]", "");
        }

        private void RemovePunctuationCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}