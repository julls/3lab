using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Data.Entity;

namespace дэ2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshSchoolChildNewDataGrid();
            ComboStatus.ItemsSource =
            SchoolChildNew1Entities.GetContext().Activities.ToList();
            Vis();
        }
        private void RefreshSchoolChildNewDataGrid() 
        {
            var context = SchoolChildNew1Entities.GetContext();
            var requestsWithRelations = context.Requests
            .Include(r => r.Children)
            .Include(r => r.Parents)
            .Include(r => r.Parent_contacts)
            .Include(r => r.Date_Of_Enrolment)
            .Include(r => r.Activities)
            .ToList();
            SchoolChildNew.ItemsSource = requestsWithRelations;
        }
        private void Vis()
        {
            switch (Authorization.authorizationRole)
            {
                case "Админ":
                    BtnAdd.Visibility = Visibility.Collapsed;
                    break;
                case "Модер":
                    BtnDelet.Visibility = Visibility.Collapsed;
                    BtnAdd.Visibility = Visibility.Collapsed;
                    break;
                case "Юзер":
                    GridTemplate.Visibility = Visibility.Collapsed;
                    BtnDelet.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = (sender as Button)?.DataContext as Requests;
            if (selectedRequest != null)
            {
                RefreshWindow addEditWindow = new RefreshWindow(selectedRequest);
                if (addEditWindow.ShowDialog() == true)
                {
                    RefreshSchoolChildNewDataGrid();
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            if (addEditWindow.ShowDialog() == true)
            {
                RefreshSchoolChildNewDataGrid(); 
            }
        }
        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var servisForRemoving = SchoolChildNew.SelectedItems.Cast<Requests>().ToList();
            if (servisForRemoving.Any()
            && MessageBox.Show($"Вы точно хотите удалить следующее {servisForRemoving.Count()} элемент ? ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var context = SchoolChildNew1Entities.GetContext();
                context.Requests.RemoveRange(servisForRemoving);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                RefreshSchoolChildNewDataGrid(); 
            }
        }
        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            SchoolChildNew.ItemsSource = SchoolChildNew1Entities.GetContext().Requests.ToList();
            RefreshSchoolChildNewDataGrid(); 
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var context = SchoolChildNew1Entities.GetContext();
            try
            {
                SchoolChildNew.ItemsSource = context.Requests
                .Include(r => r.Children)
                .Include(r => r.Parents)
                .Include(r => r.Parent_contacts)
                .Include(r => r.Date_Of_Enrolment)
                .Include(r => r.Activities)
                .Where(r =>
                r.Children.namee.ToLower().Contains(searchText) ||
                r.Parents.namee.ToLower().Contains(searchText) ||
                r.Parent_contacts.phone_number.ToLower().Contains(searchText) ||
                r.Date_Of_Enrolment.enrollment_date.ToString().Contains(searchText) ||
                r.Activities.namee.ToLower().Contains(searchText))
                .ToList();
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                // Логирование или отладка исключения
                Console.WriteLine(ex.InnerException?.Message);
            }
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            if (ComboStatus.SelectedItem is Activities selectedActivities)
            {
                int selectedActivitiesId = selectedActivities.id;
                var context = SchoolChildNew1Entities.GetContext();
                SchoolChildNew.ItemsSource = context.Requests
                .Include(r => r.Children)
                .Include(r => r.Parents)
                .Include(r => r.Parent_contacts)
                .Include(r => r.Date_Of_Enrolment)
                .Include(r => r.Activities)
                .Where(r => r.activities_id == selectedActivitiesId)
                .ToList();
            }
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

    }

}
