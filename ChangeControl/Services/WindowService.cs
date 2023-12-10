using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

namespace ChangeControl.Services
{
    // IWindowServiceの定義
    public interface IWindowService
    {
        void OpenNewWindow<T>(Action<string> returnDataHandler) where T : Page, new();
    }

    // IWindowServiceの実装
    public class WindowService : IWindowService
    {
        public void OpenNewWindow<T>(Action<string> returnDataHandler) where T : Page, new()
        {
            var newWindow = new Window();
            var page = new T();
            newWindow.Content = page;
            newWindow.Activate();

            // ChangeEvaluateViewModelのReturnDataイベントにハンドラを登録
            if (page.DataContext is ChangeEvaluateViewModel changeEvaluateViewModel)
            {
                //changeEvaluateViewModel.ReturnData += returnDataHandler;
            }
        }
    }
}
