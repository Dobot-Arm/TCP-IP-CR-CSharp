using CSharthiscpDemo.com.dobot.api;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpTcpDemo.com.dobot.api
{
    class DobotMove
    {
        private Socket mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public string IP { get; private set; }
        public int Port { get; private set; }

        /// <summary>
        /// 连接设备
        /// </summary>
        /// <param name="strIp">设备地址</param>
        /// <param name="iPort">指定端口</param>
        /// <returns>true成功，false失败</returns>
        public bool Connect(string strIp, int iPort)
        {
            bool bOk = false;
            try
            {
                this.IP = strIp;
                this.Port = iPort;

                IPAddress addr = IPAddress.Parse(strIp);
                IPEndPoint endpt = new IPEndPoint(addr, iPort); //30003

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

        /// <summary>
        /// 断开连接
        /// </summary>
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

        /// <summary>
        /// 关节点动运动，不固定距离运动
        /// </summary>
        /// <param name="s">点动运动轴</param>
        /// <returns>返回执行结果的描述信息</returns>
        public string MoveJog(string s)
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str;
            if (string.IsNullOrEmpty(s))
            {
                str = "MoveJog()";
            }
            else
            {
                string strPattern = "^(J[1-6][+-])|([XYZ][+-])|(R[xyz][+-])$";
                if (Regex.IsMatch(s, strPattern))
                {
                    str = "MoveJog(" + s + ")";
                }
                else
                {
                    return "send error:invalid parameter!!!";
                }
            }
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }
        /// <summary>
        /// 停止关节点动运动
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
        public string StopMoveJog()
        {
            return MoveJog(null);
        }

        /// <summary>
        /// 点到点运动，目标点位为笛卡尔点位
        /// </summary>
        /// <param name="pt">笛卡尔点位</param>
        /// <returns>返回执行结果的描述信息</returns>
        public string MovJ(DescartesPoint pt)
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            if (null == pt)
            {
                return "send error:invalid parameter!!!";
            }
            string str = String.Format("MovJ({0},{1},{2},{3},{4},{5})", pt.x, pt.y, pt.z, pt.rx, pt.ry, pt.rz);
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }

        /// <summary>
        /// 直线运动，目标点位为笛卡尔点位
        /// </summary>
        /// <param name="pt">笛卡尔点位</param>
        /// <returns>返回执行结果的描述信息</returns>
        public string MovL(DescartesPoint pt)
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }
            if (null == pt)
            {
                return "send error:invalid parameter!!!";
            }
            string str = String.Format("MovL({0},{1},{2},{3},{4},{5})", pt.x, pt.y, pt.z, pt.rx, pt.ry, pt.rz);
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }

        /// <summary>
        /// 点到点运动，目标点位为关节点位。
        /// </summary>
        /// <param name="pt"></param>
        /// <returns>返回执行结果的描述信息</returns>
        public string JointMovJ(JointPoint pt)
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }
            if (null == pt)
            {
                return "send error:invalid parameter!!!";
            }
            string str = String.Format("JointMovJ({0},{1},{2},{3},{4},{5})", pt.j1, pt.j2, pt.j3, pt.j4, pt.j5, pt.j6);
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="str">发送内容</param>
        /// <returns>成功-true，失败-false</returns>
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

        /// <summary>
        /// 等待响应
        /// </summary>
        /// <param name="iTimeoutMillsecond">等待时间，毫秒单位</param>
        /// <returns>返回响应的内容</returns>
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("send error:" + ex.ToString());
                return ex.Message;
            }
        }
    }
}
