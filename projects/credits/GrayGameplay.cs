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
    public class GrayGameplay : StoryboardObjectGenerator
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
        public double BeatARTime = 2;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public bool SoloColor = true;

        [Configurable]
        public Color4 Color = Color4.Gray;

        [Configurable]
        public int HitCircleGap = 0;

        public string[] num = new string[10];

        public void Squish(int startTime, double rotation, double beat, OsbSprite aSprite)
        {
            aSprite.ScaleVec(startTime - beat, SpriteScale, SpriteScale);
            aSprite.Rotate(startTime, rotation);
            aSprite.ScaleVec(OsbEasing.Out, startTime, startTime + beat / 2, 0.25 * SpriteScale, SpriteScale, SpriteScale, SpriteScale);
        }

        public void ColorFlash(int startTime, Color4 Color, Color4 endColor, double beat, double beatDivisor, int repeats, OsbSprite aSprite, OsuHitObject hitobject)
        {
            for (int i = 0; i < repeats; i++)
            {
                if (i % 2 == 0) aSprite.Color(startTime + beat * beatDivisor * i, Color);
                if (i % 2 == 1) aSprite.Color(startTime + beat * beatDivisor * i, hitobject.Color);
            }
            aSprite.Color(startTime + beat * beatDivisor * repeats, endColor);
        }

        public void FakePopUp(int startTime, Color4 Color, double beat, OsbSprite aSprite, OsuHitObject hitobject, Vector2 offset)
        {
            aSprite.Move(OsbEasing.In, startTime, startTime + beat*4, hitobject.Position, hitobject.Position - offset);
        }

        public override void Generate()
        {
            for (int i = 0; i < 10; i++)
            {
                num[i] = ("custom skin/num-" + i.ToString() + ".png");
            }
            Color4 NewGray = new Color4(0.3f, 0.3f, 0.3f, 1.0f);
            var arLayer = GetLayer("ARLayer");
            var hitobjectLayer = GetLayer("HitObjects");
            var sliderLayer = GetLayer("SliderObjects");
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
            var BeatAR = BeatARTime * beat;

            foreach (var hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) && 
                    (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                    continue;

                var aSprite = arLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.Position);
                aSprite.Scale(OsbEasing.None, hitobject.StartTime - BeatAR, hitobject.StartTime, SpriteScale * 4, SpriteScale);
                aSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR * 5 / 8, 0, 1);
                aSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime, 1, 0);
                //aSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                if (SoloColor)
                {
                    aSprite.Color(hitobject.StartTime - BeatAR, Color);
                }
                else aSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                
                var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                hSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                hSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR / 2, 0, 1);
                hSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                //hSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                if (SoloColor) hSprite.Color(hitobject.StartTime - BeatAR, Color);
                else hSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale, SpriteScale);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, 1);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderEdgeSprite.Color(hitobject.StartTime - BeatAR, Color);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        // Manual Section
                        ColorFlash(12893, Color4.Gray, Color4.Gray, beat, 0.25, 7, sliderEdgeSprite, hitobject);
                        ColorFlash(15574, Color4.Gray, Color4.Gray, beat, 0.25, 7, sliderEdgeSprite, hitobject);
                        ColorFlash(18256, Color4.Gray, Color4.Gray, beat, 0.25, 7, sliderEdgeSprite, hitobject);
                        ColorFlash(20938, Color4.Gray, Color4.Gray, beat, 0.25, 7, sliderEdgeSprite, hitobject);
                        // End of Manual Section

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderBodySprite = sliderLayer.CreateSprite(SliderBody, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderBodySprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SpriteScale * 0.9, SpriteScale * 0.9);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, 1);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        sliderBodySprite.Color(hitobject.StartTime - BeatAR, Color4.Black);

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

                // Manual Section
                ColorFlash(23619, Color4.Gray, Color4.Gray, beat, 0.25, 7, hSprite, hitobject);
                ColorFlash(26301, Color4.Gray, Color4.Gray, beat, 0.25, 7, hSprite, hitobject);
                ColorFlash(28982, Color4.Gray, Color4.Gray, beat, 0.25, 7, hSprite, hitobject);
                ColorFlash(31664, Color4.Gray, Color4.Gray, beat, 0.25, 7, hSprite, hitobject);
                Squish(32334, 0, beat, hSprite);
                Squish(32837, 0, beat, hSprite);
                Squish(33005, Math.PI/2, beat, hSprite);
                Squish(33340, 0, beat, hSprite);
                Squish(33675, 0, beat, hSprite);
                Squish(34178, 0, beat, hSprite);
                Squish(34345, Math.PI/2, beat, hSprite);
                Squish(34681, 0, beat, hSprite);
                Squish(34848, Math.PI/2, beat, hSprite);
                Squish(35016, 0, beat, hSprite);
                Squish(35519, 0, beat, hSprite);
                Squish(35686, Math.PI/2, beat, hSprite);
                Squish(36021, 0, beat, hSprite);
                Squish(36357, 0, beat, hSprite);
                Squish(36859, 0, beat, hSprite);
                Squish(37027, Math.PI/2, beat, hSprite);
                Squish(37697, 0, beat, hSprite);
                Squish(38200, 0, beat, hSprite);
                Squish(38368, Math.PI/2, beat, hSprite);
                Squish(38703, 0, beat, hSprite);
                Squish(39038, 0, beat, hSprite);
                Squish(39206, Math.PI/2, beat, hSprite);
                Squish(39038, 0, beat, hSprite);
                Squish(39709, Math.PI/2, beat, hSprite);
                Squish(40044, 0, beat, hSprite);
                Squish(40379, 0, beat, hSprite);
                Squish(40882, 0, beat, hSprite);
                Squish(41049, Math.PI/2, beat, hSprite);
                Squish(41385, 0, beat, hSprite);
                Squish(41720, 0, beat, hSprite);
                Squish(42223, 0, beat, hSprite);
                // End of Manual Section

                int tens = hitobject.ComboIndex / 10;
                int ones = hitobject.ComboIndex - tens * 10;

                var numSpriteTens = hitobjectLayer.CreateSprite(num[tens], OsbOrigin.Centre, hitobject.Position);
                var numSpriteOnes = hitobjectLayer.CreateSprite(num[ones], OsbOrigin.Centre, hitobject.Position);

                Vector2 moveNum = new Vector2(HitCircleGap, 0);
                
                if (tens > 0)
                {
                    numSpriteTens.Move(hitobject.StartTime - BeatAR, hitobject.Position - moveNum);
                    numSpriteTens.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale);
                    numSpriteTens.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, 1);
                    numSpriteTens.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);

                    numSpriteOnes.Move(hitobject.StartTime - BeatAR, hitobject.Position + moveNum);
                    numSpriteOnes.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, 1);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);
                }
                else
                {
                    numSpriteOnes.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, 1);
                    numSpriteOnes.Fade(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime / 4, 1, 0);
                }
            }
        }
    }
}
