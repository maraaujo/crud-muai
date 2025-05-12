using crud_maui_blazor.Database;

namespace crud_maui_blazor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database = new ApplicationDbContext();
        }
        public static ApplicationDbContext Database { get; private set; } 

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "crud-maui-blazor" };
        }
    }
}
