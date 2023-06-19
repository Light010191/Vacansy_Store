using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vacancy_Store.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Select.xaml
    /// </summary>
    public partial class Select : Window
    {
        public Select()
        {
            InitializeComponent();
        }

        private void Res_Click(object sender, RoutedEventArgs e)
        {
            var reg = new Registr();
            reg.Show();
            this.Close();
        }
    }
}
