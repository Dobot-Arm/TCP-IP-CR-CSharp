using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharpTcpDemo.com.dobot.api
{
    class Dashboard
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
                IPEndPoint endpt = new IPEndPoint(addr, iPort);//29999

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
        /// 复位，用于清除错误
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
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

        /// <summary>
        /// 机器人上电
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
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

        /// <summary>
        /// 急停
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
        public string PowerOff()
        {
            return EmergencyStop();
        }

        /// <summary>
        /// 急停
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
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

        /// <summary>
        /// 使能机器人
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
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

        /// <summary>
        /// 下使能机器人
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
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

        /// <summary>
        /// 机器人停止
        /// </summary>
        /// <returns>返回执行结果的描述信息</returns>
        public string ResetRobot()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "ResetRobot()";
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(20000);
        }

        /// <summary>
        /// 设置全局速度比例。
        /// </summary>
        /// <param name="ratio">运动速度比例，取值范围：1~100</param>
        /// <returns>返回执行结果的描述信息</returns>
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

        /// <summary>
        /// 设置数字输出端口状态（队列指令）
        /// </summary>
        /// <param name="index">数字输出索引，取值范围：1~16或100~1000</param>
        /// <param name="status">数字输出端口状态，true：高电平；false：低电平</param>
        /// <returns>返回执行结果的描述信息</returns>
        public string DigitalOutputs(int index, bool status)
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = String.Format("DO({0},{1})", index, status ? 1 : 0);
            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }

        public string GetErrorID()
        {
            if (!mSocketClient.Connected)
            {
                return "device does not connected!!!";
            }

            string str = "GetErrorID()";
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
                return (mSocketClient.Send(data)==data.Length)?true:false;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("send error:"+ex.ToString());
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
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("send error:" + ex.ToString());
                return "send error:" + ex.Message;
            }
        }
    }
}
