using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour
{
    public float TargetDistance;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(0, 4, 0), Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(4, 4, 0), Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(-4, 4, 0), Color.red);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, TargetDistance)||Physics.Raycast(transform.position, transform.TransformDirection(1,1,0), out hit, TargetDistance)|| Physics.Raycast(transform.position, transform.TransformDirection(-1, 1, 0), out hit, TargetDistance))
        {
            Destroy(Enemy);
            Debug.Log("Stomped.");
        }
        
    }
}
