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
    public class Flashlight : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int BeatDivisor = 8;

        [Configurable]
        public int StartFadeTime = 200;

        [Configurable]
        public int EndFadeTime = 200;

        [Configurable]
        public Vector2 StartPos = new Vector2(360, 240);

        [Configurable]
        public bool ProperFade = false;

        [Configurable]
        public double Offset = 0; // in beats

        [Configurable]
        public string SpotlightPath = "sb/spotlight.png";

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public double Opacity = 1;

        [Configurable]
        public Color4 Color = Color4.Gray;
        public override void Generate()
        {
		    var arLayer = GetLayer("ARLayer");
            var hitobjectLayer = GetLayer("HitObjects");
            var sliderLayer = GetLayer("SliderObjects");
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
            var offsetBeat = beat * Offset;

            var prevPosition = new Vector2(360, 240);
            var sSprite = arLayer.CreateSprite(SpotlightPath, OsbOrigin.Centre, prevPosition);
            sSprite.Color(StartTime, Color);
            sSprite.Scale(OsbEasing.In, StartTime - StartFadeTime, StartTime, SpriteScale * 10, SpriteScale);
            if (ProperFade)
            {
                sSprite.Fade(StartTime - StartFadeTime, StartTime, 0, Opacity);
            } else {
                sSprite.Fade(StartTime, Opacity);
            }
            // sSprite.Additive(StartTime, EndTime);

            double prevStartTime = StartTime - StartFadeTime;
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;
                
                sSprite.Move(OsbEasing.None, prevStartTime, hitobject.StartTime - offsetBeat, prevPosition, hitobject.Position);
                // TODO: Add code to check if SpriteScale changed manually and scale if so

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < timestep;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = sSprite.PositionAt(startTime);
                        sSprite.Move(startTime - offsetBeat, endTime - offsetBeat, startPosition, hitobject.PositionAtTime(endTime));

                        if (complete) break;
                        startTime += timestep;
                    }
                }

                prevPosition = hitobject.PositionAtTime(hitobject.EndTime);
                prevStartTime = hitobject.EndTime - offsetBeat;

                // Manual Section

                // Add manual spotlight scale changers

                // End of Manual Section
            }
            sSprite.Scale(OsbEasing.In, EndTime, EndTime + EndFadeTime, SpriteScale, SpriteScale * 10);
            sSprite.Fade(OsbEasing.Out, EndTime, EndTime + EndFadeTime, 1, 0);
        }
    }
}
