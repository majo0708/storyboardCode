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
    public class Countdown : StoryboardObjectGenerator
    {
        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public string FolderPath = "sb/count";

        [Configurable]
        public string ImageType = ".png";

        [Configurable]
        public int Amount = 4;

        [Configurable]
        public int BeatMultiplier = 1;

        [Configurable]
        public int FadeTime = 200;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public Vector2 Position = new Vector2(320, 248);

        [Configurable]
        public Color4 NewColor = new Color4(0.0f, 0.0f, 0.0f, 1.0f);

        public string[] num = new string[10];

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            var beat = Beatmap.GetTimingPointAt((int)EndTime).BeatDuration;
            for (int i = 1; i < Amount + 1; i++)
            {
                num[i] = (FolderPath + i.ToString() + ImageType);
            }
		    for (int i = Amount; i > 0; i--)
            {
                var numSprite = hitobjectLayer.CreateSprite(num[i], OsbOrigin.Centre, Position);
                numSprite.Scale(OsbEasing.None, EndTime - beat * i / (double)BeatMultiplier , EndTime - beat * i / (double)BeatMultiplier, SpriteScale, SpriteScale);
                numSprite.Fade(OsbEasing.In, EndTime - beat * i / (double)BeatMultiplier, EndTime - beat * i / (double)BeatMultiplier + FadeTime, 1, 0);
                numSprite.Color(OsbEasing.None, EndTime - beat * i / (double)BeatMultiplier, EndTime - beat * i / (double)BeatMultiplier + FadeTime, NewColor, NewColor);
            }
            
        }
    }
}
