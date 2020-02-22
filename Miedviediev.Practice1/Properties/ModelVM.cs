using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApplication1.Annotations;

namespace WpfApplication1.Properties
{
    public class ModelVm : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public uint Age { get; set; }
        
        
    }
}