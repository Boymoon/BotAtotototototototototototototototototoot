using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var datacontext = new MainWindowViewModel();
            DataContext = datacontext;
            var ddb = new LoginViewModel(datacontext);
            Logedin.DataContext = ddb;
            Gridcontrol_PART_Follow.DataContext = ddb;
            SearchUsingOptionsCommand.DataContext = ddb;
            uid.DataContext = ddb;
            FollowAll.DataContext = ddb;
            FollowWhohasFollowingFrom_To.DataContext = ddb;
         
        }
        private void PostsAndCommentsSectionEVN(object sender, MouseEventArgs e)
        {
            Task.Run(() => {
            HelperSelector.CurrentSection = TypesSections.CommentsAndPostsSection;
            HelperSelector.Init();
            });
        }

        private void SearchSectionEVN(object sender, MouseEventArgs e)
        {
            Task.Run(() => {

            HelperSelector.CurrentSection = TypesSections.SearchSection;
            HelperSelector.Init();
            });
        }

        private void MainSectionEVN(object sender, MouseEventArgs e)
        {
            Task.Run(() => {
            HelperSelector.CurrentSection = TypesSections.FollowersSection;
            HelperSelector.Init();

            }); 
        }
    }
}
