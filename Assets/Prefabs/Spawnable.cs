using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnable", menuName = "Gooie's Adventure/Spawnable", order = 0)]
public class Spawnable : ScriptableObject
{
    public GameObject spawnTarget = null;
    public int spawnWeight = 100;
}
