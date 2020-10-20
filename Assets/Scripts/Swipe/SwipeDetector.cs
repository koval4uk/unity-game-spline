using System;
using UnityEngine;
using UnityEngine.UIElements;
using Singleton;

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}
public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;
}
public class SwipeDetector : Singleton<SwipeDetector>
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField] private float minDistanceForSwipe = 20f;

    public Action<SwipeData> OnSwipe = delegate { };

    private void Update()
    {
#if UNITY_EDITOR
        WindowsInput();
#else
        MobileInput();
#endif
    }

    private void WindowsInput()
    {
        if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
        {
            fingerUpPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse))
        {
            fingerDownPosition = Input.mousePosition;
            DetectSwipe();
        }
    }

    private void MobileInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0
                    ? SwipeDirection.Right
                    : SwipeDirection.Left;
                SendSwipe(direction);
            }

            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        OnSwipe(swipeData);
    }
}

