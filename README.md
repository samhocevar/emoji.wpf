# ![Icon](/Resources/icon.png) Emoji.Wpf

`Emoji.Wpf` is a proof of concept implementation of Emoji for WPF.

![Demo 1](/Resources/emoji.wpf.gif) ![Demo 2](/Resources/emoji.wpf.png)

### Features

 - **Very experimental** for now.
 - **Colour emojis**! 😨 💩 🍰 ✈ ✏ 📞 ☘
 - **Full vector emojis**!
 - **Lightweight**; does not embed a font, or emoji images.
 - Works with **old .NET versions** such as 3.0.
 - Uses the Segoe UI Emoji system font, even on **Windows 7 or Windows 8** (if
   installed in `c:/Windows/Fonts`) by implementing Microsoft’s COLR/CPAL font
   format extensions.
 - [Free, opensource software](http://www.wftpl.net/), with no strings attached.
 - Available as a [Nuget package](https://www.nuget.org/packages/Emoji.Wpf).

### Available classes

 - `Emoji.Wpf.TextBlock`: an emoji-aware version of `System.Windows.Controls.TextBlock`.
 - `Emoji.Wpf.RichTextBox`: an emoji-aware version of `System.Windows.Controls.RichTextBox`.

 - `Emoji.Wpf.Picker`: an emoji picker

### Examples

Here is how to use Emoji.Wpf in your XAML:

```xaml
    <Window ...
            xmlns:emoji="clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf"
            ...>
        ...
        <emoji:RichTextBox FontSize="24" Margin="5"/>
        ...
        <emoji:TextBlock FontSize="24" Text="Hello! ♥😁🐨🐱‍🐉👩🏿‍👩🏻‍👦🏽 lol"/>
        ...
        <emoji:Picker FontSize="40"/>
        ...
    </Window>
```

More classes are to come, but feedback on what is needed is welcome.

### Help needed!

I am not a very good WPF or even C# developer, but I think this could become a very
useful and robust library if given enough care. Any help appreciated!

