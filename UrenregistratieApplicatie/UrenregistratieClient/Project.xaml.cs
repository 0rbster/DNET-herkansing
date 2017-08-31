﻿using System;
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
        public string huidigeGebruiker { get; set; }

        public Project(string gebruikersnaam)
        {
            InitializeComponent();
            huidigeGebruiker = gebruikersnaam;
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
                var takenlijst = uProxy.TakenOphalen(huidigeGebruiker);
                foreach (var t in takenlijst)
                {
                    Takenlijst.Items.Add(t);
                }
            }
                
        }

        private void Takenlijst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UrenToekennen ut = new UrenToekennen(Takenlijst.SelectedItem.ToString(), huidigeGebruiker);
            ut.Show();
            using (UrenregistratieserviceClient uProxy = new UrenregistratieserviceClient())
            {
               
            }
        }
    }
}
