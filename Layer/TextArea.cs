using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016NovelBase.Layer
{
    sealed class TextArea : asd.Layer2D
    {
        public TextArea()
        {
            var obj = new asd.GeometryObject2D();
            var rect = new asd.RectangleShape();
            rect.DrawingArea = new asd.RectF(-Size/2, Size);
            obj.Shape = rect;
            obj.CenterPosition = Resource.Window.Size.To2DF() / 2;
            obj.Position = Resource.Window.Size.To2DF() / 2 + new asd.Vector2DF(0, 120);
            obj.Color = new asd.Color(255, 255, 0);
            AddObject(obj);

            nameLabel.Font = Resource.Font;
            nameLabel.Position = obj.Position - Size / 2 + new asd.Vector2DF(16, 16);
            AddObject(nameLabel);

            textLabel.Font = Resource.Font;
            textLabel.Position = obj.Position - Size / 2 + new asd.Vector2DF(32, 48);
            AddObject(textLabel);
        }

        public void Name(string name)
        {
            nameLabel.Text = name;
        }
        public void Text(string text)
        {
            textLabel.Text = text;
        }

        asd.TextObject2D nameLabel = new asd.TextObject2D();
        asd.TextObject2D textLabel = new asd.TextObject2D();

        static private asd.Vector2DF Size { get; } = new asd.Vector2DF(560, 160);
    }
}
