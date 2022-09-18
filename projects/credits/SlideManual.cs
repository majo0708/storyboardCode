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
    public class SlideManual : StoryboardObjectGenerator
    {
        [Configurable]
        public string ImagePath = "sb/line.png";

        [Configurable]
        public double SpriteScaleX = 1;

        [Configurable]
        public double SpriteScaleY = 1;

        [Configurable]
        public Vector2 Position = new Vector2(640, 248);

        public void Cycle(int startTime, int beat, Color4 Color, StoryboardLayer hitobjectLayer)
        {
            var imageSprite = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);
            imageSprite.Rotate(startTime, 0);
            imageSprite.Color(startTime, Color);
            imageSprite.ScaleVec(OsbEasing.None, startTime, startTime, SpriteScaleX, SpriteScaleY, SpriteScaleX, SpriteScaleY);
            imageSprite.MoveY(OsbEasing.None, startTime, startTime, 248, 248);

            imageSprite.Fade(OsbEasing.In, startTime, startTime, 1, 1);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 0.5, startTime + beat * 0.5, 0, 0);
            imageSprite.MoveX(OsbEasing.None, startTime, startTime + beat * 0.5, 0, 320);

            imageSprite.Fade(OsbEasing.In, startTime + beat * 1.5, startTime + beat * 1.5, 1, 1);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 2, startTime + beat * 2, 0, 0);
            imageSprite.MoveX(OsbEasing.None, startTime + beat * 1.5, startTime + beat * 2, 0, 320);

            imageSprite.MoveX(OsbEasing.None, startTime + beat * 4, startTime + beat * 4, 320, 320);
            imageSprite.Rotate(startTime + beat * 4, Math.PI / 2);

            imageSprite.Fade(OsbEasing.In, startTime + beat * 4, startTime + beat * 4, 1, 1);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 4.5, startTime + beat * 4.5, 0, 0);
            imageSprite.MoveY(OsbEasing.None, startTime + beat * 4, startTime + beat * 4.5, 0, 248);
        }

        public void Cycle2(int startTime, int beat, Color4 Color, StoryboardLayer hitobjectLayer)
        {
            var imageSprite = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);
            imageSprite.Rotate(startTime, 0);
            imageSprite.Color(startTime, Color);
            imageSprite.ScaleVec(OsbEasing.None, startTime, startTime, SpriteScaleX, SpriteScaleY, SpriteScaleX, SpriteScaleY);
            imageSprite.MoveY(OsbEasing.None, startTime, startTime, 248, 248);

            imageSprite.Fade(OsbEasing.In, startTime, startTime, 1, 1);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 0.5, startTime + beat * 0.5, 0, 0);
            imageSprite.MoveX(OsbEasing.None, startTime, startTime + beat * 0.5, 640, 320);

            imageSprite.Fade(OsbEasing.In, startTime + beat * 1.5, startTime + beat * 1.5, 1, 1);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 2, startTime + beat * 2, 0, 0);
            imageSprite.MoveX(OsbEasing.None, startTime + beat * 1.5, startTime + beat * 2, 640, 320);

            imageSprite.MoveX(OsbEasing.None, startTime + beat * 4, startTime + beat * 4, 320, 320);
            imageSprite.Rotate(startTime + beat * 4, Math.PI / 2);

            imageSprite.Fade(OsbEasing.In, startTime + beat * 4, startTime + beat * 4, 1, 1);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 4.5, startTime + beat * 4.5, 0, 0);
            imageSprite.MoveY(OsbEasing.None, startTime + beat * 4, startTime + beat * 4.5, 498, 248);
        }

        public void SlideDown(int startTime, int endTime, Color4 Color, StoryboardLayer hitobjectLayer)
        {
            var bitmap = GetMapsetBitmap(ImagePath);
            var imageSprite = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, new Vector2(320, 248));

            imageSprite.Color(startTime, Color);
            imageSprite.ScaleVec(startTime, 640.0f / bitmap.Width, 480.0f / bitmap.Height);
            imageSprite.MoveY(OsbEasing.Out, startTime, endTime, -240, 240);
        }
        
        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            var beat = Beatmap.GetTimingPointAt((int)156).BeatDuration;
            
            Cycle(10882 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(13563 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(16245 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(18926 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(21608 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(24290 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(26971 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle(29653 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);

            Cycle2(10882 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(13563 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(16245 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(18926 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(21608 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(24290 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(26971 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);
            Cycle2(29653 + (int)beat, (int)beat, Color4.Gray, hitobjectLayer);

            SlideDown(53116, 53452, Color4.Gray, hitobjectLayer);
        }
        
    }
}
