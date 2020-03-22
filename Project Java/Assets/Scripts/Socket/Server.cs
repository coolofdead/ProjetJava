using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using System.Threading;

public class Server : MonoBehaviour
{
    private IPAddress ipAdress;
    public const int port = 80;

    private const int bufferSize = 1000;
    private byte[] recieveBuffer = new byte[bufferSize];

    private TcpListener server;

    public static ManualResetEvent clientConnected = new ManualResetEvent(false);

    private void Start()
    {
        ipAdress = Dns.GetHostEntry("localhost").AddressList[0];
        server = new TcpListener(ipAdress, port);

        try
        {
            server.Start();
            Debug.Log("Server Running..");
        }
        catch (SocketException e)
        {
            Debug.Log(e.Message);
        }

        ThreadStart childref = new ThreadStart(SocketThread);
        Thread childThread = new Thread(childref);
        childThread.Start();
    }

    public void SocketThread()
    {
        while(true)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        TcpClient client = default(TcpClient);
        client = server.AcceptTcpClient();

        NetworkStream stream = client.GetStream();

        recieveBuffer = new byte[bufferSize];
        stream.Read(recieveBuffer, 0, recieveBuffer.Length);

        string msg = Encoding.ASCII.GetString(recieveBuffer, 0, recieveBuffer.Length);

        Debug.Log(msg);
        client.Close();
    }
}