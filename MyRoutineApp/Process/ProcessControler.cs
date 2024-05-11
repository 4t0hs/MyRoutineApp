namespace MyRoutineApp.Process {
	internal class ProcessControler {
		private List<IProcess> _proceses = new List<IProcess>();
		private System.Windows.Application _systemApplication;

		public ProcessControler(System.Windows.Application systemApplication) {
			_systemApplication = systemApplication;
		}

		public void RegisterProcess(IProcess process) {
			_proceses.Add(process);
		}

	}
}
