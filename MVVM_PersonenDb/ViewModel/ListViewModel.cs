using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PersonenDb.ViewModel
{
    public class ListViewModel
    {
        //Listen-Property, welche auf die Liste des Models verlinkt
        public ObservableCollection<Model.Person> Personenliste { get { return Model.Person.Personenliste; } }

        //Command-Properties
        public CustomCommand NeuCmd { get; set; }
        public CustomCommand AendernCmd { get; set; }
        public CustomCommand LoeschenCmd { get; set; }
        public CustomCommand BeendenCmd { get; set; }

        public ListViewModel()
        {
            //Command-Definitionen
            //Hinzufügen einer neuen Person
            this.NeuCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,
                    //Exe:
                    p =>
                    {
                        //Instanzieren eines neuen DetailViews
                        View.DetailView NeuePerson_Dialog = new View.DetailView();
                        //Zuweisung eines neuen DetailViewModels als dessen DataContext
                        NeuePerson_Dialog.DataContext = new DetailViewModel();
                        //Zuweisung einer neuen Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        (NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person();

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult(wird true, wenn der Benutzer OK klickt)
                        if(NeuePerson_Dialog.ShowDialog() == true)
                            //Hinzufügen der neuen Person zu Liste
                            Model.Person.Personenliste.Add((NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson);
                    }
                );

            //Ändern einer bestehenden Person
            this.AendernCmd = new CustomCommand
                (
                    //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                    //Fungiert als Null-Prüfung
                    p => p is Model.Person,
                    //Exe:
                    p =>
                    {
                        //Vgl. NeuCmd (s.o.)
                        View.DetailView NeuePerson_Dialog = new View.DetailView();
                        NeuePerson_Dialog.DataContext = new DetailViewModel();
                        //Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        (NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson = new Model.Person(p as Model.Person);
                        //Ändern des Titels des neuen DetailViews
                        (NeuePerson_Dialog as View.DetailView).Title = "Ändere " + (p as Model.Person).Vorname + " " + (p as Model.Person).Nachname;

                        if (NeuePerson_Dialog.ShowDialog() == true)
                            //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                            Model.Person.Personenliste[Model.Person.Personenliste.IndexOf(p as Model.Person)] = (NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson;
                    }
                );

            //Löschen einer Person
            this.LoeschenCmd = new CustomCommand
                (
                    //CanExe: s.o.
                    p => p is Model.Person,
                    //Exe: Löschen der ausgewählten Person
                    p => Model.Person.Personenliste.Remove(p as Model.Person)
                );

            //Schließen des Programms
            this.BeendenCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,
                    //Exe: Schließen der Applikation
                    p => (p as View.ListView).Close()
                );
        }
    }
}
