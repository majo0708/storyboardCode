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
    public class SplitLineManual : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    //This is manual code for a section
            Vector2 Middle = new Vector2(320, 248);
            string Line = "sb/line.png";

            var hitobjectLayer = GetLayer("");
            var LineX = hitobjectLayer.CreateSprite(Line, OsbOrigin.Centre, Middle);
            var LineY = hitobjectLayer.CreateSprite(Line, OsbOrigin.Centre, Middle);

            LineX.Fade(OsbEasing.None, 95122, 95122, 1, 1);
            LineY.Fade(OsbEasing.None, 95122, 95122, 1, 1);
            LineX.MoveY(OsbEasing.None, 95122, 95122, 248, 248);
            LineY.MoveY(OsbEasing.None, 95122, 95122, 248, 248);
            LineX.Rotate(OsbEasing.None, 95122, 95122, Math.PI/2, Math.PI/2);
            LineY.Rotate(OsbEasing.None, 95122, 95122, 0, 0);
            LineX.ScaleVec(OsbEasing.Out, 95122, 95533, 0.4, 0.1, 0.4, 7);
            LineY.ScaleVec(OsbEasing.Out, 95122, 95533, 0.4, 0.1, 0.4, 5);
            LineX.ScaleVec(OsbEasing.Out, 107451, 107656, 0.4, 7, 0.4, 0.01);
            LineY.ScaleVec(OsbEasing.Out, 107656, 107862, 0.4, 5, 0.4, 0.01);
            LineX.Fade(OsbEasing.None, 107656, 107656, 0, 0);
            LineY.Fade(OsbEasing.None, 107862, 107862, 0, 0);
            LineX.MoveY(OsbEasing.None, 107862, 107862, 165, 165);
            LineY.MoveY(OsbEasing.None, 107862, 107862, 331, 331);
            LineY.Rotate(OsbEasing.None, 107862, 107862, Math.PI/2, Math.PI/2);
            LineX.ScaleVec(OsbEasing.Out, 107862, 108067, 0.4, 0.1, 0.4, 7);
            LineX.Fade(OsbEasing.None, 107862, 107862, 1, 1);
            LineY.Fade(OsbEasing.None, 108067, 108067, 1, 1);
            LineY.ScaleVec(OsbEasing.Out, 108067, 108273, 0.4, 0.1, 0.4, 7);
            LineX.ScaleVec(OsbEasing.Out, 113615, 114026, 0.4, 7, 0.4, 0.1);
            LineY.ScaleVec(OsbEasing.Out, 113615, 114026, 0.4, 7, 0.4, 0.1);
            LineX.Fade(OsbEasing.Out, 113615, 114026, 1, 0);
            LineY.Fade(OsbEasing.Out, 113615, 114026, 1, 0);

            //Part 2
            LineX.Rotate(OsbEasing.None, 115259, 115259, Math.PI * 7 / 12, Math.PI * 7 / 12);
            LineX.ScaleVec(OsbEasing.Out, 115259, 115465, 0.4, 0.1, 0.4, 5);
            LineX.Fade(OsbEasing.Out, 115259, 115465, 0, 1);
            LineX.MoveX(OsbEasing.Out, 115259, 115465, 320, 426);
            LineX.MoveY(OsbEasing.Out, 115259, 115465, 248, 276);
            LineX.ScaleVec(OsbEasing.Out, 115465, 115670, 0.4, 5, 0.4, 7.5);
            LineX.MoveX(OsbEasing.Out, 115465, 115670, 426, 320);
            LineX.MoveY(OsbEasing.Out, 115465, 115670, 276, 248);
            LineX.ScaleVec(OsbEasing.Out, 118136, 118341, 0.4, 7, 0.4, 0.1);
            LineX.Fade(OsbEasing.Out, 118136, 118341, 1, 0);
        }
    }
}
