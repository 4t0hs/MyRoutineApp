using System.Diagnostics;

namespace MyRoutineApp.Application {
	internal class Command {

		public string output { get; private set; } = string.Empty;

		public int exitCode { get; private set; } = -1;

		private readonly string _command = string.Empty;

		public Command(string command) {
			_command = command;
		}
		public Command(string command, params string[] arguments) {
			_command = $"{command} {string.Join(" ", arguments)}";
		}

		public bool Execute() {
			System.Diagnostics.ProcessStartInfo startInfo = Prepare();
			System.Diagnostics.Process? process = System.Diagnostics.Process.Start(startInfo);
			if (process == null) {
				return false;
			}
			process.WaitForExit();
			output = process.StandardOutput.ReadToEnd();
			exitCode = process.ExitCode;
			process.Close();
			Debug.WriteLine($"command={startInfo.Arguments}, exit={exitCode}, output:\n{output}");
			return true;
		}

		private System.Diagnostics.ProcessStartInfo Prepare() {
			return new System.Diagnostics.ProcessStartInfo() {
				FileName = "cmd",
				Arguments = "/c " + _command,
				// コンソールは開かない
				CreateNoWindow = true,
				// シェル機能仕様市内
				UseShellExecute = false,
				// 標準出力をリダイレクト
				RedirectStandardOutput = true,
			};
		}
	}
}
