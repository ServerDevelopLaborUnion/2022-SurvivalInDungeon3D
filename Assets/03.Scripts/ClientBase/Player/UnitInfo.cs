using UnityEngine;


[System.Serializable]
public class Vt3
{
    public float x, y, z;

    public Vt3()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public Vt3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vt3(Vector3 vec)
    {
        this.x = vec.x;
        this.y = vec.y;
        this.z = vec.z;
    }
    public static Vt3 zero { get { return new Vt3(0, 0, 0); } }

    public static Vt3 operator +(Vt3 th, Vector3 vt3)
        => new Vt3(th.x + vt3.x, th.y + vt3.y, th.z + vt3.z);

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}
[System.Serializable]
public class UnitInfo
{
    [SerializeField]
    private string name;
    [SerializeField]
    private string id;
    [SerializeField]
    private Vt3 position;
    [SerializeField]
    private Vt3 eulerRotation;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vt3 inputDir = Vt3.zero;
    [SerializeField]
    private Vt3 mouseDir = Vt3.zero;

    public string Name { get { return name; } }
    public string Id { get { return id; } }
    public Vt3 Position { get { return position; } }
    public Vt3 EulerRotation { get { return eulerRotation; } }
    public float Speed { get { return speed; } }
    public Vector3 InputDir { get { return inputDir.ToVector3(); } }
    public Vector3 MouseDir { get { return mouseDir.ToVector3(); } }

    public UnitInfo(string name, string id, Vector3 pos, Vector3 rot, float speed)
    {
        this.name = name;
        this.id = id;
        this.position = new Vt3(pos);
        this.eulerRotation = new Vt3(rot);
        this.speed = speed;
    }

    public void SetDir(Vector3 dir)
    {
        this.inputDir += dir;
    }

    public void Stop()
    {
        this.inputDir = Vt3.zero;
    }

    public void Move(Vector3 pos)
    {
        position = new Vt3(pos);
    }

    public void Rotation(Vector3 rot)
    {
        eulerRotation.y = rot.y;
    }
}
