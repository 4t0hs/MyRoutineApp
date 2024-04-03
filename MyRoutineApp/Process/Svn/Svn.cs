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
		public bool update() {
			Command command = createCommand(SvnCommand.UPDATE, _directory);
			command.execute();
			return SvnCommand.isSuccess(command.exitCode);
		}

		public bool cleanup() {
			Command command = createCommand(SvnCommand.CLEANUP, _directory);
			command.execute();
			return SvnCommand.isSuccess(command.exitCode);
		}
		private Command createCommand(params string[] args) {
			return new Command(SvnCommand.COMMAND, args);
		}
	}
	internal partial class Svn {
		private static class SvnCommand {
			public static readonly string COMMAND = "svn";
			public static readonly string UPDATE = "update";
			public static readonly string CLEANUP = "cleanup";
			public static bool isSuccess(int exitCode) {
				return exitCode == 0;
			}
		}
	}
}
