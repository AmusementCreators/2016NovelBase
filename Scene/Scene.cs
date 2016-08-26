using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2016NovelBase.Scene
{
    class Scene : asd.Scene
    {
        public Scene(Chapter chap)
        {
            chapter = chap;

            var layer = new asd.Layer2D();
            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D(chapter.backgroundGraphPath);
            layer.AddObject(background);

            AddLayer(layer);

            textArea.Text((chapter.story.ElementAt(0) as Chapter.Paragraph).text);
            AddLayer(textArea);
        }

        protected override void OnUpdated()
        {
            // 会話の終わりまで来たらタイトル画面に戻る
            if (chapter.story.Count <= 0)
            {
                asd.Engine.ChangeScene(new Title());
                return;
            }

            var current = chapter.story.ElementAt(0);
            if (current is Chapter.Paragraph)
                paragraph();
            else if (current is Chapter.Options)
                options();
            else if (current is Chapter.Load)
                load();
        }

        private void paragraph()
        {

            textArea.Text((chapter.story.ElementAt(0) as Chapter.Paragraph).text);
            textArea.Name((chapter.story.ElementAt(0) as Chapter.Paragraph).speaker);

            if (Resource.IsOkPushed())
                chapter.story.RemoveAt(0);
        }
        private void options()
        {
            if (optionArea == null || !optionArea.IsAlive)
            {
                optionArea = new Layer.OptionArea((chapter.story.ElementAt(0) as Chapter.Options).items);
                AddLayer(optionArea);
            }

            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                var item = optionArea.ItemUnderMouse();
                if (item == null)
                    return;
                chapter.story = item.story;
                optionArea.Dispose();
            }

        }
        private void load()
        {
            var newChapter = new Chapter((chapter.story.ElementAt(0) as Chapter.Load).filename);
            asd.Engine.ChangeScene(new Scene(newChapter));
        }

        Chapter chapter;
        Layer.TextArea textArea = new Layer.TextArea();
        Layer.OptionArea optionArea ;
    }
}
