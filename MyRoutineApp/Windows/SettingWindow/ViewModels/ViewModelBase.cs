using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyRoutineApp.Windows.SettingWindow.ViewModels {
	class ViewModelBase : INotifyPropertyChanged {
		// INotifyPropertyChangedを実装するためのイベントハンドラ
		public event PropertyChangedEventHandler? PropertyChanged;
		// プロパティ名によって自動セットされる
		public void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
