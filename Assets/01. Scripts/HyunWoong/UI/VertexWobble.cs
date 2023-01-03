using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VertexWobble : MonoBehaviour
{
    TMP_Text textMesh;

    Mesh mesh;

    Vector3[] vertices;

    List<int> wordIndexes;
    List<int> wordLengths;

    private void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        String();
    }
    private void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = textMesh.mesh.vertices;

        Vertices();
        Character();

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    private void Character()
    {
        for (int i = 0; i < textMesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i];

            int index = c.vertexIndex;

            Vector3 offset = Wobble(Time.time + i);
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }
    }

    private void Vertices()
    {
        for(int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + 1);

            vertices[i] = vertices[i] + offset;
        }
    }

    private void String()
    {
        wordIndexes = new List<int> { 0 };
        wordLengths = new List<int> ();

        string s = textMesh.text;
        for(int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
            wordIndexes.Add (index - wordIndexes[wordIndexes.Count-1]);
            wordLengths.Add (index+1);
        }
        wordLengths.Add(s.Length-wordIndexes[wordIndexes.Count-1]);
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 3.3f), Mathf.Cos(time * 2.8f));
    }
}
