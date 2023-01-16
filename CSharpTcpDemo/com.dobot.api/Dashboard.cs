using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharpTcpDemo.com.dobot.api
{
    class Dashboard : DobotClient
    {
        protected override void OnConnected(Socket sock)
        {
            sock.SendTimeout = 5000;
            sock.ReceiveTimeout = 5000;
        }

        protected override void OnDisconnected()
        {
        }

        /// <summary>
        /// 复位，用于清除错误 "Reset to clear errors"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string ClearError()
        {
            return ExecuteCommand("ClearError()");
        }

        /// <summary>
        /// 机器人上电 "The robot is powered on"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string PowerOn()
        {
            return ExecuteCommand("PowerOn()");
        }

        /// <summary>
        /// 急停 "Emergency stop"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string PowerOff()
        {
            return EmergencyStop();
        }

        /// <summary>
        /// 急停 "Emergency stop"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string EmergencyStop()
        {
            return ExecuteCommand("EmergencyStop()");
        }

        /// <summary>
        /// 使能机器人 "Enable the robot"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string EnableRobot()
        {
            return ExecuteCommand("EnableRobot()");
        }

        /// <summary>
        /// 下使能机器人 "Under enable the robot"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string DisableRobot()
        {
            return ExecuteCommand("DisableRobot()");
        }

        /// <summary>
        /// 机器人停止 "The robot stops"
        /// </summary>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string ResetRobot()
        {
            return ExecuteCommand("ResetRobot()");
        }

        /// <summary>
        /// 设置全局速度比例。 "Set the global speed scale."
        /// </summary>
        /// <param name="ratio">运动速度比例，取值范围 "Motion speed ratio, value range"：1~100</param>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string SpeedFactor(int ratio)
        {
            return ExecuteCommand(String.Format("SpeedFactor({0})", ratio));
        }

        /// <summary>
        /// 设置数字输出端口状态（队列指令） "Setting Digital Output Port Status (Queue Instruction)"
        /// </summary>
        /// <param name="index">数字输出索引，取值范围 "Digital output index, value range"：1~16或 "or" 100~1000</param>
        /// <param name="status">数字输出端口状态 "Digital output port status"，true：高电平 "High level"；false：低电平 "Low level"</param>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string DigitalOutputs(int index, bool status)
        {
            return ExecuteCommand(String.Format("DO({0},{1})", index, status ? 1 : 0));
        }

        /// <summary>
        /// 设置末端数字输出端口状态（队列指令） "Set End Digital Output Port Status (Queue Instruction)"
        /// </summary>
        /// <param name="index">数字输出索引 "Digital output index"</param>
        /// <param name="status">数字输出端口状态 "Digital output port status"，true：高电平 "High level"；false：低电平 "Low level"</param>
        /// <returns>返回执行结果的描述信息 "Returns a description of the execution result"</returns>
        public string ToolDO(int index, bool status)
        {
            return ExecuteCommand(String.Format("ToolDO({0},{1})", index, status ? 1 : 0));
        }

        public string GetErrorID()
        {
            return ExecuteCommand("GetErrorID()");
        }

        public string RunScript(string scriptName)
        {
            return ExecuteCommand("RunScript(" + scriptName + ")");
        }

        public string PauseScript()
        {
            return ExecuteCommand("PauseScript()");
        }

        public string ContinueScript()
        {
            return ExecuteCommand("ContinueScript()");
        }

        public string StopScript()
        {
            return ExecuteCommand("StopScript()");
        }

        private string ExecuteCommand(string str)
        {
            if (!IsConnected())
            {
                return "Device is not connected!!!";
            }

            if (!SendData(str))
            {
                return str + ":send error";
            }

            return WaitReply(5000);
        }
    }
}
