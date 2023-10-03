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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aaaaaaaa.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorizacia.xaml
    /// </summary>
    public partial class Autorizacia : Page
    {
        public Autorizacia()
        {
            InitializeComponent();

            classes.connect.modelbd = new Models.OOORulEntities();
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            classes.manager.MainFrame.Navigate(new Registr());
        }

        private void Vxod(object sender, RoutedEventArgs e)
        {

            var userObj = classes.connect.modelbd.Datas.FirstOrDefault(
                x => x.Login == Login.Text && Password.Password == x.Password);

            if (userObj == null)
            {
                MessageBox.Show("Пользователя с такими данными не существует!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (userObj.Type == 1)
                {
                    classes.manager.MainFrame.Navigate(new pages.Admin());
                }
                else if (userObj.Type == 2)
                {
                    classes.manager.MainFrame.Navigate(new Pages.Manager());
                }
                else if (userObj.Type == 3)
                {
                    classes.manager.MainFrame.Navigate(new Pages.User());
                }

            }

        }
    }
}
