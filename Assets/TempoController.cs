using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TempoController : MonoBehaviour {
    
    private void Update()
    {
        // 拍に来たフレームで true になる
        if (Music.IsJustChangedBeat())
        {
            DOTween
                .To(value => OnScale(value), 0, 1, 0.1f)
                .SetEase(Ease.InQuad)
                .SetLoops(2, LoopType.Yoyo)
            ;
        }

    }

    private void OnScale(float value )
    {
        var scale = Mathf.Lerp(1, 1.05f, value);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}