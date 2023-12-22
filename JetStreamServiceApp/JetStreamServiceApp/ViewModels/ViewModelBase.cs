using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JetStreamServiceApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string? property = null)
        {
            if (Equals(storage, value)) return;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
