
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    bool exhausted;
    public float stamina = 100f;

    public float maxStamina = 100f;
    public Camera playerCam;
    public bool isGrounded;
    public bool crouching;
    public Transform ground;
    public float distance = 0.3f;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public LayerMask mask;

    public float originalHeight = 1.6f;
    public float crouchHeight = 1.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        #region Movement (Hareket)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);

        #endregion

        #region Jump (Ziplama)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        #endregion

        #region Gravity (Yercekimi)


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion 

        #region Crouch (Egilme)

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = crouchHeight;
            speed = 2.5f;
            crouching = true;
            playerCam.transform.localPosition = new Vector3( //Kamera lokasyonu, eğilmeye göre düşürülüyor.
                playerCam.transform.localPosition.x, 
                0.5f,
                playerCam.transform.localPosition.z);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = originalHeight;
            speed = 5.0f;
            crouching = false;
            playerCam.transform.localPosition = new Vector3( //Kamera lokasyonu, kalkmaya göre yükseliyor.
                playerCam.transform.localPosition.x,
                0.8f,
                playerCam.transform.localPosition.z);
        }

        #endregion

        #region Sprint (Koşma)

        if (Input.GetKeyDown(KeyCode.LeftShift) && crouching == false && exhausted == false)
        {
            speed = 7.5f;
            StaminaLoss();
        }
        else if(stamina != maxStamina && crouching == false || Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
            StaminaGain();
        }
        if (stamina >= 25)
        {
            exhausted = false;
        }
           
        
        #endregion
    }

    #region Stamina
    void StaminaLoss()
    {
        if(stamina >= 0 && exhausted == false)
        {
            stamina -= Time.deltaTime * 25;
            if(stamina <= 0)
            {
                stamina = 0;
                speed = 5.0f;
                exhausted = true;
            }
        }
    }
    void StaminaGain()
    {
        if(stamina <= maxStamina)
        { 
            stamina += Time.deltaTime * 10;
            if(stamina >= maxStamina)
            {
                stamina = 100f;
            }
        }
    }
    #endregion

}
