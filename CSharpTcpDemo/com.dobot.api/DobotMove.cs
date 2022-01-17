using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTcpDemo.com.dobot.api
{
    class DobotMove
    {
        private Socket mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public DobotMove()
        {
        }

        public bool Connect(string strIp)
        {
            bool bOk = false;
            try
            {
                IPAddress addr = IPAddress.Parse(strIp);
                IPEndPoint endpt = new IPEndPoint(addr, 30003);

                mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mSocketClient.Connect(endpt);
                mSocketClient.SendTimeout = 5000;
                mSocketClient.ReceiveTimeout = 15000;

                bOk = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Connect failed:" + ex.ToString());
            }
            return bOk;
        }

        public void Disconnect()
        {
            if (mSocketClient.Connected)
            {
                try
                {
                    mSocketClient.Shutdown(SocketShutdown.Both);
                    mSocketClient.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("close socket:" + ex.ToString());
                }
            }
        }

        public bool MoveJog(string s)
        {
            string str;
            if (string.IsNullOrEmpty(s))
            {
                str = "MoveJog()";
            }
            else
            {
                str = "MoveJog(" + s + ")";
            }
            return SendData(str);
        }
        public bool StopMoveJog()
        {
            return MoveJog(null);
        }

        private bool SendData(string str)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(str);
                return (mSocketClient.Send(data) == data.Length) ? true : false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("send error:" + ex.ToString());
            }
            return false;
        }
    }
}
