namespace MyRoutineApp.Process {
	internal interface IProcess {
		Application.Application _app { get; }
		Application.Configuration _config { get; }

		void main();
	}
}
