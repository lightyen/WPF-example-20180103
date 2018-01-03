using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Window1 myWindow;
        
        public List<Daddy> Data
        {
            get; set;
        }

        public MainWindow()
        {
            InitializeComponent();

            myWindow = new Window1();

            Data = new List<Daddy>
            {
                new Daddy { Name = "John", Money = 835593933832324142M },
                new Daddy { Name = "Alisa", Money = 7120242M },
            };
            this.DataContext = this;
        }

        public void MyDataGridSelectRow(int index)
        {
            if (index >= 0 && index < MyDataGrid.Items.Count)
            {
                var item = MyDataGrid.Items[index];
                MyDataGrid.SelectedItem = item;
            }
        }

        private void HeHeHe_Click(object sender, RoutedEventArgs e)
        {
            myWindow.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            myWindow.WindowClosed = true;
            myWindow.Close();
        }
    }

    public class Daddy : INotifyPropertyChanged
    {
        string name;

        Decimal money;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public Decimal Money
        {
            get => money;
            set
            {
                money = value;
                NotifyPropertyChanged(nameof(Money));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
