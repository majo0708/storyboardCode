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
    public class SectionSpawn : StoryboardObjectGenerator
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
            Color4 NewGray = new Color4(127, 127, 127, 255);
            var hSpriteList = new List<OsbSprite>();
            var ComboStartTime = 0.00;
            var hitobjectLayer = GetLayer("HitObjects");
            var sliderLayer = GetLayer("SliderObjects");
            foreach (var hitobject in Beatmap.HitObjects.Reverse<OsuHitObject>())
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;

                var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                var aSprite = hitobjectLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.Position);

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, StartTime, hitobject.EndTime, SpriteScale, SpriteScale);
                        sliderEdgeSprite.Fade(OsbEasing.In, StartTime - ARTime, StartTime, 0, 1);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderEdgeSprite.Color(hitobject.StartTime - ARTime, Color4.Gray);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderBodySprite = sliderLayer.CreateSprite(SliderBody, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderBodySprite.Scale(OsbEasing.In, StartTime, hitobject.EndTime, SpriteScale * SliderScale, SpriteScale * SliderScale);
                        sliderBodySprite.Fade(OsbEasing.In, StartTime - ARTime, StartTime, 0, 1);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderBodySprite.Color(hitobject.StartTime - ARTime, Color4.Gray);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < 0;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = hSprite.PositionAt(startTime);
                        hSprite.Move(startTime, endTime, startPosition, hitobject.PositionAtTime(endTime));

                        if (complete) break;
                        startTime += timestep;
                    }
                }

                hSprite.Fade(OsbEasing.In, StartTime - ARTime, StartTime, 0, 1);
                hSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                hSprite.Scale(StartTime, SpriteScale);
                hSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.1);
                //hSprite.Additive(StartTime - ARTime, hitobject.EndTime + FadeTime);
                hSprite.Color(StartTime - ARTime, hitobject.Color);

                aSprite.Fade(OsbEasing.In, StartTime, StartTime + FadeTime, 0, 1);
                aSprite.Color(StartTime, Color4.White);
                aSprite.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
                aSprite.Scale(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, SpriteScale * 2.5, SpriteScale);

                
                if (hitobject.ComboIndex == 1)
                {
                    ComboStartTime = hitobject.StartTime;
                    hSpriteList.Add(hSprite);
                    foreach (var hSpriteObject in hSpriteList)
                    {
                        hSpriteObject.Color(OsbEasing.In, ComboStartTime - ARTime, ComboStartTime, NewGray, hitobject.Color);
                    }
                    hSpriteList.Clear();
                }
                else
                {
                    hSpriteList.Add(hSprite);  
                }

                int tens = hitobject.ComboIndex / 10;
                int ones = hitobject.ComboIndex - tens * 10;

                var numSpriteTens = hitobjectLayer.CreateSprite(num[tens], OsbOrigin.Centre, hitobject.Position);
                var numSpriteOnes = hitobjectLayer.CreateSprite(num[ones], OsbOrigin.Centre, hitobject.Position);

                Vector2 moveNum = new Vector2(HitCircleGap, 0);
                
                if (tens > 0)
                {
                    numSpriteTens.Move(StartTime, hitobject.Position - moveNum);
                    numSpriteTens.Scale(StartTime, SpriteScale);
                    numSpriteTens.Fade(OsbEasing.In, StartTime, StartTime + FadeTime, 0, 1);
                    numSpriteTens.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);

                    numSpriteOnes.Move(StartTime, hitobject.Position - moveNum);
                    numSpriteOnes.Scale(StartTime, SpriteScale);
                    numSpriteOnes.Fade(OsbEasing.In, StartTime, StartTime + FadeTime, 0, 1);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);
                }
                else
                {
                    numSpriteOnes.Scale(StartTime, SpriteScale);
                    numSpriteOnes.Fade(OsbEasing.In, StartTime, StartTime + FadeTime, 0, 1);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);
                }
            }
        }
    }
}