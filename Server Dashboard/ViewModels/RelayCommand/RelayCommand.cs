using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Server_Dashboard {
    class RelayCommand : ICommand {

        //New Action
        private Action<object> execAction;

        //Never gets fires, but needs to be implemented
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Sets the given action to the private one
        /// </summary>
        /// <param name="action">The function to be executed</param>
        public RelayCommand(Action<object> action) => execAction = action;

        //Makes all functions always executable
        public bool CanExecute(object parameter) { return true; }

        //Executes the function
        public void Execute(object parameter) { execAction(parameter); }
    }
}
