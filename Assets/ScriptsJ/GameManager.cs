using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float timeBoss;
    public GameObject boss;
    public bool bossActivo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bossActivo = false;
        StartCoroutine(TiempoParaBoss());
    }

    void ActivarBoss()
    {
        boss.SetActive(true);
        bossActivo = true;
    }

    IEnumerator TiempoParaBoss()
    {
        yield return new WaitForSeconds(timeBoss);
        ActivarBoss();
    }

}
