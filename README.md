# ![Icon](/Resources/icon.png) Emoji.Wpf

`Emoji.Wpf` adds Emoji rendering support to WPF applications.

![Demo 1](/Resources/emoji.wpf.gif)

## Features

 - Provides drop-in replacements for `TextBlock` and `RichTextBox`, no additional
   code required.
 - **Colour emoji**! 😨 💩 🍰 ✈️ ✏️ 📞 ☘️
 - **Multiracial family emoji**! 👩🏿‍👩🏻‍👦🏽 👨🏻‍👩🏿‍👧🏽‍👦🏽 👩🏻‍👶🏽
 - **Full vector emoji**! Render at huge sizes without quality loss.
 - **Lightweight**; does not embed a font or emoji images; just uses the system font.
 - Works with **old .NET versions** such as .NET Framework 4.0.
 - Can work on **Windows 7 or Windows 8** by installing the Segoe UI Emoji font in
   `c:/Windows/Fonts`.
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
        <emoji:TextBlock FontSize="24" Text="Hello! 💖😁🐨🐱‍🐉👩🏿‍👩🏻‍👦🏽 lol"/>
        ...
        <emoji:Picker FontSize="40"/>
        ...
    </Window>
```

More classes are to come, but feedback on what is needed is welcome.

![Demo 2](/Resources/emoji.wpf.png)

### Help needed!

I am not a very good WPF or even C# developer, but I think this could become a very
useful and robust library if given enough care. Any help appreciated!

### Version changelog

 - v0.2.3 (2021/01/26):
   - the rendering pipeline now exclusively uses vector objects
 - v0.2.2 (2021/01/25):
   - increased picker performance through virtualisation
   - rendering fallback for emoji ZWJ sequences
 - v0.2.1 (2021/01/22):
   - `emoji:RichTextBox.Text` is two-way bindable and binding defaults to `LostFocus`
   - all base controls implement an `IEmojiControl` interface for convenience
   - fixed a warning caused by the Typography DLLs about `ExtensionAttribute` being redefined
 - v0.2.0 (2021/01/17):
   - support for undo/redo and numerous bugfixes in `emoji:RichTextBox`
   - minimal .NET version is now Framework 4.0 (was 3.0).
 - v0.1.8 (2021/01/13):
   - composite emoji such as 🧔🏻 or 👨🏻‍🦰 now render properly in `emoji:RichTextBox`
   - new `Picked` event in `emoji:Picker`
 - v0.1.7 (2021/01/12):
   - colour blending is off by default; use `ColorBlend="True"` to enable
 - v0.1.6 (2021/01/11):
   - add support for colour blending in `emoji:TextBlock`; ~~use `Blending="False"` to disable~~
 - v0.1.4 (2020/11/23):
   - add support for complex family emoji and mixed skin tone families
 - v0.1.2 (2020/11/22):
   - support hair style variation emoji
   - fix kerning and positioning issues with family emoji
 - v0.1.1 (2020/11/10):
   - support wrapping in `emoji:TextBlock`
 - v0.1.0 (2020/11/9):
   - first non-experimental release

### How does it work?

Emoji.Wpf renders emoji as images, using the text rendering engine. In the Segoe UI Emoji
font, emoji are encoded using multiple layers of single-colour text glyphs, using Microsoft’s
COLR/CPAL format extensions.
