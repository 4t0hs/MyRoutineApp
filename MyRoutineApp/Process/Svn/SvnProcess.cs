using MyRoutineApp.Application;

namespace MyRoutineApp.Process.Svn {
	internal partial class SvnProcess : IProcess {

		public Application.Configuration _config;

		private readonly string[] _checkoutDirectories;

		public SvnProcess() {
			_config = AppService.configManager.GetConfiguration(ConfigKey.KEY);
			_checkoutDirectories = _config.GetArray<string>(ConfigKey.CHECKOUT_DIRECTORIES);
		}

		public void Main() {
			const int numAttempts = 10;

			foreach (string dir in _checkoutDirectories) {
				bool updateFailed = true;
				for (int i = 0; i < numAttempts; i++) {
					Svn svn = new Svn(dir);
					// 更新に失敗したらクリーンアップ子もう一度試す
					if (svn.Update()) {
						AppService.logger.Info($"Updated svn. {dir}");
						updateFailed = false;
						break;
					}
					svn.Cleanup();
				}
				if (updateFailed) {
					AppService.logger.Error($"Svn({dir}) update failed.");
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
