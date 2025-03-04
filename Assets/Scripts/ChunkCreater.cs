using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChunkCreater : MonoBehaviour
{
    void Start()
    {
        GameObject chunk = new GameObject("Chunk");
        chunk.transform.parent = gameObject.transform;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                float rand = Random.Range(1, 3);
                Debug.Log("rand: " + rand);
                Object TM = AssetDatabase.LoadAssetAtPath($"Assets/Tilemaps/TM{rand}.prefab", typeof(GameObject));

                GameObject tilemap = Instantiate(TM, new Vector3((float)(((4-i)*-2.5)+(j*2.5)), (float)((i*-1.25)+(j*1.25)), 0), Quaternion.identity) as GameObject;
                tilemap.transform.parent = chunk.transform; 
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
