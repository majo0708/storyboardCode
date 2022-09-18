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
    public class TextManual : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    var hitobjectLayer = GetLayer("");
            var ImagePath = "sb/happy_face.png";
            Vector2 Position = new Vector2(320, 248);
            var Image = hitobjectLayer.CreateSprite(ImagePath, OsbOrigin.Centre, Position);
            Image.ScaleVec(OsbEasing.Out, 92554, 92656, 0.6, 0.6, 1, 1);
            Image.Fade(OsbEasing.Out, 92554, 92656, 0, 1);
            Image.Rotate(OsbEasing.Out, 92554, 92656, -Math.PI/4, -Math.PI/6);
            Image.Color(OsbEasing.Out, 92554, 92656, Color4.Transparent, Color4.White);
            Image.ScaleVec(OsbEasing.In, 92656, 95122, 1, 1, 0.2, 0.2);
            Image.Fade(OsbEasing.In, 92656, 95122, 1, 0);
            Image.Rotate(OsbEasing.In, 92656, 95122, -Math.PI/6, Math.PI/6);
            Image.Color(OsbEasing.In, 92656, 95122, Color4.White, Color4.Transparent);
        }
    }
}
