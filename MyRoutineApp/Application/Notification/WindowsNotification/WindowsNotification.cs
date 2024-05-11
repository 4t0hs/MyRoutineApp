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

		public void Infomation(params string[] messages) {
			NotificationContent content = CreateContent(Title.INFO, Image.INFO, messages);
			// todo:設定値を使って出力するかの判断および、表示する時間を設定したい
			try {
				_notifier.Show(content);
			} catch (Exception ex) {
				LogError(ex);
			}
		}

		public void Error(params string[] messages) {
			NotificationContent content = CreateContent(Title.ERROR, Image.ERROR, messages);
			try {
				_notifier.Show(content);
			} catch (Exception ex) {
				LogError(ex);
			}
		}

		private static NotificationContent CreateContent(string title, string image, string[] messages) {
			NotificationContent content = new NotificationContent();
			content.AddTitle(title);
			content.AddBody(messages);
			content.AddImage(image);
			return content;
		}

		private void LogError(Exception e) {
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
