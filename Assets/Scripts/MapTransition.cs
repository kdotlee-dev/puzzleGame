using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner confiner;
    [SerializeField] Direction direction;
    [SerializeField] float additivePosition = 2f;
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPosition = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
                newPosition.y += additivePosition;
                break;
            case Direction.Down:
                newPosition.y -= additivePosition;
                break;
            case Direction.Left:
                newPosition.x += additivePosition;
                break;
            case Direction.Right:
                newPosition.x -= additivePosition;
                break;
        }
        player.transform.position = newPosition;
    }      
}
