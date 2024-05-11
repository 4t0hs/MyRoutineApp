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
	partial class NetworkDrive(string driveCharacter) {

		private readonly string _driveCharacter = driveCharacter;

		public void Mount(string sharePath, string user, string password) {
			// 割り当て済みのネットワークドライブ
			if (IsAssigned()) {
				throw new ArgumentException("Drive name is already assigned.");
			}
			NETRESOURCE netResource = new NETRESOURCE() {
				dwScope = 0,
				dwType = 1,
				dwDisplayType = 0,
				dwUsage = 0,
				lpLocalName = GetDriveName(),
				lpRemoteName = sharePath,
				lpComment = "",
				lpProvider = "",
			};

			try {
				int error = WNetAddConnection3(nint.Zero, ref netResource, user, password, 0);
				if (error != 0) {
					throw new Exception($"Mount failed. sharePath={sharePath}");
				}
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}

		public void Unmount() {
			try {
				int error = WNetCancelConnection2(GetDriveName(), 0, true);
				Debug.WriteLine($"WNetCancelConnection2: {error}");
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}

		public bool IsMounted() {
			return false;
		}

		private string GetDriveName() {
			return _driveCharacter + @":";
		}

		private bool IsAssigned() {
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
