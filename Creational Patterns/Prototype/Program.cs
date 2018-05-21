using System;
using System.Collections.Generic;

namespace Prototype
{
    static class Program
    {
        private static void Main()
        {
            ColorController colorController = new ColorController();
            colorController["yellow"] = new Color(255, 255, 0);
            colorController["orange"] = new Color(255, 128, 0);
            colorController["purple"] = new Color(128, 0, 255);

            colorController["custom1"] = new Color(255, 0, 0);
            colorController["custom2"] = new Color(0, 0, 255);
            colorController["custom3"] = new Color(0, 255, 0);

            Color c1 = colorController["custom1"].Clone() as Color;
            Color c2 = colorController["custom2"].Clone() as Color;
            Color c3 = colorController["custom3"].Clone() as Color;

            Console.Read();
        }
    }

    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    public class Color : ColorPrototype
    {
        private readonly int mYellow;
        private readonly int mOrange;
        private readonly int mPurple;

        public Color(int yellow, int orange, int purple)
        {
            mYellow = yellow;
            mOrange = orange;
            mPurple = purple;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine($"Color is cloned to {mYellow},{mOrange},{mPurple}");
            return MemberwiseClone() as ColorPrototype;
        }
    }

    public class ColorController
    {
        private readonly Dictionary<string,ColorPrototype> mColors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get
            {
                return mColors[key];
            }
            set
            {
                mColors.Add(key, value);
            }
        }
    }
}
