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
    public class FacesManual : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    //This is manual code for a section
            Vector2 TopLeft = new Vector2(160, 124);
            Vector2 TopRight = new Vector2(480, 124);
            Vector2 BotLeft = new Vector2(160, 372);
            Vector2 BotRight = new Vector2(480, 372);
            Vector2 TopMiddle = new Vector2(320, 84);
            Vector2 Middle = new Vector2(320, 248);
            Vector2 BotMiddle = new Vector2(320, 414);
            string Red = "sb/red_square.png";
            string White = "sb/white_square.png";

            var hitobjectLayer = GetLayer("");
            var Red1 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, TopLeft);
            var Red2 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, TopRight);
            var Red3 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, BotLeft);
            var Red4 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, BotRight);
            var White1 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, TopLeft);
            var White2 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, TopRight);
            var White3 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, BotLeft);
            var White4 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, BotRight);
            var Red5 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, TopMiddle);
            var Red6 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, Middle);
            var Red7 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, BotMiddle);
            var White5 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, TopMiddle);
            var White6 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, Middle);
            var White7 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, BotMiddle);
            var Red8 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, Middle);
            var Red9 = hitobjectLayer.CreateSprite(Red, OsbOrigin.Centre, Middle);
            var White8 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, Middle);
            var White9 = hitobjectLayer.CreateSprite(White, OsbOrigin.Centre, Middle);

            //Top Left
            Red1.Move(OsbEasing.None, 95122, 95122, TopLeft, TopLeft);
            Red1.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            Red1.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            Red1.Fade(OsbEasing.In, 95533, 95533, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 95533, 95738, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 97177, 97382, 0.5, 0.5, 0.01, 0.5);
            Red1.Fade(OsbEasing.Out, 97382, 97382, 0, 0);
            White1.ScaleVec(OsbEasing.Out, 96766, 96766, 0.5, 0.5, 0.5, 0.5);
            White1.Fade(OsbEasing.In, 96766, 96971, 0.5, 0);
            White1.Move(OsbEasing.None, 97177, 97177, TopLeft, TopLeft);
            White1.Fade(OsbEasing.Out, 97382, 97382, 0.5, 0.5);
            White1.ScaleVec(OsbEasing.Out, 97382, 97588, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 103341, 103341, 0.5, 0.5, 0.5, 0.5);
            Red1.Fade(OsbEasing.In, 103341, 103547, 0.5, 0);
            White1.Fade(OsbEasing.In, 103341, 103547, 0, 0.5);
            Red1.Fade(OsbEasing.In, 103958, 103958, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 103958, 104163, 0.01, 0.5, 0.5, 0.5);
            White1.ScaleVec(OsbEasing.Out, 103752, 103958, 0.5, 0.5, 0.01, 0.5);
            White1.Fade(OsbEasing.Out, 103958, 103958, 0, 0);
            White1.ScaleVec(OsbEasing.Out, 104985, 104985, 0.5, 0.5, 0.5, 0.5);
            White1.Fade(OsbEasing.In, 104985, 105191, 0.5, 0);
            Red1.ScaleVec(OsbEasing.Out, 105396, 105601, 0.5, 0.5, 0.01, 0.5);
            Red1.Fade(OsbEasing.Out, 105601, 105601, 0, 0);
            White1.Fade(OsbEasing.Out, 105601, 105601, 0.5, 0.5);
            White1.ScaleVec(OsbEasing.Out, 105601, 105807, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red1.Fade(OsbEasing.In, 106629, 106834, 0.5, 0);
            White1.Fade(OsbEasing.In, 106629, 106834, 0, 0.5);
            White1.ScaleVec(OsbEasing.Out, 107040, 107245, 0.5, 0.5, 0.01, 0.5);
            White1.Fade(OsbEasing.Out, 107245, 107245, 0, 0);
            Red1.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 107040, 107245, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 107656, 107862, 0.5, 0.5, 0.01, 0.5);
            Red1.Fade(OsbEasing.Out, 107862, 107862, 0, 0);

            //Top Right
            White2.Rotate(OsbEasing.None, 95122, 95122, 0, 0);
            White2.Move(OsbEasing.None, 95122, 95122, TopRight, TopRight);
            White2.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            White2.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            White2.Fade(OsbEasing.In, 95533, 95533, 0.5, 0.5);
            White2.ScaleVec(OsbEasing.Out, 95533, 95738, 0.01, 0.5, 0.5, 0.5);
            White2.ScaleVec(OsbEasing.Out, 100465, 100670, 0.5, 0.5, 0.01, 0.5);
            White2.Fade(OsbEasing.Out, 100670, 100670, 0, 0);
            White2.Fade(OsbEasing.Out, 100054, 100054, 0, 0);
            White2.Fade(OsbEasing.In, 100054, 100259, 0, 0.5);
            White2.ScaleVec(OsbEasing.Out, 101697, 101697, 0.5, 0.5, 0.5, 0.5);
            White2.Fade(OsbEasing.In, 101697, 101903, 0.5, 0);
            Red2.Move(OsbEasing.None, 100054, 100054, TopRight, TopRight);
            Red2.Fade(OsbEasing.In, 100054, 100259, 0.5, 0);
            Red2.ScaleVec(OsbEasing.Out, 100054, 100054, 0.5, 0.5, 0.5, 0.5);
            Red2.Fade(OsbEasing.Out, 100670, 100670, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 100670, 100875, 0.01, 0.5, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 102108, 102314, 0.5, 0.5, 0.01, 0.5);
            Red2.Fade(OsbEasing.Out, 102314, 102314, 0, 0);
            White2.Fade(OsbEasing.In, 102314, 102314, 0.5, 0.5);
            White2.ScaleVec(OsbEasing.Out, 102314, 102519, 0.01, 0.5, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red2.Fade(OsbEasing.In, 106629, 106834, 0.5, 0);
            White2.Fade(OsbEasing.In, 106629, 106834, 0, 0.5);
            White2.ScaleVec(OsbEasing.Out, 107040, 107245, 0.5, 0.5, 0.01, 0.5);
            White2.Fade(OsbEasing.Out, 107245, 107245, 0, 0);
            Red2.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 107040, 107245, 0.01, 0.5, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 107451, 107656, 0.5, 0.5, 0.01, 0.5);
            Red2.Fade(OsbEasing.Out, 107656, 107656, 0, 0);

            //Bot Left
            White3.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            White3.Fade(OsbEasing.In, 95533, 95533, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 95533, 95738, 0.01, 0.5, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 98821, 99026, 0.5, 0.5, 0.01, 0.5);
            White3.Fade(OsbEasing.Out, 99026, 99026, 0, 0);
            White3.Fade(OsbEasing.In, 98410, 98615, 0, 0.5);
            Red3.Fade(OsbEasing.In, 98410, 98615, 0.5, 0);
            Red3.Fade(OsbEasing.Out, 95944, 95944, 0, 0);
            Red3.ScaleVec(OsbEasing.Out, 96766, 96766, 0.5, 0.5, 0.5, 0.5);
            Red3.Fade(OsbEasing.In, 98410, 98821, 0.5, 0);
            Red3.Fade(OsbEasing.In, 98821, 99026, 0.5, 0);
            Red3.Fade(OsbEasing.Out, 99026, 99026, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 99026, 99232, 0.01, 0.5, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 100465, 100670, 0.5, 0.5, 0.01, 0.5);
            Red3.Fade(OsbEasing.Out, 100670, 100670, 0, 0);
            Red3.ScaleVec(OsbEasing.Out, 101697, 101697, 0.5, 0.5, 0.5, 0.5);
            Red3.Fade(OsbEasing.In, 100054, 100259, 0, 0.5);
            White3.ScaleVec(OsbEasing.Out, 100054, 100054, 0.5, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 100054, 100259, 0.5, 0);
            White3.Fade(OsbEasing.Out, 100670, 100670, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 100670, 100875, 0.01, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 101697, 101903, 0, 0.5);
            Red3.Fade(OsbEasing.In, 101697, 101903, 0.5, 0);
            White3.ScaleVec(OsbEasing.Out, 102108, 102314, 0.5, 0.5, 0.01, 0.5);
            White3.Fade(OsbEasing.Out, 102314, 102314, 0, 0);
            Red3.Fade(OsbEasing.Out, 102314, 102314, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 102314, 102519, 0.01, 0.5, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 103341, 103341, 0.5, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 103341, 103547, 0.5, 0);
            White3.Fade(OsbEasing.In, 103958, 103958, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 103958, 104163, 0.01, 0.5, 0.5, 0.5);
            Red3.Fade(OsbEasing.In, 103341, 103547, 0, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 103752, 103958, 0.5, 0.5, 0.01, 0.5);
            Red3.Fade(OsbEasing.Out, 103958, 103958, 0, 0);
            Red3.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red3.Fade(OsbEasing.In, 106629, 106834, 0.5, 0);
            White3.Fade(OsbEasing.In, 106629, 106834, 0, 0.5);
            White3.ScaleVec(OsbEasing.Out, 107040, 107245, 0.5, 0.5, 0.01, 0.5);
            White3.Fade(OsbEasing.Out, 107245, 107245, 0, 0);
            Red3.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 107040, 107245, 0.01, 0.5, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 108067, 108273, 0.5, 0.5, 0.01, 0.5);
            Red3.Fade(OsbEasing.Out, 108273, 108273, 0, 0);

            //Bot Right
            White4.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            White4.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            White4.Fade(OsbEasing.In, 96766, 96971, 0, 0.5);
            White4.Fade(OsbEasing.In, 95533, 95533, 0.5, 0.5);
            White4.ScaleVec(OsbEasing.Out, 95533, 95738, 0.01, 0.5, 0.5, 0.5);
            White4.ScaleVec(OsbEasing.Out, 97177, 97382, 0.5, 0.5, 0.01, 0.5);
            White4.Fade(OsbEasing.Out, 97382, 97382, 0, 0);
            Red4.ScaleVec(OsbEasing.Out, 96766, 96766, 0.5, 0.5, 0.5, 0.5);
            Red4.Fade(OsbEasing.In, 96766, 96971, 0.5, 0);
            Red4.Fade(OsbEasing.Out, 97382, 97382, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 97382, 97588, 0.01, 0.5, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 98821, 99026, 0.5, 0.5, 0.01, 0.5);
            Red4.Fade(OsbEasing.Out, 99026, 99026, 0, 0);
            White4.ScaleVec(OsbEasing.Out, 98410, 984, 0.5, 0.5, 0.5, 0.5);
            White4.Fade(OsbEasing.In, 98410, 98615, 0.5, 0);
            White4.Fade(OsbEasing.Out, 99026, 99026, 0.5, 0.5);
            White4.ScaleVec(OsbEasing.Out, 99026, 99232, 0.01, 0.5, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 104985, 104985, 0.5, 0.5, 0.5, 0.5);
            Red4.Fade(OsbEasing.In, 104985, 105191, 0.5, 0);
            White4.Fade(OsbEasing.In, 104985, 105191, 0, 0.5);
            White4.ScaleVec(OsbEasing.Out, 105396, 105601, 0.5, 0.5, 0.01, 0.5);
            White4.Fade(OsbEasing.Out, 105601, 105601, 0, 0);
            Red4.Fade(OsbEasing.Out, 105601, 105601, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 105601, 105807, 0.01, 0.5, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red4.Fade(OsbEasing.In, 106629, 106834, 0.75, 0.5);
            Red4.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 107862, 108067, 0.5, 0.5, 0.01, 0.5);
            Red4.Fade(OsbEasing.Out, 108067, 108067, 0, 0);

            /* In case I switch back
            //Top Left
            Red1.Move(OsbEasing.None, 95122, 95122, TopLeft, TopLeft);
            Red1.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            Red1.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            Red1.Fade(OsbEasing.In, 95533, 95738, 0.5, 0);
            Red1.Fade(OsbEasing.In, 95944, 95944, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 95944, 96149, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 97588, 97793, 0.5, 0.5, 0.01, 0.5);
            Red1.Fade(OsbEasing.Out, 97793, 97793, 0, 0);
            White1.ScaleVec(OsbEasing.Out, 96766, 96766, 0.5, 0.5, 0.5, 0.5);
            White1.Fade(OsbEasing.In, 96766, 96971, 0.5, 0);
            White1.Fade(OsbEasing.In, 97177, 97382, 0.5, 0);
            White1.Move(OsbEasing.None, 97177, 97177, TopLeft, TopLeft);
            White1.Fade(OsbEasing.Out, 97588, 97588, 0.5, 0.5);
            White1.ScaleVec(OsbEasing.Out, 97588, 97793, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 103341, 103341, 0.5, 0.5, 0.5, 0.5);
            Red1.Fade(OsbEasing.In, 103341, 103547, 0.5, 0);
            White1.Fade(OsbEasing.In, 103341, 103547, 0, 0.5);
            Red1.Fade(OsbEasing.In, 103752, 103752, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 103752, 103958, 0.01, 0.5, 0.5, 0.5);
            White1.ScaleVec(OsbEasing.Out, 103752, 103958, 0.5, 0.5, 0.01, 0.5);
            White1.Fade(OsbEasing.Out, 103958, 103958, 0, 0);
            Red1.ScaleVec(OsbEasing.Out, 105396, 105601, 0.5, 0.5, 0.01, 0.5);
            Red1.Fade(OsbEasing.Out, 105601, 105601, 0, 0);
            White1.Fade(OsbEasing.Out, 105396, 105601, 0.5, 0.5);
            White1.ScaleVec(OsbEasing.Out, 105601, 105601, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red1.Fade(OsbEasing.In, 106629, 106834, 0.5, 0);
            White1.Fade(OsbEasing.In, 106629, 106834, 0, 0.5);
            White1.ScaleVec(OsbEasing.Out, 107040, 107245, 0.5, 0.5, 0.01, 0.5);
            White1.Fade(OsbEasing.Out, 107245, 107245, 0, 0);
            Red1.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 107040, 107245, 0.01, 0.5, 0.5, 0.5);
            Red1.ScaleVec(OsbEasing.Out, 107656, 107862, 0.5, 0.5, 0.01, 0.5);
            Red1.Fade(OsbEasing.Out, 107862, 107862, 0, 0);

            //Top Right
            White2.Rotate(OsbEasing.None, 95122, 95122, 0, 0);
            White2.Move(OsbEasing.None, 95122, 95122, TopRight, TopRight);
            White2.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            White2.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            White2.Fade(OsbEasing.In, 95533, 95738, 0.5, 0);
            White2.Fade(OsbEasing.In, 95944, 95944, 0.5, 0.5);
            White2.ScaleVec(OsbEasing.Out, 95944, 96149, 0.01, 0.5, 0.5, 0.5);
            White2.ScaleVec(OsbEasing.Out, 100465, 100670, 0.5, 0.5, 0.01, 0.5);
            White2.Fade(OsbEasing.Out, 100670, 100670, 0, 0);
            White2.Fade(OsbEasing.Out, 100054, 100054, 0, 0);
            White2.Fade(OsbEasing.In, 100054, 100259, 0, 0.5);
            Red2.Rotate(OsbEasing.None, 100054, 100054, 0, 0);
            Red2.Move(OsbEasing.None, 100054, 100054, TopRight, TopRight);
            Red2.Fade(OsbEasing.In, 100054, 100259, 0.5, 0);
            Red2.ScaleVec(OsbEasing.Out, 100054, 100054, 0.5, 0.5, 0.5, 0.5);
            Red2.Fade(OsbEasing.Out, 100465, 100465, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 100465, 100670, 0.01, 0.5, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 102108, 102314, 0.5, 0.5, 0.01, 0.5);
            Red2.Fade(OsbEasing.Out, 102314, 102314, 0, 0);
            White2.Fade(OsbEasing.In, 102108, 102108, 0.5, 0.5);
            White2.ScaleVec(OsbEasing.Out, 102108, 102314, 0.01, 0.5, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red2.Fade(OsbEasing.In, 106629, 106834, 0.5, 0);
            White2.Fade(OsbEasing.In, 106629, 106834, 0, 0.5);
            White2.ScaleVec(OsbEasing.Out, 107040, 107245, 0.5, 0.5, 0.01, 0.5);
            White2.Fade(OsbEasing.Out, 107245, 107245, 0, 0);
            Red2.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 107040, 107245, 0.01, 0.5, 0.5, 0.5);
            Red2.ScaleVec(OsbEasing.Out, 107451, 107656, 0.5, 0.5, 0.01, 0.5);
            Red2.Fade(OsbEasing.Out, 107656, 107656, 0, 0);

            //Bot Left
            White3.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            White3.Fade(OsbEasing.In, 95533, 95738, 0.5, 0);
            White3.Fade(OsbEasing.In, 95944, 95944, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 95944, 96149, 0.01, 0.5, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 98821, 99026, 0.5, 0.5, 0.01, 0.5);
            White3.Fade(OsbEasing.Out, 99026, 99026, 0, 0);
            White3.Fade(OsbEasing.In, 98410, 98615, 0, 0.5);
            Red3.Fade(OsbEasing.In, 98410, 98615, 0.5, 0);
            Red3.Fade(OsbEasing.Out, 95944, 95944, 0, 0);
            Red3.ScaleVec(OsbEasing.Out, 96766, 96766, 0.5, 0.5, 0.5, 0.5);
            Red3.Fade(OsbEasing.Out, 98410, 98821, 0.5, 0);
            Red3.Fade(OsbEasing.Out, 98821, 98821, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 98821, 99026, 0.01, 0.5, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 100465, 100670, 0.5, 0.5, 0.01, 0.5);
            Red3.Fade(OsbEasing.Out, 100670, 100670, 0, 0);
            Red3.ScaleVec(OsbEasing.Out, 101697, 101697, 0.5, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.Out, 100465, 100465, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 100465, 100670, 0.01, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 101697, 101903, 0, 0.5);
            Red3.Fade(OsbEasing.In, 101697, 101903, 0.5, 0);
            White3.ScaleVec(OsbEasing.Out, 102108, 102314, 0.5, 0.5, 0.01, 0.5);
            White3.Fade(OsbEasing.Out, 102314, 102314, 0, 0);
            Red3.Fade(OsbEasing.Out, 102108, 102108, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 102108, 102314, 0.01, 0.5, 0.5, 0.5);
            White3.Fade(OsbEasing.In, 103752, 103752, 0.5, 0.5);
            White3.ScaleVec(OsbEasing.Out, 103752, 103958, 0.01, 0.5, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 103752, 103752, 0.5, 0.5, 0.01, 0.5);
            Red3.Fade(OsbEasing.Out, 103752, 103958, 0, 0);
            Red3.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red3.Fade(OsbEasing.In, 106629, 106834, 0.5, 0);
            White3.Fade(OsbEasing.In, 106629, 106834, 0, 0.5);
            White3.ScaleVec(OsbEasing.Out, 107040, 107245, 0.5, 0.5, 0.01, 0.5);
            White3.Fade(OsbEasing.Out, 107245, 107245, 0, 0);
            Red3.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 107040, 107245, 0.01, 0.5, 0.5, 0.5);
            Red3.ScaleVec(OsbEasing.Out, 108067, 108273, 0.5, 0.5, 0.01, 0.5);
            Red3.Fade(OsbEasing.Out, 108273, 108273, 0, 0);

            //Bot Right
            White4.ScaleVec(OsbEasing.Out, 95122, 95122, 0.5, 0.5, 0.5, 0.5);
            White4.Fade(OsbEasing.In, 95122, 95328, 0.5, 0);
            White4.Fade(OsbEasing.In, 96766, 96971, 0, 0.5);
            White4.Fade(OsbEasing.In, 97177, 97382, 0, 0.5);
            White4.Fade(OsbEasing.In, 95533, 95738, 0.5, 0);
            White4.Fade(OsbEasing.In, 95944, 95944, 0.5, 0.5);
            White4.ScaleVec(OsbEasing.Out, 95944, 96149, 0.01, 0.5, 0.5, 0.5);
            White4.ScaleVec(OsbEasing.Out, 97588, 97793, 0.5, 0.5, 0.01, 0.5);
            White4.Fade(OsbEasing.Out, 97793, 97793, 0, 0);
            Red4.ScaleVec(OsbEasing.Out, 96766, 96766, 0.5, 0.5, 0.5, 0.5);
            Red4.Fade(OsbEasing.In, 96766, 96971, 0.5, 0);
            Red4.Fade(OsbEasing.In, 97177, 97382, 0.5, 0);
            Red4.Fade(OsbEasing.Out, 97588, 97793, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 97588, 97793, 0.01, 0.5, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 98821, 99026, 0.5, 0.5, 0.01, 0.5);
            Red4.Fade(OsbEasing.Out, 99026, 99026, 0, 0);
            White4.Fade(OsbEasing.Out, 98821, 98821, 0.5, 0.5);
            White4.ScaleVec(OsbEasing.Out, 98821, 99026, 0.01, 0.5, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 104985, 104985, 0.5, 0.5, 0.5, 0.5);
            Red4.Fade(OsbEasing.In, 104985, 105191, 0.5, 0);
            White4.Fade(OsbEasing.In, 104985, 105191, 0, 0.5);
            White4.ScaleVec(OsbEasing.Out, 105396, 105601, 0.5, 0.5, 0.01, 0.5);
            White4.Fade(OsbEasing.Out, 105601, 105601, 0, 0);
            Red4.Fade(OsbEasing.Out, 105396, 105396, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 105396, 105601, 0.01, 0.5, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 106629, 106629, 0.5, 0.5, 0.5, 0.5);
            Red4.Fade(OsbEasing.In, 106629, 106834, 0.75, 0.5);
            Red4.Fade(OsbEasing.In, 107040, 107040, 0.5, 0.5);
            Red4.ScaleVec(OsbEasing.Out, 107862, 108067, 0.5, 0.5, 0.01, 0.5);
            Red4.Fade(OsbEasing.Out, 108067, 108067, 0, 0);
            */

            //Top Middle
            Red5.ScaleVec(OsbEasing.Out, 108273, 108273, 0.33, 0.33, 0.33, 0.33);
            Red5.Fade(OsbEasing.In, 108273, 108478, 0.5, 0);
            Red5.Fade(OsbEasing.In, 108684, 108889, 0.5, 0);
            White5.ScaleVec(OsbEasing.Out, 109917, 109917, 0.33, 0.33, 0.33, 0.33);
            White5.Fade(OsbEasing.In, 109917, 110122, 0.5, 0);
            White5.Fade(OsbEasing.In, 110328, 110533, 0.5, 0);
            White5.Fade(OsbEasing.In, 111560, 111766, 0.5, 0);
            White5.Fade(OsbEasing.In, 111971, 112177, 0.5, 0);

            //Middle
            White6.ScaleVec(OsbEasing.Out, 108273, 108273, 0.33, 0.33, 0.33, 0.33);
            White6.Fade(OsbEasing.In, 108273, 108478, 0.5, 0);
            White6.Fade(OsbEasing.In, 108684, 108889, 0.5, 0);
            White6.Fade(OsbEasing.In, 109917, 110122, 0.5, 0);
            White6.Fade(OsbEasing.In, 110328, 110533, 0.5, 0);
            Red6.ScaleVec(OsbEasing.Out, 111560, 111560, 0.33, 0.33, 0.33, 0.33);
            Red6.Fade(OsbEasing.In, 111560, 111766, 0.5, 0);
            Red6.Fade(OsbEasing.In, 111971, 112177, 0.5, 0);


            //Bot Middle
            White7.ScaleVec(OsbEasing.Out, 108273, 108273, 0.33, 0.33, 0.33, 0.33);
            White7.Fade(OsbEasing.In, 108273, 108478, 0.5, 0);
            White7.Fade(OsbEasing.In, 108684, 108889, 0.5, 0);
            Red7.ScaleVec(OsbEasing.Out, 109917, 109917, 0.33, 0.33, 0.33, 0.33);
            Red7.Fade(OsbEasing.In, 109917, 110122, 0.5, 0);
            Red7.Fade(OsbEasing.In, 110328, 110533, 0.5, 0);
            White7.Fade(OsbEasing.In, 111560, 111766, 0.5, 0);
            White7.Fade(OsbEasing.In, 111971, 112177, 0.5, 0);

            //2nd part - TopRight
            Red8.MoveX(OsbEasing.None, 114848, 114848, 353, 353);
            Red8.MoveY(OsbEasing.None, 114848, 114848, 130, 130);
            Red8.Rotate(OsbEasing.None, 114848, 114848, Math.PI / 12, Math.PI / 12);
            Red8.ScaleVec(OsbEasing.Out, 114848, 114848, 0.5, 0.5, 0.5, 0.5);
            Red8.Fade(OsbEasing.In, 114848, 115054, 0.5, 0);
            Red8.Fade(OsbEasing.In, 115259, 115465, 0.5, 0);
            White8.MoveX(OsbEasing.None, 116492, 116492, 353, 353);
            White8.MoveY(OsbEasing.None, 116492, 116492, 130, 130);
            White8.Rotate(OsbEasing.None, 116492, 116492, Math.PI / 12, Math.PI / 12);
            White8.ScaleVec(OsbEasing.Out, 116492, 116492, 0.5, 0.5, 0.5, 0.5);
            White8.Fade(OsbEasing.In, 116492, 116697, 0.5, 0);
            White8.Fade(OsbEasing.In, 116903, 117108, 0.5, 0);

            //BottomLeft
            White9.MoveX(OsbEasing.None, 114848, 114848, 289, 289);
            White9.MoveY(OsbEasing.None, 114848, 114848, 368, 368);
            White9.Rotate(OsbEasing.None, 114848, 114848, Math.PI / 12, Math.PI / 12);
            White9.ScaleVec(OsbEasing.Out, 114848, 114848, 0.5, 0.5, 0.5, 0.5);
            White9.Fade(OsbEasing.In, 114848, 115054, 0.5, 0);
            White9.Fade(OsbEasing.In, 115259, 115465, 0.5, 0);
            Red9.MoveX(OsbEasing.None, 116492, 116492, 289, 289);
            Red9.MoveY(OsbEasing.None, 116492, 116492, 368, 368);
            Red9.Rotate(OsbEasing.None, 116492, 116492, Math.PI / 12, Math.PI / 12);
            Red9.ScaleVec(OsbEasing.Out, 116492, 116492, 0.5, 0.5, 0.5, 0.5);
            Red9.Fade(OsbEasing.In, 116492, 116697, 0.5, 0);
            Red9.Fade(OsbEasing.In, 116903, 117108, 0.5, 0);
        }
    }
}
