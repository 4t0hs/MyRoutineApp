using System.Runtime.CompilerServices;

namespace MyRoutineApp.Application {
	internal partial class Trace(string name, Printer printer) {

		public Level level { get; set; } = Level.INFO;

		private bool _disabled = false;

		private readonly Printer _printer = printer;

		private readonly string _name = name;

		public void Debug(string message, [CallerMemberName] string callerMathod = "") {
			if (IsNotDisplayable(Level.DEBUG)) {
				return;
			}
			string output = $"{callerMathod}::{message}";
			_printer.debug(Format(Level.DEBUG, output));
		}

		public void Info(string message) {
			if (IsNotDisplayable(Level.INFO)) {
				return;
			}
			_printer.info(Format(Level.INFO, message));
		}

		public void Error(string message) {
			if (IsNotDisplayable(Level.ERROR)) {
				return;
			}
			_printer.error(Format(Level.ERROR, message));
		}

		public void Enable() {
			_disabled = false;
		}

		public void Disable() {
			_disabled = true;
		}

		private bool IsNotDisplayable(Level level) {
			if (_disabled) {
				return true;
			}
			if (level < this.level) {
				return true;
			}
			return false;
		}

		private string Format(Level type, string message) {
			return $"{LevelToString(type)} [{_name}]{message}";
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
		private static string LevelToString(Level level) {
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
