using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BlockController : MonoBehaviour
{
    public float hp;

    public GameObject mesh;

    private void Update()
    {
        if (hp <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerMining>().blocks.Remove(gameObject);
            //GameObject.Find("A*").GetComponent<AstarPath>().Scan();
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
