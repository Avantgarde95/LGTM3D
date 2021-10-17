using UnityEngine;

public class MazeMovingPlayer : MonoBehaviour {
    private GameObject movingCamera = null;
    private GameObject movingLight = null;
    private Light guiLight = null;
    private Vector3 dPosition = Vector3.zero;
    private Vector3 dRotation = Vector3.zero;
    private int animationIndex = 0;

    void Start() {
        movingCamera = GameObject.Find("MovingCamera");
        movingLight = GameObject.Find("MovingLight");
        guiLight = GameObject.Find("GUILight").GetComponent<Light>();
    }

    void Update() {
        var positionSpeed = 0.017f;
        var rotationSpeed = 0.15f;

        if (animationIndex == 0) {
            if (movingCamera.transform.localPosition.z > 52.5) {
                dPosition.z = -positionSpeed;
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 1) {
            if (movingCamera.transform.localEulerAngles.x < 89.9) {
                dRotation.x = rotationSpeed;
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 2) {
            if (movingCamera.transform.localPosition.y > 3) {
                dPosition.y = -positionSpeed;
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 3) {
            if (movingCamera.transform.localEulerAngles.y < 269.9) {
                dRotation.y = rotationSpeed;
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 4) {
            if (movingCamera.transform.localEulerAngles.x > 0.1) {
                dRotation.x = -rotationSpeed;
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 5) {
            if (movingCamera.transform.localPosition.x > -35) {
                dPosition.x = -positionSpeed;
                guiLight.intensity += 0.005f;
            }
            else {
                NextAnimation();
            }
        }

        movingCamera.transform.localPosition += dPosition;
        movingCamera.transform.localEulerAngles += dRotation;
        movingLight.transform.localPosition = movingCamera.transform.localPosition;
    }

    private void NextAnimation() {
        dPosition.x = 0;
        dPosition.y = 0;
        dPosition.z = 0;

        dRotation.x = 0;
        dRotation.y = 0;
        dRotation.z = 0;

        animationIndex++;
        Debug.Log($"Moving to animation {animationIndex}...");
    }
}
