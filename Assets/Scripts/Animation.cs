using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;
    private bool fadeOut = false;
    private float x = 0;
    private SceneChange sC;
    [SerializeField] private SpriteRenderer fadeBlock;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        sC = this.GetComponent<SceneChange>();

    }

    public void runAnimation()
    {
        anim.SetBool("IsStarting", true);
    }

    public void stopAnimation()
    {
        anim.SetBool("IsStarting", false);
    }

    public void fadeIn()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if(fadeOut == true && x < 1)
        {
            fadeBlock.color = new Color(0.3910199f,0.7376195f,0.8207547f,x);
            x = x + .001f;
        }
        else if(x > .99f)
        {
            sC.changeScene();
        }
    }
}
