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
Initialization using custom string. In this case Logger's name will be equal to used string.
```
ILogger Log = Logger.Logger.GetLogger("ConsoleAppDotNetSample");
```

Initialization using any object. In this case Logger's name will be equal to type name of used object.
```
ILogger Log = Logger.Logger.GetLogger(this);
ILogger Log = Logger.Logger.GetLogger(anyObject);
```

This second way also could be simplified
```
ILogger Log = anyObject.GetLogger();
ILogger Log = this.GetLogger();
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

Telegram: https://t.me/ryabinin_alex

## License
Logger is licensed under the MIT license.
