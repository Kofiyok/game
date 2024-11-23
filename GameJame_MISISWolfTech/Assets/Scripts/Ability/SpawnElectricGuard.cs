using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElectricGuard : MonoBehaviour
{
    [SerializeField] private GameObject electricGuradPrefab;

    private void Start()
    {
        Instantiate(electricGuradPrefab, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
    }
}
