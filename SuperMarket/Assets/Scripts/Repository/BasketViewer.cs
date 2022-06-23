using System.Linq;
using UnityEngine;

public class BasketViewer
{
    private const float VERTICAL_OFFSET = 0.5f;
    public readonly Vector3 PositionVector = Vector3.up * VERTICAL_OFFSET;

    private readonly Transform _parentTransform;
    private readonly GameObject _maxUiLabel;
    private readonly Basket _basket;

    public BasketViewer(Basket basket, Transform parentTransform, GameObject maxUiLabel){
        _basket = basket;
        _parentTransform = parentTransform;
        _maxUiLabel = maxUiLabel;
        
        _basket.PutEvent += PutInOrder;
        _basket.GetEvent += RecalculatePositions;

        _basket.PutEvent += MaxLabelVisible;
        _basket.GetEvent += MaxLabelVisible;
    }

    private void PutInOrder(){
        var transform = _basket.Items.Last().transform;
        transform.parent = _parentTransform;
        transform.localRotation = Quaternion.Euler(0, 0, 90);
        transform.localPosition = PositionVector * (_basket.Items.Count - 1);
    }

    private void RecalculatePositions(){
        for (var i = 0; i < _basket.Items.Count; i++)
            _basket.Items[i].transform.localPosition = PositionVector * i;
    }

    private void MaxLabelVisible(){
        if (_basket.OutOfSpace){
            _maxUiLabel.transform.localPosition = PositionVector * _basket.Items.Count;
            _maxUiLabel.SetActive(true);
        }
        else{
            _maxUiLabel.SetActive(false);
        }
    }
}