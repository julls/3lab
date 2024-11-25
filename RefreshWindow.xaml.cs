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

namespace дэ2
{
    /// <summary>
    /// Логика взаимодействия для RefreshWindow.xaml
    /// </summary>
    public partial class RefreshWindow : Window
    {
        private Requests _currentRequest;

        public RefreshWindow(Requests request)
        {
            InitializeComponent();
            _currentRequest = request;
            ComboStatus.ItemsSource =
                            SchoolChildNew1Entities.GetContext().Activities.ToList();
            ComboStatus1.ItemsSource =
                            SchoolChildNew1Entities.GetContext().Date_Of_Enrolment.ToList();
            // Перезагрузка данных

            FioChildTextBox.Text = request.Children.namee;
            FioParentTextBox1.Text = request.Parents.namee;
            NumberParentTextBox.Text = request.Parent_contacts.phone_number;

            ComboStatus.SelectedItem = request.Activities;
            ComboStatus1.SelectedItem = request.Date_Of_Enrolment;

        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(FioChildTextBox.Text))
                error.AppendLine("Введите имя ребенка!");
            if (string.IsNullOrWhiteSpace(FioParentTextBox1.Text))
                error.AppendLine("Введите имя родителя!");
            if (string.IsNullOrWhiteSpace(NumberParentTextBox.Text))
                error.AppendLine("Введите номер родителя!");


            if (ComboStatus.SelectedItem !=
            null && ComboStatus.SelectedItem is Activities selectedActivities)
            {
                _currentRequest.activities_id = selectedActivities.id;
            }
            else error.AppendLine("Выберите желаемую группу!");

            if (ComboStatus1.SelectedItem !=
            null && ComboStatus1.SelectedItem is Date_Of_Enrolment selectedDate)
            {
                _currentRequest.enrollment_date_id = selectedDate.id;
            }
            else error.AppendLine("Выберите желаемую дату!");

            try
            {
                var context = SchoolChildNew1Entities.GetContext();
                _currentRequest.Children.namee = FioChildTextBox.Text;
                _currentRequest.Parents.namee = FioParentTextBox1.Text;
                _currentRequest.Parent_contacts.phone_number = NumberParentTextBox.Text;

                context.SaveChanges();
                MessageBox.Show("Данные заявки обновлены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
