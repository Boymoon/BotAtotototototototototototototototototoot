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

namespace Ar_Project.Interface
{
    /// <summary>
    /// Interaction logic for RepairViewPage.xaml
    /// </summary>
    public partial class RepairViewPage : Page
    {
        public RepairViewPage()
        {
            InitializeComponent();
            var a = new CountView();
            Te.Text = a.count_isdone;
        }
    }
}
