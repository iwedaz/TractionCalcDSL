using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
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

			var rusLowLetter = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

			foreach(var item in _scriptLines)
			{
				StringBuilder strBuilder = new StringBuilder(item);
				//for(int i = 0 ; i < strBuilder.Length ; i++)
				//{
				//	if(rusLowLetter.Contains(strBuilder [i].ToString()))
				//		strBuilder [i] = Char.ToUpper(strBuilder [i]);
				//}

				Encoding destinationDecoder1 = System.Console.OutputEncoding;
				Encoding destinationDecoder2 = System.Console.InputEncoding;
				Encoding destinationDecoder3 = Encoding.Default;
				Encoding destinationDecoder4 = Encoding.UTF7;
				Encoding destinationDecoder5 = Encoding.UTF8;
				Encoding destinationDecoder6 = Encoding.UTF32;
				Encoding destinationDecoder7 = Encoding.Unicode;
				Encoding destinationDecoder8 = Encoding.GetEncoding(866);
				Encoding destinationDecoder9 = Encoding.GetEncoding(1251);
				Encoding destinationDecoder10 = _proc.StandardInput.Encoding;
				

				byte [] bStr = Encoding.UTF8.GetBytes(strBuilder.ToString());

				byte [] dstBytes1 = Encoding.Convert(Encoding.UTF8 , destinationDecoder1 , bStr);
				byte [] dstBytes2 = Encoding.Convert(Encoding.UTF8 , destinationDecoder2 , bStr);
				byte [] dstBytes3 = Encoding.Convert(Encoding.UTF8 , destinationDecoder3 , bStr);
				byte [] dstBytes4 = Encoding.Convert(Encoding.UTF8 , destinationDecoder4 , bStr);
				byte [] dstBytes5 = Encoding.Convert(Encoding.UTF8 , destinationDecoder5 , bStr);
				byte [] dstBytes6 = Encoding.Convert(Encoding.UTF8 , destinationDecoder6 , bStr);
				byte [] dstBytes7 = Encoding.Convert(Encoding.UTF8 , destinationDecoder7 , bStr);
				byte [] dstBytes8 = Encoding.Convert(Encoding.UTF8 , destinationDecoder8 , bStr);
				byte [] dstBytes9 = Encoding.Convert(Encoding.UTF8 , destinationDecoder9 , bStr);

				string str1 = destinationDecoder1.GetString(bStr);
				string str2 = destinationDecoder2.GetString(bStr);
				string str3 = destinationDecoder3.GetString(bStr);
				string str4 = destinationDecoder4.GetString(bStr);
				string str5 = destinationDecoder5.GetString(bStr);
				string str6 = destinationDecoder6.GetString(bStr);
				string str7 = destinationDecoder7.GetString(bStr);
				string str8 = destinationDecoder8.GetString(bStr);
				string str9 = destinationDecoder9.GetString(bStr);

				if(item.Contains("поезд"))
				{
					int i = 0;
					i++;
				}

				//_proc.StandardInput.WriteLine(strBuilder.ToString());
				_proc.StandardInput.WriteLine(str8);
				//_proc.StandardInput.WriteLine(item);
			}

			var v = _proc.StartInfo.EnvironmentVariables ["path"];
			_proc.StandardInput.WriteLine(";;");
			_proc.OutputDataReceived += Session_OutputReceived;
			_proc.ErrorDataReceived += Session_ErrorReceived;
			_proc.StandardInput.Flush();
		}

		private void Session_ErrorReceived(object sender , DataReceivedEventArgs e)
		{
			AppendText(e.Data);
		}

		private void Session_OutputReceived(object sender , DataReceivedEventArgs e)
		{
			AppendText(e.Data);
		}

		public void AppendText(string consoleOutputText)
		{
			if(consoleOutputText == null)
				return;

			if(InvokeRequired)
				this.BeginInvoke((MethodInvoker) delegate
				{
					AppendText(consoleOutputText);
				});
			else
			{
				//Encoding destinationDecoder = Encoding.Default;
				//Encoding destinationDecoder = Encoding.UTF8;
				//Encoding destinationDecoder = Encoding.Unicode;
				//Encoding destinationDecoder = Encoding.GetEncoding(866);
				//Encoding destinationDecoder = System.Console.InputEncoding;
				Encoding sourceDecoder = System.Console.OutputEncoding;

				byte [] bStr = sourceDecoder.GetBytes(consoleOutputText);

				string str1 = Encoding.UTF8.GetString(bStr);
				string str2 = Encoding.ASCII.GetString(bStr);
				string str3 = Encoding.BigEndianUnicode.GetString(bStr);
				string str4 = Encoding.Default.GetString(bStr);
				string str5 = Encoding.Unicode.GetString(bStr);
				string str6 = Encoding.UTF32.GetString(bStr);
				string str7 = Encoding.UTF7.GetString(bStr);
				string str8 = Encoding.GetEncoding(1251).GetString(bStr);
				string str9 = System.Console.InputEncoding.GetString(bStr);
				string str10 = System.Console.OutputEncoding.GetString(bStr);

				string decodedStr = Encoding.GetEncoding(866).GetString(bStr);

				if(decodedStr.Contains("задача5"))
				{
					int i = 0;
					i++;
				}
				if(decodedStr.Contains("яюхчф"))
				{
					int i = 0;
					i++;
				}

				fastColoredTextBox1.AppendText(decodedStr + Environment.NewLine);
			}
		}

		protected virtual void UpdateTextEvent(string str)
		{
			if(UpdateText != null)
				UpdateText(this , str);
		}

		private void FSharpInterctive_FormClosing(object sender , FormClosingEventArgs e)
		{
			if(_proc != null)
				_proc.Close();

			e.Cancel = false;
		}
	}
}
