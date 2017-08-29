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
using UrenregistratieClient.UrenregistratieService;

namespace UrenregistratieClient
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }
    
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Registreren r = new Registreren();
            r.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                bool l = uProxy.Login(GebruikersnaamBox.Text, WachtwoordBox.Password.ToString());
                if (l.Equals(false))
                {
                    Error.Text = "Er is geen combinatie bekend van deze gebruikersnaam/wachtwoord, probeer het opnieuw!";
                } else
                {
                    Project p = new Project();
                    p.Show();
                    this.Close();
                }
            }
        }
    }
}
