using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Window1 : Window
    {
        public bool WindowClosed { set; get; }

        public Window1()
        {
            InitializeComponent();

            WindowClosed = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!WindowClosed)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
