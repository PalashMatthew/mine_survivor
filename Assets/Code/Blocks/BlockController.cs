using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BlockController : MonoBehaviour
{
    public float hp;

    public GameObject mesh;

    public bool isHP;
    public bool isResources;

    public int expCount;

    public GameObject expObj;
    public GameObject hpObj;
    public GameObject resObj;


    private void Update()
    {
        if (hp <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerMining>().blocks.Remove(gameObject);

            if (isHP)
            {
                for (int i = 0; i < expCount; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f), 1, Random.Range(transform.position.z - 3.5f, transform.position.z + 3.5f));

                    Instantiate(expObj, pos, transform.rotation);
                }

                Vector3 posHp = new Vector3(Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f), 1, Random.Range(transform.position.z - 3.5f, transform.position.z + 3.5f));

                Instantiate(hpObj, posHp, transform.rotation);
            }

            if (isResources)
            {
                for (int i = 0; i < expCount; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f), 1, Random.Range(transform.position.z - 3.5f, transform.position.z + 3.5f));

                    Instantiate(expObj, pos, transform.rotation);
                }

                Vector3 posHp = new Vector3(Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f), 1, Random.Range(transform.position.z - 3.5f, transform.position.z + 3.5f));

                Instantiate(resObj, posHp, transform.rotation);
            }

            Destroy(gameObject);
        }
    }

    public void Hit()
    {
        StartCoroutine(HitAnim());
    }

    IEnumerator HitAnim()
    {
        mesh.transform.DOScale(0.7f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        mesh.transform.DOScale(1f, 0.1f);
    }
}
