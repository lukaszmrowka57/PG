using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;

    public GameObject block;
    public int objectsToGenerate = 10;
    public Material[] materials;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;

        int minX = Mathf.FloorToInt(bounds.min.x);
        int maxX = Mathf.CeilToInt(bounds.max.x);
        int minZ = Mathf.FloorToInt(bounds.min.z);
        int maxZ = Mathf.CeilToInt(bounds.max.z);

        int rangeX = maxX - minX;
        int rangeZ = maxZ - minZ;

        List<int> pozycje_x = new List<int>(Enumerable.Range(minX, rangeX).OrderBy(x => Guid.NewGuid()).Take(objectsToGenerate));
        List<int> pozycje_z = new List<int>(Enumerable.Range(minZ, rangeZ).OrderBy(z => Guid.NewGuid()).Take(objectsToGenerate));

        int count = Mathf.Min(objectsToGenerate, Mathf.Min(pozycje_x.Count, pozycje_z.Count));

        for (int i = 0; i < count; i++)
        {
            positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            if (materials != null && materials.Length > 0)
            {
                Renderer rend = newBlock.GetComponent<Renderer>();
                if (rend != null)
                {
                    Material randomMat = materials[UnityEngine.Random.Range(0, materials.Length)];
                    rend.material = randomMat;
                }
            }

            objectCounter++;
            yield return new WaitForSeconds(delay);
        }

        StopCoroutine(GenerujObiekt());
    }
}
