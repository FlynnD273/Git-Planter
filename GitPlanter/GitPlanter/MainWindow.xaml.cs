using GitPlanter.View;
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

namespace GitPlanter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel.ViewModel _vm;
        private Control _dragSource = null;

        public MainWindow()
        {
            InitializeComponent();
            _vm = ((ViewModel.ViewModel)DataContext);
        }

        private void commitTree_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.RefreshCommand.Execute(this);
        }

        private void commitTree_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _vm.SizeChanged();
        }

        private void ChangesList_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _dragSource = sender as Control;
        }

        private void ChangesList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _dragSource != null)
            {
                ListView control = sender as ListView;
                var change = control.SelectedItem as GitChange;
                if (change != null)
                {
                    DragDrop.DoDragDrop(control, change, DragDropEffects.Move);
                }
            }
        }

        private void ChangesList_Drop(object sender, DragEventArgs e)
        {
            if (sender != stagedChangesList && sender != unstagedChangesList) { return; }
            if (e.Data.GetDataPresent(typeof(GitChange)))
            {
                var change = (GitChange)e.Data.GetData(typeof(GitChange));
                if (_dragSource == stagedChangesList && e.Source == unstagedChangesList)
                {
                    _vm.UnstageChange(change);
                }
                else if (_dragSource == unstagedChangesList && e.Source == stagedChangesList)
                {
                    _vm.StageChange(change);
                }
                _dragSource = null;
            }
        }
    }
}