using System;
using System.Drawing;

namespace Asteroid.Objects
{
    class Asteroids : BaseObject
    {
        static Image planet = Image.FromFile("images\\mars.png");
        static Image asteroid = Image.FromFile("images\\hotpng.png");
        static Image[] asteroids = { planet, asteroid };
        static Random point = new Random();
        static Image selectAsteroid = asteroids[1];

        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(selectAsteroid, pos.X, pos.Y);
        }

        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            
            if (pos.X < 0 || pos.X > Game.Width)
            {
                pos.X = Game.Width;
                selectAsteroid = asteroids[point.Next(0, 2)];
            }

        }
    }
}
