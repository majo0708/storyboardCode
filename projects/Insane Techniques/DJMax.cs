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
    public class DJMax : StoryboardObjectGenerator
    {
        [Configurable]
          public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int BeatDivisor = 8;

        [Configurable]
        public int FadeTime = 200;

        [Configurable]
        public string Direction = "V";

        [Configurable]
        public string SpritePath = "sb/line.png";

        [Configurable]
        public string GlowPath = "sb/line_glow.png";

        [Configurable]
        public string HitcirclePath = "sb/circle.png";

        [Configurable]
        public string ApproachcirclePath = "sb/approachcircle.png";

        [Configurable]
        public string SliderBody = "sb/sliderbody.png";

        [Configurable]
        public string SliderEdge = "sb/slideredge.png";

        [Configurable]
        public Vector2 StartPosition = new Vector2(320, 248);

        [Configurable]
        public Vector2 EndPosition = new Vector2(320, 248);

        [Configurable]
        public int BeatARTime = 2;

        [Configurable]
        public int BeatARFlash = 2;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public double SliderScale = 1;

        [Configurable]
        public double VectorScale = 1;

        [Configurable]
        public double AngleDegrees = 0;

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("Hitobjects");
            var sliderLayer = GetLayer("Sliders");
            var lineLayer = GetLayer("Lines");
            var dSprite = lineLayer.CreateSprite(SpritePath, OsbOrigin.Centre, StartPosition);
            var fSprite = lineLayer.CreateSprite(GlowPath, OsbOrigin.Centre, StartPosition);
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
            var Angle = AngleDegrees / 180.0 * Math.PI;
            Color4 NewGray = new Color4(0.3f, 0.3f, 0.3f, 1.0f);
            dSprite.ScaleVec(OsbEasing.In, StartTime, StartTime, SpriteScale, SpriteScale * VectorScale, SpriteScale, SpriteScale * VectorScale); //assuming the image is vertical normally

            if (Direction == "V")
            {
                Angle += Math.PI/2;
            } else if (Direction == "H") {
                Angle += 0;
            }

            for (int i = BeatARFlash; i > 0; i--)
            {
                dSprite.Fade(OsbEasing.In, StartTime - beat * i, StartTime - beat * i + FadeTime, 1, 0);
            }
        

            dSprite.Fade(OsbEasing.None, StartTime, StartTime, 1, 1);
            dSprite.Rotate(OsbEasing.Out, StartTime, StartTime, Angle, Angle);
            dSprite.Move(OsbEasing.None, StartTime, EndTime, StartPosition, EndPosition);
            dSprite.Fade(OsbEasing.In, EndTime, EndTime + FadeTime, 1, 0);
            
            foreach (var hitobject in Beatmap.HitObjects.Reverse<OsuHitObject>())
            {
                var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);

                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;
                
                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale, SpriteScale);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatARTime * beat, hitobject.StartTime - BeatARTime * beat * 0.4, 0, 1);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderEdgeSprite.Color(hitobject.StartTime - BeatARTime * beat, NewGray);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderBodySprite = sliderLayer.CreateSprite(SliderBody, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderBodySprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale * SliderScale, SpriteScale * SliderScale);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.StartTime - BeatARTime * beat, hitobject.StartTime - BeatARTime * beat * 0.4, 0, 1);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderBodySprite.Color(hitobject.StartTime - BeatARTime * beat, NewGray);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < timestep;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = hSprite.PositionAt(startTime);
                        hSprite.Move(startTime, endTime, startPosition, hitobject.PositionAtTime(endTime));
                        hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime, 1, 0);

                        if (complete) break;
                        startTime += timestep;
                    }
                }
                
                hSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatARTime * beat, hitobject.StartTime - BeatARTime * beat * 0.4, 0, 1);
                hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                hSprite.Color(StartTime - BeatARTime, hitobject.Color);
            }
        }
    }
}
