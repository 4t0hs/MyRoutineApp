using MyRoutineApp.Application;

namespace MyRoutineApp.Process {
	internal partial class NetworkDriveProcess : IProcess {

		public Application.Configuration _config;

		private readonly string _sharePath;

		private readonly string _driveName;

		private readonly string _userName;

		private readonly string _password;

		public NetworkDriveProcess() {
			_config = AppService.configManager.GetConfiguration(ConfigKey.KEY);
			_sharePath = _config.Get<string>(ConfigKey.SHARE_PATH);
			_driveName = _config.Get<string>(ConfigKey.DRIVE_NAME);
			_userName = _config.Get<string>(ConfigKey.USER_NAME);
			_password = _config.Get<string>(ConfigKey.PASSWORD);
		}

		public void Main() {
			NetworkDrive drive = new NetworkDrive(_driveName);
			try {
				drive.Mount(_sharePath, _userName, _password);
			} catch (Exception ex) {
				AppService.logger.Error(ex.Message);
			}
		}
	}
	internal partial class NetworkDriveProcess {
		private static class ConfigKey {

			public static readonly string KEY = "NetworkDrive";

			public static readonly string SHARE_PATH = "SharePath";

			public static readonly string DRIVE_NAME = "DriveName";

			public static readonly string USER_NAME = "UserName";

			public static readonly string PASSWORD = "password";
		}
	}

}
