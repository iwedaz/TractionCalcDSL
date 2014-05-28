using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using FsiRunner;
using System.IO;

namespace FSharpGUI
{
	public partial class FSharpInterctive : Form
	{
		public event EventHandler<string> UpdateText;

		readonly ProcessStartInfo _startupInfo = new ProcessStartInfo()
		{
			FileName = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)") ,
										@"Microsoft SDKs\F#\3.1\Framework\v4.0\Fsi.exe") ,
			WindowStyle = ProcessWindowStyle.Normal ,
			CreateNoWindow = false ,
			UseShellExecute = false ,
			RedirectStandardOutput = true
		};

		readonly List<string> _scriptLines;
		FsiSession session;

		public FSharpInterctive(string fileName , IEnumerable<string> scriptLines)
		{
			InitializeComponent();
			fastColoredTextBox1.Text = "";
			Text = fileName + "  in FSharpInterctive";

			_scriptLines = new List<string>(scriptLines);
		}

		public void Run()
		{
			//Process proc = new Process();
			//proc.StartInfo = _startupInfo;
			//proc.StartInfo.Arguments = " --exec " + tsFiles.SelectedItem.Tag.ToString();
			//proc.Start();
			//proc.WaitForExit();
			//var v = proc.ExitCode;


			session = new FsiSession(_startupInfo.FileName);
			session.OutputReceived += Session_OutputReceived;
			session.ErrorReceived += Session_ErrorReceived;
			session.Start();

			foreach(var item in _scriptLines)
				session.AddLine(item);


			session.Evaluate();
		}

		private void Session_ErrorReceived(object sender , DataReceivedEventArgs e)
		{
			AppendText(e.Data);
		}

		private void Session_OutputReceived(object sender , DataReceivedEventArgs e)
		{
			AppendText(e.Data);
		}

		public void AppendText(string str)
		{
			if(InvokeRequired)
				this.BeginInvoke((MethodInvoker) delegate
					{
						AppendText(str);
					});
			else fastColoredTextBox1.AppendText(str + Environment.NewLine);
		}

		protected virtual void UpdateTextEvent(string str)
		{
			if(UpdateText != null)
				UpdateText(this , str);
		}

		private void FSharpInterctive_FormClosing(object sender , FormClosingEventArgs e)
		{
			session.Close();
		}
	}
}
