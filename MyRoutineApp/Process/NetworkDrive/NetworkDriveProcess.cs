namespace MyRoutineApp.Process {
	internal partial class NetworkDriveProcess : IProcess {
		public Application.Application _app { get; }
		public Application.Configuration _config { get; }

		private string _sharePath { get; }
		private string _driveName { get; }
		private string _userName { get; }
		private string _password { get; }

		public NetworkDriveProcess(Application.Application app) {
			_app = app;
			_config = _app.configManager.getConfiguration(ConfigKey.KEY);
			_sharePath = _config.get<string>(ConfigKey.SHARE_PATH);
			_driveName = _config.get<string>(ConfigKey.DRIVE_NAME);
			_userName = _config.get<string>(ConfigKey.USER_NAME);
			_password = _config.get<string>(ConfigKey.PASSWORD);
		}
		public void main() {
			NetworkDrive drive = new NetworkDrive(_driveName);
			try {
				drive.mount(_sharePath, _userName, _password);
			} catch (Exception ex) {
				_app.logger.error(ex.Message);
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
