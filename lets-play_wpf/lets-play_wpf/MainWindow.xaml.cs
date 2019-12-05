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
// Ajout de using
using MySql.Data.MySqlClient;

namespace lets_play_wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string motATrouve;
        public static Mode mode_de_jeu;
        public static Revision mode_revision;
        public static bool state_checkBox1;
        public static Classe classer = new Classe();
        public Database orthoDb = new Database("127.0.0.1", "root", "", "orthogenie");
        public DatabaseDataSet orthoDbDs = new DatabaseDataSet();

        private void btnPendu_Click(object sender, RoutedEventArgs e)
        {
           
            if (txtMoMystere.Text != "")
            {
                motATrouve = txtMoMystere.Text;
                mode_de_jeu = Mode.pendu;

                this.Hide();
                Jeu window = new Jeu();
                window.Show();
            }
            else
            {
                // Ouvrir message d'alerte
            }
        }

        private void btnBescherelle_Click(object sender, RoutedEventArgs e)
        {
            if (txtMoMystere.Text != "")
            {
                motATrouve = txtMoMystere.Text;
                mode_de_jeu = Mode.bescherelle;

                this.Hide();
                Jeu window = new Jeu();
                window.Show();

            }
            else
            {
                // Ouvrir un message d'alerte
            }
        }

        private void cbRevision_Checked(object sender, RoutedEventArgs e)
        {
            cbRevision.IsEnabled = true;
            state_checkBox1 = cbRevision.IsEnabled;
        }

        private void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            //orthoDb.ChargeDatabase(); // without dataset
            orthoDbDs.ChargeDatabaseDataSet(); // with dataset
            txtTableScores.Clear();
            txtTableScores.AppendText("Prenom\t\t\tScore" + "\r\n");
            txtTableScores.AppendText(orthoDb.AfficherDatabase());
        }

        private void btnUpdateScore_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MajScore window = new MajScore();
            window.Show();
        }

        private void btnDeleteDatabase_Click(object sender, RoutedEventArgs e)
        {
            orthoDb.DeleteAllDatabase(); // without Data Set
            //orthoDbDs.DeleteDatabaseDataSet(); // With Data Set
            txtTableScores.Clear();
            txtTableScores.AppendText("Prenom\t\t\tScore" + "\r\n");
            txtTableScores.AppendText(orthoDb.AfficherDatabase());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTableScores.Text = string.Empty;
            txtMoMystere.Text = string.Empty;
            txtTableScores.AppendText("Prenom\t\t\tScore" + "\r\n");
            //textBox2.AppendText(orthoDb.AfficherDatabase());              // whithout Data Set
            txtTableScores.AppendText(orthoDbDs.AfficherDatabaseDataSet());       // With Data Set
        }

        private void txtTableScores_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
