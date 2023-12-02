using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.Storage;
using Microsoft.UI.Text;
using Windows.UI;
using System.Windows.Input;
using Windows.Devices.Enumeration;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChangeControl.Controls;
public sealed partial class MyRichEditBox : UserControl
{

    public static readonly DependencyProperty RichEditBoxDocumentProperty =
    DependencyProperty.Register(
        nameof(RichEditBoxDocument),         // プロパティ名
        typeof(string), // バインドするデータの型
        typeof(MyRichEditBox),  // 自分自身の型
        new PropertyMetadata(  // 初期値をPropertyMetadata経由でつっこむ
            null)
    );

    public RichEditTextDocument RichEditBoxDocument
    {
           get => (RichEditTextDocument)GetValue(RichEditBoxDocumentProperty);
           set => SetValue(RichEditBoxDocumentProperty, value);
       }

    public static readonly DependencyProperty RichEditBoxTextProperty =
    DependencyProperty.Register(
        nameof(RichEditBoxText),         // プロパティ名
        typeof(string), // バインドするデータの型
        typeof(MyRichEditBox),  // 自分自身の型
        new PropertyMetadata(  // 初期値をPropertyMetadata経由でつっこむ
            "")
    );

    public string RichEditBoxText
    {
        get => (string)GetValue(RichEditBoxTextProperty);
        set => SetValue(RichEditBoxTextProperty, value);
    }


    private Color currentColor;

    public MyRichEditBox()
    {
        this.InitializeComponent();

        TestTextBlock.SetBinding(TextBlock.TextProperty, 
            new Binding() 
            { Source = this, Path = new PropertyPath("RichEditBoxText"), UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged });
       
    }





    private void BoldButton_Click(object sender, RoutedEventArgs e)
    {
        editor.Document.Selection.CharacterFormat.Bold = FormatEffect.Toggle;
        editor.Document.GetText(TextGetOptions.None, out var text);
        Debug.WriteLine(text);
    }

    private void ItalicButton_Click(object sender, RoutedEventArgs e)
    {
        editor.Document.Selection.CharacterFormat.Italic = FormatEffect.Toggle;
    }

    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
        // Extract the color of the button that was clicked.
        Button clickedColor = (Button)sender;
        var rectangle = (Microsoft.UI.Xaml.Shapes.Rectangle)clickedColor.Content;
        var color = ((Microsoft.UI.Xaml.Media.SolidColorBrush)rectangle.Fill).Color;

        editor.Document.Selection.CharacterFormat.ForegroundColor = color;

        fontColorButton.Flyout.Hide();
        editor.Focus(Microsoft.UI.Xaml.FocusState.Keyboard);
    }

    private void FindBoxHighlightMatches()
    {
        FindBoxRemoveHighlights();

        Color highlightBackgroundColor = (Color)App.Current.Resources["SystemColorHighlightColor"];
        Color highlightForegroundColor = (Color)App.Current.Resources["SystemColorHighlightTextColor"];

        string textToFind = findBox.Text;
        if (textToFind != null)
        {
            ITextRange searchRange = editor.Document.GetRange(0, 0);
            while (searchRange.FindText(textToFind, TextConstants.MaxUnitCount, FindOptions.None) > 0)
            {
                searchRange.CharacterFormat.BackgroundColor = highlightBackgroundColor;
                searchRange.CharacterFormat.ForegroundColor = highlightForegroundColor;
            }
        }
    }

    private void FindBoxRemoveHighlights()
    {
        ITextRange documentRange = editor.Document.GetRange(0, TextConstants.MaxUnitCount);
        SolidColorBrush defaultBackground = editor.Background as SolidColorBrush;
        SolidColorBrush defaultForeground = editor.Foreground as SolidColorBrush;

        documentRange.CharacterFormat.BackgroundColor = defaultBackground.Color;
        documentRange.CharacterFormat.ForegroundColor = defaultForeground.Color;
    }

    private void Editor_GotFocus(object sender, RoutedEventArgs e)
    {
        editor.Document.GetText(TextGetOptions.UseCrlf, out string currentRawText);

        // reset colors to correct defaults for Focused state
        ITextRange documentRange = editor.Document.GetRange(0, TextConstants.MaxUnitCount);
        SolidColorBrush background = (SolidColorBrush)App.Current.Resources["TextControlBackgroundFocused"];

        if (background != null)
        {
            documentRange.CharacterFormat.BackgroundColor = background.Color;
        }
    }

    private void Editor_TextChanged(object sender, RoutedEventArgs e)
    {
        editor.Document.Selection.CharacterFormat.ForegroundColor = currentColor;
    }
}
