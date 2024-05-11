using System.Windows;

namespace MyRoutineApp.Application {
	/// <summary>
	/// SettingsWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class SettingWindow : Window {
		public SettingWindow() {
			InitializeComponent();

			this.Loaded += AppService.configManager.NotifySettingWindowLoaded;
		}
	}
}
