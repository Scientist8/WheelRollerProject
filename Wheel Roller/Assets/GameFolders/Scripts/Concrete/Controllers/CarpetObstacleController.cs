﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetObstacleController : MonoBehaviour
{
    Vector3 _wheelSize;
    float _downSizeIndex=15f;

    
    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            WheelSizeAction(player);
        }
       
    }
    
    private void WheelSizeAction(PlayerController player)
    {
        _wheelSize = player._wheel.transform.localScale;
        _wheelSize.z -= _downSizeIndex;
        player._wheel.transform.localScale = _wheelSize;
        if(_wheelSize.z <= 25f)
        {
            player._wheel.gameObject.SetActive(false);
            player._moveSpeed = 0f;
            player._characterAnimation.FallingAnimation(true);
        }
    }
}
