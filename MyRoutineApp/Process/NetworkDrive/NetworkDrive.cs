using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace MyRoutineApp.Process {
	partial class NetworkDrive {
		[StructLayout(LayoutKind.Sequential)]
		private struct NETRESOURCE {
			public int dwScope;
			public int dwType;
			public int dwDisplayType;
			public int dwUsage;
			public string lpLocalName;
			public string lpRemoteName;
			public string lpComment;
			public string lpProvider;
		}

		[DllImport("mpr.dll")]
		private static extern int WNetAddConnection3(
			nint hWndOwner,
			ref NETRESOURCE lpNetResource,
			string lpPassword,
			string lpUserName,
			int dwFlags
		);

		[DllImport("mpr.dll")]
		private static extern int WNetCancelConnection2(
			string lpName,
			int dwFlags,
			bool fForce
		);

		[DllImport("mpr.dll")]
		private static extern int WNetAddConnection2(
			ref NETRESOURCE lpNetResource,
			string lpPassword,
			string lpUsername,
			int dwFlags
		);
	}
	partial class NetworkDrive {
		private readonly string _driveCharacter = string.Empty;

		public NetworkDrive(string driveCharacter) {
			_driveCharacter = driveCharacter;
		}
		public void mount(string sharePath, string user, string password) {
			// 割り当て済みのネットワークドライブ
			if (isAssigned()) {
				throw new ArgumentException("Drive name is already assigned.");
			}
			NETRESOURCE netResource = new NETRESOURCE();
			netResource.dwScope = 0;
			netResource.dwType = 1;
			netResource.dwDisplayType = 0;
			netResource.dwUsage = 0;
			netResource.lpLocalName = getDriveName();
			netResource.lpRemoteName = sharePath;
			netResource.lpComment = "";
			netResource.lpProvider = "";

			try {
				int error = WNetAddConnection3(nint.Zero, ref netResource, user, password, 0);
				if (error != 0) {
					throw new Exception($"Mount failed. sharePath={sharePath}");
				}
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
		public void unmount() {
			try {
				int error = WNetCancelConnection2(getDriveName(), 0, true);
				Debug.WriteLine($"WNetCancelConnection2: {error}");
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
		public bool isMounted() {
			return false;
		}
		private string getDriveName() {
			return _driveCharacter + @":";
		}
		private bool isAssigned() {
			string[] driveNames = Directory.GetLogicalDrives();

			foreach (string driveName in driveNames) {
				if (driveName.Contains(_driveCharacter, StringComparison.OrdinalIgnoreCase)) {
					return true;
				}
			}
			return false;
		}
	}
}
