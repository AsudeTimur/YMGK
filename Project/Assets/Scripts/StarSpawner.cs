using UnityEngine;
using System.Linq;

public class StarSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Spawn noktalarını içeren dizi
    public GameObject[] starPrefabs; // Yıldız prefab'larını içeren dizi

    void Start()
    {
        SpawnStars();
    }

    void SpawnStars()
    {
        var shuffledSpawnPoints = spawnPoints.OrderBy(x => Random.value).Take(5).ToArray();

        for (int i = 0; i < shuffledSpawnPoints.Length; i++)
        {
            GameObject randomStarPrefab = starPrefabs[Random.Range(0, starPrefabs.Length)];
            GameObject spawnedStar = Instantiate(randomStarPrefab, shuffledSpawnPoints[i].position, Quaternion.identity, shuffledSpawnPoints[i]);
            
            // Collider ekle
            AddCollider(spawnedStar);
        }
    }

    void AddCollider(GameObject star)
    {
        // Eğer zaten Collider yoksa ekle
        if (star.GetComponent<Collider>() == null)
        {
            BoxCollider boxCollider = star.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }

        // Tıklama bileşeni ekle
        star.AddComponent<StarClickDetector>();
    }
}

public class StarClickDetector : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} yıldızına tıklandı ve kayboldu!");
        
        // Yıldızı yok et
        Destroy(gameObject);
    }
}
