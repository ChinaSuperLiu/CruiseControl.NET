using ThoughtWorks.CruiseControl.Core.Util;

namespace ThoughtWorks.CruiseControl.Core.Test
{
	public class ProcessResultFixture
	{
		public static ProcessResult CreateSuccessfulResult()
		{
			return new ProcessResult("success", "", ProcessResult.SUCCESSFUL_EXIT_CODE, false);
		}

		public static ProcessResult CreateTimedOutResult()
		{
			return new ProcessResult("timed out", "", ProcessResult.TIMED_OUT_EXIT_CODE, true);
		}

		public static ProcessResult CreateNonZeroExitCodeResult()
		{
			return new ProcessResult("failed", "", -2, false);
		}
	}
}
