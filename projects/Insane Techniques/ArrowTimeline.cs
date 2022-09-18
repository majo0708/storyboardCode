using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class ArrowTimeline : StoryboardObjectGenerator
    {
        [Configurable]
        public double SpriteScale = 1;

        public override void Generate()
        {
            //This is manual code for a section
            //Variables
            Vector2 Position1 = new Vector2(110, 62);
            Vector2 Position2 = new Vector2(200, 62);
            Vector2 Position3 = new Vector2(290, 62);
            Vector2 Position4 = new Vector2(380, 62);
            Vector2 Position5 = new Vector2(470, 62);
            Vector2 Position6 = new Vector2(530, 62);
            Vector2 Middle = new Vector2(320, 62);
            var FadeTime = 200;
            string ArrowPath = "sb/arrow.png";
            //xaxis: 0 - 640 -> 80 - 560
		    var hitobjectLayer = GetLayer("");
            var Line = hitobjectLayer.CreateSprite("sb/line.png", OsbOrigin.Centre, Middle);
            var Line2 = hitobjectLayer.CreateSprite("sb/line.png", OsbOrigin.Centre, Middle);
            var Bar = hitobjectLayer.CreateSprite("sb/line.png", OsbOrigin.Centre, Middle);
            var ArrowLine = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            var Arrow1 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position1);
            var Arrow2 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position2);
            var Arrow3 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position3);
            var Arrow4 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position4);
            var Arrow5 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position5);
            var Arrow6 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position6);
            var Arrow7 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position1);
            var Arrow8 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position2);
            var Arrow9 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position3);
            var Arrow10 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position4);
            var Arrow11 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position5);
            var Arrow12 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Position6);
            var Arrow13 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            var Arrow14 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            var Arrow15 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            var Arrow16 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            var Arrow17 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            var Arrow18 = hitobjectLayer.CreateSprite(ArrowPath, OsbOrigin.Centre, Middle);
            Line.ScaleVec(OsbEasing.Out, 36355, 36355, SpriteScale*30, SpriteScale*14, SpriteScale*30, SpriteScale*14);
            Line2.ScaleVec(OsbEasing.Out, 36355, 36355, SpriteScale*30, SpriteScale*14, SpriteScale*30, SpriteScale*14);
            Line.Fade(OsbEasing.None, 38410, 38410 + FadeTime, 1, 0);
            ArrowLine.MoveX(OsbEasing.None, 36355, 38821, -10, 710);
            ArrowLine.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            ArrowLine.Fade(OsbEasing.Out, 38410, 38821, 1, 0);
            ArrowLine.Scale(OsbEasing.Out, 38410, 38410, SpriteScale*1.2, SpriteScale*1.2);
            ArrowLine.Rotate(OsbEasing.Out, 36766, 37074, 0, Math.PI);
            ArrowLine.Rotate(OsbEasing.Out, 37074, 37382, Math.PI, Math.PI/3);
            ArrowLine.Rotate(OsbEasing.Out, 37382, 37691, Math.PI/3, Math.PI*2/3);
            ArrowLine.Rotate(OsbEasing.Out, 37691, 37999, Math.PI*2/3, -Math.PI/3);
            ArrowLine.Rotate(OsbEasing.Out, 37999, 38204, -Math.PI/3, -Math.PI*2/3);
            Arrow13.MoveX(OsbEasing.None, 35533, 35533, 398, 398);
            Arrow13.MoveY(OsbEasing.None, 35533, 35533, 248, 248);
            Arrow14.MoveX(OsbEasing.None, 35533, 35533, 242, 242);
            Arrow14.MoveY(OsbEasing.None, 35533, 35533, 248, 248);
            Arrow15.MoveX(OsbEasing.None, 35533, 35533, 359, 359);
            Arrow15.MoveY(OsbEasing.None, 35533, 35533, 316, 316);
            Arrow16.MoveX(OsbEasing.None, 35533, 35533, 281, 281);
            Arrow16.MoveY(OsbEasing.None, 35533, 35533, 316, 316);
            Arrow17.MoveX(OsbEasing.None, 35533, 35533, 359, 359);
            Arrow17.MoveY(OsbEasing.None, 35533, 35533, 181, 181);
            Arrow18.MoveX(OsbEasing.None, 35533, 35533, 281, 281);
            Arrow18.MoveY(OsbEasing.None, 35533, 35533, 181, 181);
            Arrow13.Fade(OsbEasing.In, 36355, 36560, 0, 1);
            Arrow14.Fade(OsbEasing.In, 36355, 36560, 0, 1);
            Arrow15.Fade(OsbEasing.In, 36355, 36560, 0, 1);
            Arrow16.Fade(OsbEasing.In, 36355, 36560, 0, 1);
            Arrow17.Fade(OsbEasing.In, 36355, 36560, 0, 1);
            Arrow18.Fade(OsbEasing.In, 36355, 36560, 0, 1);
            
            //Colors
            Arrow1.Color(36355, Color4.Red);
            Arrow2.Color(36355, Color4.Green);
            Arrow3.Color(36355, Color4.Blue);
            Arrow4.Color(36355, Color4.Green);
            Arrow5.Color(36355, Color4.Red);
            Arrow6.Color(36355, Color4.Blue);
            Arrow7.Color(36355, Color4.Red);
            Arrow8.Color(36355, Color4.Green);
            Arrow9.Color(36355, Color4.Blue);
            Arrow10.Color(36355, Color4.Green);
            Arrow11.Color(36355, Color4.Red);
            Arrow12.Color(36355, Color4.Blue);

            //Angle
            Arrow2.Rotate(OsbEasing.Out, 36355, 36766, 0, Math.PI);
            Arrow3.Rotate(OsbEasing.Out, 36355, 36766, 0, Math.PI/3);
            Arrow4.Rotate(OsbEasing.Out, 36355, 36766, 0, Math.PI*2/3);
            Arrow5.Rotate(OsbEasing.Out, 36355, 36766, 0, -Math.PI/3);
            Arrow6.Rotate(OsbEasing.Out, 36355, 36766, 0, -Math.PI*2/3);
            Arrow8.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI);
            Arrow9.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI/3);
            Arrow10.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI*2/3);
            Arrow11.Rotate(OsbEasing.Out, 35533, 35533, 0, -Math.PI/3);
            Arrow12.Rotate(OsbEasing.Out, 35533, 35533, 0, -Math.PI*2/3);
            Arrow14.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI);
            Arrow15.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI/3);
            Arrow16.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI*2/3);
            Arrow17.Rotate(OsbEasing.Out, 35533, 35533, 0, -Math.PI/3);
            Arrow18.Rotate(OsbEasing.Out, 35533, 35533, 0, -Math.PI*2/3);
            Line.Rotate(OsbEasing.Out, 36355, 36355, 0, Math.PI/2);
            Line2.Rotate(OsbEasing.Out, 35533, 35533, 0, Math.PI/2);

            //Flash
            Arrow7.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow8.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow9.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow10.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow11.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow12.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow13.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow14.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow15.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow16.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow17.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Arrow18.Scale(OsbEasing.None, 35533, 35533, SpriteScale, SpriteScale);
            Line2.MoveY(OsbEasing.None, 35533, 35533, 56, 56);
            Arrow7.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow7.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow7.Fade(OsbEasing.In, 36355, 36766, 1, 0);
            Arrow8.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow8.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow8.Fade(OsbEasing.In, 36355, 36766, 1, 0);
            Arrow9.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow9.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow9.Fade(OsbEasing.In, 36355, 36766, 1, 0);
            Arrow10.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow10.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow10.Fade(OsbEasing.In, 36355, 36766, 1, 0);
            Arrow11.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow11.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow11.Fade(OsbEasing.In, 36355, 36766, 1, 0);
            Arrow12.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow12.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow12.Fade(OsbEasing.In, 36355, 36766, 1, 0);
            Arrow13.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow13.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow13.Fade(OsbEasing.In, 38410, 38615, 1, 0);
            Arrow14.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow14.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow14.Fade(OsbEasing.In, 38410, 38615, 1, 0);
            Arrow15.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow15.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow15.Fade(OsbEasing.In, 38410, 38615, 1, 0);
            Arrow16.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow16.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow16.Fade(OsbEasing.In, 38410, 38615, 1, 0);
            Arrow17.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow17.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow17.Fade(OsbEasing.In, 38410, 38615, 1, 0);
            Arrow18.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Arrow18.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Arrow18.Fade(OsbEasing.In, 38410, 38615, 1, 0);
            Line2.Fade(OsbEasing.In, 35533, 35944, 1, 0);
            Line2.Fade(OsbEasing.In, 35944, 36355, 1, 0);
            Line2.Fade(OsbEasing.In, 36355, 36766, 1, 0);

            //Move
            Arrow1.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            Arrow2.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            Arrow3.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            Arrow4.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            Arrow5.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            Arrow6.MoveY(OsbEasing.Out, 36355, 36766, 0, 62);
            Line.MoveY(OsbEasing.Out, 36355, 36766, 0, 56);

            //Hit
            Arrow1.Scale(OsbEasing.None, 36766, 36766 + FadeTime, SpriteScale, SpriteScale * 1.2);
            Arrow2.Scale(OsbEasing.None, 37074, 37074 + FadeTime, SpriteScale, SpriteScale * 1.2);
            Arrow3.Scale(OsbEasing.None, 37382, 37382 + FadeTime, SpriteScale, SpriteScale * 1.2);
            Arrow4.Scale(OsbEasing.None, 37691, 37691 + FadeTime, SpriteScale, SpriteScale * 1.2);
            Arrow5.Scale(OsbEasing.None, 37999, 37999 + FadeTime, SpriteScale, SpriteScale * 1.2);
            Arrow6.Scale(OsbEasing.None, 38204, 38204 + FadeTime, SpriteScale, SpriteScale * 1.2);

            Arrow1.Fade(OsbEasing.Out, 36766, 36766 + FadeTime, 1, 0);
            Arrow2.Fade(OsbEasing.Out, 37074, 37074 + FadeTime, 1, 0);
            Arrow3.Fade(OsbEasing.Out, 37382, 37382 + FadeTime, 1, 0);
            Arrow4.Fade(OsbEasing.Out, 37691, 37691 + FadeTime, 1, 0);
            Arrow5.Fade(OsbEasing.Out, 37999, 37999 + FadeTime, 1, 0);
            Arrow6.Fade(OsbEasing.Out, 38204, 38204 + FadeTime, 1, 0);
        }
    }
}
