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
    public class LollyManual : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public string HitcirclePath = "sb/circle.png";

        [Configurable]
        public string HitPath = "sb/circle_border.png";

        [Configurable]
        public string LightSpritePath = "sb/circle_border.png";

        [Configurable]
        public double BeatARTime = 2;

        [Configurable]
        public double SpriteScale = 1;

        [Configurable]
        public bool SoloColor = true;

        [Configurable]
        public Color4 Color = Color4.Gray;

        public override void Generate()
        {
            Vector2 posMiddle = new Vector2(256, 192);
            Vector2 posRight = new Vector2(448, 192);
            Vector2 posLeft = new Vector2(64, 192);
            Vector2 posUpRight = new Vector2(352, 26);
            Vector2 posUpLeft = new Vector2(160, 26);
            Vector2 posDownRight = new Vector2(352, 358);
            Vector2 posDownLeft = new Vector2(160, 358);
            Vector2 posOffset = OsuHitObject.PlayfieldToStoryboardOffset;
		    var lollyLayer = GetLayer("LollyLayer");
            

            // Right
            var lollySpriteR = lollyLayer.CreateSprite("sb/line.png", OsbOrigin.TopCentre, posRight + posOffset);
            lollySpriteR.Rotate(116894, Math.PI/2);
            lollySpriteR.ScaleVec(OsbEasing.In, 116894, 117381, 0.2, 0.1, 0.2, 1.9);

            lollySpriteR.Move(OsbEasing.In, 126137, 126462, posRight + posOffset, posMiddle + posOffset);
            lollySpriteR.ScaleVec(OsbEasing.In, 126137, 126462, 0.2, 1.9, 0.2, 0.1);

            var lollySpriteDR = lollyLayer.CreateSprite("sb/line.png", OsbOrigin.TopCentre, posDownRight + posOffset);
            lollySpriteDR.Rotate(116894, 2*Math.PI/3 + Math.PI/6);
            lollySpriteDR.ScaleVec(OsbEasing.In, 116894, 117381, 0.2, 0.1, 0.2, 1.9);

            lollySpriteDR.Move(OsbEasing.In, 126137, 126462, posDownRight + posOffset, posMiddle + posOffset);
            lollySpriteDR.ScaleVec(OsbEasing.In, 126137, 126462, 0.2, 1.9, 0.2, 0.1);

            var lollySpriteDL = lollyLayer.CreateSprite("sb/line.png", OsbOrigin.TopCentre, posDownLeft + posOffset);
            lollySpriteDL.Rotate(116894, Math.PI + Math.PI/6);
            lollySpriteDL.ScaleVec(OsbEasing.In, 116894, 117381, 0.2, 0.1, 0.2, 1.9);

            lollySpriteDL.Move(OsbEasing.In, 126137, 126462, posDownLeft + posOffset, posMiddle + posOffset);
            lollySpriteDL.ScaleVec(OsbEasing.In, 126137, 126462, 0.2, 1.9, 0.2, 0.1);

            var lollySpriteL = lollyLayer.CreateSprite("sb/line.png", OsbOrigin.TopCentre, posLeft + posOffset);
            lollySpriteL.Rotate(116894, 3*Math.PI/2);
            lollySpriteL.ScaleVec(OsbEasing.In, 116894, 117381, 0.2, 0.1, 0.2, 1.9);

            lollySpriteL.Move(OsbEasing.In, 126137, 126462, posLeft + posOffset, posMiddle + posOffset);
            lollySpriteL.ScaleVec(OsbEasing.In, 126137, 126462, 0.2, 1.9, 0.2, 0.1);

            var lollySpriteUL = lollyLayer.CreateSprite("sb/line.png", OsbOrigin.TopCentre, posUpLeft + posOffset);
            lollySpriteUL.Rotate(116894, 3*Math.PI/2 + Math.PI/3);
            lollySpriteUL.ScaleVec(OsbEasing.In, 116894, 117381, 0.2, 0.1, 0.2, 1.9);

            lollySpriteUL.Move(OsbEasing.In, 126137, 126462, posUpLeft + posOffset, posMiddle + posOffset);
            lollySpriteUL.ScaleVec(OsbEasing.In, 126137, 126462, 0.2, 1.9, 0.2, 0.1);

            var lollySpriteUR = lollyLayer.CreateSprite("sb/line.png", OsbOrigin.TopCentre, posUpRight + posOffset);
            lollySpriteUR.Rotate(116894, Math.PI/6);
            lollySpriteUR.ScaleVec(OsbEasing.In, 116894, 117381, 0.2, 0.1, 0.2, 1.9);

            lollySpriteUR.Move(OsbEasing.In, 126137, 126462, posUpRight + posOffset, posMiddle + posOffset);
            lollySpriteUR.ScaleVec(OsbEasing.In, 126137, 126462, 0.2, 1.9, 0.2, 0.1);

            var hitSpriteRight = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posRight + posOffset);
            hitSpriteRight.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteRight.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteRight.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.8);
            hitSpriteRight.Scale(OsbEasing.Out, 119327, 119651, 0.8, 0.3);
            hitSpriteRight.Scale(OsbEasing.Out, 121921, 122246, 0.3, 0.8);
            hitSpriteRight.Scale(OsbEasing.Out, 124516, 124840, 0.8, 0.3);
            hitSpriteRight.Scale(OsbEasing.Out, 125813, 126137, 0.3, 0.8);
            hitSpriteRight.Scale(OsbEasing.Out, 126462, 126624, 0.8, 0.1);

            var hitSpriteDownRight = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posDownRight + posOffset);
            hitSpriteDownRight.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteDownRight.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteDownRight.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.8);
            hitSpriteDownRight.Scale(OsbEasing.Out, 119327, 119651, 0.8, 0.3);
            hitSpriteDownRight.Scale(OsbEasing.Out, 121921, 122246, 0.3, 0.8);
            hitSpriteDownRight.Scale(OsbEasing.Out, 124516, 124840, 0.8, 0.3);
            hitSpriteDownRight.Scale(OsbEasing.Out, 125813, 126137, 0.3, 0.8);
            hitSpriteDownRight.Scale(OsbEasing.Out, 126462, 126624, 0.8, 0.1);

            var hitSpriteDownLeft = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posDownLeft + posOffset);
            hitSpriteDownLeft.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteDownLeft.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteDownLeft.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.8);
            hitSpriteDownLeft.Scale(OsbEasing.Out, 119327, 119651, 0.8, 0.3);
            hitSpriteDownLeft.Scale(OsbEasing.Out, 121921, 122246, 0.3, 0.8);
            hitSpriteDownLeft.Scale(OsbEasing.Out, 124516, 124840, 0.8, 0.3);
            hitSpriteDownLeft.Scale(OsbEasing.Out, 125813, 126137, 0.3, 0.8);
            hitSpriteDownLeft.Scale(OsbEasing.Out, 126462, 126624, 0.8, 0.1);

            var hitSpriteLeft = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posLeft + posOffset);
            hitSpriteLeft.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteLeft.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteLeft.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.8);
            hitSpriteLeft.Scale(OsbEasing.Out, 119327, 119651, 0.8, 0.3);
            hitSpriteLeft.Scale(OsbEasing.Out, 121921, 122246, 0.3, 0.8);
            hitSpriteLeft.Scale(OsbEasing.Out, 124516, 124840, 0.8, 0.3);
            hitSpriteLeft.Scale(OsbEasing.Out, 125813, 126137, 0.3, 0.8);
            hitSpriteLeft.Scale(OsbEasing.Out, 126462, 126624, 0.8, 0.1);

            var hitSpriteUpLeft = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posUpLeft + posOffset);
            hitSpriteUpLeft.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteUpLeft.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteUpLeft.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.8);
            hitSpriteUpLeft.Scale(OsbEasing.Out, 119327, 119651, 0.8, 0.3);
            hitSpriteUpLeft.Scale(OsbEasing.Out, 121921, 122246, 0.3, 0.8);
            hitSpriteUpLeft.Scale(OsbEasing.Out, 124516, 124840, 0.8, 0.3);
            hitSpriteUpLeft.Scale(OsbEasing.Out, 125813, 126137, 0.3, 0.8);
            hitSpriteUpLeft.Scale(OsbEasing.Out, 126462, 126624, 0.8, 0.1);

            var hitSpriteUpRight = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posUpRight + posOffset);
            hitSpriteUpRight.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteUpRight.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteUpRight.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.8);
            hitSpriteUpRight.Scale(OsbEasing.Out, 119327, 119651, 0.8, 0.3);
            hitSpriteUpRight.Scale(OsbEasing.Out, 121921, 122246, 0.3, 0.8);
            hitSpriteUpRight.Scale(OsbEasing.Out, 124516, 124840, 0.8, 0.3);
            hitSpriteUpRight.Scale(OsbEasing.Out, 125813, 126137, 0.3, 0.8);
            hitSpriteUpRight.Scale(OsbEasing.Out, 126462, 126624, 0.8, 0.1);

            var hitSpriteMiddle = lollyLayer.CreateSprite(HitPath, OsbOrigin.Centre, posMiddle + posOffset);
            hitSpriteMiddle.Fade(OsbEasing.In, 116570, 117381, 0, 0.8);
            hitSpriteMiddle.Fade(OsbEasing.In, 126462, 126624, 0.8, 0);
            hitSpriteMiddle.Scale(OsbEasing.Out, 116570, 117381, 0.1, 0.3);
            hitSpriteMiddle.Scale(OsbEasing.Out, 119327, 119651, 0.3, 0.8);
            hitSpriteMiddle.Scale(OsbEasing.Out, 121921, 122246, 0.8, 0.3);
            hitSpriteMiddle.Scale(OsbEasing.Out, 124516, 124840, 0.3, 0.8);
            hitSpriteMiddle.Scale(OsbEasing.Out, 125813, 126137, 0.8, 0.3);
            hitSpriteMiddle.Scale(OsbEasing.Out, 126462, 126624, 0.3, 0.1);

            var hitobjectLayer = GetLayer("HitObjects");
            var beat = Beatmap.GetTimingPointAt((int)StartTime).BeatDuration;
            var BeatAR = BeatARTime * beat;
            Vector2[] startPos = {
                posRight,
                posDownRight,
                posDownLeft,
                posLeft,
                posUpLeft,
                posUpRight,
                posRight,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posUpRight,
                posDownRight,
                posDownRight,
                posLeft,
                posRight,
                posRight,
                posDownLeft,
                posDownLeft,
                posUpLeft,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posUpLeft,
                posUpRight
            };

            Vector2[] endPos = {
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posDownRight,
                posLeft,
                posUpRight,
                posDownRight,
                posUpLeft,
                posUpLeft,
                posDownLeft,
                posDownLeft,
                posRight,
                posLeft,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posMiddle,
                posRight,
                posRight,
                posRight,
                posDownRight,
                posDownRight,
                posDownRight,
                posDownLeft,
                posDownLeft,
                posDownLeft,
                posLeft,
                posLeft,
                posLeft,
                posMiddle,
                posMiddle
            };

            int i = 0;
            foreach (var hitobject in Beatmap.HitObjects)
            {
                if (!(hitobject is OsuSpinner))
                {
                    if ((StartTime != 0 || EndTime != 0) && 
                        (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                        continue;

                    var hSprite = hitobjectLayer.CreateSprite(HitcirclePath, OsbOrigin.Centre, hitobject.Position);
                    hSprite.Scale(hitobject.StartTime, SpriteScale);
                    hSprite.Move(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime, startPos[i] + posOffset, endPos[i] + posOffset);
                    hSprite.Fade(OsbEasing.In, hitobject.StartTime - BeatAR, hitobject.StartTime - BeatAR * 5 / 8, 0, 1);
                    hSprite.Fade(OsbEasing.None, hitobject.StartTime, hitobject.StartTime, 1, 0);
                    //aSprite.Additive(hitobject.StartTime - BeatAR, hitobject.EndTime + FadeTime);
                    if (SoloColor) hSprite.Color(hitobject.StartTime - BeatAR, Color);
                    else hSprite.Color(hitobject.StartTime - BeatAR, hitobject.Color);

                    var lightSprite = hitobjectLayer.CreateSprite(LightSpritePath, OsbOrigin.Centre, hitobject.Position);
                    lightSprite.Scale(OsbEasing.Out, hitobject.StartTime, hitobject.StartTime + 163, SpriteScale, SpriteScale * 1.2);
                    lightSprite.Fade(OsbEasing.Out, hitobject.StartTime, hitobject.StartTime + 163, 1, 0);

                    i += 1;
                }
            }
        }
    }
}
