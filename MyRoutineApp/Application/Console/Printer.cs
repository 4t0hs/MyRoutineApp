namespace MyRoutineApp.Application {
	internal class Printer {
		public Action<string> debug { get; }
		public Action<string> info { get; }
		public Action<string> error { get; }
		public Printer(Action<string> debug, Action<string> info, Action<string> error) {
			this.debug = debug;
			this.info = info;
			this.error = error;
		}
	}
}
