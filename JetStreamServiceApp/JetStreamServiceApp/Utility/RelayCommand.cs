using System;
using System.Windows.Input;

namespace JetStreamServiceApp.Utility
{
    public class RelayCommand : ICommand
    {
        // Dieser Event wird an den Event RequerySuggested des CommandManagers 
        // angehängt. Das bedeutet, wenn immer sich etwas ändert, was zur Folge
        // hat, dass sich die Verfügbarkeit des Befehls ändert, wird der Command-
        // Manager auch diese Klasse abfragen.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Die Delegates, hier private, weil nur die Methoden Execute und CanExecute relevant sind.
        // Die Zuweisung der Funktionalität erfolgt im Konstruktor
        private Action<object?>? _execute = null;
        private Predicate<object?>? _canExecute = null;

        #region ICommand Members

        public bool CanExecute(object? parameter)
        {
            return (_canExecute == null) ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }

        #endregion

        // Der Konstruktor, hier werden die Aktionen zugewiesen
        public RelayCommand(Action<object?>? execute, Predicate<object?>? canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Der Execute-Parameter darf nicht null sein");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object?> execute)
            : this(execute, null)
        {

        }
    }
}
