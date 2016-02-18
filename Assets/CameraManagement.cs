using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arena;

public class CameraManagement : MonoBehaviour {
    [SerializeField]
    public Camera currentCamera;
    private ArenaManagement arena;
    private Vector2 player1X, player2X;

    void Awake()
    {
        if(currentCamera == null)
        {
            currentCamera = Camera.main;
        }
        if (arena == null)
        {
            arena = GetComponent<ArenaManagement>();
        }
    }

    void Update()
    {
        player1X = arena.Players[0].playerInformation.transform.position;
        player2X = arena.Players[1].playerInformation.transform.position;

        Debug.Log(Vector2.Distance(player1X, player2X));
    }

    void MoveCamera(Direction targetDir)
    {
        Vector2 cameraPos = currentCamera.transform.localPosition;
        if (targetDir == Direction.LEFT)
        {
            if(cameraPos.x > -30)
            {
                currentCamera.transform.Translate(-15 * Time.deltaTime, 0, 0);
            }
        }
        else if(targetDir == Direction.RIGHT)
        {
            if (cameraPos.x < 30)
            {
                currentCamera.transform.Translate(15 * Time.deltaTime, 0, 0);
            }
        }
    }

    bool OnPosition()
    {
        return true;
    }
}

enum Direction
{
    LEFT,
    RIGHT
}
