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
    public class Flash : StoryboardObjectGenerator
    {
        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public string ImagePath = "sb/image.png";

        [Configurable]
        public int Flashes = 4;

        [Configurable]
        public int BeatMultiplier = 1;

        [Configurable]
        public int FadeTime = 200;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public Vector2 Position = new Vector2(320, 248);

        public string[] num = new string[10];

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            var beat = Beatmap.GetTimingPointAt((int)EndTime).BeatDuration;
            var numSprite = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);
            
		    for (int i = Flashes; i > 0; i--)
            {
                numSprite.Scale(OsbEasing.None, EndTime - beat * i / (double)BeatMultiplier , EndTime - beat * i / (double)BeatMultiplier, SpriteScale, SpriteScale);
                numSprite.Fade(OsbEasing.In, EndTime - beat * i / (double)BeatMultiplier, EndTime - beat * i / (double)BeatMultiplier + FadeTime, 1, 0);
            }
        
            
        }
    }
}
