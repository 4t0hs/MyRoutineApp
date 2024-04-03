using System.IO;

namespace MyRoutineApp.Application.Notification {
	internal partial class WindowsNotification {
		private static readonly string APPLICATION_NAME = "My Routine";
		// 表示する時間とかをユーザーで設定できるようにしたい
		// "Application": [
		//	  "Notification": [
		//	    "情報を表示する時間": 0 0の時はずっと表示する
		//		"エラーをリマインドするか": true false
		private readonly Notifier _notifier;
		public WindowsNotification() {
			_notifier = new Notifier(APPLICATION_NAME);
		}

		public void infomation(params string[] messages) {
			NotificationContent content = createContent(Title.INFO, Image.INFO, messages);
			// todo:設定値を使って出力するかの判断および、表示する時間を設定したい
			try {
				_notifier.show(content);
			} catch (Exception ex) {
				logError(ex);
			}
		}

		public void error(params string[] messages) {
			NotificationContent content = createContent(Title.ERROR, Image.ERROR, messages);
			try {
				_notifier.show(content);
			} catch (Exception ex) {
				logError(ex);
			}
		}
		private NotificationContent createContent(string title, string image, string[] messages) {
			NotificationContent content = new NotificationContent(Title.INFO);
			content.addBody(messages);
			content.addImage(image);
			return content;
		}
		private void logError(Exception e) {
		}
	}
	internal partial class WindowsNotification {
		private static class Title {
			public static readonly string INFO = "[確認]";
			public static readonly string ERROR = "[エラー]";
		}
		private static class Image {
			public static readonly string INFO = Path.Join(Directory.GetCurrentDirectory(), @"icons\info_notification.png");
			public static readonly string ERROR = Path.Join(Directory.GetCurrentDirectory(), @"icons\err_notification.png");
		}
	}

}
