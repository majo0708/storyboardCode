using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Linq;

namespace StorybrewScripts
{
    public class Background : StoryboardObjectGenerator
    {
        [Configurable]
        public string BackgroundPath = "";

        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int FadeEndTime = 0;

        [Configurable]
        public int FadeStartTime = 0;

        [Configurable]
        public double OpacityStart = 0;

        [Configurable]
        public double OpacityEnd = 0.2;

        public override void Generate()
        {
            if (BackgroundPath == "") BackgroundPath = Beatmap.BackgroundPath ?? string.Empty;
            if (StartTime == EndTime) EndTime = (int)(Beatmap.HitObjects.LastOrDefault()?.EndTime ?? AudioDuration);

            var bitmap = GetMapsetBitmap(BackgroundPath);
            var bg = GetLayer("").CreateSprite(BackgroundPath, OsbOrigin.Centre);
            bg.Scale(StartTime, 480.0f / bitmap.Height);
            bg.Fade(StartTime - FadeStartTime, StartTime, 0, OpacityStart);
            bg.Fade(StartTime, EndTime, OpacityStart, OpacityEnd);
            bg.Fade(EndTime, EndTime + FadeEndTime, OpacityEnd, 0);
        }
    }
}