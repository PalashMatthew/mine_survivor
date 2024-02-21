using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    bool isPlayerHere = false;

    public float fillingSpeed;

    public GameObject mesh;

    public List<GameObject> blockInZone;

    SphereCollider col;

    public bool isZoneClear;

    public GameObject Turret; 


    private void Start()
    {
        col = GetComponent<SphereCollider>();

        StartCoroutine(CheckCol());
    }

    private void Update()
    {
        if (isPlayerHere && isZoneClear)
        {
            mesh.transform.localScale = new Vector3(mesh.transform.localScale.x + (Time.deltaTime * fillingSpeed),
                                                    mesh.transform.localScale.y,
                                                    mesh.transform.localScale.z + (Time.deltaTime * fillingSpeed));

            if (mesh.transform.localScale.x > 15.67f)
            {
                Instantiate(Turret, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            if (mesh.transform.localScale.x > 0)
            {
                mesh.transform.localScale = new Vector3(mesh.transform.localScale.x - (Time.deltaTime * fillingSpeed),
                                                    mesh.transform.localScale.y,
                                                    mesh.transform.localScale.z - (Time.deltaTime * fillingSpeed));
            }
        }
    }

    IEnumerator CheckCol()
    {
        col.enabled = true;
        yield return new WaitForSeconds(0.8f);
        col.enabled = false;

        yield return new WaitForSeconds(0.1f);

        col.enabled = true;

        yield return new WaitForSeconds(0.1f);

        if (blockInZone.Count == 0)
        {
            isZoneClear = true;
        }
        else
        {
            blockInZone.Clear();
            StartCoroutine(CheckCol());
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            isPlayerHere = true;
        }

        if (other.tag == "block")
        {
            blockInZone.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "player")
        {
            isPlayerHere = false;
        }

        if (other.tag == "block")
        {
            blockInZone.Remove(other.gameObject);
        }
    }
}
