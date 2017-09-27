# Emoji.Wpf ♥ 😨 🍰 ✈ ✏ 📞 ☘

`Emoji.Wpf` is a proof of concept implementation of Emoji for WPF.

### Features

 - **Colour emojis**!
 - **Full vector emojis**!
 - **Lightweight**; does not embed a font, or emoji images; the DLL is only 12 kilobytes.
 - Works with **old .NET versions** such as 3.0.
 - Uses the Segoe UI Emoji system font, even on **Windows 7 or Windows 8** by
   implementing Microsoft’s COLR/CPAL font format extensions.
 - **Very experimental** for now.
 - [Free, opensource software](http://www.wftpl.net/), with no strings attached.

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

![Demo](/emoji.wpf.gif)

### Help needed!

I am not a very good WPF or even C# developer, but I think this could become a very
useful and robust library if given enough care. Any help or feedback appreciated!

