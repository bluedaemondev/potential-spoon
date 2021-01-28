using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePusher : MonoBehaviour
{
    public List<Sprite> spritesGood;
    public List<Sprite> spritesBad;

    SpriteRenderer rend;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    public void PlayGoodPushNotif()
    {
        int randMsg = Random.Range(0, spritesGood.Count);
        rend.sprite = spritesGood[randMsg];

        this.anim.SetTrigger("push");
    }

    // llamado en animacion
    public void ResetStatus()
    {
        this.anim.ResetTrigger("push");

    }
}
