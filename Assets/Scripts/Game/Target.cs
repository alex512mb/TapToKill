using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(MeshFilter))]
public class Target : MonoBehaviour
{
    public event System.Action<int> OnTargetDestroyed;


    public Mesh[] shapes;

    [Tooltip("If value is true then player scores will reduce")]
    public bool negative;
    public int containScores = 1;
    public Color positiveColor = Color.white;
    public Color negativeColor = Color.red;

    private Renderer rendererComponent;
    private MeshFilter meshComponent;


    private void Awake()
    {
        if (containScores <= 0)
        {
            Debug.LogWarning("containScores must being with positive value");
        }
        if (shapes.Length == 0)
        {
            shapes = new Mesh[1];
            shapes[0] = meshComponent.mesh;
        }
    }
    private void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        meshComponent = GetComponent<MeshFilter>();

        rendererComponent.material.color = negative ? negativeColor : positiveColor;

        if (shapes.Length > 0)
        {
            meshComponent.mesh = shapes[Random.Range(0, shapes.Length)];
        }
        else
        {
            Debug.LogWarning("shape variants does not assigned in the inspector");
        }
    }

    private void OnMouseDown()
    {
        int scores = negative ? -containScores : containScores;
        OnTargetDestroyed?.Invoke(scores);
        Destroy(gameObject);
    }
}
