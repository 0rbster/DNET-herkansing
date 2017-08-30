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
using UrenregistratieClient.UrenregistratieService;

namespace UrenregistratieClient
{
    /// <summary>
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Window
    {
        public string gebruiker { get; set; }

        public Project(string gebruiker)
        {
            InitializeComponent();
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                var takenlijst = uProxy.TakenOphalen(gebruiker);
                Console.WriteLine("ik kom hier");
                foreach (var t in takenlijst)
                {
                    Takenlijst.Items.Add(t);
                }
            }
                
        }
    }
}
