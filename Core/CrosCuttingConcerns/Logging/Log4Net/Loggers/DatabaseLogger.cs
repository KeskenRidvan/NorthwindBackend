namespace Core.CrosCuttingConcerns.Logging.Log4Net.Loggers;
public class DatabaseLogger : LoggerServiceBase
{
	string name = "DatabaseLogger";
	public DatabaseLogger(string name) : base(name)
	{
	}
}