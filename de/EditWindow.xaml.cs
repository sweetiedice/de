using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            using (var context = new ТехносервисEntities())
            {
                var idList = context.Requests.ToList();
                cbID.ItemsSource = idList;
                cbID.DisplayMemberPath = "RequestID";
                cbID.SelectedValuePath = "RequestID";

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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbProblem.Text == null || cbClient.SelectedItem == null || cbStage.SelectedItem == null || cbTypeMaif.SelectedItem == null || cbEquip.SelectedItem == null || Data.SelectedDate == null)
                {
                    MessageBox.Show("Заполните все поля для ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    using (var context = new ТехносервисEntities())
                    {
                        int requestID = (int)cbID.SelectedValue;
                        var selectedRequest = context.Requests.Find(requestID);

                        if (selectedRequest != null)
                        {
                            selectedRequest.RequestStage = (int)cbStage.SelectedValue;
                            selectedRequest.RequestDate = Data.SelectedDate.Value;
                            selectedRequest.RequestDescriptionProblems = tbProblem.Text;
                            selectedRequest.RequestTypeMalfunctions = (int)cbTypeMaif.SelectedValue;
                            selectedRequest.RequestClient = (int)cbClient.SelectedValue;

                            context.SaveChanges();
                        }
                    }

                        MessageBox.Show("Запись успешно отредактирована", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании записи: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbID.SelectedValue != null)
            {
                int RequestID = (int)cbID.SelectedValue;
                LoadData(RequestID);

            }

        }
        private void LoadData(int RequestID)
        {
            using (var context = new ТехносервисEntities())
            {
                var SelectRequest = context.Requests.Find(RequestID);
                if (SelectRequest != null)
                {
                    cbEquip.SelectedValue = SelectRequest.RequestEquipment;
                    cbTypeMaif.SelectedValue = SelectRequest.RequestTypeMalfunctions;
                    tbProblem.SelectedText = SelectRequest.RequestDescriptionProblems;
                    cbClient.SelectedValue = SelectRequest.RequestClient;
                    cbStage.SelectedValue = SelectRequest.RequestStage;
                    Data.SelectedDate = SelectRequest.RequestDate;

                }
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
