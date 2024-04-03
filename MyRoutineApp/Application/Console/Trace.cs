using System.Runtime.CompilerServices;

namespace MyRoutineApp.Application {
	internal partial class Trace {
		public Level level { get; set; } = Level.INFO;
		private bool _disabled = false;
		private readonly Printer _printer;
		private readonly string _name;

		public Trace(string name, Printer printer) {
			_name = name;
			_printer = printer;
		}
		public void debug(string message, [CallerMemberName] string callerMathod = "") {
			if (isNotDisplayable(Level.DEBUG)) {
				return;
			}
			string output = $"{callerMathod}::{message}";
			_printer.debug(format(Level.DEBUG, output));
		}
		public void info(string message) {
			if (isNotDisplayable(Level.INFO)) {
				return;
			}
			_printer.info(format(Level.INFO, message));
		}
		public void error(string message) {
			if (isNotDisplayable(Level.ERROR)) {
				return;
			}
			_printer.error(format(Level.ERROR, message));
		}
		public void enable() {
			_disabled = false;
		}
		public void disable() {
			_disabled = true;
		}

		private bool isNotDisplayable(Level level) {
			if (_disabled) {
				return true;
			}
			if (level < this.level) {
				return true;
			}
			return false;
		}
		private string format(Level type, string message) {
			return $"{levelToString(type)} [{_name}]{message}";
		}
	}
	internal partial class Trace {
		public enum Level {
			DEBUG = 0,
			INFO,
			ERROR,
		}
		private static class Label {
			public static readonly string DEBUG = "-";
			public static readonly string INFO = " ";
			public static readonly string ERROR = "!";
		}
		private string levelToString(Level level) {
			switch (level) {
			case Level.DEBUG:
				return Label.DEBUG;
			case Level.INFO:
				return Label.INFO;
			case Level.ERROR:
				return Label.ERROR;
			default:
				throw new ArgumentException("Undefined in enum Level");
			}
		}
	}

}
