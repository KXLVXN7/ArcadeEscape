using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private Animator anim;
    [SerializeField] private float crouchHeight = 0.5f;

    private bool isGrounded = false;

    private void Awake()
    {
        // Subscribe event Swipe ke method TestSwipe
        StaticSwipeDetector.OnSwipe += TestSwipe;
    }

    private void OnDestroy()
    {
        // Unsubscribe event Swipe dari method TestSwipe saat objek dihancurkan
        StaticSwipeDetector.OnSwipe -= TestSwipe;
    }

    // Method untuk menangani input melompat
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // Set animasi kembali ke false jika karakter menyentuh tanah dan sebelumnya sedang melompat
        if (isGrounded && anim.GetBool("Jump"))
        {
            anim.SetBool("Jump", false);
        }
    }

    // Method untuk melompat
    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("Jump", true);
        }
    }

    // Method untuk merunduk
    public void Crouch()
    {
        if (isGrounded)
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
        }
    }

    // Method untuk berhenti merunduk
    public void EndCrouch()
    {
        GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
    }

    // Method untuk menangani swipe
    private void TestSwipe(SwipeData data)
    {
        Debug.Log(data.Direction);
        if (data.Direction == SwipeDirection.Up)
        {
            Jump();
            Debug.Log("Lompat");
        }
        else if (data.Direction == SwipeDirection.Down)
        {
            Crouch();
            Debug.Log("Merunduk");
        }
    }
}
