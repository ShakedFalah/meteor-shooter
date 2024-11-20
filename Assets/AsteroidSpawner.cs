using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float maxSize = 10f;
    [SerializeField] private float minSize = 5f;

    private float minY;
    private float maxY;
    private float minX;
    private float maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var mainCamera = Camera.main;
        var cameraPosition = mainCamera.transform.position;

        minY = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -cameraPosition.z)).y;
        minX = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -cameraPosition.z)).x;
        maxY = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, -cameraPosition.z)).y;
        maxX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, -cameraPosition.z)).x;

        StartCoroutine(spawnAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            InstantiateRandomAsteroid();
        }
    }

    private void InstantiateRandomAsteroid()
    {
        float spawnX = 0;
        float spawnY = 0;

        float scale = UnityEngine.Random.Range(minSize, maxSize);
        float randomValue = UnityEngine.Random.value;

        // Spawn left
        if (randomValue > 0.75f)
        {
            spawnX = UnityEngine.Random.Range(minX - maxSize - scale, minX - minSize - scale);
            spawnY = UnityEngine.Random.Range(minY, maxY);
        }
        // Spawn right
        else if (randomValue > 0.5f)
        {
            spawnX = UnityEngine.Random.Range(maxX + minSize + scale, maxX + maxSize + scale);
            spawnY = UnityEngine.Random.Range(minY, maxY);
        }
        // Spawn top
        else if (randomValue > 0.25f)
        {
            spawnX = UnityEngine.Random.Range(minX, maxX);
            spawnY = UnityEngine.Random.Range(minY - maxSize - scale, minY - minSize - scale);
        } else
        // Spawn bottom
        {
            spawnX = UnityEngine.Random.Range(minX, maxX);
            spawnY = UnityEngine.Random.Range(maxY + minSize + scale, maxY + maxSize + scale);
        }

        var asteroidObject = Instantiate(asteroid, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0,0,0));
        asteroidObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}
