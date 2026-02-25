using UnityEngine;
using UnityEngine.AI;

public class Ghosti : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private NavMeshAgent agent;
    public float speed;
    public bool isInBaño = false;

    [Header("Vision")]
    [SerializeField] private float rangoVision = 10f;
    [SerializeField] private float checkInterval = 0.2f;

    private int currentWaypoint = 0;
    private float checkTimer;

    void Start()
    {
        
    }

    void Update()
    {
        isInBaño = FindFirstObjectByType<JohnLemmon>().isInBaño;
        checkTimer += Time.deltaTime;

        
        if (isInBaño && this.name == "GhostBaño")
        {
            
            Patrullar();
        }
        else if(!isInBaño && this.name == "GhostNormal")
        {
            
            Patrullar();
        }
        // Solo comprobamos visión cada X segundos
        if (checkTimer >= checkInterval)
        {
            checkTimer = 0f;

            if (PuedeVerAlPlayer())
            {
                agent.SetDestination(player.position);
                return;
            }
        }

    }
    

    void Patrullar()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    bool PuedeVerAlPlayer()
    {
        Vector3 direccion = player.position - transform.position;

        if (direccion.sqrMagnitude > rangoVision)
            return false;

        if (Physics.Raycast(transform.position + Vector3.up,
                            direccion.normalized,
                            out RaycastHit hit,
                            rangoVision))
        {
            return hit.transform == player;
        }

        return false;
    }

    
}