
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public bool WindowClosed { set; get; }

        private bool enabled;

        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                NotifyPropertyChanged(nameof(Enabled));
            }
        }

        public Window1()
        {
            this.DataContext = this;

            InitializeComponent();

            WindowClosed = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (enabled)
            {
                var mainWin = App.Current.MainWindow as MainWindow;
                try
                {
                    int i = int.Parse(MyTextBox.Text);
                    mainWin.MyDataGridSelectRow(i);
                }
                catch
                {

                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!WindowClosed)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Enabled = true;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Enabled = false;
        }

        
    }
}
