using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private int enemiesNumber;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private List<GameObject> observables;

    private Bounds levelBounds;


    private void Start()
    {
        levelBounds = CalculateLevelBounds(mainCamera, Vector2.one / 4f);
        InitializeLevel(levelBounds);
    }

    private void FixedUpdate()
    {
        foreach (var observable in observables)
        {
            if (observable.transform.position.x > levelBounds.max.x || observable.transform.position.x < levelBounds.min.x ||
                observable.transform.position.y > levelBounds.max.y || observable.transform.position.y < levelBounds.min.y)
            {
                Vector2 inBounds = new Vector2();
                inBounds.x = Mathf.Clamp(observable.transform.position.x, levelBounds.min.x, levelBounds.max.x);
                inBounds.y = Mathf.Clamp(observable.transform.position.y, levelBounds.min.y, levelBounds.max.y);
                observable.transform.position = inBounds;
            }
        }
    }

    private void InitializeLevel(Bounds levelBounds)
    {
        var enemiesFactory = new EnemiesFactory(player, enemyPrefab);
        for (int i = 0; i < enemiesNumber; i++)
        {
            var enemy = enemiesFactory.SpawnEnemy(levelBounds);
            observables.Add(enemy);
        }
    }

    private Bounds CalculateLevelBounds(Camera camera, Vector2 padding)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect - padding.x, cameraHeight - padding.y, 0));
        return bounds;
    }
}
