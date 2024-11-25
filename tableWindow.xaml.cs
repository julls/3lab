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
using System.Data.Entity;
using System.Xml.Linq;
using System.Data;

namespace дэ2
{
    /// <summary>
    /// Логика взаимодействия для tableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        public TableWindow()
        {
            InitializeComponent();
            this.Loaded += TableWindow_Loaded;
        }
        private void TableWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshSchoolChildNewDataGrid();
        }
        private void RefreshSchoolChildNewDataGrid()
        {
            var context = SchoolChildNew1Entities.GetContext();

            var requestsWithRelations = context.Activity_Schedule
                .Include(r => r.Activities)
                .ToList();

            tableWindow.ItemsSource = requestsWithRelations;

        }

    }
}
