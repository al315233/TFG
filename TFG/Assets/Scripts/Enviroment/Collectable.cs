using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableEnum { FlashlightPart = 0}

public class Collectable : MonoBehaviour
{
    public CollectableEnum MyCollectable;
    public AudioClip CatchedSound;
    public int CollectableIndex;

    private bool catched = false;
    private AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !catched)
        {
            catched = true;
            switch (MyCollectable)
            {
                case CollectableEnum.FlashlightPart:
                    HUDLabyrinth.Instance.ShowAnimationFlashlightPart((FlashlightParts)CollectableIndex);
                    break;
            }
            StartCoroutine(catchCollectable());
        }
    }

    IEnumerator catchCollectable()
    {
        Vector3 ANIMATION_SCALING_SPEED = new Vector3(1, 1, 0) * 1f;
        bool disappear = true;

        myAudioSource.PlayOneShot(CatchedSound);

        while(disappear)
        {
            transform.localScale -= ANIMATION_SCALING_SPEED * Time.fixedDeltaTime;
            if (transform.localScale.x < 0)
            {
                transform.localScale = Vector3.zero;
                disappear = false;
            }

            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
