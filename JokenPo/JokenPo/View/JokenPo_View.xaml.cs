using JokenPo.ViewModels;

namespace JokenPo.View
{
    public partial class JokenPo_View : ContentPage
    {
        public JokenPo_View()
        {
            InitializeComponent();
            BindingContext = new JokenPo_ViewModel();
        }
    }

}
