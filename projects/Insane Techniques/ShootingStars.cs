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
    public class ShootingStars : StoryboardObjectGenerator
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
        public string SpawnPath = "sb/square.png";

        [Configurable]
        public int ARTime = 600;

        [Configurable]
        public Vector2 Position = new Vector2(320, 240);

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
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
            var Spawn = hitobjectLayer.CreateSprite(SpawnPath, OsbOrigin.Centre, Position);
            Spawn.Rotate(OsbEasing.Out, StartTime - beat*3, StartTime, 0, Math.PI*5/4);
            Spawn.Scale(OsbEasing.Out, StartTime - beat*3, StartTime, SpriteScale*0.2, SpriteScale*0.5);
            Spawn.Fade(OsbEasing.Out, StartTime - beat*3, StartTime - beat*2.5, 0, 1);
            Spawn.Fade(OsbEasing.None, EndTime - beat, EndTime - beat/4, 1, 0);

            double startTime0 = StartTime;
            var counting = 1;
            while (true)
            {

                if (counting % 2 == 0)
                {
                    Spawn.Rotate(OsbEasing.Out, startTime0, startTime0 + beat, Math.PI*22/16, Math.PI*5/4);
                } else {
                    Spawn.Rotate(OsbEasing.Out, startTime0, startTime0 + beat, Math.PI*18/16, Math.PI*5/4);
                }
                

                var endTime = startTime0 + beat;
                var complete = EndTime - endTime < -beat;

                if (complete) break;
                startTime0 += beat;
                counting += 1;
            }

            foreach (var hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;
                
                var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 1);
                hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                hSprite.Additive(hitobject.StartTime - ARTime, hitobject.EndTime + FadeTime);
                hSprite.Color(hitobject.StartTime - ARTime, Color4.White);

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale * SliderScale, SpriteScale * SliderScale);
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
                        var sliderBodySprite = sliderLayer.CreateSprite(SliderBody, OsbOrigin.Centre, hitobject.PositionAtTime(hitobject.StartTime));

                        sliderBodySprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale * SliderScale, SpriteScale * SliderScale);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 1);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderBodySprite.Move(OsbEasing.None, startTime - ARTime, startTime, Position, hitobject.PositionAtTime(hitobject.StartTime));
                        sliderBodySprite.Rotate(OsbEasing.None, startTime - ARTime, startTime, 0, Math.PI*2);
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
                        hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime, 1, 0);

                        if (complete) break;
                        startTime += timestep;
                    }
                }

                var aSprite = hitobjectLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, Position);
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - ARTime, hitobject.StartTime - ARTime, SliderScale, SliderScale);
                aSprite.Fade(OsbEasing.In, hitobject.StartTime - ARTime, hitobject.StartTime - ARTime, 0, 1);
                aSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
                aSprite.Move(OsbEasing.None, hitobject.StartTime - ARTime, hitobject.StartTime, Position, hitobject.Position);
                aSprite.Rotate(OsbEasing.None, hitobject.StartTime - ARTime, hitobject.StartTime, 0, 3.14*2);
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
