using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction PlayerControls;
    [SerializeField] private InputAction PlayerShoot;
    private float moveDir;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float shootCooldown;
    private bool canShoot;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform cannon;
    [SerializeField] private AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("shooting", false);
        StartCoroutine(shootCooldownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = PlayerControls.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, moveDir * moveSpeed);

        if(canShoot == true && PlayerShoot.ReadValue<float>() >= 1)
        {
            canShoot = false;
            ///Here is where the shoot animation is called
            animator.SetBool("shooting", true);
            //Summons the bullet
            Instantiate(bulletPrefab, cannon.transform.position, Quaternion.identity);
            //Shoot Sound
            AudioSource.PlayClipAtPoint(shootSound, Vector3.zero, 3f);
            //Restarts the cooldown
            StartCoroutine(shootCooldownTimer());
        }
    }

    private void OnEnable()
    {
        PlayerControls.Enable();
        PlayerShoot.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
        PlayerShoot.Disable();
    }

    public IEnumerator shootCooldownTimer()
    {
        //animator.SetBool("shooting", false);
        canShoot = false;
        yield return new 
            WaitForSeconds(shootCooldown);
        canShoot = true;
        animator.SetBool("shooting", false);
    }

}
