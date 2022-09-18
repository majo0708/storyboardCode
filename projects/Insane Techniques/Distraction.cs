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
    public class Distraction : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int FadeTime = 500;

        [Configurable]
        public string ImagePath = "sb/image.png";

        [Configurable]
        public string Type = "distraction type";

        [Configurable]
        public Vector2 Position = new Vector2(320, 248);

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public double AngleDegrees = -15;

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");
            var Image = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);
            Image.Scale(OsbEasing.In, StartTime, StartTime, SpriteScale, SpriteScale);

		    if (Type == "Fade In")
            {
                Vector2 offset = new Vector2(5, 2);
                var frames = 40;
                var counting = 0;
                var totalFrames = (EndTime - StartTime);
                var startTime0 = StartTime;
                Image.Fade(OsbEasing.In, StartTime, EndTime, 0, 1);
                while (true)
                {
                    if (counting % 2 == 0)
                    {
                        Image.Move(OsbEasing.None, startTime0, startTime0, Position, Position+offset);
                    } else {
                        Image.Move(OsbEasing.None, startTime0, startTime0, Position+offset, Position);
                    }

                    var complete = startTime0 + frames > EndTime;
                    if (complete) break;

                    startTime0 += frames;
                    counting += 1;
                }
                

            } else if (Type == "Jump Scare")
            {
                var Angle = AngleDegrees/180*Math.PI;
                Image.Scale(OsbEasing.Out, StartTime - FadeTime, StartTime, SpriteScale*0.01, SpriteScale*5);
                Image.Scale(OsbEasing.In, StartTime, EndTime, SpriteScale*5, SpriteScale*25);
                Image.Rotate(OsbEasing.Out, StartTime - FadeTime, StartTime, 0, Angle);
                Image.Rotate(OsbEasing.In, StartTime, EndTime, Angle, Angle*2);
                Image.Fade(OsbEasing.In, StartTime, EndTime, 1, 0);
            }

        }
    }
}
