using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using Object = System.Object;

public class Connection : MonoBehaviour
{
    static TcpClient tcpClient = new TcpClient();
    static NetworkStream stream = null;
    private static void ConnectSocket(string server, int port)
    {
        tcpClient.Connect(server, port);
        stream = tcpClient.GetStream();
    }

    public static void Send(byte[] msg)
    {
        stream.Write(msg);
    }

    public static void Send(Object @object)
    {
        byte[] msg = MakeArray(@object);
        stream.Write(msg);
    }

    private void Awake()
    {
        ConnectSocket("localhost", 3000);

    }
    private void Update()
    {
        Recv();
    }
    static byte[] MakeArray(Object obj)
    {
        List<byte> bytes = new();
        bytes.AddRange(BitConverter.GetBytes((uint)1));
        byte[] data = ObjectToByteArray(obj);
        bytes.AddRange(BitConverter.GetBytes((uint)data.Length));
        bytes.AddRange(data);
        return bytes.ToArray();
    }
    public static void Recv()
    {
        byte[] data = new byte[1000];
        stream.Read(data, 0, data.Length);
        if (data.Length <= 0)
            return;
        data = data.Skip(8).ToArray();
        string a = "";
        foreach (byte b in data)
            a += b.ToString();
        Debug.Log(a);
        UnitInfo info = ByteArrayToObject(data) as UnitInfo;
    }
    private void OnApplicationQuit()
    {
        tcpClient?.Close();
    }

    // Convert an object to a byte array
    private static byte[] ObjectToByteArray(Object obj)
    {
        if (obj == null)
            return null;

        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, obj);

        return ms.ToArray();
    }

    // Convert a byte array to an Object
    private static Object ByteArrayToObject(byte[] arrBytes)
    {
        BinaryFormatter binForm = new BinaryFormatter();
        using(MemoryStream ms = new MemoryStream(arrBytes))
        {
            object obj = binForm.Deserialize(ms);
            return obj;
        }

    }
}