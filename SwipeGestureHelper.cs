/// <summary>
/// The Swipe Gesture Helper.
/// </summary>
public static class SwipeGestureHelper
{
    /// <summary>
    /// Gesture Directions
    /// </summary>
    public enum GestureDirection
    {
        Unknown,
        Right,
        Left,
        Up,
        Down
    }

    /// <summary>
    /// Find out direction
    /// </summary>
    public static GestureDirection DetectSwipeGestureByPosition(TouchPoint startTouchPosition, TouchPoint endTouchPosition, int minimumOffset)
    {
        var actualXOffset = Math.Abs(endTouchPosition.Position.X - startTouchPosition.Position.X);
        var actualYOffset = Math.Abs(endTouchPosition.Position.Y - startTouchPosition.Position.Y);
        if (actualXOffset > actualYOffset)
        {
            if (!(actualXOffset > minimumOffset)) { return GestureDirection.Unknown; }
            if (startTouchPosition.Position.X < endTouchPosition.Position.X)
            {
                // Debug.WriteLine("swipped right");
                return GestureDirection.Right;
            }
            else if (startTouchPosition.Position.X > endTouchPosition.Position.X)
            {
                // Debug.WriteLine("swipped left ");
                return GestureDirection.Left;
            }
        }

        if (actualXOffset < actualYOffset)
        {
            if (!(actualYOffset > minimumOffset)) { return GestureDirection.Unknown; }
            if (startTouchPosition.Position.Y < endTouchPosition.Position.Y)
            {
                // Debug.WriteLine("swipped down");
                return GestureDirection.Down;
            }
            else if (startTouchPosition.Position.Y > endTouchPosition.Position.Y)
            {
                // Debug.WriteLine("swipped up");
                return GestureDirection.Up;                   
            }
        }

        return GestureDirection.Unknown;
    }
}
