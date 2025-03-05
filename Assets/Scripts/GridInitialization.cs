using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInitialization : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                float offsetX = ((2-i)*-ChunkCreator.CHUNK_OFFSET_X)+(j*ChunkCreator.CHUNK_OFFSET_X);
                float offsetY = (i*-ChunkCreator.CHUNK_OFFSET_Y)+(j*ChunkCreator.CHUNK_OFFSET_Y);

                GameObject chunk = ChunkCreator.generateChunk(offsetX, offsetY);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
