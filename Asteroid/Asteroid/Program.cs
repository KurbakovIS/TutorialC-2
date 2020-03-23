using System;
using System.Windows.Forms;

namespace Asteroid
{
    class Program
    {

        static void Main()
        {
            Form form = new Form
            {
                Width = 800,
                Height = 600
            };
            Game.Init(form);
            Game.Load();
            form.Show();
            Game.Draw();

            Application.Run(form);
        }
    }
}

