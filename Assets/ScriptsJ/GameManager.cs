using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeBoss;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TiempoParaBoss());
    }

    void ActivarBoss()
    {
        boss.SetActive(true);
    }

    IEnumerator TiempoParaBoss()
    {
        yield return new WaitForSeconds(timeBoss);
        ActivarBoss();
    }
}
