namespace MyRoutineApp {
	partial class AppNotifyIcon {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppNotifyIcon));
			notifyIcon = new NotifyIcon(components);
			contextMenuStrip = new ContextMenuStrip(components);
			toolStripMenuItem_Notification = new ToolStripMenuItem();
			toolStripMenuItem_Settings = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			toolStripMenuItem_Exit = new ToolStripMenuItem();
			contextMenuStrip.SuspendLayout();
			// 
			// notifyIcon
			// 
			notifyIcon.ContextMenuStrip = contextMenuStrip;
			notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
			notifyIcon.Text = "My Routine App";
			notifyIcon.Visible = true;
			// 
			// contextMenuStrip
			// 
			contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_Notification, toolStripMenuItem_Settings, toolStripSeparator1, toolStripMenuItem_Exit });
			contextMenuStrip.Name = "contextMenuStrip";
			contextMenuStrip.Size = new Size(99, 76);
			// 
			// toolStripMenuItem_Notification
			// 
			toolStripMenuItem_Notification.Name = "toolStripMenuItem_Notification";
			toolStripMenuItem_Notification.Size = new Size(98, 22);
			toolStripMenuItem_Notification.Text = "通知";
			// 
			// toolStripMenuItem_Settings
			// 
			toolStripMenuItem_Settings.Name = "toolStripMenuItem_Settings";
			toolStripMenuItem_Settings.Size = new Size(98, 22);
			toolStripMenuItem_Settings.Text = "設定";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(95, 6);
			// 
			// toolStripMenuItem_Exit
			// 
			toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
			toolStripMenuItem_Exit.Size = new Size(98, 22);
			toolStripMenuItem_Exit.Text = "終了";
			contextMenuStrip.ResumeLayout(false);
		}

		#endregion

		private NotifyIcon notifyIcon;
		private ContextMenuStrip contextMenuStrip;
		private ToolStripMenuItem toolStripMenuItem_Settings;
		private ToolStripMenuItem toolStripMenuItem_Exit;
		private ToolStripMenuItem toolStripMenuItem_Notification;
		private ToolStripSeparator toolStripSeparator1;
	}
}
