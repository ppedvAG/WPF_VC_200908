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

namespace Controls
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

        //Event-Handler für das Click-Event des Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Änderung der Hintergrundfarbe des Fensters
            Wnd_Main.Background = new SolidColorBrush(Colors.LightGreen);
            //Ausgabe einer MessageBox mit dem Wert der Combobox und des Sliders
            MessageBox.Show(Cbb_Auswahl.SelectedItem?.ToString() + "\n" + Slr_Bsp.Value);
        }

        //Event-Handler für das Click-Event des MenuItems
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
