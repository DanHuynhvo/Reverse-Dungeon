using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public GameObject fogTilePrefab; // Fog tile prefab
    public Transform player; // Reference to the player
    public LayerMask wallLayer; // Layer for walls
    public float visionRadius = 5f;
    public int initialFogSize = 50; // Initial fog coverage size in tiles (adjust as needed)

    private Dictionary<Vector2Int, GameObject> fogTiles = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        InitializeFogGrid();
    }

    void Update()
    {
        UpdateFog();
    }

    void InitializeFogGrid()
    {
        // Create fog tiles over a wide area to cover the initial map
        Vector2Int playerPos = new Vector2Int(Mathf.RoundToInt(player.position.x), Mathf.RoundToInt(player.position.y));
        
        for (int x = -initialFogSize; x <= initialFogSize; x++)
        {
            for (int y = -initialFogSize; y <= initialFogSize; y++)
            {
                Vector2Int tilePos = playerPos + new Vector2Int(x, y);

                // Instantiate a fog tile if it doesn't already exist
                if (!fogTiles.ContainsKey(tilePos))
                {
                    GameObject fogTile = Instantiate(fogTilePrefab, new Vector3(tilePos.x, tilePos.y, 0), Quaternion.identity);
                    fogTiles[tilePos] = fogTile;
                }

                // Start with all tiles covered by fog
                fogTiles[tilePos].SetActive(true);
            }
        }
    }

    void UpdateFog()
    {
        // Calculate the player's current position in grid coordinates
        Vector2Int playerPos = new Vector2Int(Mathf.RoundToInt(player.position.x), Mathf.RoundToInt(player.position.y));

        // Clear visibility using a flood-fill algorithm within the vision radius
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(playerPos);

        while (queue.Count > 0)
        {
            Vector2Int currentPos = queue.Dequeue();
            float distance = Vector2.Distance(player.position, currentPos);

            // Skip tiles that are outside the vision radius
            if (distance > visionRadius) continue;

            // Reveal the current tile
            if (fogTiles.ContainsKey(currentPos))
            {
                fogTiles[currentPos].SetActive(false);
            }

            // Check each direction around the current position
            foreach (Vector2Int direction in new Vector2Int[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right })
            {
                Vector2Int neighborPos = currentPos + direction;

                // Skip if we've already visited this tile
                if (visited.Contains(neighborPos)) continue;

                // Check if the neighbor is a wall by raycasting from the player to the tile
                RaycastHit2D hit = Physics2D.Raycast(player.position, ((Vector2)(neighborPos - playerPos)).normalized, visionRadius, wallLayer);

                if (hit.collider != null && hit.collider.gameObject.layer == wallLayer)
                {
                    // Reveal the wall tile, but don't enqueue it
                    Vector2Int wallPos = new Vector2Int(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y));
                    if (fogTiles.ContainsKey(wallPos))
                    {
                        fogTiles[wallPos].SetActive(false);
                    }
                }
                else
                {
                    // No wall blocking, add to the queue
                    queue.Enqueue(neighborPos);
                }

                // Mark this tile as visited
                visited.Add(neighborPos);
            }
        }
    }
}
