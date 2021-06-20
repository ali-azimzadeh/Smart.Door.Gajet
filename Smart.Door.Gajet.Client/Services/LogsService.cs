using Azx.Razor;

namespace Smart.Door.Gajet.Client.Services
{
	/// <summary>
	/// این کلاس برای ثبت و ضبط کلیه ی وقایع و اتفاقاتی وخطاهایی که 
	/// در هنگام کار با نرم افزار توسط کاربر ممکن است بوجود 
	/// بیاید به کار می رود کلیه این وقایع در یک فایل متنی ذخیره می شود 
	/// که در سمت کلاینت می باشد که بعد ها در صورت نیاز می توان به آن قایل مراجعه کرد و 
	/// مشکلات بوجود آمده را بررسی نمود
	/// </summary>
	public class LogsService : object
	{
		public LogsService() : base()
		{
			Logs =
				new System.Collections.Generic.List<Models.Log>();
		}

		protected System.Collections.Generic.IList<Models.Log> Logs { get; }

		public void AddLog(System.Type type, string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			// **************************************************
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();
			// **************************************************

			message =
				$"{ type.Namespace } -> { type.Name } -> { methodBase.Name }: { message.Fix() }";

			var log =
				new Models.Log(message: message);

			//Logs.Add(log);
			Logs.Insert(index: 0, item: log);
		}

		public void AddLog(System.Type type, Models.Log log)
		{
			if (log == null)
			{
				return;
			}

			if (string.IsNullOrWhiteSpace(log.Message))
			{
				return;
			}

			// **************************************************
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();
			// **************************************************

			log.Message =
				$"{ type.Namespace } -> { type.Name } -> { methodBase.Name }: { log.Message.Fix() }";

			Logs.Insert(index: 0, item: log);
		}

		public System.Collections.Generic.IList<Models.Log> GetLogs()
		{
			return Logs;
		}

		public void ClearLogs()
		{
			Logs.Clear();
		}
	}
}
