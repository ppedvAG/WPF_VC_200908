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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person BspPerson { get; set; }

        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> Personenliste { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Erstellen von Bsp-Daten
            BspPerson = new Person() { Vorname = "Anna", Nachname = "Meier", Alter = 27 };

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Otto", Nachname="Meier", Alter=55},
                new Person(){Vorname="Jürgen", Nachname="Müller", Alter=78},
                new Person(){Vorname="Maria", Nachname="Schmidt", Alter=24}
            };

            //Setzen des DataContext eines StackPanels auf die BspPerson
            Spl_DataContextBsp.DataContext = BspPerson;

            //Setzen des DataContext des Fensters auf sich selbst (Einfache Bindungen zu Properties in dieser Datei möglich)
            this.DataContext = this;
        }

        private void Btn_ControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button funktioniert");
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            //Erhöhung des Alters der Person im DataContextes des StackPanels
            BspPerson.Alter++;
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Sarah", Nachname = "Schmidt", Alter = 45 });
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der in dem ListView angewählten Person
            if (Lbx_Personen.SelectedItem is Person)
                Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }
    }
}
