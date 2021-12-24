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
    class Feedback
    {
        private Socket mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Thread mThread;

        #region 数据包解析
        public short MessageSize { get; private set; }
        public short[] Reserved1 { get; private set;}
        public long DigitalInputBits { get; private set;}
        public long DigitalOutputs { get; private set;}
        public long RobotMode { get; private set;}
        public long ControllerTimer { get; private set;}
        public long Time { get; private set;}
        public long TestValue { get; private set;}
        public long SafetyMode { get; private set;}
        public double SpeedScaling { get; private set;}
        public double LinearMomentumNorm { get; private set;}
        public double VMain { get; private set;}
        public double VRobot { get; private set;}
        public double IRobot { get; private set;}
        public double ProgramState { get; private set;}
        public double SafetyStatus { get; private set;}
        public double[] ToolAccelerometerValues { get; private set;}
        public double[] ElbowPosition { get; private set;}
        public double[] ElbowVelocity { get; private set;}
        public double[] QTarget { get; private set;}
        public double[] QdTarget { get; private set;}
        public double[] QddTarget { get; private set;}
        public double[] ITarget { get; private set;}
        public double[] MTarget { get; private set;}
        public double[] QActual { get; private set;}
        public double[] QdActual { get; private set;}
        public double[] IActual { get; private set;}
        public double[] IControl { get; private set;}
        public double[] ToolVectorActual { get; private set;}
        public double[] TCPSpeedActual { get; private set;}
        public double[] TCPForce { get; private set;}
        public double[] ToolVectorTarget { get; private set;}
        public double[] TCPSpeedTarget { get; private set;}
        public double[] MotorTempetatures { get; private set;}
        public double[] JointModes { get; private set;}
        public double[] VActual { get; private set;}
        public byte[] Handtype { get; private set;}
        public byte User { get; private set;}
        public byte Tool { get; private set;}
        public byte RunQueuedCmd { get; private set;}
        public byte PauseCmdFlag { get; private set;}
        public byte VelocityRatio { get; private set;}
        public byte AccelerationRatio { get; private set;}
        public byte JerkRatio { get; private set;}
        public byte XYZVelocityRatio { get; private set;}
        public byte RVelocityRatio { get; private set;}
        public byte XYZAccelerationRatio { get; private set;}
        public byte RAccelerationRatio { get; private set;}
        public byte XYZJerkRatio { get; private set;}
        public byte RJerkRatio { get; private set;}
        public byte[] Reserved2 { get; private set;}
        public double[] Actual { get; private set;}
        public double Load { get; private set;}
        public double CenterX { get; private set;}
        public double CenterY { get; private set;}
        public double CenterZ { get; private set;}
        public double[] UserValue { get; private set;}
        public double[] Tools { get; private set;}
        public byte[] Reserved3 { get; private set;}

        #endregion
        
        public bool DataHasRead { get; set; }

        public Feedback()
        {
            #region 数据包解析
            this.MessageSize = 0; //unsigned short
            this.Reserved1 = new short[3];
            this.DigitalInputBits = 0;
            this.DigitalOutputs = 0;
            this.RobotMode = 0;
            this.ControllerTimer = 0;
            this.Time = 0;
            this.TestValue = 0;
            this.SafetyMode = 0;
            this.SpeedScaling = 0.0;
            this.LinearMomentumNorm = 0.0;
            this.VMain = 0.0;
            this.VRobot = 0.0;
            this.IRobot = 0.0;
            this.ProgramState = 0.0;
            this.SafetyStatus = 0.0;
            this.ToolAccelerometerValues = new double[3];
            this.ElbowPosition = new double[3];
            this.ElbowVelocity = new double[3];
            this.QTarget = new double[6];
            this.QdTarget = new double[6];
            this.QddTarget = new double[6];
            this.ITarget = new double[6];
            this.MTarget = new double[6];
            this.QActual = new double[6];
            this.QdActual = new double[6];
            this.IActual = new double[6];
            this.IControl = new double[6];
            this.ToolVectorActual = new double[6];
            this.TCPSpeedActual = new double[6];
            this.TCPForce = new double[6];
            this.ToolVectorTarget = new double[6];
            this.TCPSpeedTarget = new double[6];
            this.MotorTempetatures = new double[6];
            this.JointModes = new double[6];
            this.VActual = new double[6];
            this.Handtype = new byte[4];
            this.User = 0;
            this.Tool = 0;
            this.RunQueuedCmd = 0;
            this.PauseCmdFlag = 0;
            this.VelocityRatio = 0;
            this.AccelerationRatio = 0;
            this.JerkRatio = 0;
            this.XYZVelocityRatio = 0;
            this.RVelocityRatio = 0;
            this.XYZAccelerationRatio = 0;
            this.RAccelerationRatio = 0;
            this.XYZJerkRatio = 0;
            this.RJerkRatio = 0;
            this.Reserved2 = new byte[95];
            this.Actual = new double[6];
            this.Load = 0.0;
            this.CenterX = 0.0;
            this.CenterY = 0.0;
            this.CenterZ = 0.0;
            this.UserValue = new double[6];
            this.Tools = new double[6];
            this.Reserved3 = new byte[144];
            #endregion
        }

        public bool Connect(string strIp)
        {
            bool bOk = false;
            try
            {
                IPAddress addr = IPAddress.Parse(strIp);
                IPEndPoint endpt = new IPEndPoint(addr, 30004);

                mSocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mSocketClient.Connect(endpt);
                mSocketClient.SendTimeout = 5000;
                mSocketClient.ReceiveTimeout = 15000;

                mThread = new Thread(OnRecvData);
                mThread.IsBackground = true;
                mThread.Start();

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
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("close socket:" + ex.ToString());
                }
            }
            if ( null!= mThread && mThread.IsAlive)
            {
                try
                {
                    mThread.Abort();
                    mThread = null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("close thread:" + ex.ToString());
                }
            }
        }

        /*****************************************
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
        *******************************************************************/

        private void OnRecvData()
        {
            byte[] buffer = new byte[4320];//1440*3
            int iHasRead = 0;
            while (mSocketClient.Connected)
            {
                try
                {
                    int iRet = mSocketClient.Receive(buffer, iHasRead, buffer.Length - iHasRead, SocketFlags.None);
                    if (iRet <= 0)
                    {
                        continue;
                    }
                    iHasRead += iRet;
                    if (iHasRead < 1440)
                    {
                        continue;
                    }

                    bool bHasFound = false;//是否找到数据包头了
                    for (int i=0; i<iHasRead; ++i)
                    {
                        //找到消息头
                        int iMsgSize = buffer[i+1];
                        iMsgSize <<= 8;
                        iMsgSize |= buffer[i];
                        iMsgSize &= 0x00FFFF;
                        if (1440 != iMsgSize)
                        {
                            continue;
                        }
                        //校验
                        ulong checkValue = BitConverter.ToUInt64(buffer, i + 48);
                        if (0x0123456789ABCDEF == checkValue)
                        {//找到了校验值
                            bHasFound = true;
                            if (i != 0)
                            {//说明存在粘包，要把前面的数据清理掉
                                iHasRead = iHasRead - i;
                                Array.Copy(buffer, i, buffer, 0, buffer.Length-i);
                            }
                            break;
                        }
                    }
                    if (!bHasFound)
                    {//如果没找到头，判断数据长度是不是快超过了总长度，超过了，说明数据全都有问题，删掉
                        if (iHasRead >= buffer.Length) iHasRead = 0;
                        continue;
                    }
                    //再次判断字节数是否够
                    if (iHasRead < 1440)
                    {
                        continue;
                    }
                    iHasRead = 0;
                    //按照协议的格式解析数据
                    ParseData(buffer);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("recv thread:" + ex.ToString());
                }
            }
        }

        private void ParseData(byte[] buffer)
        {
            int iStartIndex = 0;

            this.MessageSize = BitConverter.ToInt16(buffer, iStartIndex); //unsigned short
            iStartIndex += 2;

            for (int i = 0; i < this.Reserved1.Length; ++i)
            {
                this.Reserved1[i] = BitConverter.ToInt16(buffer, iStartIndex);
                iStartIndex += 2;
            }

            this.DigitalInputBits = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.DigitalOutputs = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.RobotMode = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.ControllerTimer = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.Time = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.TestValue = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.SafetyMode = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.SpeedScaling = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.LinearMomentumNorm = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.VMain = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.VRobot = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.IRobot = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.ProgramState = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.SafetyStatus = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            for (int i = 0; i < this.ToolAccelerometerValues.Length; ++i)
            {
                this.ToolAccelerometerValues[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.ElbowPosition.Length; ++i)
            {
                this.ElbowPosition[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.ElbowVelocity.Length; ++i)
            {
                this.ElbowVelocity[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.QTarget.Length; ++i)
            {
                this.QTarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.QdTarget.Length; ++i)
            {
                this.QdTarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.QddTarget.Length; ++i)
            {
                this.QddTarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.ITarget.Length; ++i)
            {
                this.ITarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.MTarget.Length; ++i)
            {
                this.MTarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.QActual.Length; ++i)
            {
                this.QActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.QdActual.Length; ++i)
            {
                this.QdActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.IActual.Length; ++i)
            {
                this.IActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.IControl.Length; ++i)
            {
                this.IControl[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.ToolVectorActual.Length; ++i)
            {
                this.ToolVectorActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.TCPSpeedActual.Length; ++i)
            {
                this.TCPSpeedActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.TCPForce.Length; ++i)
            {
                this.TCPForce[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.ToolVectorTarget.Length; ++i)
            {
                this.ToolVectorTarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.TCPSpeedTarget.Length; ++i)
            {
                this.TCPSpeedTarget[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.MotorTempetatures.Length; ++i)
            {
                this.MotorTempetatures[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.JointModes.Length; ++i)
            {
                this.JointModes[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.VActual.Length; ++i)
            {
                this.VActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.Handtype.Length; ++i)
            {
                this.Handtype[i] = buffer[iStartIndex];
                iStartIndex += 1;
            }

            this.User = buffer[iStartIndex];
            iStartIndex += 1;

            this.Tool = buffer[iStartIndex];
            iStartIndex += 1;

            this.RunQueuedCmd = buffer[iStartIndex];
            iStartIndex += 1;

            this.PauseCmdFlag = buffer[iStartIndex];
            iStartIndex += 1;

            this.VelocityRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.AccelerationRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.JerkRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.XYZVelocityRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.RVelocityRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.XYZAccelerationRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.RAccelerationRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.XYZJerkRatio = buffer[iStartIndex];
            iStartIndex += 1;

            this.RJerkRatio = buffer[iStartIndex];
            iStartIndex += 1;

            for (int i = 0; i < this.Reserved2.Length; ++i)
            {
                this.Reserved2[i] = buffer[iStartIndex];
                iStartIndex += 1;
            }

            for (int i = 0; i < this.Actual.Length; ++i)
            {
                this.Actual[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            this.Load = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.CenterX = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.CenterY = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.CenterZ = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            for (int i = 0; i < this.UserValue.Length; ++i)
            {
                this.UserValue[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.Tools.Length; ++i)
            {
                this.Tools[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.Reserved3.Length; ++i)
            {
                this.Reserved3[i] = buffer[iStartIndex];
                iStartIndex += 1;
            }

            this.DataHasRead = true;
        }

        public string ConvertRobotMode()
        {
            switch (this.RobotMode)
            {
                case -1:
                    return "没有控制器";
                case 0:
                    return "没有连接";
                case 1:
                    return "配置安全参数";
                case 2:
                    return "启动";
                case 3:
                    return "下电";
                case 4:
                    return "上电";
                case 5:
                    return "空闲，可以进行操作机械臂";
                case 6:
                    return "拖拽示教模式";
                case 7:
                    return "运行";
                case 8:
                    return "更新固件";
                case 9:
                    return "报警";
            }
            return string.Format("未知：RobotMode={0}", this.RobotMode);
        }
    }
}
