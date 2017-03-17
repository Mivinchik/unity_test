using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpHeight = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform MyTrans,tagGround;
    Rigidbody2D MyBody;
    float hInput = 0;
    bool isGrounded = false;
    AnimatorController MyAnim;

    void Start () {

        MyBody = this.GetComponent<Rigidbody2D>();
        MyTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;

        MyAnim = AnimatorController.instance;
      	}
		
	void FixedUpdate () {

        isGrounded = Physics2D.Linecast(MyTrans.position, tagGround.position,playerMask);
        MyAnim.UpdateIsGrounded(isGrounded);

    #if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT

       hInput=Input.GetAxisRaw("Horizontal");
        MyAnim.UpdateSpeed(hInput);
        if (Input.GetButtonDown("Jump"))
               Jump();

    #endif
        Move(hInput);
    }
    public void Move(float horizontalInput)
    {
        if (!canMoveInAir && !isGrounded)
            return;

        Vector2 moveVel = MyBody.velocity;
        moveVel.x = horizontalInput * speed;
        MyBody.velocity = moveVel;
    }
    public void Jump()
    {
        if (isGrounded){
            MyBody.velocity += jumpHeight * Vector2.up;
        }
    }
    public void startMoving(float horizontalInput)
    {
        hInput = horizontalInput;
        MyAnim.UpdateSpeed(horizontalInput);
    }

}
