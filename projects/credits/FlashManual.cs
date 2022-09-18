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
    public class FlashManual : StoryboardObjectGenerator
    {
        [Configurable]
        public string ImagePath = "sb/square.png";

        [Configurable]
        public double SpriteScale = 13;

        [Configurable]
        public Color4 Color = Color4.Black;

        [Configurable]
        public Vector2 Position = new Vector2(320, 248);

        public void Flash(int startTime, StoryboardLayer hitobjectLayer, double beat, OsbSprite imageSprite)
        {
            imageSprite.Color(startTime, Color);
            imageSprite.Scale(OsbEasing.None, startTime, startTime, SpriteScale, SpriteScale);
            imageSprite.Fade(OsbEasing.In, startTime, startTime + beat, 1, 0);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 1.5, startTime + beat * 2.5, 1, 0);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 3, startTime + beat * 4, 1, 0);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 4, startTime + beat * 5, 1, 0);
            imageSprite.Fade(OsbEasing.In, startTime + beat * 5.5, startTime + beat * 6.5, 1, 0);
        }
        
        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            var beat = Beatmap.GetTimingPointAt((int)156).BeatDuration;
            var imageSprite = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);

            Flash(10882, hitobjectLayer, beat, imageSprite);
            Flash(13563, hitobjectLayer, beat, imageSprite);
            Flash(16245, hitobjectLayer, beat, imageSprite);
            Flash(18926, hitobjectLayer, beat, imageSprite);
            Flash(21608, hitobjectLayer, beat, imageSprite);
            Flash(24290, hitobjectLayer, beat, imageSprite);
            Flash(26971, hitobjectLayer, beat, imageSprite);
            Flash(29653, hitobjectLayer, beat, imageSprite);
        }
        
    }
}
