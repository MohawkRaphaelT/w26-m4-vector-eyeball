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
        Eyeball[] eyeballs;
        int eyesClosedCount;
        bool isGameOver;

        public void Setup()
        {
            Window.SetTitle("Eyeball Animation with Vectors");
            Window.SetSize(400, 400);

            // Set up variables
            eyeballs = new Eyeball[]
            {
                new Eyeball(),
                new Eyeball(200, 200, 50),
                new Eyeball(100, 100, 35),
                new Eyeball(new Vector2(100, 300), 15),
            };
            eyesClosedCount = 0;
            isGameOver = false;
        }

        public void Update()
        {
            if (isGameOver)
            {
                EndScreen();
            }
            else
            {
                Gameplay();
            }
        }

        void Gameplay()
        {
            Window.ClearBackground(Color.OffWhite);
            for (int i = 0; i < eyeballs.Length; i++)
            {
                bool wasClicked = eyeballs[i].WasEyeClicked();
                if (wasClicked == true)
                {
                    eyesClosedCount += 1;
                    if (eyesClosedCount == eyeballs.Length)
                    {
                        isGameOver = true;
                    }
                }

                eyeballs[i].DrawEyeball();
            }
            Text.Draw($"{eyesClosedCount}/{eyeballs.Length}", 10, 10);
        }

        void EndScreen()
        {
            Window.ClearBackground(Color.Yellow);
            Text.Draw("YOU WIN!", 10, 10);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                Setup();
            }
        }

    }

}
