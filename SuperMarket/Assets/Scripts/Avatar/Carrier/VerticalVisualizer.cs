using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VerticalVisualizer
{
    private const float VERTICAL_OFFSET = 0.5f;
    public Vector3 Direction => Vector3.up * VERTICAL_OFFSET;

    private readonly Transform _parentTransform;
    private readonly List<Product> _list;

    private readonly UIDrawer _uiDrawer;

    public VerticalVisualizer(Carrier carrier, Transform parentTransform, List<Product> list, GameObject label){
        _list = list;
        _parentTransform = parentTransform;
        _uiDrawer = new UIDrawer(carrier, this, label);

        carrier.PutInEvent += Visualise;
        carrier.PutOutEvent += RecalculatePositions;

        carrier.PutInEvent += _uiDrawer.MaxLabelVisible;
        carrier.PutOutEvent += _uiDrawer.MaxLabelVisible;
    }

    private void Visualise(){
        var transform = _list.Last().transform;
        transform.parent = _parentTransform;
        transform.localRotation = Quaternion.Euler(0, 0, 90);
        transform.localPosition = Direction * (_list.Count - 1);
    }

    private void RecalculatePositions(){
        for (var i = 0; i < _list.Count; i++)
            _list[i].transform.localPosition = Direction * i;
    }
}