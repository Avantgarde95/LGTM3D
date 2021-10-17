using System.Linq;

using UnityEngine;

public class Balls : MonoBehaviour {
    void Start() {
        Vector2[] uvDiffs = {
            new Vector2(0.0f, 0.5f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.5f, 0.0f)
        };

        var ballCount = uvDiffs.Length;

        for (var i = 0; i < ballCount; i++) {
            var ball = GameObject.Find($"Ball{i + 1}");

            var mesh = ball.GetComponent<MeshFilter>().mesh;
            mesh.uv = mesh.uv.Select(coor => coor * 0.5f + uvDiffs[i]).ToArray();
        }
    }

    void Update() {

    }
}
