using System.ComponentModel;
using Power_of_God_Lib.GUI;

namespace LessonPlugin
{
    public partial class LessonPage : PowerTabPage
    {
        public LessonPage()
        {
            InitializeComponent();
            webBrowser1.Navigate("https://www.youtube.com/embed/hV__1XE4tq4");
        }
    }
}
