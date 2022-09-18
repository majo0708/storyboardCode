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
    public class FakeGameplay : StoryboardObjectGenerator
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
            Color4 NewGray = new Color4(0.3f, 0.3f, 0.3f, 1.0f);
            var hitobjectLayer = GetLayer("HitObjects");
            var sliderLayer = GetLayer("SliderObjects");
            foreach (var hitobject in Beatmap.HitObjects.Reverse<OsuHitObject>())
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;
                
                var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime - ARTime*2/5, 0, 1);
                hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                //hSprite.Additive(hitobject.StartTime - ARTime, hitobject.EndTime + FadeTime);
                hSprite.Color(hitobject.StartTime - ARTime, hitobject.Color);

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale, SpriteScale);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime - ARTime*2/5, 0, 1);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderEdgeSprite.Color(hitobject.StartTime - ARTime, NewGray);

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
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 1);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderBodySprite.Color(hitobject.StartTime - ARTime, NewGray);

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

                var aSprite = hitobjectLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.Position);
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - ARTime, hitobject.StartTime, SpriteScale * 4, SpriteScale);
                aSprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime - ARTime * 2 / 5, 0, 1);
                aSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
                aSprite.Additive(hitobject.StartTime - ARTime, hitobject.EndTime + FadeTime);
                aSprite.Color(hitobject.StartTime - ARTime, hitobject.Color);

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
