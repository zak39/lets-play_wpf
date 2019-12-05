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
    /// Logique d'interaction pour Jeu.xaml
    /// </summary>
    public partial class Jeu : Window
    {
        public Jeu()
        {
            InitializeComponent();
        }

        public Orthogenie monjeu;   // J'ai eu l'idée mais c'est Arthur qui m'a indique de declarer mon constructeur d'objet de cette facon
        public Revision mode_revision;   // J'ai eu l'idée mais c'est Arthur qui m'a indique de declarer mon constructeur d'objet de cette facon
        public Database orthoDb = new Database("127.0.0.1", "root", "", "orthogenie");
        //public MySqlConnection connection;
        public DatabaseDataSet orthoDbDs = new DatabaseDataSet();

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            monjeu.joue(txtCharacter.Text[0]);
            txtCharacter.Text = "";
            txtblMotMystere.Text = monjeu.mot;
            monjeu.nbDeCoup -= 1;

            if (monjeu.nbDeCoup == 0)
            {
                txtblWin.Text = "Perdu ! Vous n'avez pas gagne mais vous avez " + monjeu.points + " points !";
                btnPlay.IsEnabled = false;
                txtblWin.IsEnabled = false;
                txtblWin.Visibility = Visibility;
                btnRegister.Visibility = Visibility;
                txtbPrenom.Visibility = Visibility;
                txtbScore.Visibility = Visibility;
            }

            if (monjeu.victoire)
            {
                txtblWin.Text = "Victoire ! Vous avez gagne avec " + monjeu.points + " points !";
                btnPlay.IsEnabled = false;
                txtblWin.IsEnabled = false;
                btnRegister.Visibility = Visibility;
                txtblWin.Visibility = Visibility;

                if (MainWindow.state_checkBox1)
                {
                    txtbPrenom.Visibility = Visibility;
                    txtbScore.Visibility = Visibility;

                    //textBox4.Visible = true;
                    //txtbScore.IsVisible = true;
                    txtbScore.Text = Convert.ToString(monjeu.points);

                    btnRegister.Visibility = Visibility;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            monjeu = new Orthogenie();
            if (MainWindow.state_checkBox1)
            {
                mode_revision = new Revision("unkwown");
            }
            monjeu.solution = MainWindow.motATrouve;
            monjeu.motMystere(monjeu.solution);
            monjeu.mode = MainWindow.mode_de_jeu;
            monjeu.nbDeCoup = monjeu.mot.Length;

            //txtbPrenom.Visibility = Hidden;
            //txtbScore.Visibility = Hidden;

            txtblWin.Text = monjeu.mot;
            txtblWin.IsEnabled = false;
            txtblMotMystere.Text = monjeu.mot;
            txtbPrenom.Text = string.Empty;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //mode_revision.prenom = textBox4.Text;
            //mode_revision.note = monjeu.points;
            string prenom = txtbPrenom.Text;
            int score = monjeu.points;
            //Form2.classer.classement.Add(mode_revision);

            // orthoDb.SaveDatabase(prenom, score); // without Data Set
            orthoDbDs.SaveDatabaseDataSet(prenom, score); // with Data Set

            //Form2.classer.Save(prenom, score);
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
