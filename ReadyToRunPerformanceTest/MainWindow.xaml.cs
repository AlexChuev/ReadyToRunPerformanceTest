using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadyToRunPerformanceTest
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
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            ApplicationThemeHelper.ApplicationThemeName = Theme.Office2019ColorfulName;
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}