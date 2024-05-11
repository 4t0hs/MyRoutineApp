using System.ComponentModel;

namespace MyRoutineApp {
	public partial class AppNotifyIcon : Component {
		public AppNotifyIcon() {
			InitializeComponent();
			initializeContextMenu();
		}

		public AppNotifyIcon(IContainer container) {
			container.Add(this);

			InitializeComponent();
		}
		private void initializeContextMenu() {
			toolStripMenuItem_Settings.Click += toolStripMenuItem_Settings_onClick;
			toolStripMenuItem_Notification.Click += toolStripMenuItem_Notification_onClick;
			toolStripMenuItem_Exit.Click += toolStripMenuItem_Exit_onClick;
		}

		private void toolStripMenuItem_Settings_onClick(object? sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("Settings on cliked");
			Application.SettingWindow window = new Application.SettingWindow();
			window.Show();
		}

		private void toolStripMenuItem_Notification_onClick(object? sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("Notification on cliked");
			Application.NotificationWindow window = new Application.NotificationWindow();
			window.Show();
		}
		private void toolStripMenuItem_Exit_onClick(object? sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("Exit on cliked");
			System.Windows.Application.Current.Shutdown();
		}
	}
}
