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
        public double BeatMultiplier = 1;

        [Configurable]
        public double BeatARTime = 1;
        
        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public Vector2 Position = new Vector2(320, 248);

        [Configurable]
        public Color4 Color = Color4.White;

        [Configurable]
        public double Opacity = 1;

        public string[] num = new string[10];

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            var beat = Beatmap.GetTimingPointAt((int)EndTime).BeatDuration;
            var BeatAR = BeatARTime * beat;
            var numSprite = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);
            numSprite.Color(EndTime - BeatAR, Color);
            
		    for (int i = Flashes; i > 0; i--)
            {
                numSprite.Scale(OsbEasing.None, EndTime - beat * i / (double)BeatMultiplier , EndTime - beat * i / BeatMultiplier, SpriteScale, SpriteScale);
                numSprite.Fade(OsbEasing.In, EndTime - beat * i / (double)BeatMultiplier, EndTime - beat * i / BeatMultiplier + BeatAR, Opacity, 0);
            }
        
            
        }
    }
}
