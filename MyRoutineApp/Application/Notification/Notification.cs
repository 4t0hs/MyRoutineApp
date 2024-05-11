namespace MyRoutineApp.Application.Notification {
	internal class Notification {

		private readonly WindowsNotification _desktop = new WindowsNotification();

		private readonly AppNotification _local = new AppNotification();

		public Notification() { }

		public void PopInfo(params string[] messages) {
			_desktop.Infomation(messages);
			// ローカルも出す
		}
		public void PopError(params string[] messages) {
			_desktop.Error(messages);
			// ローカルも出す
		}
	}
}
