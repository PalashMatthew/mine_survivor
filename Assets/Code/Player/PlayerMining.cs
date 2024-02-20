using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    public float miningSpeed;
    public float miningForce;

    public bool isMine = false;

    public List<GameObject> blocks = new List<GameObject>();


    private void Update()
    {
        if (blocks.Count == 0)
        {
            isMine = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "block")
        {
            blocks.Add(other.gameObject);

            if (!isMine)
            {
                isMine = true;
                StartCoroutine(Mining());
            }           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (blocks.Contains(other.gameObject))
        {
            blocks.Remove(other.gameObject);
        }        
    }

    IEnumerator Mining()
    {
        foreach(GameObject block in blocks)
        {
            block.GetComponent<BlockController>().hp -= miningForce;
            block.GetComponent<BlockController>().Hit();
        }

        yield return new WaitForSeconds(miningSpeed);

        if (blocks.Count > 0)
        {
            StartCoroutine(Mining());
        }
    }
}
