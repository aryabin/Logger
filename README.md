# logger
Lightwaight and ease to use logger for .Net

This project has been made as attempt to create logger which could be used out of the box. I mean something like Plug and Play - without difficult configuration and thinking about files location.

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

This second way also could be simplified using Logger.Extensions namespace
```
using Logger.Extensions;
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
