using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Linq;

namespace StorybrewScripts
{
    public class BackgroundManual : StoryboardObjectGenerator
    {
        [Configurable]
        public string BackgroundPath = "";
/*
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
*/
        public void Time(int startTime, int endTime, System.Drawing.Bitmap bitmap, OsbSprite bg)
        { 
            bg.Scale(startTime, 480.0f / bitmap.Height);
            bg.Fade(startTime, 1);
            bg.Fade(endTime, 0);
        }

        public override void Generate()
        {
            if (BackgroundPath == "") BackgroundPath = Beatmap.BackgroundPath ?? string.Empty;

            var bitmap = GetMapsetBitmap(BackgroundPath);
            var bg = GetLayer("").CreateSprite(BackgroundPath, OsbOrigin.Centre);

            Time(1999, 2837, bitmap, bg);
            Time(4681, 5519, bitmap, bg);
            Time(7362, 8200, bitmap, bg);
            Time(10044, 10882, bitmap, bg);
            
            
        }
    }
}