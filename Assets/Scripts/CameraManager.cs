using UnityEngine;
using Unity.Cinemachine;
public class CameraManager : MonoBehaviour
{
    [Header("Parámetros de la cámara")]
    public GameObject camaraActivaGame;
    public CinemachineCamera camaraActiva;
    public CinemachineCamera[] camaras;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        foreach (var cam in camaras)
        {
            cam.Priority.Value = 0;
        }
        camaraActiva.Priority.Value = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
