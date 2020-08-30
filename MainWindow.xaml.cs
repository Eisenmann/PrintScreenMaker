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
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading;

namespace PrintScreenMaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReadConfig();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
            
        }

        private void txtBoxFileDir_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            FolderBrowserDialog flDlg = new FolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            flDlg.ShowDialog();

            txtBoxFilePath.Text = flDlg.SelectedPath;
            
        }

        private void ReadConfig()
        {
            txtBoxInterval.Text = ConfigurationManager.AppSettings.Get("Key0");
            txtBoxFilePath.Text = ConfigurationManager.AppSettings.Get("Key1");
            Key1 = txtBoxFilePath.Text;
            Key0 = Convert.ToInt32(txtBoxInterval.Text);
        }

        
        private void SetConfig(int Key0, string Key1)
        {
            ConfigurationManager.AppSettings.Set("Key0", Key0.ToString());
            ConfigurationManager.AppSettings.Set("Key1", Key1.ToString());
        }

        int Key0;
        string Key1;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Key1 = txtBoxFilePath.Text;
            Key0 = Convert.ToInt32(txtBoxInterval.Text);
            SetConfig(Key0, Key1);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            timerStart();
        }

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
       
        private void timerStart()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, Key0);
            dispatcherTimer.Start();
        }

        MakeScreenShot mkScrnShoot = new MakeScreenShot();
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            mkScrnShoot.CaptureMyScreen(Key1);
        }
    }
}
