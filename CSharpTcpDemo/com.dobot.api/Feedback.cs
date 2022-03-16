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
        public short MessageSize { get; private set; } //消息字节总长度

        public short[] Reserved1 { get; private set; } //保留位

        public long DigitalInputs { get; private set; } //数字输入
        public long DigitalOutputs { get; private set; } //数字输出
        public long RobotMode { get; private set; } //机器人模式
        public long TimeStamp { get; private set; } //时间戳（单位ms）

        public long Reserved2 { get; private set; } //保留位

        public long TestValue { get; private set; } //内存结构测试标准值  0x0123 4567 89AB CDEF

        public double Reserved3 { get; private set; } //保留位

        public double SpeedScaling { get; private set; } //速度比例
        public double LinearMomentumNorm { get; private set; } //机器人当前动量
        public double VMain { get; private set; } //控制板电压
        public double VRobot { get; private set; } //机器人电压
        public double IRobot { get; private set; } //机器人电流

        public double Reserved4 { get; private set; } //保留位
        public double Reserved5 { get; private set; } //保留位

        public double[] ToolAccelerometerValues { get; private set;} //TCP加速度
        public double[] ElbowPosition { get; private set; } //肘位置
        public double[] ElbowVelocity { get; private set; } //肘速度

        public double[] QTarget { get; private set; } //目标关节位置
        public double[] QdTarget { get; private set; } //目标关节速度
        public double[] QddTarget { get; private set; } //目标关节加速度
        public double[] ITarget { get; private set; } //目标关节加速度
        public double[] MTarget { get; private set; } //目标关节电流
        public double[] QActual { get; private set; } //实际关节位置
        public double[] QdActual { get; private set; } //实际关节速度
        public double[] IActual { get; private set; } //实际关节电流
        public double[] IControl { get; private set; } //TCP传感器力值
        public double[] ToolVectorActual { get; private set; } //TCP笛卡尔实际坐标值
        public double[] TCPSpeedActual { get; private set; } //TCP笛卡尔实际速度值
        public double[] TCPForce { get; private set; } //TCP力值
        public double[] ToolVectorTarget { get; private set; } //TCP笛卡尔目标坐标值
        public double[] TCPSpeedTarget { get; private set; } //TCP笛卡尔目标速度值
        public double[] MotorTempetatures { get; private set; } //关节温度
        public double[] JointModes { get; private set; } //关节控制模式
        public double[] VActual { get; private set; } //关节电压

        public byte[] Handtype { get; private set; } //手系
        public byte User { get; private set; } //用户坐标
        public byte Tool { get; private set; } //工具坐标
        public byte RunQueuedCmd { get; private set; } //算法队列运行标志
        public byte PauseCmdFlag { get; private set; } //算法队列暂停标志
        public byte VelocityRatio { get; private set; } //关节速度比例(0~100)
        public byte AccelerationRatio { get; private set; } //关节加速度比例(0~100)
        public byte JerkRatio { get; private set; } //关节加加速度比例(0~100)
        public byte XYZVelocityRatio { get; private set; } //笛卡尔位置速度比例(0~100)
        public byte RVelocityRatio { get; private set; } //笛卡尔姿态速度比例(0~100)
        public byte XYZAccelerationRatio { get; private set; } //笛卡尔位置加速度比例(0~100)
        public byte RAccelerationRatio { get; private set; } //笛卡尔姿态加速度比例(0~100)
        public byte XYZJerkRatio { get; private set; } //笛卡尔位置加加速度比例(0~100)
        public byte RJerkRatio { get; private set; } //笛卡尔姿态加加速度比例(0~100)

        public byte BrakeStatus { get; private set; } //机器人抱闸状态
        public byte EnableStatus { get; private set; } //机器人使能状态
        public byte DragStatus { get; private set; } //机器人拖拽状态
        public byte RunningStatus { get; private set; } //机器人运行状态
        public byte ErrorStatus { get; private set; } //机器人报警状态
        public byte JogStatus { get; private set; } //机器人点动状态
        public byte RobotType { get; private set; } //机器类型
        public byte DragButtonSignal { get; private set; } //按钮板拖拽信号
        public byte EnableButtonSignal { get; private set; } //按钮板使能信号
        public byte RecordButtonSignal { get; private set; } //按钮板录制信号
        public byte ReappearButtonSignal { get; private set; } //按钮板复现信号
        public byte JawButtonSignal { get; private set; } //按钮板夹爪控制信号
        public byte SixForceOnline { get; private set; } //六维力在线状态

        public byte[] Reserved6 { get; private set; } //保留位

        public double[] MActual { get; private set; } //实际扭矩

        public double Load { get; private set; } //负载重量kg
        public double CenterX { get; private set; } //X方向偏心距离mm
        public double CenterY { get; private set; } //Y方向偏心距离mm
        public double CenterZ { get; private set; } //Z方向偏心距离mm
        public double[] UserValu { get; private set; } //用户坐标值
        public double[] Tools { get; private set; } //工具坐标值
        public double TraceIndex { get; private set; } //轨迹复现运行索引
        public double[] SixForceValue { get; private set; } //当前六维力数据原始值
        public double[] TargetQuaternion { get; private set; } //[qw,qx,qy,qz] 目标四元数
        public double[] ActualQuaternion { get; private set; } //[qw,qx,qy,qz]  实际四元数

        public byte[] Reserved7 { get; private set; } //保留位

        #endregion

        public bool DataHasRead { get; set; }

        public string IP { get; private set; }
        public int Port { get; private set; }

        public Feedback()
        {
            #region 数据包解析
            this.MessageSize = 0;

            this.Reserved1 = new short[3];

            this.DigitalInputs = 0;
            this.DigitalOutputs = 0;
            this.RobotMode = 0;
            this.TimeStamp = 0;

            this.Reserved2 = 0;
            this.TestValue = 0;
            this.Reserved3 = 0;

            this.SpeedScaling = 0;
            this.LinearMomentumNorm = 0;
            this.VMain = 0;
            this.VRobot = 0;
            this.IRobot = 0;

            this.Reserved4 = 0;
            this.Reserved5 = 0;

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

            this.BrakeStatus = 0;
            this.EnableStatus = 0;
            this.DragStatus = 0;
            this.RunningStatus = 0;
            this.ErrorStatus = 0;
            this.JogStatus = 0;
            this.RobotType = 0;
            this.DragButtonSignal = 0;
            this.EnableButtonSignal = 0;
            this.RecordButtonSignal = 0;
            this.ReappearButtonSignal = 0;
            this.JawButtonSignal = 0;
            this.SixForceOnline = 0;

            this.Reserved6 = new byte[82];

            this.MActual = new double[6];
            this.Load = 0;
            this.CenterX = 0;
            this.CenterY = 0;
            this.CenterZ = 0;
            this.UserValu = new double[6];
            this.Tools = new double[6];
            this.TraceIndex = 0;
            this.SixForceValue = new double[6];
            this.TargetQuaternion = new double[4];
            this.ActualQuaternion = new double[4];

            this.Reserved7 = new byte[24];
            #endregion
        }

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
                IPEndPoint endpt = new IPEndPoint(addr, iPort);//30004

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

        /// <summary>
        /// 接收返回的数据并解析处理
        /// </summary>
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
                    iHasRead = iHasRead - 1440;
                    //按照协议的格式解析数据
                    ParseData(buffer);
                    Array.Copy(buffer, 1440, buffer, 0, buffer.Length - 1440);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("recv thread:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="buffer">一包完整的数据</param>
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

            this.DigitalInputs = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.DigitalOutputs = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.RobotMode = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.TimeStamp = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.Reserved2 = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.TestValue = BitConverter.ToInt64(buffer, iStartIndex);
            iStartIndex += 8;

            this.Reserved3 = BitConverter.ToInt64(buffer, iStartIndex);
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

            this.Reserved4 = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            this.Reserved5 = BitConverter.ToDouble(buffer, iStartIndex);
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

            this.BrakeStatus = buffer[iStartIndex];
            iStartIndex += 1;
            this.EnableStatus = buffer[iStartIndex];
            iStartIndex += 1;
            this.DragStatus = buffer[iStartIndex];
            iStartIndex += 1;
            this.RunningStatus = buffer[iStartIndex];
            iStartIndex += 1;
            this.ErrorStatus = buffer[iStartIndex];
            iStartIndex += 1;
            this.JogStatus = buffer[iStartIndex];
            iStartIndex += 1;
            this.RobotType = buffer[iStartIndex];
            iStartIndex += 1;
            this.DragButtonSignal = buffer[iStartIndex];
            iStartIndex += 1;
            this.EnableButtonSignal = buffer[iStartIndex];
            iStartIndex += 1;
            this.RecordButtonSignal = buffer[iStartIndex];
            iStartIndex += 1;
            this.ReappearButtonSignal = buffer[iStartIndex];
            iStartIndex += 1;
            this.JawButtonSignal = buffer[iStartIndex];
            iStartIndex += 1;
            this.SixForceOnline = buffer[iStartIndex];
            iStartIndex += 1;

            for (int i = 0; i < this.Reserved6.Length; ++i)
            {
                this.Reserved6[i] = buffer[iStartIndex];
                iStartIndex += 1;
            }

            for (int i = 0; i < this.MActual.Length; ++i)
            {
                this.MActual[i] = BitConverter.ToDouble(buffer, iStartIndex);
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

            for (int i = 0; i < this.UserValu.Length; ++i)
            {
                this.UserValu[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.Tools.Length; ++i)
            {
                this.Tools[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            this.TraceIndex = BitConverter.ToDouble(buffer, iStartIndex);
            iStartIndex += 8;

            for (int i = 0; i < this.SixForceValue.Length; ++i)
            {
                this.SixForceValue[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.TargetQuaternion.Length; ++i)
            {
                this.TargetQuaternion[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.ActualQuaternion.Length; ++i)
            {
                this.ActualQuaternion[i] = BitConverter.ToDouble(buffer, iStartIndex);
                iStartIndex += 8;
            }

            for (int i = 0; i < this.Reserved7.Length; ++i)
            {
                this.Reserved7[i] = buffer[iStartIndex];
                iStartIndex += 1;
            }

            this.DataHasRead = true;
        }

        public string ConvertRobotMode()
        {
            switch (this.RobotMode)
            {
                case -1:
                    return "NO_CONTROLLER";
                case 0:
                    return "NO_CONNECTED";
                case 1:
                    return "ROBOT_MODE_INIT";
                case 2:
                    return "ROBOT_MODE_BRAKE_OPEN";
                case 3:
                    return "ROBOT_RESERVED";
                case 4:
                    return "ROBOT_MODE_DISABLED";
                case 5:
                    return "ROBOT_MODE_ENABLE";
                case 6:
                    return "ROBOT_MODE_BACKDRIVE";
                case 7:
                    return "ROBOT_MODE_RUNNING";
                case 8:
                    return "ROBOT_MODE_RECORDING";
                case 9:
                    return "ROBOT_MODE_ERROR";
                case 10:
                    return "ROBOT_MODE_PAUSE";
                case 11:
                    return "ROBOT_MODE_JOG";
            }
            return string.Format("UNKNOW：RobotMode={0}", this.RobotMode);
        }
    }
}
