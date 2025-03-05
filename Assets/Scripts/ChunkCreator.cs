using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChunkCreator : MonoBehaviour
{
    // Chunk constants
    public const int CHUNK_LENGTH = 5;
    public const float CHUNK_OFFSET_X = 12.5f;
    public const float CHUNK_OFFSET_Y = 6.25f;

    // Tilemap constants
    public const float TILEMAP_OFFSET_X = 2.5f;
    public const float TILEMAP_OFFSET_Y = 1.25f;

    public static GameObject generateChunk(float x, float y) {
        GameObject chunk = new GameObject($"Chunk{x}{y}", typeof(Rigidbody2D), typeof(PolygonCollider2D));
        
        chunk.transform.position = new Vector3(x, y, 0);
        GameObject grid = GameObject.Find("Grid");
        if (grid != null) {
            chunk.transform.parent = grid.transform;
        }

        chunk.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        Vector2[] colliderPoints = {new Vector2(0f, 6f), new Vector2(-12.5f, -0.25f), new Vector2(0f, -6.5f), new Vector2(12.5f, -0.25f)};
        chunk.GetComponent<PolygonCollider2D>().SetPath(0, colliderPoints);

        for (int i = 0; i < CHUNK_LENGTH; i++) {
            for (int j = 0; j < CHUNK_LENGTH; j++) {
                float rand = Random.Range(1, 3);
                Object TM = AssetDatabase.LoadAssetAtPath($"Assets/Tilemaps/TM{rand}.prefab", typeof(GameObject));

                float offsetX = ((CHUNK_LENGTH-1-i)*-TILEMAP_OFFSET_X)+(j*TILEMAP_OFFSET_X);
                float offsetY = (i*-TILEMAP_OFFSET_Y)+(j*TILEMAP_OFFSET_Y);

                GameObject tilemap = Instantiate(TM, new Vector3(x + offsetX, y + offsetY, 0), Quaternion.identity) as GameObject;
                tilemap.transform.parent = chunk.transform; 
            }
        }

        return chunk;
    }

    public static void checkChunkNeighbors(GameObject chunk) {
        float x = chunk.transform.position.x;
        float y = chunk.transform.position.y;

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                float offsetX = ((2-i)*-CHUNK_OFFSET_X)+(j*CHUNK_OFFSET_X);
                float offsetY = (i*-CHUNK_OFFSET_Y)+(j*CHUNK_OFFSET_Y);

                if (Physics2D.OverlapCircle(new Vector2(x + offsetX, y + offsetY), 0.5f) == null) {
                    generateChunk(x + offsetX, y + offsetY);
                }
                
            }
        }
    }
}
