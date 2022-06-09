using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDrawer
{
    private readonly GameObject _maxLabel;
    private readonly Carrier _carrier;
    private readonly VerticalVisualizer _visualizer;

    public UIDrawer(Carrier carrier, VerticalVisualizer visualizer, GameObject maxLabel){
        _carrier = carrier;
        _visualizer = visualizer;
        _maxLabel = maxLabel;
    }

    public void MaxLabelVisible(){
        if (_carrier.MaxCount){
            _maxLabel.transform.localPosition = _visualizer.Direction * _carrier.Count;
            _maxLabel.SetActive(true);
        }
        else{
            _maxLabel.SetActive(false);
        }
    }
}
