﻿using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System.Reflection;
using System.Xml;

namespace Core.CrosCuttingConcerns.Logging.Log4Net;
public class LoggerServiceBase
{
	private ILog _log;

	public LoggerServiceBase(string name)
	{
		XmlDocument xmlDocument = new();
		xmlDocument.Load(inStream: File.OpenRead(path: "log4net.config"));

		ILoggerRepository loggerRepository =
			LogManager.CreateRepository(
				Assembly.GetEntryAssembly(),
				typeof(Hierarchy));

		XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

		_log = LogManager.GetLogger(loggerRepository.Name, name);
	}
	public bool IsInfoEnabled => _log.IsInfoEnabled;
	public bool IsDebugEnabled => _log.IsDebugEnabled;
	public bool IsWarnEnabled => _log.IsWarnEnabled;
	public bool IsFatalEnabled => _log.IsFatalEnabled;
	public bool IsErrorEnabled => _log.IsErrorEnabled;

	public void Info(object logMessage)
	{
		if (IsInfoEnabled)
			_log.Info(logMessage);
	}
	public void Debug(object logMessage)
	{
		if (IsDebugEnabled)
			_log.Debug(logMessage);
	}
	public void Warn(object logMessage)
	{
		if (IsWarnEnabled)
			_log.Warn(logMessage);
	}
	public void Fatal(object logMessage)
	{
		if (IsFatalEnabled)
			_log.Fatal(logMessage);
	}
	public void Error(object logMessage)
	{
		if (IsErrorEnabled)
			_log.Error(logMessage);
	}
}