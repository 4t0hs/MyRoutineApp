namespace MyRoutineApp.Application {
	internal partial class DebugConsole {

		private object _lockObject = new object();

		public Trace Register(string name) {
			return new Trace(name, new Printer(Debug, Info, Error));
		}

		private void Debug(string message) {
			lock (_lockObject) {
				System.Diagnostics.Debug.WriteLine(message);
			}
		}

		private void Info(string message) {
			lock (_lockObject) {
				System.Diagnostics.Debug.WriteLine(message);
			}
		}

		private void Error(string message) {
			lock (_lockObject) {
				System.Diagnostics.Debug.WriteLine(message);
			}
		}
	}
}
