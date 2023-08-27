using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer sprtR;
    private float x = 1;
    void Start()
    {
        sprtR = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(x>-.1f)
        {
            sprtR.color = new Color(0.3910199f,0.7376195f,0.8207547f,x);
            x = x - .01f;
        }
    }
}
