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
        // Place your variables here:


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Eyeball Animation with Vectors");
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            DrawEyeball(Window.Size / 2);
        }

        void DrawEyeball(Vector2 position)
        {
            // Cornea
            Draw.LineSize = 1; // 1px
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.White;
            Draw.Circle(position, 50);

            // Iris
            Draw.FillColor = Color.Gray;
            Draw.Circle(position, 35);

            // Pupil
            Draw.FillColor = Color.Black;
            Draw.Circle(position, 20);
        }
    }

}
