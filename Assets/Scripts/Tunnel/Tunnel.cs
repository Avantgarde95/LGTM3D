using System.Collections.Generic;

using UnityEngine;

public class Tunnel : MonoBehaviour {
    private GameObject movingPlayer = null;
    private GameObject movingPlane = null;
    private List<Light> staticLights = new List<Light>();
    private int animationIndex = 0;
    private float animationStartTime = 0;

    void Start() {
        movingPlayer = GameObject.Find("MovingPlayer");

        movingPlane = GameObject.Find("MovingPlane");
        movingPlane.SetActive(false);

        for (var i = 1; i <= 3; i++) {
            staticLights.Add(GameObject.Find($"StaticLight{i}").GetComponent<Light>());
        }
    }

    void Update() {
        if (animationIndex == 0) {
            if (movingPlayer.transform.localPosition.z < -5.3f) {
                movingPlayer.transform.localPosition += new Vector3(0, 0, 0.002f);
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 1) {
            var lightIntensity = staticLights[0].intensity;

            if (lightIntensity > 0.01f) {
                lightIntensity = Mathf.Max(lightIntensity - 0.003f, 0.01f);

                staticLights.ForEach(light => {
                    light.intensity = lightIntensity;
                });
            }
            else {
                staticLights.ForEach(light => {
                    light.color = new Color(1.0f, 0.0f, 0.0f);
                    light.intensity = 0;
                });

                NextAnimation();
            }
        }
        else if (animationIndex == 2) {
            if (Time.time - animationStartTime >= 1.5f) {
                NextAnimation();
            }
        }
        else if (animationIndex == 3) {
            var lightIntensity = staticLights[0].intensity;

            if (lightIntensity < 1.5f) {
                lightIntensity = Mathf.Min(lightIntensity + 0.01f, 1.5f);

                staticLights.ForEach(light => {
                    light.intensity = lightIntensity;
                });
            }
            else {
                NextAnimation();
            }
        }
        else if (animationIndex == 4) {
            if (Time.time - animationStartTime >= 2f) {
                movingPlane.SetActive(true);
                NextAnimation();
            }
        }
        else if (animationIndex == 5) {
            if (movingPlane.transform.localPosition.z > -4.3f) {
                movingPlane.transform.localPosition += new Vector3(0, 0, -0.15f);
            }
            else {
                NextAnimation();
            }
        }
    }

    private void NextAnimation() {
        animationIndex++;
        animationStartTime = Time.time;
        Debug.Log($"Moving to animation {animationIndex}...");
    }
}
