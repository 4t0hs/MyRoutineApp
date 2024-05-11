namespace MyRoutineApp.Application {
	internal static class AppService {

		public static readonly ConfigurationManager configManager = new ConfigurationManager();

		public static readonly Notification.Notification notification = new Notification.Notification();

		public static readonly Logger logger = new Logger(100);

		public static readonly DebugConsole console = new DebugConsole();
	}
}
