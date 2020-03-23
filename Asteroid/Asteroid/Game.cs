using Asteroid.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroid
{
    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;

        static public int Width { get; set; }
        static public int Height { get; set; }
        static Image background = Image.FromFile("images\\fon.jpg");
        static public BaseObject[] objs;
        static Random point = new Random();

        static Game()
        {
        }

        static public void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;

            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }

        static public void Load()
        {
            objs = new BaseObject[61];


            for (int i = 0; i < 2; i++)
                objs[i] = new Asteroids(new Point(60 * point.Next(5, 10), i * 20), new Point(-3, 0), new Size(2, 2));

            for (int i = 1; i < objs.Length /2; i++)
                objs[i] = new Star(new Point(point.Next(0, 200) * point.Next(0,7), i  * 20), new Point(-7, 0), new Size(5, 5));
               
            for (int i = 30; i < objs.Length; i++)
                objs[i] = new Star(new Point(point.Next(0, 200) * point.Next(0, 7), (i - 30) * 20), new Point(0, +7), new Size(5, 5));

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        static public void Draw()
        {
            buffer.Graphics.DrawImage(background, 0, 0);

            foreach (BaseObject obj in objs)
                obj.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }


    }
}
