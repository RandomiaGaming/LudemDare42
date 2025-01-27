using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveForce;
    public float skidMoveForce;
    public float maxMoveSpeed;
    public float liniarAirResistance;
    [Header("Jump")]
    public float jumpForce;
    public float maximumJumpDuration;
    public float jumpDampningForce;
    public float gravityForce;
    public float maximumFallSpeed;
    [Space]
    public float invincibilityDuration = 10;
    [Space]
    public int titleScreenSceneBuildIndex = 0;

    private new Rigidbody2D rigidbody2D;
    private GroundChecker groundChecker;
    private SwordController swordController;

    private float jumpTimer = 0;
    private void Start()
    {
        swordController = GetComponent<SwordController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }
    private void Update()
    {
        //Movement and x axis movement.
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (swordController.GetSwordState() == SwordState.Idle)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (rigidbody2D.velocity.x < -0.01)
            {
                rigidbody2D.velocity += new Vector2(skidMoveForce * Time.deltaTime, 0);
            }
            else
            {
                rigidbody2D.velocity += new Vector2(moveForce * Time.deltaTime, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (swordController.GetSwordState() == SwordState.Idle)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (rigidbody2D.velocity.x > 0.01)
            {
                rigidbody2D.velocity += new Vector2(skidMoveForce * Time.deltaTime * -1, 0);
            }
            else
            {
                rigidbody2D.velocity += new Vector2(moveForce * Time.deltaTime * -1, 0);
            }
        }

        rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, maxMoveSpeed * -1, maxMoveSpeed), rigidbody2D.velocity.y);

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (rigidbody2D.velocity.x > 0)
            {
                rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x - (liniarAirResistance * Time.deltaTime), 0, maxMoveSpeed), rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x + (liniarAirResistance * Time.deltaTime), maxMoveSpeed * -1, 0), rigidbody2D.velocity.y);
            }
        }

        //Jumping and y axis movement.
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.grounded)
        {
            jumpTimer = maximumJumpDuration;
        }
        else if (Input.GetKey(KeyCode.Space) && jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }
        else
        {
            jumpTimer = 0;
        }

        if (jumpTimer > 0)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
        else if (rigidbody2D.velocity.y > 0.01)
        {
            rigidbody2D.velocity += new Vector2(0, jumpDampningForce * Time.deltaTime * -1);
        }
        else
        {
            rigidbody2D.velocity += new Vector2(0, gravityForce * Time.deltaTime * -1);
        }

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Clamp(rigidbody2D.velocity.y, maximumFallSpeed * -1, float.MaxValue));
    }
    public void OnKilled()
    {
        SceneManager.LoadScene(titleScreenSceneBuildIndex, LoadSceneMode.Single);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[collision.contactCount];
        collision.GetContacts(contactPoints);
        foreach (ContactPoint2D contactPoint2D in contactPoints)
        {
            if (contactPoint2D.normal.y <= 0 && contactPoint2D.normal.x >= -0.707106f && contactPoint2D.normal.x < 0.707106f)
            {
                jumpTimer = 0;
            }
        }
    }
}
