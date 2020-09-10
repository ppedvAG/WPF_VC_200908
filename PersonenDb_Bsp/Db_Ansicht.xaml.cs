using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PersonenDb_Bsp
{
    /// <summary>
    /// Interaction logic for Db_Ansicht.xaml
    /// </summary>
    public partial class Db_Ansicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; }

        public Db_Ansicht()
        {
            InitializeComponent();

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Rainer", Nachname="Zufall", Geburtsdatum = new DateTime(2002, 5, 12), Verheiratet=true, Lieblingsfarbe = Colors.Blue, Geschlecht=Gender.Männlich},
                new Person(){Vorname="Anna", Nachname="Nass", Geburtsdatum = new DateTime(1988, 4, 23), Verheiratet=false, Lieblingsfarbe = Colors.DarkMagenta, Geschlecht=Gender.Weiblich}
            };

            this.DataContext = this;
        }

        private void MeI_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            Personendialog personendialog = new Personendialog();

            if (personendialog.ShowDialog() == true)
                Personenliste.Add(personendialog.NeuePerson);
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            Personendialog personendialog = new Personendialog();
            personendialog.NeuePerson = new Person(Dgd_Personen.SelectedItem as Person);
            personendialog.DataContext = personendialog.NeuePerson;

            if (personendialog.ShowDialog() == true)
                Personenliste[Personenliste.IndexOf(Dgd_Personen.SelectedItem as Person)] = personendialog.NeuePerson;
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Remove(Dgd_Personen.SelectedItem as Person);
        }
    }
}
