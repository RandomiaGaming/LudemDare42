using UnityEngine;
using UnityEditor;
public enum SpawnerDirection { Horizontal, Vertical };
public class Spawner : MonoBehaviour
{
    public SpawnerDirection spawnerDirection = SpawnerDirection.Vertical;
    public float spawnRange = 10;
    public float spawnRate = 1;
    public Spawnable[] spawnables;

    private float timer = 0;
    private System.Random RNG = new System.Random();

    private void Update()
    {
        timer = Mathf.Clamp(timer, 0, float.MaxValue);
        timer += Time.deltaTime;
        if(timer >= spawnRate)
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        timer = 0;

        Vector3 start;
        Vector3 end;
        if (spawnerDirection == SpawnerDirection.Vertical)
        {
            start = new Vector3(transform.position.x, transform.position.y - (spawnRange / 2), 0);
            end = new Vector3(transform.position.x, transform.position.y + (spawnRange / 2), 0);
        }
        else
        {
            start = new Vector3(transform.position.x - (spawnRange / 2), transform.position.y, 0);
            end = new Vector3(transform.position.x + (spawnRange / 2), transform.position.y, 0);
        }

        Spawnable selectedSpawnable = spawnables[RNG.Next(0, spawnables.Length)];
        GameObject selectedSpawnTarget = selectedSpawnable.spawnTarget;
        float randomT = (float)RNG.NextDouble();
        Vector3 spawnPosition = new Vector3(Mathf.Lerp(start.x, end.x, randomT), Mathf.Lerp(start.y, end.y, randomT), 0);
        GameObject spawnedGameObject = Instantiate(selectedSpawnTarget, transform);
        spawnedGameObject.transform.position = spawnPosition;
    }
    private void OnDrawGizmos()
    {
        Vector3 start;
        Vector3 end;
        if(spawnerDirection == SpawnerDirection.Vertical)
        {
            start = new Vector3(transform.position.x, transform.position.y - (spawnRange / 2), 0);
            end = new Vector3(transform.position.x, transform.position.y + (spawnRange / 2), 0);
        }
        else
        {
            start = new Vector3(transform.position.x - (spawnRange / 2), transform.position.y, 0);
            end = new Vector3(transform.position.x + (spawnRange / 2), transform.position.y, 0);
        }
        Color originalGizmosColor = Gizmos.color;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, end);
        Gizmos.color = originalGizmosColor;
    }
}
