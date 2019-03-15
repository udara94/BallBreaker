using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject rocket;

    [SerializeField]
    private AudioClip shootSound;

    private float speed=0f;
    private float maxVelocity=4f;
    private Rigidbody2D myBody;
    private Animator anim;

    private bool canShoot;
    private bool canWalk;
    // Start is called before the first frame update
    void Awake()
    {
       InitializeVariable(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        PlayerWalk();
    }

    void InitializeVariable(){
        myBody=GetComponent<Rigidbody2D>();
        anim=GetComponent <Animator>();
        canShoot=true;
        canWalk=true;
    }

    void PlayerWalk(){
        var force=0f;
        var velocity = Mathf.Abs(myBody.velocity.x);

        float h=Input.GetAxis("Horizontal");

        if(h>0){
            if(velocity<maxVelocity)
                force=speed;
            

            Vector3 scale= transform.localScale;
            scale.x=1;
            transform.localScale=scale;
            anim.SetBool("Walk",true);
               
        }
        else if(h<0){
            if (velocity<maxVelocity)
                force= -speed;
            
            Vector3 scale=transform.localScale;
            scale.x= -1;
            transform.localScale=scale;
            anim.SetBool("Walk",true);
        }
        else if (h==0){
            anim.SetBool("Walk",false);
        }

        myBody.AddForce(new Vector2(force,0));
    }
}
