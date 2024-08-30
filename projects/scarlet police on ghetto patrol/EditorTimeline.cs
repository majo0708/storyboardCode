using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
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
    public class EditorTimeline : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int SliderDivisor = 8;

        [Configurable]
        public int TimelineDivisor = 4;

        [Configurable]
        public int FadeTime = 200;

        [Configurable]
        public double BeatARTime = 2;

        [Configurable]
        public string TimelinePath = "sprite.png";

        [Configurable]
        public string HitAreaPath = "sb/circle.png";

        [Configurable]
        public string HitcirclePath = "sb/circle.png";

        [Configurable]
        public string HitcircleOverlayPath = "hitcircleoverlay.png";

        [Configurable]
        public string SliderBody = "sb/sliderbody.png";

        [Configurable]
        public Vector2 TStartPos = new Vector2(0,0);

        [Configurable]
        public Vector2 TEndPos = new Vector2(0,0);

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public double SliderSpriteScale = 1;

        [Configurable]
        public double SliderBodyFade = 1;

        [Configurable]
        public bool SoloColor = true;

        [Configurable]
        public bool STickColor = true;

        [Configurable]
        public Color4 Color = Color4.Gray;

        [Configurable]
        public Color4 SliderColor = Color4.Gray;

        public override void Generate()
        {
		    var arLayer = GetLayer("ARLayer");
            var hitobjectLayer = GetLayer("HitObjects");
            var sliderLayer = GetLayer("SliderObjects");
            var timelineLayer = GetLayer("TimelineObjects");
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
            var BeatAR = BeatARTime * beat;

            var hitArea = hitobjectLayer.CreateSprite(HitAreaPath, OsbOrigin.Centre, TEndPos);
            hitArea.Fade(OsbEasing.None, StartTime - BeatAR, StartTime, 0, 1);
            hitArea.Scale(OsbEasing.In, EndTime, EndTime + FadeTime, SpriteScale, SpriteScale * 1.2);
            hitArea.Fade(OsbEasing.None, EndTime, EndTime + FadeTime, 1, 0);

            // TODO: create timeline, use hSprite.Move

            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (!(hitobject is OsuSpinner))
                {
                    if ((StartTime != 0 || EndTime != 0) && 
                        (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                        continue;
                
                    var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, TStartPos);
                    hSprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                    hSprite.Move(OsbEasing.None, hitobject.StartTime - BeatAR, hitobject.StartTime, TStartPos, TEndPos);
                    hSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime + FadeTime, 1, 0);
                    //hSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                    if (SoloColor) hSprite.Color(hitobject.StartTime - BeatAR, Color);
                    else hSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                    if (HitcircleOverlayPath == "hitcircleoverlay.png")
                    {
                        var h2Sprite = hitobjectLayer.CreateSprite(HitcircleOverlayPath, OsbOrigin.Centre, TStartPos);
                        h2Sprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.StartTime + FadeTime, SpriteScale, SpriteScale * 1.2);
                        h2Sprite.Move(OsbEasing.None, hitobject.StartTime - BeatAR, hitobject.StartTime, TStartPos, TEndPos);
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
                    var timestep = Beatmap.GetTimingPointAt((int)hitobject.StartTime).BeatDuration / SliderDivisor;
                    var startTime = hitobject.StartTime;
                    while (true)
                    {
                        var sliderBodySprite = sliderLayer.CreateSprite(SliderBody, OsbOrigin.Centre, TStartPos);

                        sliderBodySprite.Scale(OsbEasing.In, hitobject.StartTime, hitobject.EndTime, SliderSpriteScale * 0.9, SliderSpriteScale * 0.9);
                        sliderBodySprite.Move(OsbEasing.None, startTime - BeatAR, startTime, TStartPos, TEndPos);
                        sliderBodySprite.Fade(OsbEasing.In, hitobject.EndTime, hitobject.EndTime + FadeTime, SliderBodyFade, 0);
                        if (SoloColor) sliderBodySprite.Color(hitobject.StartTime - BeatAR, SliderColor);
                        else sliderBodySprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                        var endTime = startTime + timestep;
                        var complete = hitobject.EndTime - endTime < -timestep;

                        if (complete) break;
                        startTime += timestep;
                    }
                }
            }
            for (int i = 0; i < (EndTime - StartTime) / (beat / TimelineDivisor); i++)
            {
                var timestep = Beatmap.GetTimingPointAt(StartTime).BeatDuration / TimelineDivisor;
                var startTime = StartTime;
                var bitmap = GetMapsetBitmap(TimelinePath);
                var lineSprite = timelineLayer.CreateSprite(TimelinePath, OsbOrigin.Centre, TStartPos);

                lineSprite.ScaleVec(startTime, (double)1 / bitmap.Width, 1);
                lineSprite.Move(OsbEasing.None, startTime + timestep * i - BeatAR, startTime + timestep * i, TStartPos, TEndPos);
                lineSprite.Fade(OsbEasing.In, startTime + timestep * i, startTime + timestep * i + FadeTime, 1, 0);
                if (i % TimelineDivisor == 3) lineSprite.Color(startTime + timestep * i - BeatAR, Color4.White);
                else if (i % TimelineDivisor == 1) lineSprite.Color(startTime + timestep * i - BeatAR, Color4.Red);
                else lineSprite.Color(startTime + timestep * i - BeatAR, Color4.Blue);
            }
        }
    }
}
