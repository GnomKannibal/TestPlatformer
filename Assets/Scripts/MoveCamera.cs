using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;                                     // объект, к которой будет стремиться камера (в данном случае игрок)
    private float smoothTime = 0.3F;                                                // время, за которое будет настигаться цель
    private Vector2 velocity = Vector2.zero;


    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, _player.position, ref velocity, smoothTime);
    }
}
