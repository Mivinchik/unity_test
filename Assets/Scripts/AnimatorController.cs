using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour {

    public static AnimatorController instance;

    Transform MyTrans;
    Animator MyAnim;
    Vector3 artScaleCache;

	void Start () {
        MyTrans = this.transform;
        MyAnim = this.gameObject.GetComponent<Animator>();
        instance = this;
        artScaleCache = MyTrans.localScale;

    }
	
    void FlipArt(float currentSpeed)
    {
        if((currentSpeed <0 && artScaleCache.x == 1) //going Left
            || (currentSpeed > 0 && artScaleCache.x == -1)) //going right
        {
            artScaleCache.x *= -1;
            MyTrans.localScale = artScaleCache;
        }
    }
	public void UpdateSpeed (float currentSpeed) {
        MyAnim.SetFloat("Speed", currentSpeed);
        FlipArt(currentSpeed);
	}
    public void UpdateIsGrounded(bool isGrounded)
    {
        MyAnim.SetBool("isGrounded", isGrounded);
    }
}
