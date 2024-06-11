namespace Core.CrosCuttingConcerns.Logging.Log4Net.Loggers;
public class FileLogger : LoggerServiceBase
{
	string name = "JsonFileLogger";
	public FileLogger(string name) : base(name)
	{
	}
}