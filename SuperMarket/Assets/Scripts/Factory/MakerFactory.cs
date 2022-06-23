using UnityEngine;

public class MakerFactory<T> where T : ProductFactory
{
    public T Get(T prefab, Vector3 position, Transform parent){
        return Object.Instantiate(prefab, position, Quaternion.identity, parent);
    }
}
