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
using TradITAM.Model;
using TradITAM.ViewModel;

namespace TradITAM.View
{
    /// <summary>
    /// Interaction logic for UpdateSelectedAssetWindow.xaml
    /// </summary>
    public partial class UpdateSelectedAssetWindow : Window
    {
        public UpdateSelectedAssetWindow(AssetData selectedAsset)
        {
            InitializeComponent();
            this.DataContext = new UpdateSelectedAssetWindowViewModel(selectedAsset);
        }
    }
}
