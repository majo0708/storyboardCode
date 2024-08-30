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
    public class Spotlight : StoryboardObjectGenerator
    {
        [Configurable]
        public string Mode = "Scroll";
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int MoveIn = 0;

        [Configurable]
        public int MoveOut = 0;

        [Configurable]
        public string SpritePath = "sprite.png";

        [Configurable]
        public double SpriteScale = 1;

        [Description("Rotation of the sprite; does not influences particle motion direction.")]
        [Configurable] public float Rotation = 0;

        [Description("Spacing between sprites in x-direction.")]
        [Configurable]
        public int xSpace = 0;

        [Description("Spacing between sprites in y-direction.")]
        [Configurable]
        public int ySpace = 0;

        [Description("Offset between sprites in columns in x-direction.")]
        [Configurable]
        public int xOffset = 0;

        [Description("Offset between sprites in rows in y-direction.")]
        [Configurable]
        public int yOffset = 0;

        [Configurable]
        public Vector2 offScreen1 = new Vector2(0,0);

        [Configurable]
        public Vector2 onScreen1 = new Vector2(0,0);

        [Configurable]
        public Vector2 onScreen2 = new Vector2(0,0);

        [Configurable]
        public Vector2 offScreen2 = new Vector2(0,0);

        [Configurable]
        public bool ComboColor = true;

        [Configurable]
        public Color4 Color = Color4.Gray;

        public void Squish(int startTime, double rotation, double beat, OsbSprite aSprite)
        {
            aSprite.ScaleVec(startTime - beat, SpriteScale, SpriteScale);
            aSprite.Rotate(startTime, rotation);
            aSprite.ScaleVec(OsbEasing.Out, startTime, startTime + beat / 2, 0.25 * SpriteScale, SpriteScale, SpriteScale, SpriteScale);
        }

        public void Cover(System.Drawing.Bitmap bitmap, double beat)
        {
            var coverLayer = GetLayer("Cover");
            var widthSize = (int)(640.0f / (bitmap.Width * SpriteScale + xSpace * 0.2));
            var heightSize = (int)(480.0f / (bitmap.Height * SpriteScale + ySpace * 0.2));
            Vector2 xxOffset = new Vector2(xOffset, 0);
            Vector2 yyOffset = new Vector2(0, yOffset);
            // var cirlce = Beatmap.HitObjects;

            for (int i = 0; i < widthSize * 2; i++)
            {
                for (int j = 0; j < heightSize * 2; j++)
                {
                    Vector2 space = new Vector2(xSpace * i, ySpace * j);
                    if (i % 2 == 0) space += yyOffset;
                    if (j % 2 == 0) space += xxOffset;
                    
                    var localSprite = coverLayer.CreateSprite(SpritePath, OsbOrigin.Centre);
                    localSprite.Fade(StartTime - MoveIn, 1);
                    localSprite.Fade(EndTime + MoveOut, 0);
                    localSprite.Rotate(StartTime - MoveIn, Rotation / 180 * Math.PI);
                    localSprite.Scale(StartTime - MoveIn, SpriteScale);
                    localSprite.Move(OsbEasing.Out, StartTime - MoveIn, StartTime, offScreen1 + space, onScreen1 + space);
                    localSprite.Move(OsbEasing.None, StartTime, EndTime, onScreen1 + space, onScreen2 + space);
                    localSprite.Move(OsbEasing.In, EndTime, EndTime + MoveOut, onScreen2 + space, space + offScreen2);
                    if (ComboColor) localSprite.Color(StartTime - MoveIn, Color);
                    else localSprite.Color(StartTime - MoveIn, Color);

                    var duration = (EndTime - StartTime) / beat;
                    var designSprite = coverLayer.CreateSprite(SpritePath, OsbOrigin.Centre);
                    designSprite.Fade(StartTime - MoveIn, 0);
                    designSprite.Fade(EndTime + MoveOut, 0); 
                    designSprite.Rotate(StartTime - MoveIn, Rotation / 180 * Math.PI);
                    designSprite.Scale(StartTime - MoveIn, SpriteScale);
                    designSprite.Move(OsbEasing.Out, StartTime - MoveIn, StartTime, offScreen1 + space, onScreen1 + space);
                    designSprite.Move(OsbEasing.None, StartTime, EndTime, onScreen1 + space, onScreen2 + space);
                    designSprite.Move(OsbEasing.In, EndTime, EndTime + MoveOut, onScreen2 + space, space + offScreen2);
                    if (ComboColor) designSprite.Color(StartTime - MoveIn, Color);
                    else designSprite.Color(StartTime - MoveIn, Color);
                    for (int k = 1; k < 2*duration; k+=2)
                    {
                        designSprite.Scale(OsbEasing.In, StartTime + beat * k, StartTime + beat * (k+1), SpriteScale * 1.3, SpriteScale);
                        designSprite.Fade(OsbEasing.In, StartTime + beat * k, StartTime + beat * (k+1), 1, 0);
                    }
                }
            
            }
        }

        public void Scroll(System.Drawing.Bitmap bitmap, double beat)
        {
            var coverLayer = GetLayer("Cover");
            var widthSize = (int)(640.0f / (bitmap.Width * SpriteScale + xSpace * 0.2));
            var heightSize = (int)(480.0f / (bitmap.Height * SpriteScale + ySpace * 0.2));
            int i = 0;

            var movingSprite = coverLayer.CreateSprite(SpritePath, OsbOrigin.Centre);
            movingSprite.Fade(OsbEasing.None, StartTime - beat, StartTime, 0, 1);
            movingSprite.ScaleVec(StartTime, SpriteScale, 1);
            movingSprite.Color(StartTime, Color);

            while (StartTime + i*beat < EndTime)
            {
                movingSprite.Move(StartTime + i * beat, StartTime + (i+1) * beat, onScreen1, onScreen2);
                i++;
            }
            movingSprite.Fade(OsbEasing.None, EndTime - beat, EndTime, 1, 0);
        }

        public void Spin(System.Drawing.Bitmap bitmap, double beat)
        {
            var coverLayer = GetLayer("Cover");
            var widthSize = (int)(640.0f / (bitmap.Width * SpriteScale + xSpace * 0.2));
            var heightSize = (int)(480.0f / (bitmap.Height * SpriteScale + ySpace * 0.2));
            int i = 0;

            var spinSprite = coverLayer.CreateSprite(SpritePath, OsbOrigin.Centre);
            spinSprite.Fade(OsbEasing.None, StartTime - beat, StartTime, 0, 1);
            spinSprite.Move(StartTime, onScreen1);
            spinSprite.ScaleVec(StartTime, SpriteScale, 1);
            spinSprite.Color(StartTime, Color);

            while (StartTime + i*beat < EndTime)
            {
                spinSprite.Rotate(StartTime + i * beat, StartTime + (i+2) * beat, 0, 2*Math.PI);
                i++;
            }
            spinSprite.Fade(OsbEasing.None, EndTime - beat, EndTime, 1, 0);
        }

        public override void Generate()
        {
            var beat = Beatmap.GetTimingPointAt((int)788).BeatDuration;
            var bitmap = GetMapsetBitmap(SpritePath);
            if (Mode == "Scroll") Scroll(bitmap, beat);
            else if (Mode == "Spin") Spin(bitmap, beat);
            else Cover(bitmap, beat);
        }
    }
}
