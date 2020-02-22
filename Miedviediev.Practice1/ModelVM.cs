using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Miedviediev.Practice1.Properties;

namespace Miedviediev.Practice1
{
    public sealed class ModelVm : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly Data _data;
        public int Age => _data.Age;

        public bool IsBirthDay => _data.IsBirthDay;

        public string RemainDays => _data.RemainDays;

        public WesternZodiac WesternZodiac => _data.WesternZodiac;

        public ChineseZodiac ChineseZodiac => _data.ChineseZodiac;

        public DateTime DateTime
        {
            get => _data.DateTime;
            set => UpdateFields(value);
        }

        private async void UpdateFields(DateTime value)
        {
            try
            {
                _data.CountAge(value);
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            Task t1 = Task.Run(() =>
            {
                _data.FindChineseZodiac();
            });
            Task t2 = Task.Run(() =>
            {
                _data.FindWesternZodiac();
            });
            Task t3 = Task.Run(() =>
            {
                _data.CalculateBirthDay();
            });
            await Task.WhenAll(t1, t2, t3);
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(DateTime));
            OnPropertyChanged(nameof(ChineseZodiac));
            OnPropertyChanged(nameof(WesternZodiac));
            OnPropertyChanged(nameof(IsBirthDay));
            OnPropertyChanged(nameof(RemainDays));
        }

        public ModelVm()
        {
            _data = new Data(DateTime.Now);
        }
    }
}