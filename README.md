# ![Icon](/Resources/icon.png) Emoji.Wpf

`Emoji.Wpf` is a proof of concept implementation of Emoji for WPF.

![Demo](/Resources/emoji.wpf.gif)

### Features

 - **Very experimental** for now.
 - **Colour emojis**! 😨 💩 🍰 ✈ ✏ 📞 ☘
 - **Full vector emojis**!
 - **Lightweight**; does not embed a font, or emoji images; the DLL is only 12 kilobytes.
 - Works with **old .NET versions** such as 3.0.
 - Uses the Segoe UI Emoji system font, even on **Windows 7 or Windows 8** by
   implementing Microsoft’s COLR/CPAL font format extensions.
 - [Free, opensource software](http://www.wftpl.net/), with no strings attached.
 - Available as a [Nuget package](https://www.nuget.org/packages/Emoji.Wpf).

### Example

Just add an `Emoji.Wpf.RichTextBox` to your XAML:

```xaml
    <Window ...
            xmlns:emoji="clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf"
            ...>
        ...
        <emoji:RichTextBox Name="SampleTextBox" FontSize="24" Margin="5"/>
        ...
    </Window>
```

More classes are to come, but feedback on what is needed is welcome.

### Help needed!

I am not a very good WPF or even C# developer, but I think this could become a very
useful and robust library if given enough care. Any help appreciated!

