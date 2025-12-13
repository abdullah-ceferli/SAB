using UnityEngine;

public class BrainrotSpawner : MonoBehaviour
{
    [Header("Spawn Positions")]
    public Transform spawnPointA;
    public Transform targetPointB;

    [Header("Prefabs")]
    public GameObject[] commonBrainrots;
    public GameObject[] legendaryBrainrots;
    public GameObject[] mythicBrainrots;

    [Header("Timers")]
    public float commonInterval = 10f;
    public float legendaryInterval = 300f;
    public float mythicInterval = 900f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCommon), 1f, commonInterval);
        InvokeRepeating(nameof(SpawnLegendary), 5f, legendaryInterval);
        InvokeRepeating(nameof(SpawnMythic), 10f, mythicInterval);
    }

    void SpawnCommon() => SpawnFromList(commonBrainrots);
    void SpawnLegendary() => SpawnFromList(legendaryBrainrots);
    void SpawnMythic() => SpawnFromList(mythicBrainrots);

    void SpawnFromList(GameObject[] list)
    {
        if (list.Length == 0) return;

        int i = Random.Range(0, list.Length);
        GameObject prefab = list[i];

        GameObject obj = Instantiate(prefab, spawnPointA.position, Quaternion.identity);

        BrainrotMover mover = obj.GetComponent<BrainrotMover>();
        if (mover != null)
            mover.Init(targetPointB.position);
    }
}
