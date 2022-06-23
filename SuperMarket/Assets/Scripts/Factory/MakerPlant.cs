using UnityEngine;

public class MakerPlant : MonoBehaviour
{
    [SerializeField] private ProductFactory prefab;
    [SerializeField] private Transform[] createPoints;
    [SerializeField] private KeyCode key;
    private readonly MakerFactory<ProductFactory> _factory = new MakerFactory<ProductFactory>();
    private int _count = 0;

    private void CreateNext(){
        if (_count >= createPoints.Length) return;

        var createPos = createPoints[_count].position;
        var item = _factory.Get(prefab, createPos, transform);
        _count++;
    }

    private void Update(){
        if (Input.GetKeyDown(key))
            CreateNext();
    }
}
