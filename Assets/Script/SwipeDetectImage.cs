using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetectImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private float minDistanceForSwipe = 2f;


    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        fingerDownPosition = eventData.position;
        fingerUpPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        fingerUpPosition = eventData.position;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (IsSwipeValid())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerUpPosition.y - fingerDownPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = fingerUpPosition.x - fingerDownPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
        }
    }

    private bool IsSwipeValid()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerUpPosition.y - fingerDownPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerUpPosition.x - fingerDownPosition.x);
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData Data = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        StaticSwipeDetector.OnSwipe?.Invoke(Data);
    }
}

public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}
