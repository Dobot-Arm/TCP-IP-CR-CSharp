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
    class Dashboard
    {
        private Socket mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        public bool Connect(string strIp)
        {
            bool bOk = false;
            try
            {
                IPAddress addr = IPAddress.Parse(strIp);
                IPEndPoint endpt = new IPEndPoint(addr, 29999);

                mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mSocketClient.Connect(endpt);
                mSocketClient.SendTimeout = 5000;
                mSocketClient.ReceiveTimeout = 5000;

                bOk = true;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Connect failed:"+ex.ToString());
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

        public string ClearError()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "ClearError()";
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }
        public string PowerOn()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "PowerOn()";
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(15000);
        }

        public string PowerOff()
        {
            return EmergencyStop();
        }
        public string EmergencyStop()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "EmergencyStop()";
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(15000);
        }
        public string EnableRobot()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "EnableRobot()";
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(20000);
        }

        public string DisableRobot()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "DisableRobot()";
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(20000);
        }
        public string SpeedFactor(int ratio)
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = String.Format("SpeedFactor({0})", ratio);
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }

        private bool SendData(string str)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(str);
                return (mSocketClient.Send(data)==data.Length)?true:false;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("send error:"+ex.ToString());
            }
            return false;
        }
        private string WaitReply(int iTimeoutMillsecond)
        {
            try
            {
                if (iTimeoutMillsecond != mSocketClient.ReceiveTimeout)
                {
                    mSocketClient.ReceiveTimeout = iTimeoutMillsecond;
                }
                byte[] buffer = new byte[1024];
                int length = mSocketClient.Receive(buffer);
                string str = Encoding.UTF8.GetString(buffer, 0, length);

                return str;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("send error:" + ex.ToString());
                return ex.Message;
            }
        }
    }
}
