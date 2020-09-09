﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    //Das Interface INotifyPropertyChanged ist dafür verantwortlich, dass die GUI über Veränderungen in den Properties informiert wird
    //und somit diese Veränderungen abbilden kann.
    public class Person : INotifyPropertyChanged
    {
        //Durch das Interface gefordertes Event
        public event PropertyChangedEventHandler PropertyChanged;

        public string Vorname { get; set; }
        public string Nachname { get; set; }

        private int alter;
        public int Alter
        {
            get { return alter; }
            //Aufruf des PropertyChanged-Events im Setter (dort wo die Veränderung durchgeführt wird) mit Übergabe des Event-Senders und der veränderten Property
            set { alter = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alter")); }
        }

    }
}
