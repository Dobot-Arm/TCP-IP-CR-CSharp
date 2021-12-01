using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP_IP_CSharp
{
    class Feedback
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress iPAddress;
        IPEndPoint iPEndPoint;


      
        byte[] buffer = new byte[1440];
        #region 数据包解析

        short _Message_Size;

        Int64 _Digital_input_bits;
        Int64 _Digital_outputs;
        Int64 _Robot_Mode;
        Int64 _Controller_Timer;
        Int64 _Time;
        Int64 _test_value;
        double _Safety_Mode;
        double _Speed_scaling;
        double _Linear_momentum_norm;
        double _V_main;
        double _V_robot;
        double _I_robot;
        double _Program_state;
        double _Safety_Status;
        double[] _Tool_Accelerometer_values = new double[3];
        double[] _Elbow_position = new double[3];
        double[] _Elbow_velocity = new double[3];
        double[] _q_target = new double[6];
        double[] _qd_target = new double[6];
        double[] _qdd_target = new double[6];
        double[] _I_target = new double[6];
        double[] _M_target = new double[6];
        double[] _q_actual = new double[6];
        double[] _qd_actual = new double[6];
        double[] _I_actual = new double[6];
        double[] _I_control = new double[6];
        double[] _Tool_vector_actual = new double[6];
        double[] _TCP_speed_actual = new double[6];
        double[] _TCP_force = new double[6];
        double[] _Tool_vector_target = new double[6];
        double[] _TCP_speed_target = new double[6];
        double[] _Motor_temperatures = new double[6];

        double[] _Joint_Modes = new double[6];
        double[] _V_actual = new double[6];

        #endregion
        Thread thread;





        public Feedback(string ip)
        {
           

            try
            {
                iPAddress = IPAddress.Parse(ip);
                iPEndPoint = new IPEndPoint(iPAddress, 30003);
                _socket.Connect(iPEndPoint);
                Console.WriteLine("30003连接成功");
                
                thread = new Thread(Recv);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("连接失败 !" + ex.ToString());

            }
        }

        public short Message_Size { get => _Message_Size; }
        public Int64 Digital_input_bits { get => _Digital_input_bits; }
        public Int64 Digital_outputs { get => _Digital_outputs; }
        public Int64 Robot_Mode { get => _Robot_Mode; }
        public Int64 Controller_Timer { get => _Controller_Timer; }
        public Int64 Time { get => _Time; }
        public Int64 Test_value { get => _test_value; }
        public double Safety_Mode { get => _Safety_Mode; }
        public double Speed_scaling { get => _Speed_scaling; }
        public double Linear_momentum_norm { get => _Linear_momentum_norm; }
        public double V_main { get => _V_main; }
        public double V_robot { get => _V_robot; }

        public double I_robot { get => _I_robot; }
        public double Program_state { get => _Program_state; }
        public double Safety_Status { get => _Safety_Status; }
        public double[] Tool_Accelerometer_values { get => _Tool_Accelerometer_values; }
        public double[] Elbow_position { get => Elbow_position1; }
        public double[] Elbow_position1 { get => _Elbow_position; }
        public double[] Elbow_velocity { get => _Elbow_velocity; }
        public double[] Q_target { get => _q_target; }
        public double[] Qd_target { get => _qd_target; }
        public double[] Qdd_target { get => Qdd_target1; }
        public double[] Qdd_target1 { get => _qdd_target; }
        public double[] I_target { get => _I_target; }
        public double[] M_target { get => _M_target; }
        public double[] Q_actual { get => _q_actual; }
        public double[] Qd_actual { get => _qd_actual; }
        public double[] I_actual { get => _I_actual; }
        public double[] I_control { get => _I_control; }
        public double[] Tool_vector_actual { get => _Tool_vector_actual; }
        public double[] TCP_speed_actual { get => _TCP_speed_actual; }
        public double[] TCP_force { get => _TCP_force; }
        public double[] Tool_vector_target { get => _Tool_vector_target; }
        public double[] TCP_speed_target { get => _TCP_speed_target; }
        public double[] Motor_temperatures { get => _Motor_temperatures; }
        public double[] Joint_Modes1 { get => _Joint_Modes; }
        public double[] V_actual1 { get => _V_actual; }
        public void MoveJ(double x, double y, double z, double a, double b, double c)
        {
            string str = String.Format("MovJ({0},{1},{2},{3},{4},{5})", x, y, z, a, b, c);
            Console.WriteLine(str);
            _socket.Send(Encoding.UTF8.GetBytes(str));
          
        }

        public void MoveL(double x, double y, double z, double a, double b, double c)
        {
            string str = String.Format("MovL({0},{1},{2},{3},{4},{5})", x, y, z, a, b, c);
            Console.WriteLine(str);
            _socket.Send(Encoding.UTF8.GetBytes(str));
          
        }



        public void JointMovJ(double x, double y, double z, double a, double b, double c)
        {
            string str = String.Format("JointMovJ({0},{1},{2},{3},{4},{5})", x, y, z, a, b, c);
            Console.WriteLine(str);
            _socket.Send(Encoding.UTF8.GetBytes(str));
          
        }



        public void RelMovJ(double x, double y, double z, double a, double b, double c)
        {
            string str = String.Format("RelMovJ({0},{1},{2},{3},{4},{5})", x, y, z, a, b, c);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
           
        }




        public void RelMovL(double x, double y, double z)
        {
            string str = String.Format("RelMovL({0},{1},{2})", x, y, z);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
           
        }


        public void MovLIO(double x, double y, double z, double a, double b, double c, List<MoveIOEnum> moveIOEnums)
        {
            string str = String.Format("MovLIO({0},{1},{2},{3},{4},{5}", x, y, z, a, b, c);
            for (int i = 0; i < moveIOEnums.Count; i++)
            {
                str = str + String.Format(",{{0},{1},{2},{3}}", moveIOEnums[i].mode, moveIOEnums[i].distance, moveIOEnums[i].index, moveIOEnums[i].status);
            }
            str = str + ")";
            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
          
        }

        public void MovJIO(double x, double y, double z, double a, double b, double c, List<MoveIOEnum> moveIOEnums)
        {
            string str = String.Format("MovJIO({0},{1},{2},{3},{4},{5}", x, y, z, a, b, c);
            for (int i = 0; i < moveIOEnums.Count; i++)
            {
                str = str + String.Format(",{{0},{1},{2},{3}}", moveIOEnums[i].mode, moveIOEnums[i].distance, moveIOEnums[i].index, moveIOEnums[i].status);
            }
            str = str + ")";
            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
           
        }



        public void Arc(double x1, double y1, double z1, double a1, double b1, double c1, double x2, double y2, double z2, double a2, double b2, double c2)
        {
            string str = String.Format("Arc({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})", x1, y1, z1, a1, b1, c1, x2, y2, z2, a2, b2, c2);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
          
        }
        public void Circle(int count, double x1, double y1, double z1, double a1, double b1, double c1, double x2, double y2, double z2, double a2, double b2, double c2)
        {
            string str = String.Format("Circle({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})", count, x1, y1, z1, a1, b1, c1, x2, y2, z2, a2, b2, c2);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
           
        }


        public void MoveJog(string s)
        {
            string str;
            if (s != "stop")
            {
                str = "MoveJog(" + s + ")";

            }
            else
            {
                str = "MoveJog()";
            }


            _socket.Send(Encoding.UTF8.GetBytes(str));
            Console.WriteLine(str);
          

        }

        void Recv()
        {
            while (true)
            {
                try
                {

                    buffer = new byte[1440];
                    int r = _socket.Receive(buffer);
                    //Console.WriteLine(r);
                    if (r == 0)
                    {


                        //   thread.
                        break;
                    }
                    //  File.WriteAllText(Application.StartupPath + "\\ProgramData.ini", JsonConvert.SerializeObject(buffer));
                    // buffer = copy.Skip(0).Take(1440).ToArray();
                    _Message_Size = BitConverter.ToInt16(buffer, 0);
                    _Digital_input_bits = BitConverter.ToInt64(buffer, 8);
                    _Digital_outputs = BitConverter.ToInt64(buffer, 16);
                    _Robot_Mode = BitConverter.ToInt64(buffer, 24);
                    _Controller_Timer = BitConverter.ToInt64(buffer, 32);
                    _Time = BitConverter.ToInt64(buffer, 40);
                    _test_value = BitConverter.ToInt64(buffer, 48);
                    _Safety_Mode = BitConverter.ToDouble(buffer, 56);
                    _Speed_scaling = BitConverter.ToDouble(buffer, 64);
                    _Linear_momentum_norm = BitConverter.ToDouble(buffer, 72);
                    _V_main = BitConverter.ToDouble(buffer, 80);
                    _V_robot = BitConverter.ToDouble(buffer, 88);
                    _I_robot = BitConverter.ToDouble(buffer, 96);
                    _Program_state = BitConverter.ToDouble(buffer, 104);
                    _Safety_Status = BitConverter.ToDouble(buffer, 112);
                    for (int i = 0; i < 3; i++)
                    {
                        _Tool_Accelerometer_values[i] = BitConverter.ToDouble(buffer, 120 + i * 8);//120-143
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        _Elbow_position[i] = BitConverter.ToDouble(buffer, 144 + i * 8);//120-143
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        _Elbow_velocity[i] = BitConverter.ToDouble(buffer, 168 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _q_target[i] = BitConverter.ToDouble(buffer, 192 + i * 8);//120-143
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        _qd_target[i] = BitConverter.ToDouble(buffer, 240 + i * 8);//120-143
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        _qdd_target[i] = BitConverter.ToDouble(buffer, 288 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _I_target[i] = BitConverter.ToDouble(buffer, 336 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _M_target[i] = BitConverter.ToDouble(buffer, 384 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _q_actual[i] = BitConverter.ToDouble(buffer, 432 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _qd_actual[i] = BitConverter.ToDouble(buffer, 480 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _I_actual[i] = BitConverter.ToDouble(buffer, 528 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _I_control[i] = BitConverter.ToDouble(buffer, 576 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _Tool_vector_actual[i] = BitConverter.ToDouble(buffer, 624 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _TCP_speed_actual[i] = BitConverter.ToDouble(buffer, 672 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _TCP_force[i] = BitConverter.ToDouble(buffer, 720 + i * 8);//120-143
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        _Tool_vector_target[i] = BitConverter.ToDouble(buffer, 768 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _TCP_speed_target[i] = BitConverter.ToDouble(buffer, 816 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _Motor_temperatures[i] = BitConverter.ToDouble(buffer, 864 + i * 8);//120-143
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        _Joint_Modes[i] = BitConverter.ToDouble(buffer, 912 + i * 8);//120-143
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        _V_actual[i] = BitConverter.ToDouble(buffer, 960 + i * 8);//120-143
                    }





                }
                catch (Exception ex)
                {


                }
                Thread.Sleep(5);
            }

        }
        public void Close()
        {
            try
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                thread.Abort();
            }
            catch (Exception)
            {


            }
        }

    }
    public struct MoveIOEnum
    {
        public int mode;//0----distance是距离百分比，1-----distance是离起始点的或目标点距离
        public int distance;//运行指定的距离:  若Mode为0，则Distance表示起始点与目标点之间距离的百分比，取值范围：0~100; 若Distance取值为正，则表示离起始点的距离; 若Distance取值为负，则表示离目标点的距离
        public int index;
        public int status;

    }



    class Dashboard
    {
     
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress iPAddress;
        IPEndPoint iPEndPoint;
        public Dashboard(string ip)
        {
          
            try
            {
                iPAddress = IPAddress.Parse(ip);
                iPEndPoint = new IPEndPoint(iPAddress, 29999);
                _socket.Connect(iPEndPoint);
                Console.WriteLine("29999连接成功");
             

            }
            catch (Exception ex)
            {

                Console.WriteLine ("连接失败 !" + ex.ToString());

            }
        }

        public string EmergencyStop()
        {
            string str = "EmergencyStop()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
          
            return WaitReply();
        }
        public string EnableRobot()
        {
            string str = "EnableRobot()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
         
            return WaitReply();
        }

        public string DisableRobot()
        {
            string str = "DisableRobot()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }
        public string ClearError()
        {
            string str = "ClearError()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }





        public string ResetRobot()
        {
            string str = "ResetRobot()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }

        public string SpeedFactor(int ratio)
        {
            string str = String.Format("SpeedFactor({0})", ratio);
            byte[] aq = Encoding.UTF8.GetBytes(str);
            _socket.Send(Encoding.UTF8.GetBytes(str));
         
            return WaitReply();
        }


        public string User(int index)
        {
            string str = String.Format("User({0})", index);
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }


        public string Tool(int index)
        {
            string str = String.Format("Tool({0})", index);
            _socket.Send(Encoding.UTF8.GetBytes(str));
          
            return WaitReply();
        }


        public string RobotMode()
        {
            string str = "RobotMode()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
          
            return WaitReply();
        }


        public string PayLoad(float weight, float inertia)
        {
            string str = String.Format("PayLoad({0},{1})", weight, inertia);
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }

        public string DO(int index, int val)
        {
            string str = String.Format("DO({0},{1})", index, val);
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }




        public string DOExecute(int index, int val)
        {
            string str = String.Format("DOExecute({0},{1})", index, val);
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }


        public string ToolDO(int index, int val)
        {
            string str = String.Format("ToolDO({0},{1})", index, val);
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }




        public string ToolDOExecute(int index, int val)
        {
            string str = String.Format("ToolDOExecute({0},{1})", index, val);
            _socket.Send(Encoding.UTF8.GetBytes(str));
           
            return WaitReply();
        }





        public string AO(int index, float val)
        {
            string str = String.Format("AO({0},{1})", index, val);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }





        public string AOExecute(int index, float val)
        {
            string str = String.Format("AOExecute({0},{1})", index, val);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }


        public string AccJ(int speed)
        {
            string str = String.Format("AccJ({0})", speed);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }




        public string AccL(int speed)
        {
            string str = String.Format("AccL({0})", speed);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }



        public string SpeedJ(int speed)
        {
            string str = String.Format("SpeedJ({0})", speed);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }




        public string SpeedL(int speed)
        {
            string str = String.Format("SpeedL({0})", speed);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }




        public string Arch(int index)
        {
            string str = String.Format("Arch({0})", index);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }

        public string CP(int ratio)
        {
            string str = String.Format("CP({0})", ratio);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }





        public string LimZ(int value)
        {
            string str = String.Format("LimZ({0})", value);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }

        public string SetArmOrientation(int r, int d, int n, int cfg)
        {
            string str = String.Format("SetArmOrientation({0},{1},{2},{3})", r, d, n, cfg);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }

        public string PowerOn()
        {
            string str = "PowerOn()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }



        public string RunScript(string project_name)
        {
            string str = String.Format("RunScript({0})", project_name);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }



        public string StopScript()
        {
            string str = "StopScript()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }



        public string PauseScript()
        {
            string str = "PauseScript()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }


        public string ContinueScript()
        {
            string str = "ContinueScript()";
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }


        public string GetHoldRegs(int id, int add, int count, string type)
        {
            string str = String.Format("GetHoldRegs({0},{1},{2},{3})", id, add, count, type);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }

        public string SetHoldRegs(int id, int add, int count, int table, string type)
        {
            string str = String.Format("SetHoldRegs({0},{1},{2},{3},{4})", id, add, count, table, type);
            _socket.Send(Encoding.UTF8.GetBytes(str));
            return WaitReply();
        }


        string WaitReply()
        {
            byte[] buffer = new byte[1024];
            int length = _socket.Receive(buffer);
            string r = Encoding.UTF8.GetString(buffer, 0, length);
            Console.WriteLine(r);
            return r;
        }

        public void Close()
        {
            try
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            catch (Exception)
            {


            }        
        }
    }
}
