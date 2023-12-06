using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace GitPlanter
{
    /// <summary>
    /// Interaction logic for CommandDialog.xaml
    /// </summary>
    public partial class CommandDialog : Window
    {
        private ProcessStartInfo processStartInfo;
        public CommandDialog(ProcessStartInfo startInfo)
        {
            InitializeComponent();
            processStartInfo = startInfo;
            Title = $"{startInfo.FileName} {startInfo.Arguments}";
        }

        private async void _RunCommand()
        {
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;

            Process process = new Process
            {
                StartInfo = processStartInfo
            };

            process.OutputDataReceived += (sender, args) => UpdateTextBlock(args.Data);
            process.ErrorDataReceived += (sender, args) => UpdateTextBlock(args.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await Task.Run(() => process.WaitForExit());

            process.Close();

            confirmButton.IsEnabled = true;
        }

        private void UpdateTextBlock(string text)
        {
            Dispatcher.Invoke(() =>
            {
                outputTextBlock.Text += text + Environment.NewLine;
                //outputTextBlock.ScrollToEnd();
            });
        }

        private void outputTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            _RunCommand();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
