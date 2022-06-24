using System;
using UnityEngine;

public class Basket : Repository, IDisposable
{
    private const float PUT_IN_DELAY = 0.1f;
    private const float PUT_OUT_DELAY = 0.1f;

    public override bool CanPut => !OutOfSpace && _putDelayTimer.IsDone();
    public override  bool CanGet => Items.Count > 0 && _getDelayTimer.IsDone();

    private readonly CustomTimer _putDelayTimer, _getDelayTimer;
    private StackViewer _stackViewer;

    public Basket(int maxCount, Transform basketTransform, GameObject maxLabel) : base(maxCount) {
        _stackViewer = new StackViewer(this, basketTransform, maxLabel);

        _putDelayTimer = new CustomTimer(PUT_IN_DELAY);
        _getDelayTimer = new CustomTimer(PUT_OUT_DELAY);

        PutEvent += _putDelayTimer.Start;
        GetEvent += _getDelayTimer.Start;
    }

    public void Dispose(){
        PutEvent -= _putDelayTimer.Start;
        GetEvent -= _getDelayTimer.Start;
    }
}