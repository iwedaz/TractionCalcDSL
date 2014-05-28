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
		readonly string _fsiPath = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)") ,
										@"Microsoft SDKs\F#\3.1\Framework\v4.0\Fsi.exe");

		readonly string _fileName;
		readonly List<string> _scriptLines;

		readonly ProcessStartInfo _startupInfo;

		FsiSession _session;
		Process _proc;

		public event EventHandler<string> UpdateText;
		public FSharpInterctive(string fileName , IEnumerable<string> scriptLines)
		{
			InitializeComponent();
			fastColoredTextBox1.Text = "";
			Text = Path.GetFileName(fileName) + "  in FSharpInterctive";

			_fileName = fileName;
			_scriptLines = new List<string>(scriptLines);

			_startupInfo = new ProcessStartInfo()
			{
				FileName = _fsiPath ,
				WindowStyle = ProcessWindowStyle.Normal ,
				CreateNoWindow = true ,
				UseShellExecute = false ,
				RedirectStandardOutput = true ,
				RedirectStandardInput = true
			};
		}

		public void Run()
		{
			_proc = new Process();
			_proc.StartInfo.FileName = _fsiPath;
			_proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			_proc.StartInfo.CreateNoWindow = true;
			_proc.StartInfo.UseShellExecute = false;
			_proc.StartInfo.EnvironmentVariables["path"] += ";" + Path.GetDirectoryName(_fileName);
			_proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(_fileName);
			_proc.StartInfo.RedirectStandardOutput = true;
			_proc.StartInfo.RedirectStandardError = true;
			_proc.StartInfo.RedirectStandardInput = true;
			_proc.Start();
			_proc.BeginOutputReadLine();
			_proc.BeginErrorReadLine();

			foreach(var item in _scriptLines)
				_proc.StandardInput.WriteLine(item);


			var v = _proc.StartInfo.EnvironmentVariables ["path"];
			_proc.StandardInput.WriteLine(";;");
			_proc.OutputDataReceived += Session_OutputReceived;
			_proc.ErrorDataReceived += Session_ErrorReceived;
			_proc.StandardInput.Flush();

			//session = new FsiSession(_startupInfo);
			//session.OutputReceived += Session_OutputReceived;
			//session.ErrorReceived += Session_ErrorReceived;
			//session.Start();

			//foreach(var item in _scriptLines)
			//	session.AddLine(item);


			//session.Evaluate();
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
			if(_session != null)
				_session.Close();

			if(_proc != null)
				_proc.Close();

			e.Cancel = false;
		}
	}
}
