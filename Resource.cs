using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016NovelBase
{
    static class Resource
    {
        public static class Window
        {
            public static string TitleName { get; } = "Novel Base";
            public static asd.Vector2DI Size { get; } = new asd.Vector2DI(640, 480);
        }

        static public asd.Font Font { get; set; }
        static public asd.Font OptionFont { get; set; }

        static public void Init()
        {
            Font = asd.Engine.Graphics.CreateDynamicFont("", 16, new asd.Color(0, 0, 0), 0, new asd.Color(0, 0, 0));
            OptionFont = asd.Engine.Graphics.CreateDynamicFont("", 32, new asd.Color(0, 0, 0), 1, new asd.Color(255, 255, 255));
        }


        public static bool IsOkPushed()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
                return true;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Space) == asd.KeyState.Push)
                return true;
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Enter) == asd.KeyState.Push)
                return true;
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
                return true;
            return false;
        }
    }
}
