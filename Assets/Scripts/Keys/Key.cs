using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public KeyCode key;
	public bool IsOccupied { get; private set; }

	void Update(){
		if(Input.GetKeyDown(key)){
            if (IsOccupied == false)
                StartCoroutine(Lerp(KeyController.Instance.pressedHeight, KeyController.Instance.pressedMoveTime, KeyController.Instance.pressedLerpType));

            KeyController.Instance.KeyPressed (this);
		}

        if (Input.GetKeyUp(key)) {
            if (IsOccupied == false)
                StartCoroutine(Lerp(KeyController.Instance.OriginalHeight, KeyController.Instance.pressedMoveTime, KeyController.Instance.pressedLerpType));
            KeyController.Instance.KeyReleased (this);
        }
	}

	public void BecomeOccupied() {
		IsOccupied = true;
	}

    public IEnumerator Lerp(float yLocation, float moveTime, LerpType lerpType) {
        StopAllCoroutines();

        float currentLerpTime = 0f;
        float t = 0f;

        Vector3 location = transform.position;
        location.y = yLocation;

        Vector3 originalPos = transform.position;

        while (currentLerpTime < moveTime) {
            currentLerpTime += Time.deltaTime;

            t = currentLerpTime / moveTime;

            //If we need to add a curve to the lerp time do so
            if (lerpType != LerpType.Normal)
                t = LerpController.Instance.ApplyCurveToLerpTime(t, KeyController.Instance.pressedLerpType);

            transform.position = Vector3.Lerp(originalPos, location, t);

            yield return null;
        }

        transform.position = location;
    }
}
