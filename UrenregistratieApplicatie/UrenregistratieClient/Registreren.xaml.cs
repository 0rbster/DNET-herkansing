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
using System.Windows.Navigation;
using UrenregistratieClient.UrenregistratieService;

namespace UrenregistratieClient
{
    /// <summary>
    /// Interaction logic for Registreren.xaml
    /// </summary>
    public partial class Registreren : Window
    {
        public Registreren()
        {
            InitializeComponent();
        }

        private void Registreer_Click(object sender, RoutedEventArgs e)
        {
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                var r = uProxy.Registreer(Gebruikersnaambox.Text);
                if (r.Equals(true))
                {
                    MainWindow l = new MainWindow();
                    char[] charArray = Gebruikersnaambox.Text.ToCharArray();
                    Array.Reverse(charArray);
                    var ww = new string(charArray);
                    l.Error.Text = "U account is aangemaakt! Uw wachtwoord is: " + ww;
                    l.Show();
                    this.Close();
                } else
                {
                    MessageBlock.Text = "Er bestaat al een account met deze gebruikersnaam, probeer het opnieuw.";
                    Gebruikersnaambox.Text = "";
                }
            }
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            MainWindow l = new MainWindow();
            l.Show();
            this.Close();
        }
    }
}
