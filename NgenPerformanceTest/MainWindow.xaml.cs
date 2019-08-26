using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

namespace NgenPerformanceTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            grid.Children.Add(new GridControl() { Width = 0, Height = 0 });
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ngen("install");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Ngen("uninstall");
        }

        static void Ngen(string action)
        {
            string runtimeStr = RuntimeEnvironment.GetRuntimeDirectory();
            string ngenStr = Path.Combine(runtimeStr, "ngen.exe");
            string dir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(dir);
            var file = Path.Combine(dir, "run.bat");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"""{ngenStr}"" ""{action}"" ""{Assembly.GetExecutingAssembly().Location}"" /nologo");
            File.WriteAllText(file, sb.ToString());
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $@"/C {file}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    Verb = "runas"
                }
            };
            process.Start();
            process.WaitForExit();
            process.Dispose();
        }
    }
}