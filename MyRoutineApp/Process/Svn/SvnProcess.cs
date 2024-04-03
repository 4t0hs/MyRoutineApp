namespace MyRoutineApp.Process.Svn {
	internal partial class SvnProcess : IProcess {
		public Application.Application _app { get; }
		public Application.Configuration _config { get; }

		private string[] _checkoutDirectories { get; }

		public SvnProcess(Application.Application app) {
			_app = app;
			_config = _app.configManager.getConfiguration(ConfigKey.KEY);
			_checkoutDirectories = _config.getArray<string>(ConfigKey.CHECKOUT_DIRECTORIES);
		}
		public void main() {
			const int numAttempts = 10;

			foreach (string dir in _checkoutDirectories) {
				bool updateFailed = true;
				for (int i = 0; i < numAttempts; i++) {
					Svn svn = new Svn(dir);
					// 更新に失敗したらクリーンアップ子もう一度試す
					if (svn.update()) {
						_app.logger.info($"Updated svn. {dir}");
						updateFailed = false;
						break;
					}
					svn.cleanup();
				}
				if (updateFailed) {
					_app.logger.error($"Svn({dir}) update failed.");
				}
			}
		}
	}
	internal partial class SvnProcess {
		private static class ConfigKey {
			public static readonly string KEY = "Svn";

			public static readonly string CHECKOUT_DIRECTORIES = "CheckoutDirectories";
		}
	}
}
