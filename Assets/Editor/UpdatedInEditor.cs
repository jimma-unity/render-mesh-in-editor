using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class UpdatedInEditor
{
    private static UpdatedInEditor instance = null;

    public static UpdatedInEditor Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UpdatedInEditor();
                SceneView.beforeSceneGui += instance.BeforeSceneGui;
                //EditorApplication.playModeStateChanged += PlayModeStateChanged;
            }
            return instance;
        }
        private set { }
    }

    private Mesh mesh;
    private Material material;

    static UpdatedInEditor()
    {
        var v = Instance;
    }
    //public void Dispose()
    //{
    //    SceneView.beforeSceneGui -= BeforeSceneGui;
    //    Debug.Log("I've been destroyed");
    //}

    void BeforeSceneGui(SceneView sceneview)
    {
        if (mesh == null && material == null)
        {
            mesh = CreateMesh.CreatePlane();
            material = CreateMesh.LoadMaterial();
        }

        if (mesh && material)
        {
            material.SetPass(0); // Necessary when calling DrawMeshNow
            Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
        }

        //SceneView.RepaintAll();
    }

    private static void PlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            var v = Instance;
            v.mesh = CreateMesh.CreatePlane();
            v.material = CreateMesh.LoadMaterial();
        }
    }
}
