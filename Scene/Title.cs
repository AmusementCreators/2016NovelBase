using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016NovelBase.Scene
{
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();
            var background = new asd.TextureObject2D();
            background.Texture = asd.Engine.Graphics.CreateTexture2D("Resource/title.png");
            layer.AddObject(background);
            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (Resource.IsOkPushed())
                asd.Engine.ChangeScene(new Scene(new Chapter("Resource/chap1")));
        }
    }
}
