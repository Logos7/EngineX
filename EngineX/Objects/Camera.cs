using System.Numerics;

public class Camera
{
    private float _radius;
    private float _elevation; // w radianach
    private float _azimuth;   // w radianach
    private Vector3 _position; // Pozycja kamery w przestrzeni 3D

    private Matrix4x4 _viewMatrix;
    private Matrix4x4 _projectionMatrix;

    public Camera(float radius, float elevationInDegrees, float aspectRatio)
    {
        _radius = radius;
        SetElevation(elevationInDegrees);
        UpdatePosition();
        UpdateViewMatrix();
        UpdateProjectionMatrix(aspectRatio);
    }

    public void SetRotation(float azimuthInDegrees)
    {
        _azimuth = MathF.PI * azimuthInDegrees / 180.0f; // konwersja do radianów
        UpdatePosition();
        UpdateViewMatrix();
    }

    public void SetElevation(float elevationInDegrees)
    {
        _elevation = MathF.PI * elevationInDegrees / 180.0f; // konwersja do radianów
        UpdatePosition();
        UpdateViewMatrix();
    }

    private void UpdatePosition()
    {
        // Aktualizacja pozycji kamery na orbicie wokół środka sceny
        _position = new Vector3(
            _radius * MathF.Cos(_elevation) * MathF.Cos(_azimuth),
            _radius * MathF.Sin(_elevation),
            _radius * MathF.Cos(_elevation) * MathF.Sin(_azimuth)
        );
    }

    private void UpdateViewMatrix()
    {
        Vector3 cameraTarget = Vector3.Zero; // Kamera patrzy na (0,0,0)
        Vector3 upVector = Vector3.UnitY;    // Wektor "góry" (oś Y)

        _viewMatrix = Matrix4x4.CreateLookAt(_position, cameraTarget, upVector);
    }

    private void UpdateProjectionMatrix(float aspectRatio)
    {
        float fieldOfView = MathF.PI / 4; // 45 stopni
        float nearPlane = 0.1f;
        float farPlane = 1000f;

        _projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlane, farPlane);
    }

    public Vector4 TransformWithDepth(Vector3 point)
    {
        // Przekształcenie punktu przez macierz widoku
        Vector4 viewSpacePoint = Vector4.Transform(new Vector4(point, 1.0f), _viewMatrix);

        // Przekształcenie punktu przez macierz projekcji
        Vector4 clipSpacePoint = Vector4.Transform(viewSpacePoint, _projectionMatrix);

        // Homogeniczne dzielenie
        if (clipSpacePoint.W != 0)
        {
            clipSpacePoint /= clipSpacePoint.W;
        }

        return clipSpacePoint;
    }
}
