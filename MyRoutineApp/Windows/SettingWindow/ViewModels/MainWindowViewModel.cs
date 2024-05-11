using MyRoutineApp.Application;
using MyRoutineApp.Windows.SettingWindow.Command;

namespace MyRoutineApp.Windows.SettingWindow.ViewModels {
	class MainWindowViewModel : ViewModelBase {
		private ViewModelBase _activeView = new GeneralSettingsViewModel();
		private Trace _trace;
		/// <summary>
		/// 画面に表示するUserControlのViewModelを設定するプロパティ
		/// </summary>
		public ViewModelBase ActiveView {
			get { return _activeView; }
			set {
				if (_activeView != value) {
					_activeView = value;
					OnPropertyChanged(nameof(ActiveView));
				}
			}
		}
		/// <summary>
		/// ボタンのコマンドプロパティ
		/// </summary>
		public DelegateCommand<string> ViewTransitionCommand { get; }

		public MainWindowViewModel() {
			ViewTransitionCommand = new DelegateCommand<string>(OnSwitchingViewButtonClicked);

			_trace = AppService.console.Register("MainViewModel");
		}
		/// <summary>
		/// ボタンのコマンド実行メソッド
		/// </summary>
		/// <param name="parameter"></param>
		private void OnSwitchingViewButtonClicked(string? parameter) {
			/**
			 * コマンドパラメータによって
			 * ActiveViewにセットするViewModelを切り替える
			 */
			switch (parameter) {
			case "GeneralSettingsView":
				ActiveView = new GeneralSettingsViewModel();
				break;
			case "ProcessSettingsView":
				ActiveView = new ProcessSettingsViewModel();
				break;
			}
			_trace.Debug($"parameter={parameter}");
		}
	}
}
