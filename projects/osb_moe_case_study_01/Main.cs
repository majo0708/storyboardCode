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
    public class Main : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    var layer = GetLayer("MainBackground");

            var bg = layer.CreateSprite("miku.jpg", OsbOrigin.Centre);
            var sideGlow = layer.CreateSprite("sb/sideglow.png", OsbOrigin.CentreLeft);
            var sideGlow2 = layer.CreateSprite("sb/sideglow.png", OsbOrigin.CentreRight);
            var mikuGlow = layer.CreateSprite("sb/miku_glow.png", OsbOrigin.Centre);
            var miku = layer.CreateSprite("sb/miku_cut.png", OsbOrigin.Centre);
            var flash = layer.CreateSprite("sb/white.png", OsbOrigin.Centre);

            var beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;
            var screenScale = 480.0 / 1080;

            bg.Scale(0, screenScale);
            bg.Fade(0, 9000, 0, 0.7);
            bg.Fade(OsbEasing.OutCubic, 9000, 9600, bg.OpacityAt(9000), 0.1);
            bg.Fade(9600, 9900, bg.OpacityAt(9600), 1);
            bg.Fade(249627, 0);

            flash.Fade(9600, 9600 + beatDuration * 4, 0.8, 0);

            // Calculating Miku's position based on the original image's dimensions.
            var initialMikuLocation = new Vector2(847.5f, 551);

            var xRatio = initialMikuLocation.X / 1920;
            var yRatio = initialMikuLocation.Y / 1080;

            var mikuX = (854 * xRatio) + -107;
            var mikuY = 480 * yRatio;

            miku.Move(9000, mikuX, mikuY);
            miku.Scale(9000, screenScale);
            miku.Fade(9000, 9600, bg.OpacityAt(9000), 1);
            miku.Fade(249627, 0);

            var sideGlowWidthScale = 0.6;
            var sideGlowHeightScale = 480.0 / 640;
            var sideGlowStartTime = 9900;
            var sideGlow2StartTime = sideGlowStartTime + beatDuration * 2;

            sideGlow.ScaleVec(sideGlowStartTime, sideGlowWidthScale, sideGlowHeightScale);
            sideGlow2.ScaleVec(sideGlow2StartTime, sideGlowWidthScale, sideGlowHeightScale);
            sideGlow.Move(sideGlowStartTime, -107, 240);
            sideGlow2.Move(sideGlow2StartTime, 747, 240);
            sideGlow.Color(sideGlowStartTime, Color4.SeaGreen);
            sideGlow2.Color(sideGlow2StartTime, Color4.SeaGreen);
            sideGlow2.FlipH(sideGlow2StartTime, sideGlow2StartTime);

            sideGlow.StartLoopGroup(sideGlowStartTime, 8);
                sideGlow.Fade(0, beatDuration * 2, 0.7, 0);
                sideGlow.Fade(beatDuration * 4, 0);
            sideGlow.EndGroup();

            sideGlow2.StartLoopGroup(sideGlow2StartTime, 7);
                sideGlow2.Fade(0, beatDuration * 2, 0.7, 0);
                sideGlow2.Fade(beatDuration * 4, 0);
            sideGlow2.EndGroup();

            mikuGlow.Move(sideGlow2StartTime, mikuX, mikuY);
            mikuGlow.Color(sideGlowStartTime, Color4.LightSeaGreen);

            mikuGlow.StartLoopGroup(sideGlowStartTime, 15);
                mikuGlow.Scale(OsbEasing.Out, 0 ,beatDuration * 2, screenScale, screenScale * 1.04);
                mikuGlow.Fade(OsbEasing.Out, 0, beatDuration * 2, 0.7, 0);
            mikuGlow.EndGroup();

            bg.Fade(OsbEasing.OutCirc, 18900, 19200, 1, 0.1);
            bg.Fade(19200, 1);
            bg.Color(19200, 19500, bg.ColorAt(19200), Color4.Crimson);
            flash.Fade(OsbEasing.Out, 19200, 19500, 1, 0);

            sideGlow.Color(19200, Color4.Crimson);
            sideGlow.StartLoopGroup(19200, 32);
                sideGlow.Fade(OsbEasing.OutBack, 0, beatDuration, 1, 0);
                sideGlow.Fade(beatDuration * 2, 0);
            sideGlow.EndGroup();

            sideGlow2.Color(19200, Color4.Crimson);
            sideGlow2.StartLoopGroup(19200, 32);
                sideGlow2.Fade(OsbEasing.OutBack, 0, beatDuration, 1, 0);
                sideGlow2.Fade(beatDuration * 2, 0);
            sideGlow2.EndGroup();

            mikuGlow.Color(19200, Color4.Red);
            mikuGlow.StartLoopGroup(19200, 32);
                mikuGlow.Scale(OsbEasing.OutCirc, 0, beatDuration * 2, screenScale, screenScale * 1.1);
                mikuGlow.Fade(OsbEasing.OutCirc, 0, beatDuration * 2, 1, 0);
            mikuGlow.EndGroup();

            bg.Color(OsbEasing.In, 38400, 39600, bg.ColorAt(38400), Color4.Navy);
            bg.Fade(OsbEasing.Out, 39600, 4800, 1, 0.3);

            
        }
    }
}
