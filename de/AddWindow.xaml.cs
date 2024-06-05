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

namespace de
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        
        public AddWindow()
        {
            InitializeComponent();
            FillComboBox();
        }
        private void FillComboBox()
        {
            using (var context = new ТехносервисEntities())
            {
                var equipmentList = context.Equipment.ToList();
                cbEquip.ItemsSource = equipmentList;
                cbEquip.DisplayMemberPath = "equipment1";
                cbEquip.SelectedValuePath = "EquipmentID";

                var typeMaifList = context.TypeMalfunctions.ToList();
                cbTypeMaif.ItemsSource = typeMaifList;
                cbTypeMaif.DisplayMemberPath = "typeMalfunctions1";
                cbTypeMaif.SelectedValuePath = "TypeMalfunctionsID";

                var ClientList = context.Client.ToList();
                cbClient.ItemsSource = ClientList;
                cbClient.DisplayMemberPath = "clientName";
                cbClient.SelectedValuePath = "ClientID";

                var StageList = context.Stage.ToList();
                cbStage.ItemsSource = StageList;
                cbStage.DisplayMemberPath = "stage1";
                cbStage.SelectedValuePath = "StageID";
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbProblem.Text == null || cbClient.SelectedItem == null || cbStage.SelectedItem == null || cbTypeMaif.SelectedItem == null || cbEquip.SelectedItem == null || Data.SelectedDate == null)
                {
                    MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var newRequest = new Requests
                    {
                        RequestDate = Data.SelectedDate.Value,
                        RequestEquipment = (int)cbEquip.SelectedValue,
                        RequestTypeMalfunctions = (int)cbTypeMaif.SelectedValue,
                        RequestDescriptionProblems = tbProblem.Text,
                        RequestClient = (int)cbClient.SelectedValue,
                        RequestStage = (int)cbStage.SelectedValue,
                    };
                    using (var context = new ТехносервисEntities())
                    {
                        context.Requests.Add(newRequest);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Запись успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}