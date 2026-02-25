using UnityEngine;
using UnityEngine.AI;

public class BañoTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ghost; // Etiqueta del jugador
    [SerializeField] private NavMeshAgent ghostAgent; // Componente NavMeshAgent del jugador
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghostAgent = ghost.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            ghostAgent.speed = FindFirstObjectByType<Ghosti>().speed;

            // Aquí puedes agregar la lógica que deseas ejecutar cuando el jugador entre al baño
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
