using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public int planeSize = 10;
    public int cubesToSpawn = 10;

    void Start()
    {
        List<Vector3> positions = new List<Vector3>();
        int half = planeSize / 2;

        for (int x = -half; x < half; x++)
        {
            for (int z = -half; z < half; z++)
            {
                positions.Add(new Vector3(x, 0.5f, z));
            }
        }

        for (int i = 0; i < cubesToSpawn && positions.Count > 0; i++)
        {
            int index = Random.Range(0, positions.Count);
            Instantiate(cubePrefab, positions[index], Quaternion.identity);
            positions.RemoveAt(index);
        }
    }
}
