using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016NovelBase.Layer
{
    class OptionArea : asd.Layer2D
    {
        public OptionArea(List<Chapter.Item> items)
        {
            this.items = items;
            for (int i=0; i<items.Count; i++)
            {
                var optionLabel = new asd.TextObject2D();
                optionLabel.Font = Resource.OptionFont;
                optionLabel.Text = items.ElementAt(i).value;
                optionLabel.Position = new asd.Vector2DF(200, 100 + 64 * i);
                AddObject(optionLabel);
            }
        }

        public Chapter.Item ItemUnderMouse()
        {
            foreach (var obj in Objects)
            {
                if (!(obj is asd.TextObject2D))
                    continue;
                var label = obj as asd.TextObject2D;
                var size = Resource.OptionFont.CalcTextureSize(label.Text, asd.WritingDirection.Horizontal).To2DF();
                var optionRect = new asd.RectF(label.Position, size);
                var mousePos = asd.Engine.Mouse.Position;

                if (mousePos.X < optionRect.X || optionRect.X + optionRect.Width < mousePos.X)
                    continue;
                if (mousePos.Y < optionRect.Y || optionRect.Y + optionRect.Height < mousePos.Y)
                    continue;

                return items.Find(item => item.value == label.Text);
            }
            return null;
        }

        List<Chapter.Item> items;
    }
}
