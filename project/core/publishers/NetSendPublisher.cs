using Exortech.NetReflector;
using ThoughtWorks.CruiseControl.Core.Util;

namespace ThoughtWorks.CruiseControl.Core.Publishers
{
	// THIS IS DEPRECATED
	// TODO - Delete (see http://www.microsoft.com/technet/prodtechnol/winxppro/maintain/sp2netwk.mspx#EKAA)
	[ReflectorType("netsend")]
	public class NetSendPublisher : PublisherBase
	{
		[ReflectorProperty("names")]
		public string Names;

		[ReflectorProperty("failedMessage", Required=false)]
		public string FailedMessage = "BUILD FAILED!";

		[ReflectorProperty("fixedMessage", Required=false)]
		public string FixedMessage = "BUILD FIXED!";

		public override void PublishIntegrationResults(IIntegrationResult result)
		{
			if (ShouldSendMessage(result))
			{
				string[] names = Names.Split(',');
				foreach (string name in names)
				{
					Send(name, GetMessage(result));
				}
			}
		}

		internal bool ShouldSendMessage(IIntegrationResult result)
		{
			return result.Failed || result.Fixed;
		}

		internal string GetMessage(IIntegrationResult result)
		{
			if (result.Failed)
			{
				string comment = result.Modifications.Length == 0 ? "Unknown" : result.Modifications[0].Comment;
				string committer = result.Modifications.Length == 0 ? "Unknown" : result.Modifications[0].UserName;
				return string.Format("{2}\nLast comment: {0}\nLast committer: {1}", comment, committer, FailedMessage);
			}
			else
			{
				return FixedMessage;
			}
		}

		internal int Send(string name, string message)
		{
			ProcessInfo processInfo = new ProcessInfo("net", string.Format("send \"{0}\" \"{1}\"", name, message));
			return ExecuteProcess(processInfo);
		}

		protected virtual int ExecuteProcess(ProcessInfo processInfo)
		{
			return new ProcessExecutor().Execute(processInfo).ExitCode;
		}
	}
}
