using MyRoutineApp.Application.Notification;

namespace MyRoutineApp.Application {
	internal partial class Application {
		public readonly ConfigurationManager configManager = new ConfigurationManager();
		public readonly WindowsNotification notification = new WindowsNotification();
		public readonly Logger logger = new Logger(100);
		public readonly DebugConsole console = new DebugConsole();
	}
}
