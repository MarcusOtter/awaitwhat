# AwaitWhat ⁉

![banner](https://i.imgur.com/jlIR94L.png)


- Forgotten if `Task.Delay` takes milliseconds or seconds?
- Not happy with the readability of your `new TimeSpan` with a billion parameters?
- Tired of coworkers understanding your code?
- **Then `AwaitWhat` is for you!**

AwaitWhat is a .NET Standard 2.0 library that lets you `await` a `String` after you have installed the [NuGet package](https://www.nuget.org/packages/AwaitWhat). Yes, you read that right. Just a normal string. No configuration needed, just hit install. Write the TimeSpan format however you want[¹](https://github.com/MarcusOtter/awaitwhat#user-content-foot1) in the string, and just await it! How are you ever going to top the readability of plain english!?

## Installation

> **Warning**:
> If it wasn't clear already, you probably should not use this in production code. Like, you **can** use it, if you really want to. It works fine. But you probably, most certainly, definitely should not use it. I mean, just look at it. You're awaiting a `String`. That's not a `Task`. Shame on you!

1. Install the [NuGet Package](https://www.nuget.org/packages/AwaitWhat), for example like this:
    ```
    dotnet add package AwaitWhat
    ```
2. Done! Now you can await any `String` in your project. Enjoy!

## Examples
| Standard | With `AwaitWhat` |
| ------ | ----- |
| `await Task.Delay(1210)` | `await "1.21s"` |
| `await Task.Delay(1210)` | `await "1 second, 210 milliseconds"` |
| `await Task.Delay(1210)` | `await "1210ms"` |
| `await Task.Delay(1210)` | `await "0.02016667 MiNUteS"` |
| ... | ... |
| `await Task.Delay(new TimeSpan(1, 23, 9));` | `await "1h23m9s"` |
| `await Task.Delay(new TimeSpan(1, 23, 9));` | `await "1:23:09"` |
| `await Task.Delay(new TimeSpan(1, 23, 9));` | `await "1 hr 23 min 9 sec"` | 
| `await Task.Delay(new TimeSpan(1, 23, 9));` | `await "1 hour, 23 minutes and 9 seconds"` | 
| ... | ... |

You get the idea, check [TimeSpanParser](https://github.com/pengowray/TimeSpanParser) for all the valid formats.

## Wait... what? How does this even work?
I got the idea from a [wonderful video](https://www.youtube.com/watch?v=ileC_qyLdD4) by the wonderful [Nick Chapsas](https://www.youtube.com/@nickchapsas). Basically Microsoft has some weird internal compiler wizardry that is exposed and I used that to add an awaiter to `String`. Just watch the video 👉👈


---

<div id="foot1"></div>

¹ Okay, not *however* you want. If you mess it up too much you will get an `ArgumentException`. Like, don't await your email address, because I have no idea what you want me to do with that. We currently rely fully on the wonderful [TimeSpanParser](https://github.com/pengowray/TimeSpanParser) package, so go ~~complain there if you don't like it~~ give them some love!! :)
