namespace MyRoutineApp.Application {
	internal class Printer(Action<string> debug, Action<string> info, Action<string> error) {
		public Action<string> debug { get; } = debug;
		public Action<string> info { get; } = info;
		public Action<string> error { get; } = error;
	}
}
