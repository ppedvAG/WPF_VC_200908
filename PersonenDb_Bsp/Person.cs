﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PersonenDb_Bsp
{
    public enum Gender { Männlich, Weiblich, Divers}

    public class Person : IDataErrorInfo
    {
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public bool Verheiratet { get; set; }

        public Color Lieblingsfarbe { get; set; }

        public Gender Geschlecht { get; set; }

        public Person()
        {
            this.Vorname = "";
            this.Nachname = "";
            this.Geburtsdatum = DateTime.Now;
        }

        public Person(Person originalPerson)
        {
            this.Vorname = originalPerson.Vorname;
            this.Nachname = originalPerson.Nachname;
            this.Verheiratet = originalPerson.Verheiratet;
            this.Lieblingsfarbe = originalPerson.Lieblingsfarbe;
            this.Geschlecht = originalPerson.Geschlecht;
            this.Geburtsdatum = new DateTime(originalPerson.Geburtsdatum.Year, originalPerson.Geburtsdatum.Month, originalPerson.Geburtsdatum.Day);
        }

    public string Error
    {
        get { return ""; }
    }

    //private void Bsp_IndexZugriff()
    //    {
    //        Person person = new Person();

    //        person["Alter"]
    //    }

    public string this[string columnName]
    {
        get
        {
            switch (columnName)
            {
                case nameof(Vorname):
                    if (Vorname.Length <= 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                    if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben einthalten.";
                    break;

                case nameof(Nachname):
                    if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                    if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben einthalten.";
                    break;

                case nameof(Geburtsdatum):
                    if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                    if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                    break;

                case nameof(Lieblingsfarbe):
                    if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Lieblingsfarbe aus.";
                    break;
            }
            return "";
        }
    }
}
}
