# Logger
Lightwaight and ease to use logger for .Net

This project has been made as attempt to create logger which could be used out of the box. I mean something like Plug and Play - without difficult configuration and thinking about files location.

## Compatibility
According to official [documentation](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0), you can use this logger with the following .Net versions.
| .NET implementation | Version support |
| --- | --- |
| .NET and .NET Core | 2.0, 2.1, 2.2, 3.0, 3.1, 5.0, 6.0, 7.0 |
| .NET Framework | 4.6.1 2, 4.6.2, 4.7, 4.7.1, 4.7.2, 4.8, 4.8.1 |
| Mono | 5.4, 6.4 |
| Xamarin.iOS | 10.14, 12.16 |
| Xamarin.Mac | 3.8, 5.16 |
| Xamarin.Android | 8.0, 10.0 |
| Universal Windows Platform | 10.0.16299 |
| Unity | 2018.1 |

Please let me know if you are interesting in version for .Net Standard 2.1

## How to initialize
There are two ways to initialize Logger.

### Use static class LoggerManager
``` csharp
// Default logger with custom name
ILogger Log = LoggerManager.GetLogger("LoggerName");

// Default logger with name equel to type of obgect passed as parameter
ILogger Log = LoggerManager.GetLogger(myObject);

// Default logger with custom name and custom level
ILogger Log = LoggerManager.GetLoggerBuilder().SetName("LoggerName").SetLevel(LogLevel.Info).Build();

// File logger with custom name and custom level
ILogger Log = LoggerManager.GetLoggerBuilder(LoggerType.File).SetName("LoggerName").SetLevel(LogLevel.Debug).Build();
```

### Use object extensions
``` csharp
// Default logger with name equel to type of used object
ILogger Log = myObject.GetLogger();

// Default logger with custom name and custom level
ILogger Log = myObject.GetLoggerBuilder().SetName("LoggerName").SetLevel(LogLevel.Error).Build();

// Console logger with custom name and custom level
ILogger Log = myObject.GetLoggerBuilder(LoggerType.Console).SetName("MyObjectConsoleLogger").SetLevel(LogLevel.Warning).Build();

// Default logger with name equel to name of current class
ILogger Log = this.GetLogger();

// Default logger with name equel to name of current class and custom level
ILogger Log = this.GetLoggerBuilder().SetLevel(LogLevel.Trace).Build();

// File logger with name equel to name of current class and custom level
ILogger Log = this.GetLoggerBuilder(LoggerType.File).SetLevel(LogLevel.Trace).Build();
```

## How to use LoggerManager
LoggerManager is responsible for instantiating new instances of ILogger.
This class contains default type (LoggerType.File) and default level (LoggerType.Console) for all loggers.

You can change them using the following methods
``` csharp
LoggerManager.SetType(LoggerType.File);
LoggerManager.SetType(LoggerType.Console);

LoggerManager.SetLevel(LogLevel.Info);
```

## Default configuration
```
{
  "Level": 3,
  "File": {
    "Path": "<Location of your application>\\<Name of your application>.log",
    "Size": 53687091200,
    "Count": 5,
    "BufferSize": 65536
  },
  "Message": {
    "DateTimeFormat": "yyyy-MM-dd HH:mm:ss.fff",
    "Delimeter": "\t",
    "MethodEnterMessage": "+", // 
    "MethodExitMessage": "-"
  },
  "Handler": {
    "Delay": 500
  }
}
```

## Contacts
Please contact [Alexander Ryabinin](mailto:ryabinin_alex@mail.ru?subject=[GitHub]%20Feedback%20or%suggestion)
if you would share any feedback or suggestion. I would be appreciate it.

## License
Logger is licensed under the MIT license.
