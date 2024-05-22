using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawners : MonoBehaviour
{
    [SerializeField] private GameObject lizardPrefab;
    [SerializeField] private GameObject gnomePrefab;
    [SerializeField] private float lizardSpeed = 5.0f;
    [SerializeField] private float gnomeSpeed = 5.0f;
    [SerializeField] private float lizardspawnDelay = 1.0f;
    [SerializeField] private float gnomespawnDelay = 1.0f;
    [SerializeField] private float lizardspawnInterval = 0.25f;
    [SerializeField] private float gnomespawnInterval = 0.25f;
    private SpawnPoint[] spawnPoints;
    [SerializeField] private Transform LizardPointSpawner;
    [SerializeField] private Transform GnomePointSpawner;
    [SerializeField] private int maxNumLizards = 1;
    [SerializeField] private int maxNumGnomes = 1;
    [SerializeField] private float lizardWaveInterval = 2.0f;
    [SerializeField] private float gnomeWaveInterval = 5.0f;
    private int lizardCount = 0;
    private int gnomeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(SpawnLizardWaves());
        StartCoroutine(SpawnGnomeWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if(lizardCount == maxNumLizards)
        {
            CancelInvoke("SpawnLizard");
            lizardCount = 0;
        }
        if(gnomeCount == maxNumGnomes)
        {
            CancelInvoke("SpawnGnome");
            gnomeCount = 0;
        }
    }

    void SpawnLizard()
    {
        var lizard = Instantiate(lizardPrefab);
        int i = Random.Range(0, spawnPoints.Length);
        lizard.transform.position = spawnPoints[i].transform.position;
        Rigidbody2D rb = lizard.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * lizardSpeed;
        lizardCount++;
    }

    void SpawnGnome()
    {
        var gnome = Instantiate(gnomePrefab);
        int i = Random.Range(0, spawnPoints.Length);
        gnome.transform.position = spawnPoints[i].transform.position;
        Rigidbody2D rb = gnome.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * gnomeSpeed;
        gnomeCount++;
    }

    IEnumerator SpawnLizardWaves()
    {
        while(true)
        {
            InvokeRepeating("SpawnLizard", lizardspawnDelay, lizardspawnInterval);
            yield return new WaitForSeconds(lizardWaveInterval);
        }
    }

    IEnumerator SpawnGnomeWaves()
    {
        while(true)
        {
            InvokeRepeating("SpawnGnome", gnomespawnDelay, gnomespawnInterval);
            yield return new WaitForSeconds(gnomeWaveInterval);
        }
    }
}
