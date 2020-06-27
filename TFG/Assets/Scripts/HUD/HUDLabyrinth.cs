using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum FlashlightParts 
{ 
    Head = 0, Body = 1, Tail = 2
}
public class HUDLabyrinth : MonoBehaviour
{
    public static HUDLabyrinth Instance;

    public GameObject closedWalls;     //Collider
    public GameObject openWalls;      //colliders
    public GameObject arrow;
    public GameObject exitActivationCube;                
    public GameObject openWallsPicture;    //Imagen
    public GameObject closedWallsPicture;  //Imagen

    public Image[] HollowFlashlightMontable;

    private Vector3[] finalImagesPositions;
    private Vector3[] finalImagesScales;

    int contParts = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        finalImagesPositions = new Vector3[HollowFlashlightMontable.Length];
        finalImagesScales = new Vector3[HollowFlashlightMontable.Length];

        for (int i = 0; i < HollowFlashlightMontable.Length; i++)
        {
            finalImagesPositions[i] = HollowFlashlightMontable[i].transform.localPosition;
            finalImagesScales[i] = HollowFlashlightMontable[i].transform.localScale;
            HollowFlashlightMontable[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
    }

    public void ShowAnimationFlashlightPart(FlashlightParts actualFlashLightPart)
    {
        
        StartCoroutine(AnimationFlashlightPart(HollowFlashlightMontable[(int)actualFlashLightPart].transform, finalImagesPositions[(int)actualFlashLightPart], finalImagesScales[(int)actualFlashLightPart]));
    }

    IEnumerator AnimationFlashlightPart(Transform actualPart, Vector3 finalPosition, Vector3 finalScale) 
    {
        float ANIMATION_MOVEMENT_SPEED = 1f;
        float ANIMATION_SCALE_SPEED = 0.05f;
        actualPart.localPosition = Vector3.zero;
        actualPart.localScale = Vector3.zero;
        actualPart.gameObject.SetActive(true);

        float totalDistance = Vector3.Distance(actualPart.localPosition, finalPosition);
        float actualDistance = totalDistance;

        while (Vector3.Distance(actualPart.localPosition, finalPosition) > 3f || actualPart.localScale.x < finalScale.x)
        {
            actualPart.localPosition = Vector3.Lerp(actualPart.localPosition, finalPosition, ANIMATION_MOVEMENT_SPEED / actualDistance * totalDistance * Time.fixedDeltaTime);
            if(actualPart.localScale.x > finalScale.x)
            {
                actualPart.localScale = finalScale;
            }
            else if(actualPart.localScale.x < finalScale.x)
            {
                actualPart.localScale += Vector3.one * ANIMATION_SCALE_SPEED * Time.fixedDeltaTime;
            }

            yield return null;
        }

        actualPart.localPosition = finalPosition;

        contParts++;
        print(contParts);

        if (contParts >= 3)
        {
            //Activar y desactivar cosas
            //Abrimos salida
            closedWalls.gameObject.SetActive(false);
            closedWallsPicture.gameObject.SetActive(false);

            openWalls.gameObject.SetActive(true);
            openWallsPicture.gameObject.SetActive(true);
            arrow.gameObject.SetActive(true);
            exitActivationCube.gameObject.SetActive(true);

            
            //SceneManager.LoadScene("scene1");

            //OpenLabyrinth.Instance
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("scene1");
        }
    }

}
