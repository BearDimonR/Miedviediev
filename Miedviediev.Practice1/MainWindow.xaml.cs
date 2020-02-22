using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Miedviediev.Practice1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void DatePickerLoaded(object sender, RoutedEventArgs e)
        {
            if (!(sender is DatePicker datePicker)) return;
            DatePickerTextBox datePickerTextBox = 
                FindVisualChild<DatePickerTextBox>(datePicker);
            if (datePickerTextBox?.Template.FindName("PART_Watermark", datePickerTextBox) 
                is ContentControl watermark) {
                watermark.Content = "Enter your date of birth";
            }
        }
        private static T FindVisualChild<T>(DependencyObject dependencyObject) where T : DependencyObject {
            if (dependencyObject == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); ++i) {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                T result = child as T ?? FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}