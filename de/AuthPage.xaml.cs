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

namespace de
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            string username = tbLogin.Text;
            string password = tbPass.Text;

            if (authUser(username, password))
            {
                UserSession.CurrentUser = username;
                MessageBox.Show("Вы успешно вошли", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new MainPage());
            }
            else
            {
                statusBlock.Text = "Неверный логин или пароль!";
            }
        }

        private bool authUser(string username, string password)
        {
            using (var context = new ТехносервисEntities())
            {
                var user = context.User.FirstOrDefault(u => u.Login == username && u.Password == password) ;
                return user != null;
            }

        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Регистация в разработке","Регистрация",MessageBoxButton.OK, MessageBoxImage.Information) ;
        }
    }
}
