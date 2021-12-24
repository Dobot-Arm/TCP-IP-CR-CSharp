using CSharpTcpDemo.com.dobot.api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpTcpDemo
{
    public partial class MainForm : Form
    {
        private Feedback mFeedback = new Feedback();
        private DobotMove mDobotMove = new DobotMove();
        private Dashboard mDashboard = new Dashboard();

        //定时获取数据并显示到UI
        private System.Timers.Timer mTimerReader = new System.Timers.Timer(500);

        public MainForm()
        {
            InitializeComponent();

            this.textBoxIP.Text = "192.168.5.1";

            this.textBoxSpeed.Text = "10";

            //默认显示joint
            btnXYZR_Click(this, new EventArgs());

            #region +按钮事件
            this.btnAdd1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAdd1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAdd1.Tag = string.Format("J1+");

            this.btnAdd2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAdd2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAdd2.Tag = string.Format("J2+");

            this.btnAdd3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAdd3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAdd3.Tag = string.Format("J3+");

            this.btnAdd4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAdd4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAdd4.Tag = string.Format("J4+");

            this.btnAdd5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAdd5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAdd5.Tag = string.Format("J5+");

            this.btnAdd6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAdd6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAdd6.Tag = string.Format("J6+");
            #endregion

            #region -按钮事件
            this.btnMinus1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinus1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinus1.Tag = string.Format("J1-");

            this.btnMinus2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinus2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinus2.Tag = string.Format("J2-");

            this.btnMinus3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinus3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinus3.Tag = string.Format("J3-");

            this.btnMinus4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinus4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinus4.Tag = string.Format("J4-");

            this.btnMinus5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinus5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinus5.Tag = string.Format("J5-");

            this.btnMinus6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinus6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinus6.Tag = string.Format("J6-");
            #endregion

            #region XYZR+按钮事件
            this.btnAddX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAddX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAddX.Tag = string.Format("X+");

            this.btnAddY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAddY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAddY.Tag = string.Format("Y+");

            this.btnAddZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAddZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAddZ.Tag = string.Format("Z+");

            this.btnAddRX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAddRX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAddRX.Tag = string.Format("Rx+");

            this.btnAddRY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAddRY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAddRY.Tag = string.Format("Ry+");

            this.btnAddRZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnAddRZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnAddRZ.Tag = string.Format("Rz+");
            #endregion

            #region XYZR-按钮事件
            this.btnMinusX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinusX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinusX.Tag = string.Format("X-");

            this.btnMinusY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinusY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinusY.Tag = string.Format("Y-");

            this.btnMinusZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinusZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinusZ.Tag = string.Format("Z-");

            this.btnMinusRX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinusRX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinusRX.Tag = string.Format("Rx-");

            this.btnMinusRY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinusRY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinusRY.Tag = string.Format("Ry-");

            this.btnMinusRZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMoveJogEvent);
            this.btnMinusRZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnStopMoveJogEvent);
            this.btnMinusRZ.Tag = string.Format("Rz-");
            #endregion

            //启动定时器
            mTimerReader.Elapsed += new System.Timers.ElapsedEventHandler(TimeoutEvent);
            mTimerReader.AutoReset = true;

            //默认禁止窗口中的大部分控件
            DisableWindow();
        }

        private void DisableWindow()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is Button)
                {
                    ctr.Enabled = false;
                }
                else if (ctr is Panel)
                {
                    ctr.Enabled = false;
                }
            }
            this.btnConnect.Enabled = true; ;
        }

        private void EnableWindow()
        {
            foreach (Control ctr in this.Controls)
            {
                ctr.Enabled = true;
            }
            this.btnConnect.Enabled = false;
        }
    
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mTimerReader.Close();
            if (this.mFeedback != null)
            {
                this.mFeedback.Disconnect();
            }
            if (this.mDashboard != null)
            {
                this.mDashboard.Disconnect();
            }
        }

        private bool IsValidIP(string strIp)
        {
            try
            {
                IPAddress.Parse(strIp);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void InsertMsgToRichBox(string str)
        {
            if (this.richBoxResult.GetLineFromCharIndex(this.richBoxResult.TextLength) > 500)
            {
                this.richBoxResult.Text = str += "\r\n";
            }
            else
            {
                this.richBoxResult.Text += (str + "\r\n");
            }
            this.richBoxResult.Focus();
            this.richBoxResult.Select(this.richBoxResult.TextLength, 0);
            this.richBoxResult.ScrollToCaret();
        }

        private void PrintLog(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            if (this.richBoxResult.InvokeRequired)
            {
                this.richBoxResult.Invoke(new Action<string>(log=> {
                    InsertMsgToRichBox(log);
                }),str);
            }
            else
            {
                InsertMsgToRichBox(str);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strIp = textBoxIP.Text;
            if (string.IsNullOrEmpty(strIp))
            {
                MessageBox.Show("请输入IP地址");
                return;
            }
            if (!IsValidIP(strIp))
            {
                MessageBox.Show("IP地址输入格式不正确");
                return;
            }

            PrintLog("正在连接设备...");
            Thread thd = new Thread(()=> {
                if (!mFeedback.Connect(strIp))
                {
                    PrintLog(string.Format("连接 {0} 失败!!", strIp));
                    return;
                }
                if (!mDobotMove.Connect(strIp))
                {
                    PrintLog(string.Format("连接 {0} 失败!!", strIp));
                    return;
                }
                if (!mDashboard.Connect(strIp))
                {
                    PrintLog(string.Format("连接 {0} 失败!!", strIp));
                    return;
                }

                mTimerReader.Start();

                PrintLog("连接成功!!!");

                this.Invoke(new Action(()=> {
                    EnableWindow();
                }));
            });
            thd.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            PrintLog("正在断开...");
            Thread thd = new Thread(()=>{
                mFeedback.Disconnect();
                mDobotMove.Disconnect();
                mDashboard.Disconnect();
                PrintLog("断开连接完成!!!");

                mTimerReader.Stop();

                this.Invoke(new Action(()=>{
                    DisableWindow();
                }));
            });
            thd.Start();
        }

        private void btnPowerOn_Click(object sender, EventArgs e)
        {
            PrintLog("正在执行上电动作...");
            Thread thd = new Thread(() =>{
                string strRet = mDashboard.ClearError();
                PrintLog("ClearError: " + strRet);
                strRet = mDashboard.PowerOn();
                PrintLog("PowerOn: " + strRet);
                PrintLog("上电执动作行完毕!!!");
            });
            thd.Start();
        }

        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            PrintLog("正在执行下电动作...");
            Thread thd = new Thread(() =>{
                string strRet = mDashboard.PowerOff();
                PrintLog("PowerOff: " + strRet);
                PrintLog("下电动作执行完毕!!!");
            });
            thd.Start();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            PrintLog("正在执行使能动作...");
            Thread thd = new Thread(() =>{
                string strRet = mDashboard.EnableRobot();
                PrintLog("EnableRobot: " + strRet);
                PrintLog("使能动作执行完毕!!!");
            });
            thd.Start();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            PrintLog("正在执行禁止动作...");
            Thread thd = new Thread(() =>{
                string strRet = mDashboard.DisableRobot();
                PrintLog("DisableRobot: " + strRet);
                PrintLog("禁止动作执行完毕!!!");
            });
            thd.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PrintLog("正在执行清除错误动作...");
            Thread thd = new Thread(() =>{
                string strRet = mDashboard.ClearError();
                PrintLog("ClearError: " + strRet);
                PrintLog("清除错误动作执行完毕!!!");
            });
            thd.Start();
        }

        private void btnSetSpeed_Click(object sender, EventArgs e)
        {
            int iValue = 0;
            try
            {
                iValue = Int32.Parse(this.textBoxSpeed.Text);
            }
            catch
            {
            }
            PrintLog("正在设置速度比例...");
            Thread thd = new Thread(() => {
                string strRet = mDashboard.SpeedFactor(iValue);
                PrintLog("SpeedFactor: " + strRet);
                PrintLog("速度比例设置完毕!!!");
            });
            thd.Start();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.richBoxResult.Clear();
        }

        private void DoMoveJog(string str)
        {
            PrintLog(string.Format("正在执行 {0} 动作...", str));
            Thread thd = new Thread(() =>{
                string ret = mDobotMove.MoveJog(str) ? "成功" : "失败";
                PrintLog(string.Format("{0} 动作执行{1}", str, ret));
            });
            thd.Start();
        }

        private void DoStopMoveJog()
        {
            PrintLog(string.Format("正在下发停止动作..."));
            Thread thd = new Thread(() =>{
                string ret = mDobotMove.StopMoveJog() ? "成功" : "失败";
                PrintLog(string.Format("下发停止动作执行{0}", ret));
            });
            thd.Start();
        }

        private void btnJoint_Click(object sender, EventArgs e)
        {
            this.panelJoint.Hide();
            this.panelXYZR.Show();
        }

        private void btnXYZR_Click(object sender, EventArgs e)
        {
            this.panelJoint.Show();
            this.panelXYZR.Hide();
        }

        private void OnMoveJogEvent(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                string str = btn.Tag.ToString();
                DoMoveJog(str);
            }
        }
        private void OnStopMoveJogEvent(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                DoStopMoveJog();
            }
        }

        private void ShowJointData()
        {
            this.labelNowSpeedFactor.Text = string.Format("当前速度比例：{0:F2}%", mFeedback.SpeedScaling);
            this.labelRobotMode.Text = string.Format("机器人模式：{0}", mFeedback.ConvertRobotMode());

            if (null != mFeedback.QActual && mFeedback.QActual.Length >= 6)
            {
                this.textBoxJt1.Text = string.Format("{0:F3}", mFeedback.QActual[0]);
                this.textBoxJt2.Text = string.Format("{0:F3}", mFeedback.QActual[1]);
                this.textBoxJt3.Text = string.Format("{0:F3}", mFeedback.QActual[2]);
                this.textBoxJt4.Text = string.Format("{0:F3}", mFeedback.QActual[3]);
                this.textBoxJt5.Text = string.Format("{0:F3}", mFeedback.QActual[4]);
                this.textBoxJt6.Text = string.Format("{0:F3}", mFeedback.QActual[5]);
            }
        }
        private void ShowXYZRData()
        {
            this.labelNowSpeedFactor.Text = string.Format("当前速度比例：{0:F2}%", mFeedback.SpeedScaling);
            this.labelRobotMode.Text = string.Format("机器人模式：{0}", mFeedback.ConvertRobotMode());

            if (null != mFeedback.ToolVectorActual && mFeedback.ToolVectorActual.Length >= 6)
            {
                this.textBoxX.Text = string.Format("{0:F3}", mFeedback.ToolVectorActual[0]);
                this.textBoxY.Text = string.Format("{0:F3}", mFeedback.ToolVectorActual[1]);
                this.textBoxZ.Text = string.Format("{0:F3}", mFeedback.ToolVectorActual[2]);
                this.textBoxRX.Text = string.Format("{0:F3}", mFeedback.ToolVectorActual[3]);
                this.textBoxRY.Text = string.Format("{0:F3}", mFeedback.ToolVectorActual[4]);
                this.textBoxRZ.Text = string.Format("{0:F3}", mFeedback.ToolVectorActual[5]);
            }
        }

        private void ShowTextboxData()
        {
            if (this.panelJoint.Visible)
            {
                ShowJointData();
            }
            else
            {
                ShowXYZRData();
            }
        }
        private void TimeoutEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!mFeedback.DataHasRead)
            {
                return;
            }
            mFeedback.DataHasRead = false;

            if (this.labelNowSpeedFactor.InvokeRequired)
            {
                this.labelNowSpeedFactor.Invoke(new Action(() =>{
                    ShowTextboxData();
                }));
            }
            else
            {
                ShowTextboxData();
            }
        }
    }
}
