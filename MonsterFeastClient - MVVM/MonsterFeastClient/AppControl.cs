using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MonsterFeastClient.Models;
using MonsterFeastClient.Views;

namespace MonsterFeastClient
{
    public class AppControl
    {
        static AppControl _instance;
        public static AppControl GetInstance()
        {
            if (_instance == null)
                _instance = new AppControl();
            return _instance;
        }

        Border _stage;

        private AppControl() { }

        public void GoToPage(AppControl page)
        {
            switch (page)
            {
                case ApplicationPage.NewControl1:
                    _stage.Child = new UserControl1();
                    break;
                case ApplicationPage.NewWindow2:
                    var win = new Window2();
                    win.Show();
                    break;
            }
        }

        public void SetStage(Border Stage)
        {
            _stage = Stage;
        }
    }
}
