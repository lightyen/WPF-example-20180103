
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public bool WindowClosed { set; get; }

        public Window1()
        {
            this.DataContext = this;

            InitializeComponent();

            WindowClosed = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = App.Current.MainWindow as MainWindow;
            try
            {
                int i = int.Parse(MyTextBox.Text);
                mainWin.MyDataGridSelectRow(i);
                this.Close();
            }
            catch
            {

            }
        }
    }
}
