using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arena;

public class CameraManagement : MonoBehaviour {
    [SerializeField]
    public Camera currentCamera;
    private ArenaManagement arena;
    private Vector3 player1X, player2X;
    float Xpos,Ypos,Zpos;
    Vector3 targetPos;

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
        Mathf.Clamp(Xpos, -30, 30);
        player1X = new Vector3(arena.Players[0].playerInformation.transform.position.x,0,-10);
        player2X = new Vector3(arena.Players[1].playerInformation.transform.position.x,0,-10);
        targetPos = Vector3.Lerp(player1X, player2X, 0.5f);
        Xpos = targetPos.x;
        Ypos = targetPos.y;
        Zpos = targetPos.z;
        


        AdjustCameraSize(Vector2.Distance(player1X, player2X));

        currentCamera.transform.localPosition = AdjustCameraPosition(new Vector3(Xpos,Ypos,Zpos),-30,30);
    }

    void AdjustCameraSize(float DistFromPlayers)
    {
        if(DistFromPlayers < 15)
        {
            currentCamera.fieldOfView = Mathf.SmoothStep(currentCamera.fieldOfView, 50, 0.1f);
        }
        else
        {
            currentCamera.fieldOfView = Mathf.SmoothStep(currentCamera.fieldOfView,50 + DistFromPlayers,0.1f);
        }
    }

    Vector3 AdjustCameraPosition(Vector3 tPos,float MinX, float MaxX)
    {
        if(tPos.x < MinX)
        {
            return new Vector3(-30, tPos.y, tPos.z);
        }
        else if(tPos.x > MaxX)
        {
            return new Vector3(30, tPos.y, tPos.z);

        }
        else
        {
            return tPos;
        }
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
