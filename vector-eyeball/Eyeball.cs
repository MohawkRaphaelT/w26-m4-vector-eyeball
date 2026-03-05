using System;
using System.Numerics;

namespace MohawkGame2D;

public class Eyeball
{
    Vector2 position;
    float radius;

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

    public void DrawEyeball()
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
}
