using UnityEngine;

public class EnemiesFactory
{
    private readonly PlayerController player;
    private readonly GameObject enemyPrefab;


    public EnemiesFactory(PlayerController player, GameObject enemyPrefab)
    {
        this.player = player;
        this.enemyPrefab = enemyPrefab;
    }

    public GameObject SpawnEnemy(Bounds bounds)
    {
        var enemy = GameObject.Instantiate(enemyPrefab);

        float spawnX = Random.Range(bounds.min.x, bounds.max.x);
        float spawnY = Random.Range(bounds.min.y, bounds.max.y);
        enemy.transform.position = new Vector3(spawnX, spawnY, 0f);

        enemy.GetComponent<Enemy>().AddPlayerDependency(player);

        return enemy;
    }
}
