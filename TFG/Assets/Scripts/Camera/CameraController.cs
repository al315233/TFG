using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static CameraController Instance;
    public Transform cameraPositionPlayer;
    private readonly Vector3 ORIGINAL_EULER_ANGLE = new Vector3(55.147f, 0 , 0);

    #region Constant values
    private const float CAMERA_MOVEMENT_SPEED = 5f;
    private const float CAMERA_ROTATION_SPEED = 5f;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPositionPlayer.position, CAMERA_MOVEMENT_SPEED * Time.fixedDeltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, cameraPositionPlayer.eulerAngles, CAMERA_ROTATION_SPEED * Time.fixedDeltaTime);


    }



}
