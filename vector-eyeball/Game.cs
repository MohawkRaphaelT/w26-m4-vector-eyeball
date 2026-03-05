// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        Eyeball[] eyeballs = new Eyeball[]
        {
            new Eyeball(),
            new Eyeball(200, 200, 50),
            new Eyeball(100, 100, 35),
            new Eyeball(new Vector2(100, 300), 15),
        };

        public void Setup()
        {
            Window.SetTitle("Eyeball Animation with Vectors");
            Window.SetSize(400, 400);
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            for (int i = 0; i < eyeballs.Length; i++)
            {
                eyeballs[i].DrawEyeball();
            }
        }
    }

}
