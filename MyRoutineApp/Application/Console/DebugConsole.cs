namespace MyRoutineApp.Application {
	internal partial class DebugConsole {
		object lockObject = new object();
		public Trace register(string name) {
			return new Trace(name, new Printer(debug, info, error));
		}

		private void debug(string message) {
			lock (lockObject) {
				System.Diagnostics.Debug.WriteLine(message);
			}
		}
		private void info(string message) {
			lock (lockObject) {
				System.Diagnostics.Debug.WriteLine(message);
			}
		}
		private void error(string message) {
			lock (lockObject) {
				System.Diagnostics.Debug.WriteLine(message);
			}
		}
	}
}
