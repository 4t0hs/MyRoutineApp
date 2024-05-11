using System.Windows.Input;

namespace MyRoutineApp.Windows.SettingWindow.Command {
	class DelegateCommand<T> : ICommand {
		public event EventHandler? CanExecuteChanged;

		private readonly Action<T?> _action;
		private readonly Func<T?, bool>? _canExecute;

		public DelegateCommand(Action<T?> action, Func<T?, bool>? canExecute = default) {
			_action = action;
			_canExecute = canExecute;
		}

		public bool CanExecute(object? parameter) {
			return _canExecute?.Invoke((T?)parameter) ?? true;
		}

		public void Execute(object? parameter) {
			_action.Invoke((T?)parameter);
		}

		public void DelegateCanExecute() {
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
