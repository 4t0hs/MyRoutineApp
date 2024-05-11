using MyRoutineApp.Application;
using System.IO;

namespace MyRoutineApp.Process.Svn {
	internal partial class Svn {

		private readonly string _directory = string.Empty;

		public Svn(string directory) {
			if (!Directory.Exists(directory)) {
				throw new ArgumentException("Specified directory does not exist.");
			}
			_directory = directory;
		}

		public bool Update() {
			Command command = BuildCommand(SvnCommand.UPDATE, _directory);
			command.Execute();
			return SvnCommand.IsSuccess(command.exitCode);
		}

		public bool Cleanup() {
			Command command = BuildCommand(SvnCommand.CLEANUP, _directory);
			command.Execute();
			return SvnCommand.IsSuccess(command.exitCode);
		}

		private static Command BuildCommand(params string[] args) {
			return new Command(SvnCommand.COMMAND, args);
		}
	}
	internal partial class Svn {
		private static class SvnCommand {

			public static readonly string COMMAND = "svn";

			public static readonly string UPDATE = "update";

			public static readonly string CLEANUP = "cleanup";

			public static bool IsSuccess(int exitCode) {
				return exitCode == 0;
			}
		}
	}
}
