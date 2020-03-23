using System.Drawing;


namespace Asteroid.Objects
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }

        public virtual void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;

            if (pos.X < 0 || pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0 || pos.Y > Game.Height) dir.Y = -dir.Y;
        }
    }

}
