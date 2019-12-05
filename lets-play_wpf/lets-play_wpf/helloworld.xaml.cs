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
    /// Logique d'interaction pour helloworld.xaml
    /// </summary>
    public partial class helloworld : Window
    {
        public helloworld()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
