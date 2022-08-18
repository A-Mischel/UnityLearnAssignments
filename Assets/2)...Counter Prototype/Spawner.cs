using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out hit, 100)) {
            Debug.Log ("hit");
            Instantiate(prefab, hit.point, Quaternion.identity);

        }
    }
}
