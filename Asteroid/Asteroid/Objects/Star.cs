using System;
using System.Drawing;

namespace Asteroid.Objects
{
    class Star : BaseObject
    {
        static Image image = Image.FromFile("images\\star.png");
        static Random point = new Random();

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(image, pos.X, pos.Y);
        }

        public override void Update()
        {

            pos.X += dir.X;
            pos.Y += dir.Y;

            if (pos.X < 0 || pos.X > Game.Width) pos.X = Game.Width * point.Next(0,20);
            if (pos.Y < 0 || pos.Y > Game.Height) pos.Y = Game.Height * point.Next(0, 20);
        }
    }
}
