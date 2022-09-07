using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int id;
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private Vector3 eulerRotation;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 inputDir;
    [SerializeField]
    private Vector3 mouseDir;

    public string Name { get { return name; } }
    public int Id { get { return id; } }
    public Vector3 Position { get { return position; } }
    public Vector3 EulerRotation { get { return eulerRotation; } }
    public float Speed { get { return speed; } }
    public Vector3 InputDir { get { return inputDir; } }
    public Vector3 MouseDir { get { return mouseDir; } }

    public PlayerInfo(string name, int id, Vector3 pos, Vector3 rot, float speed)
    {
        this.name = name;
        this.id = id;
        this.position = pos;
        this.eulerRotation = rot;
        this.speed = speed;
    }

    public void SetDir(Vector3 dir)
    {
        this.inputDir += dir;
    }

    public void Stop()
    {
        this.inputDir = Vector3.zero;
    }

    public void Move(Vector3 pos)
    {
        position = pos;
    }

    public void Rotation(Vector3 rot)
    {
        eulerRotation = rot;
    }
}
