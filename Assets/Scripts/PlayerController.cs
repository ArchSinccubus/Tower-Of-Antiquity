using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public WalkerController playerWalk;
    public JumpingController playerJump;
    public DashController playerDash;

    public bool isTouchingFloor;
    public bool isFacingLeft;

    public Rigidbody2D rb;

    public SpriteRenderer PlayerGFX;

    public override void Init()
    {
        base.Init();
        playerJump.resetJumps();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * 2,Color.black, 100);

        }


    }

    private void FixedUpdate()
    {
        if (isTouchingFloor)
        {
            if (!CheckDownCollision())
            {
                isTouchingFloor = false;
                playerJump.reduceJumps();                
            }

        }
    }

    private bool CheckDownCollision()
    {
        List<Collider2D> res = new List<Collider2D>();

        rb.GetAttachedColliders(res);

        int layerMask = 1 << 2;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(res[0].bounds.size.x - 0.001f, res[0].bounds.size.y), 0, Vector2.down, 0.01f, ~layerMask);

        return hit;

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor" && CheckDownCollision())
        {
            isTouchingFloor = true;
            playerJump.resetJumps();
            playerDash.resetDashes();
        }
    }

    public void turnGFX()
    {
        PlayerGFX.flipX = isFacingLeft;
    
    }

    public override void GetHit()
    {

        base.GetHit();
    }

    #region controller management
    public void DisableAllControllers()
    {
        playerWalk.enabled = false;
        playerJump.enabled = false;
        playerDash.enabled = false;
    }

    public void EnableAllControllers()
    {
        playerWalk.enabled = true;
        playerJump.enabled = true;
        playerDash.enabled = true;
    }

    public void DisableController(BaseController controller)
    {
        controller.enabled = false;
    }

    public void EnableController(BaseController controller)
    {
        controller.enabled = true;
    } 
    #endregion

}
