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
    public class A : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("Main");
            var bg = layer.CreateSprite("color_flow.jpg", OsbOrigin.Centre);
            bg.Scale(0, 480.0 / 1050);
            bg.Fade(0, 2000, 0, 1);
            bg.Fade(8000, 10000, 1, 0);    
        }
    }
}
