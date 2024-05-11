using MyRoutineApp.Process;
using System.Windows;


namespace MyRoutineApp {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application {

		private AppNotifyIcon? _appNotifyIcon;

		private ProcessControler _controler;

		public App() {
			_controler = new ProcessControler(this);
		}

		protected override void OnStartup(StartupEventArgs e) {
			// プロセス通常起動
			base.OnStartup(e);
			_appNotifyIcon = new AppNotifyIcon();
		}

		protected override void OnExit(ExitEventArgs e) {
			_appNotifyIcon?.Dispose();
			base.OnExit(e);
		}
	}

}
