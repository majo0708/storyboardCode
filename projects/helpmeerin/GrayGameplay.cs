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
        public string HitcircleOverlayPath = "hitcircleoverlay.png";

        [Configurable]
        public string ApproachcirclePath = "sb/approachcircle.png";

        [Configurable]
        public string SliderBody = "sb/sliderbody.png";

        [Configurable]
        public double SliderBodyFade = 1;

        [Configurable]
        public string SliderEdge = "sb/slideredge.png";

        [Configurable]
        public string SliderBall = "sb/sliderball.png";

        [Configurable]
        public string SliderTick = "sb/slidertick.png";

        [Configurable]
        public double SliderTickRate = 1;

        [Configurable]
        public string SliderEnd = "sb/sliderend.png";

        [Configurable]
        public bool SliderEndToggle = false;

        [Configurable]
        public string Reverse = "sb/reverse.png";

        [Configurable]
        public double BeatARTime = 2;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public double SliderSpriteScale = 1;

        [Configurable]
        public bool SoloColor = true;

        [Configurable]
        public bool STickColor = true;

        [Configurable]
        public bool SBallColor = true;

        [Configurable]
        public Color4 Color = Color4.Gray;

        [Configurable]
        public Color4 SliderColor = Color4.Gray;

        [Configurable]
        public Color4 BallColor = Color4.Gray;

        [Configurable]
        public int HitCircleGap = 0;

        public string[] num = new string[10];

        /// <summary>
        /// Squishes and unsquishes a given sprite on screen accordingly at a
        /// given time, rotation and duration.
        /// </summary>
        /// <param name="startTime">starts squish at given time in milliseconds.</param>
        /// <param name="rotation">direction of squish given in radients.</param>
        /// <param name="beat">duration of the squish in white ticks in the map editor (or 1/1 beats).</param>
        /// <param name="aSprite">sprite which gets squished.</param>
        public void Squish(int startTime, double rotation, double beat, OsbSprite aSprite)
        {
            aSprite.ScaleVec(startTime - beat, SpriteScale, SpriteScale);
            aSprite.Rotate(startTime, rotation);
            aSprite.ScaleVec(OsbEasing.Out, startTime, startTime + beat / 2, 0.25 * SpriteScale, SpriteScale, SpriteScale, SpriteScale);
        }

        /// <summary>
        /// Flashes the given sprite between two colors.
        /// </summary>
        /// <param name="startTime">starts flash at given time in milliseconds.</param>
        /// <param name="Color">Color4 color of every odd flash.</param>
        /// <param name="ColorB">Color4 color of every even flash.</param>
        /// <param name="endColor">Color4 color which the object returns to.</param>
        /// <param name="beat">duration of the squish in white ticks in the map editor (or 1/1 beats).</param>
        /// <param name="beatDivisor"></param>
        /// <param name="repeats">the amount of total flashes.</param>
        /// <param name="aSprite">affected sprites.</param>
        /// <param name="hitobject"></param>
        public void ColorFlash(int startTime, Color4 Color, Color4 ColorB, Color4 endColor, double beat, double beatDivisor, int repeats, OsbSprite aSprite, OsuHitObject hitobject)
        {
            for (int i = 0; i < repeats; i++)
            {
                if (i % 2 == 0) aSprite.Color(startTime + beat * beatDivisor * i, Color);
                if (i % 2 == 1) aSprite.Color(startTime + beat * beatDivisor * i, ColorB);
            }
            aSprite.Color(startTime + beat * beatDivisor * repeats, endColor);
        }

        public void FakePopUp(int startTime, Color4 Color, double beat, OsuHitObject hitobject, int xOffset, int yOffset)
        {
            var fakeLayer = GetLayer("FakeLayer");
            var BeatAR = BeatARTime * beat;
            var localSprite = fakeLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.Position);
            localSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
            localSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR / 2, 0, 1);
            localSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
            //localSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
            localSprite.Color(hitobject.StartTime - BeatAR, Color);
            Vector2 offset = new Vector2(xOffset, yOffset);
            localSprite.Move(startTime, hitobject.Position - offset);
        }

        static double Look(Vector2 Vector, Vector2 Vector2)
            {
                Vector2 SubVector = Vector2 - Vector;
                Vector2 DefaultFacingDirection = new Vector2(1, 0);
                return Math.Atan2(SubVector.Y, SubVector.X) - Math.Atan2(DefaultFacingDirection.Y, DefaultFacingDirection.X);
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
                if (!(hitobject is OsuSpinner))
                {
                    if ((StartTime != 0 || EndTime != 0) && 
                        (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                        continue;

                    var aSprite = arLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.Position);
                    aSprite.Scale(OsbEasing.None, hitobject.StartTime - BeatAR, hitobject.StartTime, SpriteScale * 4, SpriteScale * 1.1);
                    aSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR * 5 / 8, 0, 1);
                    aSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime, 1, 0);
                    //aSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                    if (SoloColor) aSprite.Color(hitobject.StartTime - BeatAR, Color);
                    else aSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                    
                    var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                    hSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                    hSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR / 2, 0, 1);
                    hSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
                    //hSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                    if (SoloColor) hSprite.Color(hitobject.StartTime - BeatAR, Color);
                    else hSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                    if (HitcircleOverlayPath == "hitcircleoverlay.png")
                    {
                        var h2Sprite = hitobjectLayer.CreateSprite(HitcircleOverlayPath, OsbOrigin.Centre, hitobject.Position);
                        h2Sprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                        h2Sprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR / 2, 0, 1);
                        h2Sprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
                        //h2Sprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                        /*
                        if (SoloColor) h2Sprite.Color(hitobject.StartTime - BeatAR, Color);
                        else h2Sprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);
                        */
                        h2Sprite.Color(hitobject.StartTime - BeatAR, Color4.White);
                    }
                }
                if (hitobject is OsuSlider)
                {
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / BeatDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderEdgeSprite = sliderLayer.CreateSprite(SliderEdge, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderEdgeSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SliderSpriteScale, SliderSpriteScale);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, 1);
                        sliderEdgeSprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                        if (SoloColor) sliderEdgeSprite.Color(hitobject.StartTime - BeatAR, Color);
                        else sliderEdgeSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        // Manual Section
                        // End of Manual Section

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderBodySprite = sliderLayer.CreateSprite(SliderBody, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));

                        sliderBodySprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SliderSpriteScale * 0.9, SliderSpriteScale * 0.9);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, 0, SliderBodyFade);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SliderBodyFade, 0);
                        if (SoloColor) sliderBodySprite.Color(hitobject.StartTime - BeatAR, SliderColor);
                        else sliderBodySprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    var sliderBallSprite = hitobjectLayer.CreateSprite(SliderBall, OsbOrigin.Centre, hitobject.PositionAtTime(startTime));
                    if (SBallColor) sliderBallSprite.Color(hitobject.StartTime - BeatAR, BallColor);
                    else sliderBallSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);
                    while (true)
                    {
                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < timestep;
                        if (complete) endTime = hitobject.EndTime;

                        var startPosition = sliderBallSprite.PositionAt(startTime);
                        sliderBallSprite.Move(startTime, endTime, startPosition, hitobject.PositionAtTime(endTime));
                        sliderBallSprite.Scale(startTime, SpriteScale * 0.5);
                        sliderBallSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime, 0, 1);
                        sliderBallSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime, 1, 0);

                        if (complete) break;
                        startTime += timestep;
                    }
                    startTime = hitobject.StartTime;
                    var slider = hitobject as OsuSlider;
                    if (SliderEndToggle)
                    {
                        var sliderEndaSprite = arLayer.CreateSprite(ApproachcirclePath, OsbOrigin.Centre, hitobject.PositionAtTime(hitobject.EndTime));
                        sliderEndaSprite.Scale(OsbEasing.None, hitobject.EndTime - BeatAR, hitobject.EndTime, SpriteScale * 4, SpriteScale * 1.1);
                        sliderEndaSprite.Fade(OsbEasing.In, hitobject.EndTime - BeatAR, hitobject.EndTime - BeatAR * 5 / 8, 0, 1);
                        sliderEndaSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime, 1, 0);
                        //aSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                        if (SoloColor) sliderEndaSprite.Color(hitobject.EndTime - BeatAR, Color);
                        else sliderEndaSprite.Color(hitobject.EndTime - BeatAR, hitobject.Color);
                    }

                    var sliderEndhSprite = hitobjectLayer.CreateSprite(SliderEnd, OsbOrigin.Centre, hitobject.PositionAtTime(hitobject.EndTime));
                    sliderEndhSprite.Scale(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SpriteScale * 0.7, SpriteScale * 0.9);
                    sliderEndhSprite.Fade(OsbEasing.In, hitobject.EndTime - BeatAR, hitobject.EndTime - BeatAR / 2, 0, 1);
                    sliderEndhSprite.Fade(OsbEasing.None, hitobject.EndTime, hitobject.EndTime + FadeTime, 1, 0);
                    sliderEndhSprite.Rotate(OsbEasing.None, hitobject.EndTime - BeatAR, hitobject.EndTime, 0, 2*Math.PI);
                    //hSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                    if (SoloColor) sliderEndhSprite.Color(hitobject.StartTime - BeatAR, Color);
                    else sliderEndhSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);
                    
                    startTime = hitobject.StartTime;
                    if (slider.RepeatCount > 0)
                    {
                        var reverses = hitobject.EndTime - hitobject.StartTime / (slider.TravelCount + 1);

                        for (int i = 0; i < slider.RepeatCount; i++)
                        {
                            var angle = Look(slider.PlayfieldPositionAtTime(startTime + slider.TravelDuration*(i+1) - timestep), slider.PlayfieldPositionAtTime(startTime + slider.TravelDuration*(i+1)));

                            var reverseSprite = hitobjectLayer.CreateSprite(Reverse, OsbOrigin.Centre, hitobject.PositionAtTime(startTime + slider.TravelDuration*(i+1)));
                            reverseSprite.Scale(startTime, SpriteScale);
                            reverseSprite.Rotate(startTime, Math.PI + angle);
                            if (i < 2) reverseSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime + slider.TravelDuration*(i+1), 0, 1);
                            else reverseSprite.Fade(OsbEasing.Out, hitobject.StartTime + slider.TravelDuration*(i-2), hitobject.StartTime + slider.TravelDuration*(i+1), 0, 1);
                        }
                        

                    }

                    if (slider.TravelDurationBeats*SliderTickRate > 1)
                    {
                        startTime = hitobject.StartTime;
                        var tickCount = Math.Floor(slider.TravelDurationBeats*SliderTickRate);

                        for (int i = 0; i < tickCount; i++)
                        {

                            var angle = Look(slider.PlayfieldPositionAtTime(startTime + beat*(i+1/SliderTickRate) - timestep), slider.PlayfieldPositionAtTime(startTime + beat*(i+1/SliderTickRate)));
                            var sliderTickSprite = sliderLayer.CreateSprite(SliderTick, OsbOrigin.Centre, hitobject.PositionAtTime(startTime + beat*(i+1/SliderTickRate)));

                            sliderTickSprite.Scale(startTime, SpriteScale);
                            sliderTickSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime + beat*(i+1/SliderTickRate), 0, 1);
                            if (STickColor) sliderTickSprite.Color(hitobject.StartTime - BeatAR, SliderColor);
                            else sliderTickSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);
                        }
                    }
                }

                // Manual Section
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