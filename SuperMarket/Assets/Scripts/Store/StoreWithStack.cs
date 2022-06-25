using System;
using UnityEngine;

public class StoreWithStack : Store, IDisposable
{
    private readonly StackViewer _stackViewer;
    private readonly GameObject _maxUiLabel;

    public StoreWithStack(int maxCount, Transform parentContainer, Vector3 offsetVector, GameObject maxUiLabel) : base(maxCount){
        _maxUiLabel = maxUiLabel;
        _stackViewer = new StackViewer(this, parentContainer, offsetVector);

        PutEvent += MaxLabelActivate;
        GetEvent += MaxLabelDeactivate;
    }

    public void Dispose(){
        PutEvent -= MaxLabelActivate;
        GetEvent -= MaxLabelDeactivate;
    }

    private void MaxLabelActivate(){
        if (!HasFreeSpace) return;
        _maxUiLabel.transform.localPosition = _stackViewer.IndexToVector3PositionWithOffset(Items.Count);
        _maxUiLabel.SetActive(true);
    }

    private void MaxLabelDeactivate() => _maxUiLabel.SetActive(false);
}