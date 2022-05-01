using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Tools.ResourceManager;
using SnakeGame.Camera;
using SnakeGame.Abstractions;

public class CameraController : BaseController
{
    private readonly ResourcePath path = new ResourcePath() { Path = "Prefabs/Camera" };
    private readonly CameraView cameraView;
    
    public CameraController()
    {
        cameraView = LoadView();
    }

    private CameraView LoadView()
    {
        var pref = ResourceLoader.LoadPrefab(path);
        GameObject obj = UnityEngine.Object.Instantiate(pref);

        return obj.GetComponent<CameraView>();

    }

    public void SetCamPos(Vector3 position)
    {
        cameraView.transform.position = position;
    }
}
