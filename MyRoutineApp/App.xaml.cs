using System.Windows;


namespace MyRoutineApp {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application {
		private AppNotifyIcon? appNotifyIcon;
		protected override void OnStartup(StartupEventArgs e) {
			// プロセス通常起動
			base.OnStartup(e);
			appNotifyIcon = new AppNotifyIcon();
			Application.Application app = new Application.Application();
			app.notification.infomation("Hello world!!");
			app.notification.error("おはよう、世界！！");
		}
		protected override void OnExit(ExitEventArgs e) {

			appNotifyIcon?.Dispose();
			base.OnExit(e);
		}
	}

}
