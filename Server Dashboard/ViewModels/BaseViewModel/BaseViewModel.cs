﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Server_Dashboard {
    /// <summary>
    /// Base View Model all the other view models inherit from
    /// Makes me write the INotifyPropertyChanged only once
    /// </summary>
    class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected void OnPropertyChanged(string prop) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
