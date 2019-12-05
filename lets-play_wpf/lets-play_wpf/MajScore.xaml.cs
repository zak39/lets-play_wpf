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
using System.Windows.Shapes;

namespace lets_play_wpf
{
    /// <summary>
    /// Logique d'interaction pour MajScore.xaml
    /// </summary>
    public partial class MajScore : Window
    {
        public Database orthoDB = new Database("127.0.0.1", "root", "", "orthogenie");
        public DatabaseDataSet orthoDbDs = new DatabaseDataSet();

        public MajScore()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //orthoDB.UpdateOneElementDatabase(textBox1.Text, Convert.ToInt32(textBox2.Text)); // whithout DataSet
            orthoDbDs.UpdateOneElementDatabaseDataSet(txtbPrenom.Text, Convert.ToInt32(txtbScore.Text)); // with DataSet
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbPrenom.Text = string.Empty;
            txtbScore.Text = string.Empty;
        }
    }
}
