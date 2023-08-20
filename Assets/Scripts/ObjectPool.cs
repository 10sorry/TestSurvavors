using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private bool poolActivated = false;
    [SerializeField] private Tilemap _tilemap;
    private int _poolSize = 20;
    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject _enemy = Instantiate(_enemyPrefab);
            _enemy.SetActive(false);
            objectPool.Add(_enemy);
        }

        StartCoroutine(SpawnObjectsWithDelay());
    }
    
    
    private IEnumerator SpawnObjectsWithDelay()
    {
        while (poolActivated)
        {
            TakeObjFromPool();

            // Задержка перед следующим появлением
            yield return new WaitForSeconds(5.0f); 
        }
    }
    
    private GameObject TakeObjFromPool()
    {
        foreach (var _enemy in objectPool)
        {
            if (!_enemy.activeInHierarchy)
            {
                _enemy.SetActive(true);
                BoundsInt bounds = _tilemap.cellBounds;
                Vector3Int randomTilePosition = new Vector3Int(
                    Random.Range(bounds.x, bounds.x + bounds.size.x),
                    Random.Range(bounds.y, bounds.y + bounds.size.y),
                    -1);

                _enemy.transform.position = randomTilePosition;
                EnemyBehavior enemyBehavior = _enemy.AddComponent<EnemyBehavior>();
                
                return _enemy;
            }
            
            

            
        }
        return null;
    }

    private void ReturnObjToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    
    
    
}
