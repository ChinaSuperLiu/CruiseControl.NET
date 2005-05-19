using System.Text;

namespace ThoughtWorks.CruiseControl.Core.Util
{
	public class ProcessArgumentBuilder
	{
		private StringBuilder builder = new StringBuilder();

		public void AppendArgument(string format, string value)
		{
			if (StringUtil.IsBlank(value)) return;

			AppendSpaceIfNotEmpty();
			builder.AppendFormat(format, value);
		}

		public void AppendArgument(string value)
		{
			AppendSpaceIfNotEmpty();
			builder.Append(value);
		}

		private void AppendSpaceIfNotEmpty()
		{
			if (builder.Length > 0) builder.Append(" ");
		}

		public override string ToString()
		{
			return builder.ToString();
		}

		public void AppendIf(bool condition, string value)
		{
			if (condition) AppendArgument(value);
		}

		public void AppendIf(bool condition, string format, string argument)
		{
			if (condition) AppendArgument(format, argument);
		}

		public void AddInQuotes(string arg, string value)
		{
			if (StringUtil.IsBlank(value)) return;

			AppendSpaceIfNotEmpty();
			builder.AppendFormat(string.Format("{0} \"{1}\"", arg, value));
		}
	}
}