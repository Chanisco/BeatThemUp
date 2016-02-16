using UnityEngine;
using System.Collections;

public class CameraManagement : MonoBehaviour {
    [SerializeField]
    public Camera currentCamera

    void Awake()
    {
        if(currentCamera == null)
        {
            currentCamera = Camera.main;
        }
    }

}
