# ![Icon](/Resources/icon.png) Emoji.Wpf

`Emoji.Wpf` adds Emoji rendering support to WPF applications.

![Demo 1](/Resources/emoji.wpf.gif)

## Features

 - Provides drop-in replacements for `TextBlock` and `RichTextBox`, no additional
   code required.
 - **Colour emoji**! 😨 💩 🍰 ✈️ ✏️ 📞 ☘️
 - **Multiracial family emoji**! 👩🏿‍👩🏻‍👦🏽 👨🏻‍👩🏿‍👧🏽‍👦🏽 👩🏻‍👶🏽
 - **Emoji for flags**! <img src="https://github.com/samhocevar/emoji.wpf/raw/main/Resources/flags.png" height="24"/>
 - **Win11 style flags**! <img src="https://github.com/samhocevar/emoji.wpf/raw/main/Resources/newflags.png" height="16"/>
 - **Full vector emoji**! Render at huge sizes without quality loss.
 - Optional support for subpixel antialiasing.
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

### Available dependency properties

 - `Emoji.Image.Source`: attach to either `System.Windows.Controls.Image` control or
   `System.Windows.Media.DrawingImage` object in order to manipulate emoji images

### Available runtime flags

 - `bool Emoji.Wpf.EmojiData.EnableSubPixelRendering`: enable subpixel rendering, defaults to `false`
 - `bool Emoji.Wpf.EmojiData.EnableWindowsStyleFlags`: enable flag rendering, defaults to autodetected

### Examples

Here is how to use Emoji.Wpf in your XAML:

```xaml
    <Window ...
            xmlns:emoji="clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf"
            ...>
        <Window.Resources>
            <DrawingImage x:Key="MyImageSource" emoji:Image.Source="👻"/>
        </Window.Resources>
        ...
        <emoji:RichTextBox FontSize="24" Margin="5"/>
        ...
        <emoji:TextBlock FontSize="24" Text="Hello! 💖😁🐨🐱‍🐉👩🏿‍👩🏻‍👦🏽 lol"/>
        ...
        <emoji:Picker FontSize="40"/>
        ...
        <Image Source="{StaticResource MyImageSource}"/>
        ...
        <Image emoji:Image.Source="🦑"/>
        ...
    </Window>
```

More classes are to come, but feedback on what is needed is welcome.

![Demo 2](/Resources/emoji.wpf.png)

### Help needed!

I am not a very good WPF or even C# developer, but I think this could become a very
useful and robust library if given enough care. Any help appreciated!

### Version changelog

 - v0.3.4 (2022/11/16):
   - fix a crash in `emoji:RichTextBox`
   - fix multiple issues with drag-and-drop in `emoji:RichTextBox`
   - glyph colourisation is now done on the GPU
   - new Windows 11 style flags on Windows 11
 - v0.3.3 (2021/06/03):
   - fix a crash on Windows 8
   - fix flag rendering with the Twemoji font
 - v0.3.1 (2021/06/02):
   - allow to disable flag rendering
 - v0.3.0 (2021/03/14):
   - glyphs for flags!
   - new `emoji:EmojiRendering` dependency property for `FlowDocument`
   - optional subpixel glyph rendering
   - experimental support for custom emoji sequences and custom glyphs
 - v0.2.5 (2021/01/29):
   - minor adjustments in `emoji:Picker`
 - v0.2.4 (2021/01/28):
   - new `emoji:Image.Source` dependency property for `Image` and `DrawingImage` objects, allowing
     to easily render emoji as icons
 - v0.2.3 (2021/01/27):
   - the rendering pipeline now exclusively uses vector objects
   - subpixel glyph positioning
   - use `ColonSyntax="True"` in `emoji:RichTextBox` for replace-as-you-type: `:koala:` becomes 🐨 _etc._
 - v0.2.2 (2021/01/25):
   - increased picker performance through virtualisation
   - rendering fallback for emoji ZWJ sequences
 - v0.2.1 (2021/01/22):
   - `emoji:RichTextBox.Text` is two-way bindable and binding defaults to `LostFocus`
   - all base controls implement an `IEmojiControl` interface for convenience
   - fixed a warning caused by the Typography DLLs about `ExtensionAttribute` being redefined
 - v0.2.0 (2021/01/17):
   - support for undo/redo and numerous bugfixes in `emoji:RichTextBox`
   - minimal .NET version is now Framework 4.0 (was 3.0)
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

Emoji.Wpf renders emoji as vector images, using the WPF text rendering engine. The geometry
information is found in the Segoe UI Emoji font glyphs. The colour information is found in the
same font, using Microsoft’s COLR/CPAL format extensions.
