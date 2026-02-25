using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    public CameraManager camManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        CinemachineCamera camera = GetComponentInParent<CinemachineCamera>();

        foreach (CinemachineCamera cam in camManager.camaras)
        {
            cam.Priority = 0;
            
        }
        if (other.CompareTag("Player"))
        {
            camera.Priority = 10;
            camManager.camaraActiva = camera;
        }


        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
