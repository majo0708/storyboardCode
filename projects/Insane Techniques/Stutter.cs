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
    public class Stutter : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int BeatDivisor = 8;

        [Configurable]
        public int BeatStutter = 4;

        [Configurable]
        public int FadeTime = 200;

        [Configurable]
        public string HitcirclePath = "sb/circle.png";

        [Configurable]
        public string ApproachcirclePath = "sb/approachcircle.png";

        [Configurable]
        public string SliderBody = "sb/sliderbody.png";

        [Configurable]
        public string SliderEdge = "sb/slideredge.png";

        [Configurable]
        public int ARTime = 600;

        [Configurable]
        public int BeatARTime = 2;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public double SliderScale = 1;

        [Configurable]
        public int HitCircleGap = 0;

        public string[] num = new string[10];

        public override void Generate()
        {
            for (int i = 0; i < 10; i++)
            {
                num[i] = ("custom skin/num-" + i.ToString() + ".png");
            }
            Color4 NewGray = new Color4(0.3f, 0.3f, 0.3f, 1.0f);
            var hitobjectLayer = GetLayer("HitObjects");
            var sliderLayer = GetLayer("SliderObjects");
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration * BeatARTime / BeatStutter;
            foreach (var hitobject in Beatmap.HitObjects.Reverse<OsuHitObject>())
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;
                
                var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                var aSprite = hitobjectLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.Position);
                
                for (int i = 1; i < BeatStutter + 1; i++)
                {
                    double Ratio = (double)(BeatStutter-i+1)/(double)BeatStutter;
                    hSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                    hSprite.Fade(OsbEasing.In, hitobject.StartTime - (BeatStutter-i)*beat, hitobject.StartTime - (BeatStutter-i+1)*beat, (double)i/(double)BeatStutter, (double)i/(double)BeatStutter);

                    aSprite.Scale(OsbEasing.None, hitobject.StartTime - (BeatStutter-i)*beat, hitobject.StartTime - (BeatStutter-i+1)*beat, Ratio * 3*SpriteScale + SpriteScale, Ratio * 3*SpriteScale + SpriteScale);
                    aSprite.Fade(OsbEasing.None, hitobject.StartTime - (BeatStutter-i)*beat, hitobject.StartTime - (BeatStutter-i+1)*beat, (double)i/(double)BeatStutter, (double)i/(double)BeatStutter);
                }
                hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime, 1, 0);
                hSprite.Color(hitobject.StartTime - BeatARTime, hitobject.Color);
                aSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime, 1, 0);
                aSprite.Color(hitobject.StartTime - BeatARTime, hitobject.Color);
                /*
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - 4*beat, hitobject.StartTime - 4*beat, 4 * SpriteScale, 4 * SpriteScale);
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - 3*beat, hitobject.StartTime - 3*beat, 3 * SpriteScale, 3 * SpriteScale);
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - 2*beat, hitobject.StartTime - 2*beat, 2 * SpriteScale, 2 * SpriteScale);
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - 1*beat, hitobject.StartTime - 1*beat, 1 * SpriteScale, 1 * SpriteScale);
                aSprite.Color(hitobject.StartTime - ARTime, hitobject.Color);
                */

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale, SpriteScale);
                        for (int i = 1; i < BeatStutter + 1; i++)
                        {
                            double Ratio = (double)(BeatStutter-i)/(double)BeatStutter;
                            sliderEdgeSprite.Fade(OsbEasing.In, hitobject.StartTime - (BeatStutter-i)*beat, hitobject.StartTime - (BeatStutter-i+1)*beat, (double)i/(double)BeatStutter, (double)i/(double)BeatStutter);
                        }
                       
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime, 1, 0);
                        sliderEdgeSprite.Color(hitobject.StartTime - BeatARTime, NewGray);

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
                        for (int i = 1; i < BeatStutter + 1; i++)
                        {
                            double Ratio = (double)(BeatStutter-i)/(double)BeatStutter;
                            sliderBodySprite.Fade(OsbEasing.In, hitobject.StartTime - (BeatStutter-i)*beat, hitobject.StartTime - (BeatStutter-i+1)*beat, (double)i/(double)BeatStutter, (double)i/(double)BeatStutter);
                        }

                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime, 1, 0);
                        sliderBodySprite.Color(hitobject.StartTime - BeatARTime, NewGray);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + beat;
                        var complete = hitobject.EndTime - startTime < beat;
                        //if (complete) startTime = hitobject.EndTime;

                        var startPosition = hSprite.PositionAt(startTime);
                        hSprite.Move(startTime, startTime, hitobject.PositionAtTime(startTime), hitobject.PositionAtTime(startTime));
                        hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime, 1, 0);

                        if (complete) break;
                        startTime += beat;
                    }
                }

                

                int tens = hitobject.ComboIndex / 10;
                int ones = hitobject.ComboIndex - tens * 10;

                var numSpriteTens = hitobjectLayer.CreateSprite(num[tens], OsbOrigin.Centre, hitobject.Position);
                var numSpriteOnes = hitobjectLayer.CreateSprite(num[ones], OsbOrigin.Centre, hitobject.Position);

                Vector2 moveNum = new Vector2(HitCircleGap, 0);
                
                if (tens > 0)
                {
                    numSpriteTens.Move(hitobject.StartTime - ARTime, hitobject.Position - moveNum);
                    numSpriteTens.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale);
                    numSpriteTens.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 1);
                    numSpriteTens.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);

                    numSpriteOnes.Move(hitobject.StartTime - ARTime, hitobject.Position + moveNum);
                    numSpriteOnes.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 1);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);
                }
                else
                {
                    numSpriteOnes.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 1);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);
                }
            }
        }
    }
}
