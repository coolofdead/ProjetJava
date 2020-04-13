using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Client : MonoBehaviour
{
    public string server = "localhost";

    public string message;

    public void SendData()
    {
        TcpClient client = new TcpClient(server, Server.port);

        int byteCount = Encoding.ASCII.GetByteCount(message);

        var datas = new byte[byteCount];

        datas = Encoding.ASCII.GetBytes(message);

        NetworkStream stream = client.GetStream();

        stream.Write(datas, 0, datas.Length);

        stream.Close();
        client.Close();
    }
}
