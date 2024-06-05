using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        string Login;
        public MainPage()
        {
            Login = UserSession.CurrentUser; 
            InitializeComponent();
            LoadData();
            btnAvailable();
        }
        
        private void btnAvailable() 
        {
            bool available = roleCheck(Login);
            btnAdd.IsEnabled = available; 
            btnEdit.IsEnabled = available; 
            btnDel.IsEnabled = available;
        }

        private bool roleCheck(string Login)
        {
            using (var context = new ТехносервисEntities())
            {
                var user = context.User.FirstOrDefault(u => u.Role == 1 && u.Login == Login);
                return user != null;
            }
        }

        private void LoadData()
        {
           using (var context =new ТехносервисEntities())
            {
                context.Requests.Load();
                dgRequests.ItemsSource = context.Requests.Local.ToBindingList();
            }
        }

        private void btnRef_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Приложение Хлуднева Антона Дмитриевича для демоэкзамена \n С использованием БД Техносервис", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Closed += (s, args) => LoadData();
            addWindow.Show();
        }

        private void AddWindow_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.Closed += (s, args) => LoadData();
            editWindow.Show();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new ТехносервисEntities())
    {
                // Получаем выбранный элемент из DataGrid
                Requests selectedItem = dgRequests.SelectedItem as Requests;

                // Проверяем, что элемент действительно выбран
                if (selectedItem != null)
                {
                    // Подтверждение удаления
                    if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        // Находим объект в текущем контексте
                        var requestToDelete = context.Requests.Find(selectedItem.RequestID);

                        // Удаляем запись из контекста
                        if (requestToDelete != null)
                        {
                            context.Requests.Remove(requestToDelete);
                            context.SaveChanges();

                            // Обновляем DataGrid после удаления
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    // Сообщение об ошибке, если ничего не выбрано
                    MessageBox.Show("Выберите запись для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
