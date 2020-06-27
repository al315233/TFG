using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2dController : MonoBehaviour
{
    const float CAMERA_MOVEMENT_SPEED = 1f;

    Vector3 playerPosition;
    Vector3 actualCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosition = Player2dController.Instance.transform.position;

        actualCameraPosition = Vector3.Lerp(transform.position, playerPosition, CAMERA_MOVEMENT_SPEED * Time.fixedDeltaTime);
        transform.position = new Vector3(actualCameraPosition.x, actualCameraPosition.y, transform.position.z);
    }
}
