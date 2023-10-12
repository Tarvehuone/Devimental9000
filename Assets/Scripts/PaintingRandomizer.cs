using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingRandomizer : MonoBehaviour
{
    public GameObject paintingPrefab;
    public Sprite[] paintingSprites;
    public Transform[] paintingSpawnPoints;
    List<int> usedIndex = new List<int>();
    private int randomAmount;
    public List<bool> paintingsBoolean = new List<bool>();

    void OnEnable()
    {
        RandomizePaintings();
    }
    void RandomizePaintings()
    {
        randomAmount = Random.Range(3, 6);

        for (int i = 0; i < paintingSpawnPoints.Length; i++)
        {
            if (usedIndex.Count > randomAmount)
                break;

            int randomSpawnPoint = Random.Range(0, paintingSpawnPoints.Length);

            if (!usedIndex.Contains(randomSpawnPoint))
            {
                GameObject newPainting = Instantiate(paintingPrefab,
                    paintingSpawnPoints[randomSpawnPoint].position,
                    Quaternion.identity, paintingSpawnPoints[randomSpawnPoint]);

                newPainting.GetComponent<SpriteRenderer>().sprite = paintingSprites[Random.Range(0, paintingSprites.Length)];

                usedIndex.Add(randomSpawnPoint);
            }
        }
    }

    public void CheckPaintings(bool isDestroyed)
    {
        paintingsBoolean.Add(isDestroyed);

        if (paintingsBoolean.Count >= randomAmount)
        {
            GameObject.FindObjectOfType<BossDoor>().CheckRooms(true);
            Destroy(transform.parent.gameObject);
        }
    }
}
