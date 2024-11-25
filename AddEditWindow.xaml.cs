using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Requests requests = new Requests();
        private Children children = new Children();
        private Parent_contacts parent_Contacts = new Parent_contacts();
        private Parents parents = new Parents();
        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = requests;
            ComboStatus.ItemsSource = 
                SchoolChildNew1Entities.GetContext().Activities.ToList();
            ComboStatus1.ItemsSource = 
                SchoolChildNew1Entities.GetContext().Date_Of_Enrolment.ToList();
        }

        private void Btn_Table_Click(object sender, RoutedEventArgs e)
        {
            TableWindow tableWindow = new TableWindow();
            tableWindow.Show();
        }

        bool ContainsCyrillic(string input)
        {
            return Regex.IsMatch(input, @"^[\p{IsCyrillic}]+$");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(ChildName.Text))
                error.AppendLine("Введите имя ребенка!");
            bool cStr = int.TryParse(ChildName.Text, out var num1);
            if (cStr && !ContainsCyrillic(ChildName.Text)) { error.AppendLine("Не верный формат имени ребёнка"); }



            if (string.IsNullOrWhiteSpace(ParentName.Text))
                error.AppendLine("Введите имя родителя!");

            bool cStr1 = int.TryParse(ParentName.Text, out var num2);
            if (cStr1 && !ContainsCyrillic(ParentName.Text)) { error.AppendLine("Не верный формат имени родителя"); }


            if (string.IsNullOrWhiteSpace(PhoneNumber.Text))
                error.AppendLine("Введите номер родителя!");

            if (!Regex.IsMatch(PhoneNumber.Text, @"^[0-9]+$"))
            {
                error.AppendLine("Неверный формат номера");
            }


            if (ComboStatus.SelectedItem !=
            null && ComboStatus.SelectedItem is Activities selectedActivities)
                requests.activities_id = selectedActivities.id;
            else error.AppendLine("Выберите желаемую группу!");

            if (ComboStatus1.SelectedItem !=
            null && ComboStatus1.SelectedItem is Date_Of_Enrolment selectedDate)
                requests.enrollment_date_id = selectedDate.id;
            else error.AppendLine("Выберите желаемую дату!");


            //if (error.Length > 0)
            //{
            //    MessageBox.Show(error.ToString(), "Предупреждение!", MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            //    return;
            //}
            try
            {
                var context = SchoolChildNew1Entities.GetContext();
                children.namee = ChildName.Text;
                parents.namee = ParentName.Text;
                parent_Contacts.phone_number = PhoneNumber.Text;

                context.Children.Add(children);
                context.Parents.Add(parents);
                context.Parent_contacts.Add(parent_Contacts);

                context.SaveChanges();

                var ChildId = children.id;
                var ParentId = parents.id;
                var ParentContactId = parent_Contacts.id;

                requests.children_id = ChildId;
                requests.parents_id = ParentId;
                requests.parent_contact_id = ParentContactId;

                context.Requests.Add(requests);
                context.SaveChanges();
                MessageBox.Show("Информация сохранена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        
    }
}
