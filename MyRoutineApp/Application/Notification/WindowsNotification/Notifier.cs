using System.Diagnostics;
using Windows.UI.Notifications;

namespace MyRoutineApp.Application.Notification {
	internal partial class WindowsNotification {
		private partial class Notifier {
			private static readonly string GROUP = "Notification";
			private readonly ToastNotifier _toastNotifier;
			private readonly string _appName = string.Empty;

			public Notifier(string appName) {
				_appName = appName;
				_toastNotifier = ToastNotificationManager.CreateToastNotifier(appName);
			}
			public void show(NotificationContent content) {
				Debug.WriteLine("Show notification.");
				_toastNotifier.Show(createNotification(content));
			}
			public void showFor(NotificationContent content, int seconds) {
				ToastNotification notification = createNotification(content);
				Debug.WriteLine("Show notification.");
				_toastNotifier.Show(notification);
				removeAfter(seconds, notification);
			}

			private void removeAfter(int seconds, ToastNotification notification) {
				System.Timers.Timer timer = new System.Timers.Timer(seconds * 1000);
				timer.Elapsed += (s, e) => {
					System.Diagnostics.Debug.WriteLine("timer!!!");
					// fixme: hideがあっても、一定時間で消えるのでhideするまで消えないような設定を調査する必要あり
					_toastNotifier.Hide(notification);
					remove(notification);
				};
				// タイマーハンドラ起動後タイマーをリセットしない
				timer.AutoReset = false;
				// タイマー開始
				timer.Enabled = true;
			}

			private void remove(ToastNotification target) {
				ToastNotificationHistory history = ToastNotificationManager.History;
				history.Remove(target.Tag, target.Group, _appName);
			}
			private ToastNotification createNotification(NotificationContent content) {
				return new ToastNotification(content.document) {
					Group = GROUP,
					Tag = DateTime.Now.ToString()
				};
			}
		}
	}
}
