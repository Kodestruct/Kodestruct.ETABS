using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Entities.Wall
{
    public class PierStoryData
    {
        public string Name { get; set; }
        public int NumberStories { get; set; }
        public string StoryName { get; set; }
        public double AxisAngle { get; set; }
        public int NumAreaObjs { get; set; }
        public int NumLineObjs { get; set; }
        public double WidthBot { get; set; }
        public double ThicknessBot { get; set; }
        public double WidthTop { get; set; }
        public double ThicknessTop { get; set; }
        public string MatProp { get; set; }
        public double CGBotX { get; set; }
        public double CGBotY { get; set; }
        public double CGBotZ { get; set; }
        public double CGTopX { get; set; }
        public double CGTopY { get; set; }
        public double CGTopZ { get; set; }

        public PierStoryData(string pierName, int NumberStories, string StoryName, double AxisAngle, int NumAreaObjs, int NumLineObjs,
                    double WidthBot, double ThicknessBot, double WidthTop, double ThicknessTop, string MatProp, double CGBotX, double CGBotY, double CGBotZ, double CGTopX, double CGTopY, double CGTopZ)
        {

            this.Name = pierName;
            this.NumberStories = NumberStories;
            this.StoryName = StoryName;
            this.AxisAngle = AxisAngle;
            this.NumAreaObjs = NumAreaObjs;
            this.NumLineObjs = NumLineObjs;
            this.WidthBot = WidthBot;
            this.ThicknessBot = ThicknessBot;
            this.WidthTop = WidthTop;
            this.ThicknessTop = ThicknessTop;
            this.MatProp = MatProp;
            this.CGBotX = CGBotX;
            this.CGBotY = CGBotY;
            this.CGBotZ = CGBotZ;
            this.CGTopX = CGTopX;
            this.CGTopY = CGTopY;
            this.CGTopZ = CGTopZ;

        }
    }
}
