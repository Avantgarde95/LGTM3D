using System.Linq;

using UnityEngine;

public class Mirror : MonoBehaviour {
    GameObject movingCamera = null;
    int animationIndex = 0;
    int animationFrameCount = 0;

    void Start() {
        var message = GameObject.Find("Message");
        var messageMesh = message.GetComponent<MeshFilter>().mesh;
        messageMesh.uv = messageMesh.uv.Select(coor => new Vector2(1 - coor.x, coor.y)).ToArray();

        movingCamera = GameObject.Find("MovingCamera");
    }

    void Update() {
        var speed = 1.0f / 540.0f;
        var position = movingCamera.transform.localPosition;

        if (animationIndex == 0) {
            if (position.x < 3) {
                position.x = -3 + 6 * easeInOutSine(speed * animationFrameCount);
                animationFrameCount++;
            }
            else {
                animationIndex = 1;
                animationFrameCount = 0;
            }
        }
        else if (animationIndex == 1) {
            if (position.x > -3) {
                position.x = 3 - 6 * easeInOutSine(speed * animationFrameCount);
                animationFrameCount++;
            }
            else {
                animationIndex = 2;
                animationFrameCount = 0;
            }
        }

        movingCamera.transform.localPosition = position;
    }

    private float easeInOutSine(float x) {
        return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
    }
}
