using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP_IP_CSharp
{
    class Program
    {

      static  Feedback feedback;
        static Dashboard dashboard;
        static void Main(string[] args)
        {
            feedback = new Feedback("192.168.5.1");
            dashboard= new Dashboard("192.168.5.1");
            ShowMes();
            dashboard.ClearError();
            Thread.Sleep(100);
            dashboard.EnableRobot();
            Thread.Sleep(100);
            dashboard.User(0);
            Thread.Sleep(100);
            dashboard.Tool(0);
            Thread.Sleep(100);
            dashboard.SpeedFactor(10);
            Thread.Sleep(100);
            feedback.JointMovJ(90, 0, -90, 0, 90, 0);
            Thread.Sleep(100);
            feedback.JointMovJ(90, 0, -90, 0, 90, 50);
            Thread.Sleep(100);
            feedback.JointMovJ(90, 0, -90, 0, 90, 0);

            Console.ReadKey();
            feedback.Close();
            dashboard.Close();
        }
       
       static void ShowMes()
        {
            Task task = new Task(new Action(() =>
            {
                Console.WriteLine("内存结构测试标准值：{0}\r\n---------------------------------------------------------------", feedback.Test_value.ToString("X"));
                Thread.Sleep(1000);
                while (true)
                {
                    Console.WriteLine("---------------------------------------------------------------\r\n" + "数据包长度：" + feedback.Message_Size.ToString() + "机器人模式：" + feedback.Robot_Mode.ToString()
                                  + "TCP笛卡尔实际坐标值：" + feedback.Tool_vector_actual[0].ToString("F2") + "," + feedback.Tool_vector_actual[1].ToString("F2") + "," + feedback.Tool_vector_actual[2].ToString("F2") + "," + feedback.Tool_vector_actual[3].ToString("F2") + "," + feedback.Tool_vector_actual[4].ToString("F2") + "," + feedback.Tool_vector_actual[5].ToString("F2")
                                  + "实际关节位置：" + feedback.Q_actual[0].ToString("F2") + "," + feedback.Q_actual[1].ToString("F2") + "," + feedback.Q_actual[2].ToString("F2") + "," + feedback.Q_actual[3].ToString("F2") + "," + feedback.Q_actual[4].ToString("F2") + "," + feedback.Q_actual[5].ToString("F2")
                                 );
                   
                    Thread.Sleep(300);
                }
            }));
            task.Start();
        }
    }
}
