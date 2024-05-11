using System.Diagnostics;
using Windows.UI.Notifications;

namespace MyRoutineApp.Application.Notification {
	internal partial class WindowsNotification {
		private partial class Notifier(string appName) {

			private static readonly string GROUP = "Notification";

			private readonly ToastNotifier _toastNotifier = ToastNotificationManager.CreateToastNotifier(appName);

			private readonly string _appName = appName;

			public void Show(NotificationContent content) {
				Debug.WriteLine("Show notification.");
				_toastNotifier.Show(CreateNotification(content));
			}

			public void ShowFor(NotificationContent content, int seconds) {
				ToastNotification notification = CreateNotification(content);
				Debug.WriteLine("Show notification.");
				_toastNotifier.Show(notification);
				RemoveAfter(seconds, notification);
			}

			private void RemoveAfter(int seconds, ToastNotification notification) {
				System.Timers.Timer timer = new System.Timers.Timer(seconds * 1000);
				timer.Elapsed += (s, e) => {
					System.Diagnostics.Debug.WriteLine("timer!!!");
					// fixme: hideがあっても、一定時間で消えるのでhideするまで消えないような設定を調査する必要あり
					_toastNotifier.Hide(notification);
					Remove(notification);
				};
				// タイマーハンドラ起動後タイマーをリセットしない
				timer.AutoReset = false;
				// タイマー開始
				timer.Enabled = true;
			}

			private void Remove(ToastNotification target) {
				ToastNotificationHistory history = ToastNotificationManager.History;
				history.Remove(target.Tag, target.Group, _appName);
			}

			private static ToastNotification CreateNotification(NotificationContent content) {
				return new ToastNotification(content.document) {
					Group = GROUP,
					Tag = DateTime.Now.ToString()
				};
			}
		}
	}
}
