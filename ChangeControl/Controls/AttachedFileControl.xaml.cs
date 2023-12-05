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
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ChangeControl.Controls;
public sealed partial class AttachedFileControl : UserControl
{
    public AttachedFileControl()
    {
        this.InitializeComponent();
    }

    private async void UserControl_Drop(object sender, DragEventArgs e)
    {
        if (e.DataView.Contains(StandardDataFormats.StorageItems))
        {
            var items = await e.DataView.GetStorageItemsAsync();
            if (items.Any())
            {
                var storageFile = items[0] as StorageFile;
                var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(storageFile.Path);    /// (@"c:\windows\system32\notepad.exe")
                var iconThumbnail = await file.GetThumbnailAsync(ThumbnailMode.SingleItem, 32);
                var bi = new BitmapImage();
                bi.SetSource(iconThumbnail);
                Icon.Source = bi;
            }
        }
    }

    private void UserControl_DragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Copy;
    }
}
