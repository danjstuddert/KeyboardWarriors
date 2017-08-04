using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LerpType {
    Normal,
    EaseOut,
    EaseIn,
    Exponential,
    SmoothStep
};

public class LerpController : Singleton<LerpController> {
    public float ApplyCurveToLerpTime(float t, LerpType type) {
        switch (type) {
            case LerpType.EaseOut:
                return Mathf.Sin(t * Mathf.PI * 0.5f);
            case LerpType.EaseIn:
                return 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
            case LerpType.Exponential:
                return t * t;
            case LerpType.SmoothStep:
                return t * t * (3f - 2f * t);
        }

        return t;
    }

    public static IEnumerator Grow(Transform obj, float finalScale, float growTime, LerpType lerpType) {
        float currentLerpTime = 0f;
        float t;

        Vector3 endingScale = Vector3.one * finalScale;
        Vector3 originalScale = obj.localScale;

        while (currentLerpTime < growTime) {
            currentLerpTime += Time.deltaTime;
            t = currentLerpTime / growTime;

           // if (lerpType != LerpType.Normal)
           //     t = ApplyCurveToLerpTime(t, lerpType);

            obj.localScale = Vector3.Lerp(originalScale, endingScale, t);

            yield return null;
        }

        obj.localScale = endingScale;
    }
}
