using System;
using System.Numerics;

namespace MohawkGame2D;

public class Eyeball
{
    Vector2 position;
    float radius;
    bool isEyeClosed = false;

    public Eyeball()
    {
        // Put it anywher on screen
        position = Random.Vector2(Window.Size);
        // Give random size
        radius = Random.Integer(15, 50);
    }

    public Eyeball(float x, float y, float radius)
    {
        this.position = new Vector2(x,y);
        this.radius = radius;
    }

    public Eyeball(Vector2 position, float radius)
    {
        this.position = position;
        this.radius = radius;
    }

    public void Update()
    {
        WasEyeClicked();
        DrawEyeball();
    }

    public bool WasEyeClicked()
    {
        // Only run code if eye is open
        if (isEyeClosed == false)
        {
            // check if we are pressing mouse button
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                // is distance to mouse cursor less than or equal to radius
                float distance = Vector2.Distance(position, Input.GetMousePosition());
                if (distance <= radius)
                {
                    // We are clicking on the eye
                    isEyeClosed = true;
                    // Tell the caller of this function we did click the eye
                    return true;
                }
            }
        }

        // Code did not return true, so we have to return something, false in this case
        return false;
    }

    public void DrawEyeball()
    {
        if (isEyeClosed == false)
        {
            // Calulate ratios for each eye
            float corneaR = radius * 1.0f; // 1.0 = 100%
            float irisR = radius * 0.7f;   // 0.7 =  70%
            float pupilR = radius * 0.3f;  // 0.3 =  30%

            // Cornea
            Draw.LineSize = 1; // 1px
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.White;
            Draw.Circle(position, corneaR);

            // Set up our look vector
            // To go form point A to point B, we do B - A
            Vector2 mousePosition = Input.GetMousePosition();
            Vector2 vectorFromEyeToMouse = mousePosition - position;
            // Split vector into its 2 components: direction and magnitude
            Vector2 direction = Vector2.Normalize(vectorFromEyeToMouse);
            float distance = vectorFromEyeToMouse.Length();

            // Calculate where to position iris and pupil
            Vector2 irisPupilPosition;
            float maxMoveDistance = corneaR - irisR;
            bool isInsideEye = distance < maxMoveDistance;
            if (isInsideEye == true)
            {
                irisPupilPosition = mousePosition;
            }
            else // is outside eye
            {
                irisPupilPosition = position + direction * maxMoveDistance;
            }

            // Iris
            Draw.FillColor = Color.Gray;
            Draw.Circle(irisPupilPosition, irisR);

            // Pupil
            Draw.FillColor = Color.Black;
            Draw.Circle(irisPupilPosition, pupilR);
        }
        else // eye is closed
        {
            // Cornea
            Draw.LineSize = 1; // 1px
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.White;
            Draw.Circle(position, radius);

            // Draw line of closed eye
            Vector2 left = new Vector2(position.X - radius, position.Y);
            Vector2 right = new Vector2(position.X + radius, position.Y);
            Draw.Line(left, right);
        }
    }
}
