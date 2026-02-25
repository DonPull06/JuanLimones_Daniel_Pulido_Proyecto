using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JohnLemmon : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 5f;
    [SerializeField] private EventManager eventManager;

    public Transform camTransform;
    public CameraManager camManager;
    public bool isInBaño = false;  

    private Vector2 movementInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnMove(InputAction.CallbackContext context)
    { 
        movementInput = context.ReadValue<Vector2>();
        
    }
    void Start()
    {
        camTransform = camManager.camaraActiva.transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WinZone":
                eventManager.win.SetActive(true);
                StartCoroutine(ResetLevel());
                break;
            case "Enemy":
                
                eventManager.lose.SetActive(true);
                StartCoroutine(ResetLevel());
                break;
            case "BañoTrigger":
                
                isInBaño = true;
                break;
            default:
                break;
        }
        
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = Vector3.zero;
        
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * movementInput.y +  right * movementInput.x;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(targetRotation);
        }
        anim.SetFloat("VelX", movementInput.x);
        anim.SetFloat("VelY", movementInput.y);

    }

    private IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(2f); // Espera 2 segundos antes de reiniciar el nivel
        SceneManager.LoadScene("Level"); // Reemplaza "Level" con el nombre de tu escena
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
