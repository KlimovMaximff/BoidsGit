using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static public Spawner S;
    static public List<Boid> boids;

    [Header("Set in Inspector: Spawning")]
    public GameObject boidPrefab;
    public Transform boidAnchor;
    public int numBoids = 100;
    public float spawnRadius = 100f;
    public float spawnDelay = 0.1f;

    [Header("Set in Inspector: Boids")]
    public float velocity = 30f;
    public float neighborDist = 30f;
    public float collDist = 4f;
    public float velMatching = 0.25f;
    public float flockCentering = 0.2f;
    public float collAvoid = 2f;
    public float attractPull = 2f;
    public float attractPush = 2f;
    public float attractPushDist = 5f;

    void Awake()
    {
        S = this;

        boids = new List<Boid>();
        InstantiateBoid();
    }

    public void InstantiateBoid()
    {
        GameObject go = Instantiate(boidPrefab);
        Boid b = go.GetComponent<Boid>();
        b.transform.SetParent(boidAnchor);
        boids.Add(b);
        
        if(boids.Count < numBoids)
        {
            Invoke("InstantiateBoid", spawnDelay);
        }
    }
}
