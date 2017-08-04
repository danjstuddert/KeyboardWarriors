using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : Singleton<KeyController> {
	public GameObject baseTile;

    [Header("Key pressed")]
    public float pressedHeight;
    public LerpType pressedLerpType;
    public float pressedMoveTime;

    public float OriginalHeight { get; private set; }

	private List<Transform> keys;

    public void Init() {
        OriginalHeight = transform.position.y;
    }

	public void KeyPressed(Key key){
		if (key.IsOccupied)
			return;

		
	}

    public void KeyReleased(Key key) {
        key.BecomeOccupied();

        StartCoroutine(SpawnTile(key));
    }

    private IEnumerator SpawnTile(Key key) {
        yield return new WaitForSeconds(pressedMoveTime);

        GameObject go = SimplePool.Spawn(baseTile, key.transform.position, key.transform.rotation);
        go.transform.SetParent(key.transform);
        go.transform.name = string.Format("{0} tile", key.name.ToUpper());
    }
}
