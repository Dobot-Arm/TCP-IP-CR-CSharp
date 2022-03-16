using CSharpTcpDemo.com.dobot.api;
using CSharpTcpDemo.com.dobot.api.com.dobot.api.bean;
using CSharthiscpDemo.com.dobot.api;
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
        private System.Timers.Timer mTimerReader = new System.Timers.Timer(300);

        public MainForm()
        {
            InitializeComponent();

            this.textBoxIP.Text = "192.168.5.1";
            this.textBoxDashboardPort.Text = "29999";
            this.textBoxMovePort.Text = "30003";
            this.textBoxFeedbackPort.Text = "30004";
            this.textBoxSpeedRatio.Text = "10";

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

            string strPath = System.Windows.Forms.Application.StartupPath + "\\";
            ErrorInfoHelper.AddJsonFromFile(strPath+ "alarm_controller.json", "Controller");
            ErrorInfoHelper.AddJsonFromFile(strPath + "alarm_servo.json", "Servo");
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
            if (this.mDobotMove != null)
            {
                this.mDobotMove.Disconnect();
            }
        }
        private void InsertLogToRichBox(RichTextBox box, string str)
        {
            if (box.GetLineFromCharIndex(box.TextLength) > 100)
            {
                box.Text = (str += "\r\n");
            }
            else
            {
                box.Text += (str + "\r\n");
            }
            box.Focus();
            box.Select(box.TextLength, 0);
            box.ScrollToCaret();
        }
        private void PrintLog(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            if (this.richTextBoxLog.InvokeRequired)
            {
                this.richTextBoxLog.Invoke(new Action<string>(log => {
                    InsertLogToRichBox(this.richTextBoxLog, log);
                }), str);
            }
            else
            {
                InsertLogToRichBox(this.richTextBoxLog, str);
            }
        }
        private void PrintErrorInfo(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            if (this.richTextBoxErrInfo.InvokeRequired)
            {
                this.richTextBoxErrInfo.Invoke(new Action<string>(log => {
                    InsertLogToRichBox(this.richTextBoxErrInfo, log);
                }), str);
            }
            else
            {
                InsertLogToRichBox(this.richTextBoxErrInfo, str);
            }
        }

        private void DisableWindow()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr == this.groupBoxConnect)
                {
                    ctr.Enabled = true;
                }
                else if (ctr == this.groupBoxLog)
                {
                    ctr.Enabled = true;
                }
                else
                {
                    ctr.Enabled = false;
                }
            }
        }
        private void EnableWindow()
        {
            foreach (Control ctr in this.Controls)
            {
                ctr.Enabled = true;
            }
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

        private void DoMoveJog(string str)
        {
            PrintLog(string.Format("send to {0}:{1}: MoveJog({2})", mDobotMove.IP,mDobotMove.Port,str));
            Thread thd = new Thread(() => {
                string ret = mDobotMove.MoveJog(str);
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDobotMove.IP, mDobotMove.Port, ret));
            });
            thd.Start();
        }

        private void DoStopMoveJog()
        {
            PrintLog(string.Format("send to {0}:{1}: MoveJog()", mDobotMove.IP, mDobotMove.Port));
            Thread thd = new Thread(() => {
                string ret = mDobotMove.StopMoveJog();
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDobotMove.IP, mDobotMove.Port, ret));
            });
            thd.Start();
        }
        private void TimeoutEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!mFeedback.DataHasRead)
            {
                return;
            }
            mFeedback.DataHasRead = false;
            if (this.labDI.InvokeRequired)
            {
                this.labDI.Invoke(new Action(() => {
                    ShowDataResult();
                }));
            }
            else
            {
                ShowDataResult();
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
        private int Parse2Int(string str)
        {
            int iValue = 0;
            try
            {
                iValue = int.Parse(str);
            }
            catch
            {
            }
            return iValue;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.btnConnect.Text.Equals("Disconnect"))
            {
                Disconnect();
                return;
            }
            Connect();
        }

        private void Connect()
        {
            string strIp = textBoxIP.Text;
            if (!IsValidIP(strIp))
            {
                MessageBox.Show("IP Address Invalid");
                return;
            }
            int iPortFeedback = Parse2Int(this.textBoxFeedbackPort.Text);
            int iPortMove = Parse2Int(this.textBoxMovePort.Text);
            int iPortDashboard = Parse2Int(this.textBoxDashboardPort.Text);

            PrintLog("Connecting...");
            Thread thd = new Thread(() => {
                if (!mDashboard.Connect(strIp, iPortDashboard))
                {
                    PrintLog(string.Format("Connect {0}:{1} Fail!!", strIp, iPortDashboard));
                    return;
                }
                if (!mDobotMove.Connect(strIp, iPortMove))
                {
                    PrintLog(string.Format("Connect {0}:{1} Fail!!", strIp, iPortMove));
                    return;
                }
                if (!mFeedback.Connect(strIp, iPortFeedback))
                {
                    PrintLog(string.Format("Connect {0}:{1} Fail!!", strIp, iPortFeedback));
                    return;
                }

                mTimerReader.Start();

                PrintLog("Connect Success!!!");

                this.Invoke(new Action(() => {
                    EnableWindow();
                    this.btnConnect.Text = "Disconnect";
                }));
            });
            thd.Start();
        }

        private void Disconnect()
        {
            PrintLog("Disconnecting...");
            Thread thd = new Thread(() => {
                mFeedback.Disconnect();
                mDobotMove.Disconnect();
                mDashboard.Disconnect();
                PrintLog("Disconnect success!!!");

                mTimerReader.Stop();

                this.Invoke(new Action(() => {
                    DisableWindow();
                    this.btnConnect.Text = "Connect";
                }));
            });
            thd.Start();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            bool bEnable = this.btnEnable.Text.Equals("Enable");

            PrintLog(string.Format("send to {0}:{1}: {2}()", mDashboard.IP, mDashboard.Port, bEnable? "EnableRobot" : "DisableRobot"));
            Thread thd = new Thread(() => {
                string ret = bEnable ? mDashboard.EnableRobot() : mDashboard.DisableRobot();
                bool bOk = ParseResult(ret);

                this.btnEnable.Invoke(new Action(() => {
                    if (bOk)
                    {
                        this.btnEnable.Text = bEnable ? "Disable" : "Enable";
                    }
                }));

                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDashboard.IP, mDashboard.Port, ret));
            });
            thd.Start();
        }

        private void btnResetRobot_Click(object sender, EventArgs e)
        {
            PrintLog(string.Format("send to {0}:{1}: ResetRobot()", mDashboard.IP, mDashboard.Port));
            Thread thd = new Thread(() => {
                string ret = mDashboard.ResetRobot();
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDashboard.IP, mDashboard.Port, ret));
            });
            thd.Start();
        }

        private void btnClearError_Click(object sender, EventArgs e)
        {
            PrintLog(string.Format("send to {0}:{1}: ClearError()", mDashboard.IP, mDashboard.Port));
            Thread thd = new Thread(() => {
                string ret = mDashboard.ClearError();
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDashboard.IP, mDashboard.Port, ret));
            });
            thd.Start();
        }

        private void btnSpeedConfirm_Click(object sender, EventArgs e)
        {
            int iValue = Parse2Int(this.textBoxSpeedRatio.Text);
            PrintLog(string.Format("send to {0}:{1}: SpeedFactor({1})", mDashboard.IP, mDashboard.Port, iValue));
            Thread thd = new Thread(() => {
                string ret = mDashboard.SpeedFactor(iValue);
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDashboard.IP, mDashboard.Port, ret));
            });
            thd.Start();
        }

        private double Parse2Double(string str)
        {
            double value = 0.0;
            try
            {
                value = Double.Parse(str);
            }
            catch { }
            return value;
        }
        private void btnMovJ_Click(object sender, EventArgs e)
        {
            DescartesPoint pt = new DescartesPoint();
            pt.x = Parse2Double(this.textBoxX.Text);
            pt.y = Parse2Double(this.textBoxY.Text);
            pt.z = Parse2Double(this.textBoxZ.Text);
            pt.rx = Parse2Double(this.textBoxRx.Text);
            pt.ry = Parse2Double(this.textBoxRy.Text);
            pt.rz = Parse2Double(this.textBoxRz.Text);

            PrintLog(string.Format("send to {0}:{1}: MovJ({2})", mDobotMove.IP, mDobotMove.Port,pt.ToString()));
            Thread thd = new Thread(() => {
                string ret = mDobotMove.MovJ(pt);
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDobotMove.IP, mDobotMove.Port, ret));
            });
            thd.Start();
        }

        private void btnMovL_Click(object sender, EventArgs e)
        {
            DescartesPoint pt = new DescartesPoint();
            pt.x = Parse2Double(this.textBoxX.Text);
            pt.y = Parse2Double(this.textBoxY.Text);
            pt.z = Parse2Double(this.textBoxZ.Text);
            pt.rx = Parse2Double(this.textBoxRx.Text);
            pt.ry = Parse2Double(this.textBoxRy.Text);
            pt.rz = Parse2Double(this.textBoxRz.Text);

            PrintLog(string.Format("send to {0}:{1}: MovL({2})", mDobotMove.IP, mDobotMove.Port, pt.ToString()));
            Thread thd = new Thread(() => {
                string ret = mDobotMove.MovL(pt);
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDobotMove.IP, mDobotMove.Port, ret));
            });
            thd.Start();
        }

        private void btnJointMovJ_Click(object sender, EventArgs e)
        {
            JointPoint pt = new JointPoint();
            pt.j1 = Parse2Double(this.textBoxJ1.Text);
            pt.j2 = Parse2Double(this.textBoxJ2.Text);
            pt.j3 = Parse2Double(this.textBoxJ3.Text);
            pt.j4 = Parse2Double(this.textBoxJ4.Text);
            pt.j5 = Parse2Double(this.textBoxJ5.Text);
            pt.j6 = Parse2Double(this.textBoxJ6.Text);

            PrintLog(string.Format("send to {0}:{1}: JointMovJ({2})", mDobotMove.IP, mDobotMove.Port, pt.ToString()));
            Thread thd = new Thread(() => {
                string ret = mDobotMove.JointMovJ(pt);
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDobotMove.IP, mDobotMove.Port, ret));
            });
            thd.Start();
        }

        private void btnDOInput_Click(object sender, EventArgs e)
        {
            int idx = Parse2Int(this.textBoxIdx.Text);
            bool bIsOn = string.Compare("on", this.cboStatus.Text, true) == 0;

            PrintLog(string.Format("send to {0}:{1}: DigitalOutputs({2},{3})", mDashboard.IP, mDashboard.Port,
                idx, bIsOn));
            Thread thd = new Thread(() => {
                string ret = mDashboard.DigitalOutputs(idx, bIsOn);
                ParseResult(ret);
                PrintLog(string.Format("Receive From {0}:{1}: {2}", mDashboard.IP, mDashboard.Port, ret));
            });
            thd.Start();
        }

        private bool ParseResult(string strResult)
        {
            //strResult=ErrorID,{id1,id2,...},funcName(param1,param2,...)
            int iBegPos = strResult.IndexOf('{');
            if (iBegPos < 0)
            {
                return false;
            }
            int iEndPos = strResult.IndexOf('}', iBegPos + 1);
            if (iEndPos < 0)
            {
                return false;
            }
            bool bOk = strResult.StartsWith("0,");
            strResult = strResult.Substring(iBegPos + 1, iEndPos - iBegPos - 1);
            if (string.IsNullOrEmpty(strResult))
            {
                return bOk;
            }
            StringBuilder sb = new StringBuilder();
            string[] all = strResult.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var d in all)
            {
                ErrorInfoBean bean = ErrorInfoHelper.Find(Parse2Int(d));
                if (null != bean)
                {
                    sb.Append("ID:" + bean.id + "\r\n");
                    sb.Append("Type:"+bean.Type + "\r\n");
                    sb.Append("Level:"+bean.level + "\r\n");
                    sb.Append("Solution:"+bean.en.solution + "\r\n");
                }
            }
            if (sb.Length > 0)
            {
                DateTime dt = DateTime.Now;
                string strTime = string.Format("Time Stamp:{0}.{1}.{2} {3}:{4}:{5}", dt.Year,
                    dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);


                PrintErrorInfo(strTime + "\r\n" + sb.ToString());
            }
            return bOk;
        }

        private void ShowDataResult()
        {
            this.labCurrentSpeedRatio.Text = string.Format("Current Speed Ratio:{0:F2}%", mFeedback.SpeedScaling);
            this.labRobotMode.Text = string.Format("Robot Mode:{0}", mFeedback.ConvertRobotMode());

            if (null != mFeedback.QActual && mFeedback.QActual.Length >= 6)
            {
                this.labJ1.Text = string.Format("J1:{0:F3}", mFeedback.QActual[0]);
                this.labJ2.Text = string.Format("J2:{0:F3}", mFeedback.QActual[1]);
                this.labJ3.Text = string.Format("J3:{0:F3}", mFeedback.QActual[2]);
                this.labJ4.Text = string.Format("J4:{0:F3}", mFeedback.QActual[3]);
                this.labJ5.Text = string.Format("J5:{0:F3}", mFeedback.QActual[4]);
                this.labJ6.Text = string.Format("J6:{0:F3}", mFeedback.QActual[5]);
            }

            if (null != mFeedback.ToolVectorActual && mFeedback.ToolVectorActual.Length >= 6)
            {
                this.labX.Text = string.Format("X:{0:F3}", mFeedback.ToolVectorActual[0]);
                this.labY.Text = string.Format("Y:{0:F3}", mFeedback.ToolVectorActual[1]);
                this.labZ.Text = string.Format("Z:{0:F3}", mFeedback.ToolVectorActual[2]);
                this.labRx.Text = string.Format("Rx:{0:F3}", mFeedback.ToolVectorActual[3]);
                this.labRy.Text = string.Format("Ry:{0:F3}", mFeedback.ToolVectorActual[4]);
                this.labRz.Text = string.Format("Rz:{0:F3}", mFeedback.ToolVectorActual[5]);
            }

            this.labDI.Text = "Digital Inputs:" + Convert.ToString(mFeedback.DigitalInputs, 2).PadLeft(64, '0');
            this.labDO.Text = "Digital Outputs:" + Convert.ToString(mFeedback.DigitalOutputs, 2).PadLeft(64, '0');
        }
    }
}
