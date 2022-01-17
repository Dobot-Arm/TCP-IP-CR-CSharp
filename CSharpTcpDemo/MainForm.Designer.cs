namespace CSharpTcpDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnPowerOn = new System.Windows.Forms.Button();
            this.btnPowerOff = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxJt1 = new System.Windows.Forms.TextBox();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.btnMinus1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxJt2 = new System.Windows.Forms.TextBox();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.btnMinus2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxJt3 = new System.Windows.Forms.TextBox();
            this.btnAdd3 = new System.Windows.Forms.Button();
            this.btnMinus3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxJt4 = new System.Windows.Forms.TextBox();
            this.btnAdd4 = new System.Windows.Forms.Button();
            this.btnMinus4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxJt5 = new System.Windows.Forms.TextBox();
            this.btnAdd5 = new System.Windows.Forms.Button();
            this.btnMinus5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxJt6 = new System.Windows.Forms.TextBox();
            this.btnAdd6 = new System.Windows.Forms.Button();
            this.btnMinus6 = new System.Windows.Forms.Button();
            this.panelJoint = new System.Windows.Forms.Panel();
            this.btnJoint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.richBoxResult = new System.Windows.Forms.RichTextBox();
            this.labelNowSpeedFactor = new System.Windows.Forms.Label();
            this.labelRobotMode = new System.Windows.Forms.Label();
            this.panelXYZR = new System.Windows.Forms.Panel();
            this.btnXYZR = new System.Windows.Forms.Button();
            this.btnAddX = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMinusRZ = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.btnMinusRY = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnMinusRX = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnMinusZ = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.btnMinusY = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnMinusX = new System.Windows.Forms.Button();
            this.btnAddY = new System.Windows.Forms.Button();
            this.btnAddRZ = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxRZ = new System.Windows.Forms.TextBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.btnAddRY = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxRY = new System.Windows.Forms.TextBox();
            this.btnAddZ = new System.Windows.Forms.Button();
            this.btnAddRX = new System.Windows.Forms.Button();
            this.textBoxRX = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.btnSetSpeed = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.panelJoint.SuspendLayout();
            this.panelXYZR.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(73, 14);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(150, 21);
            this.textBoxIP.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(241, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(322, 13);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnPowerOn
            // 
            this.btnPowerOn.Location = new System.Drawing.Point(14, 57);
            this.btnPowerOn.Name = "btnPowerOn";
            this.btnPowerOn.Size = new System.Drawing.Size(75, 23);
            this.btnPowerOn.TabIndex = 4;
            this.btnPowerOn.Text = "上电";
            this.btnPowerOn.UseVisualStyleBackColor = true;
            this.btnPowerOn.Click += new System.EventHandler(this.btnPowerOn_Click);
            // 
            // btnPowerOff
            // 
            this.btnPowerOff.Location = new System.Drawing.Point(354, 57);
            this.btnPowerOff.Name = "btnPowerOff";
            this.btnPowerOff.Size = new System.Drawing.Size(75, 23);
            this.btnPowerOff.TabIndex = 4;
            this.btnPowerOff.Text = "下电";
            this.btnPowerOff.UseVisualStyleBackColor = true;
            this.btnPowerOff.Visible = false;
            this.btnPowerOff.Click += new System.EventHandler(this.btnPowerOff_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(97, 57);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 23);
            this.btnEnable.TabIndex = 4;
            this.btnEnable.Text = "使能";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(183, 57);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(75, 23);
            this.btnDisable.TabIndex = 4;
            this.btnDisable.Text = "急停";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "JOINT1：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJt1
            // 
            this.textBoxJt1.Location = new System.Drawing.Point(81, 21);
            this.textBoxJt1.Name = "textBoxJt1";
            this.textBoxJt1.Size = new System.Drawing.Size(100, 21);
            this.textBoxJt1.TabIndex = 6;
            // 
            // btnAdd1
            // 
            this.btnAdd1.Location = new System.Drawing.Point(202, 15);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(49, 32);
            this.btnAdd1.TabIndex = 7;
            this.btnAdd1.Text = "+";
            this.btnAdd1.UseVisualStyleBackColor = true;
            // 
            // btnMinus1
            // 
            this.btnMinus1.Location = new System.Drawing.Point(285, 15);
            this.btnMinus1.Name = "btnMinus1";
            this.btnMinus1.Size = new System.Drawing.Size(49, 32);
            this.btnMinus1.TabIndex = 7;
            this.btnMinus1.Text = "-";
            this.btnMinus1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "JOINT2：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJt2
            // 
            this.textBoxJt2.Location = new System.Drawing.Point(81, 69);
            this.textBoxJt2.Name = "textBoxJt2";
            this.textBoxJt2.Size = new System.Drawing.Size(100, 21);
            this.textBoxJt2.TabIndex = 6;
            // 
            // btnAdd2
            // 
            this.btnAdd2.Location = new System.Drawing.Point(202, 63);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(49, 32);
            this.btnAdd2.TabIndex = 7;
            this.btnAdd2.Text = "+";
            this.btnAdd2.UseVisualStyleBackColor = true;
            // 
            // btnMinus2
            // 
            this.btnMinus2.Location = new System.Drawing.Point(285, 63);
            this.btnMinus2.Name = "btnMinus2";
            this.btnMinus2.Size = new System.Drawing.Size(49, 32);
            this.btnMinus2.TabIndex = 7;
            this.btnMinus2.Text = "-";
            this.btnMinus2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "JOINT3：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJt3
            // 
            this.textBoxJt3.Location = new System.Drawing.Point(81, 107);
            this.textBoxJt3.Name = "textBoxJt3";
            this.textBoxJt3.Size = new System.Drawing.Size(100, 21);
            this.textBoxJt3.TabIndex = 6;
            // 
            // btnAdd3
            // 
            this.btnAdd3.Location = new System.Drawing.Point(202, 101);
            this.btnAdd3.Name = "btnAdd3";
            this.btnAdd3.Size = new System.Drawing.Size(49, 32);
            this.btnAdd3.TabIndex = 7;
            this.btnAdd3.Text = "+";
            this.btnAdd3.UseVisualStyleBackColor = true;
            // 
            // btnMinus3
            // 
            this.btnMinus3.Location = new System.Drawing.Point(285, 101);
            this.btnMinus3.Name = "btnMinus3";
            this.btnMinus3.Size = new System.Drawing.Size(49, 32);
            this.btnMinus3.TabIndex = 7;
            this.btnMinus3.Text = "-";
            this.btnMinus3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "JOINT4：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJt4
            // 
            this.textBoxJt4.Location = new System.Drawing.Point(81, 145);
            this.textBoxJt4.Name = "textBoxJt4";
            this.textBoxJt4.Size = new System.Drawing.Size(100, 21);
            this.textBoxJt4.TabIndex = 6;
            // 
            // btnAdd4
            // 
            this.btnAdd4.Location = new System.Drawing.Point(202, 139);
            this.btnAdd4.Name = "btnAdd4";
            this.btnAdd4.Size = new System.Drawing.Size(49, 32);
            this.btnAdd4.TabIndex = 7;
            this.btnAdd4.Text = "+";
            this.btnAdd4.UseVisualStyleBackColor = true;
            // 
            // btnMinus4
            // 
            this.btnMinus4.Location = new System.Drawing.Point(285, 139);
            this.btnMinus4.Name = "btnMinus4";
            this.btnMinus4.Size = new System.Drawing.Size(49, 32);
            this.btnMinus4.TabIndex = 7;
            this.btnMinus4.Text = "-";
            this.btnMinus4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "JOINT5：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJt5
            // 
            this.textBoxJt5.Location = new System.Drawing.Point(81, 183);
            this.textBoxJt5.Name = "textBoxJt5";
            this.textBoxJt5.Size = new System.Drawing.Size(100, 21);
            this.textBoxJt5.TabIndex = 6;
            // 
            // btnAdd5
            // 
            this.btnAdd5.Location = new System.Drawing.Point(202, 177);
            this.btnAdd5.Name = "btnAdd5";
            this.btnAdd5.Size = new System.Drawing.Size(49, 32);
            this.btnAdd5.TabIndex = 7;
            this.btnAdd5.Text = "+";
            this.btnAdd5.UseVisualStyleBackColor = true;
            // 
            // btnMinus5
            // 
            this.btnMinus5.Location = new System.Drawing.Point(285, 177);
            this.btnMinus5.Name = "btnMinus5";
            this.btnMinus5.Size = new System.Drawing.Size(49, 32);
            this.btnMinus5.TabIndex = 7;
            this.btnMinus5.Text = "-";
            this.btnMinus5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "JOINT6：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJt6
            // 
            this.textBoxJt6.Location = new System.Drawing.Point(81, 221);
            this.textBoxJt6.Name = "textBoxJt6";
            this.textBoxJt6.Size = new System.Drawing.Size(100, 21);
            this.textBoxJt6.TabIndex = 6;
            // 
            // btnAdd6
            // 
            this.btnAdd6.Location = new System.Drawing.Point(202, 215);
            this.btnAdd6.Name = "btnAdd6";
            this.btnAdd6.Size = new System.Drawing.Size(49, 32);
            this.btnAdd6.TabIndex = 7;
            this.btnAdd6.Text = "+";
            this.btnAdd6.UseVisualStyleBackColor = true;
            // 
            // btnMinus6
            // 
            this.btnMinus6.Location = new System.Drawing.Point(285, 215);
            this.btnMinus6.Name = "btnMinus6";
            this.btnMinus6.Size = new System.Drawing.Size(49, 32);
            this.btnMinus6.TabIndex = 7;
            this.btnMinus6.Text = "-";
            this.btnMinus6.UseVisualStyleBackColor = true;
            // 
            // panelJoint
            // 
            this.panelJoint.Controls.Add(this.btnJoint);
            this.panelJoint.Controls.Add(this.btnAdd1);
            this.panelJoint.Controls.Add(this.label2);
            this.panelJoint.Controls.Add(this.btnMinus6);
            this.panelJoint.Controls.Add(this.textBoxJt1);
            this.panelJoint.Controls.Add(this.btnMinus5);
            this.panelJoint.Controls.Add(this.label3);
            this.panelJoint.Controls.Add(this.btnMinus4);
            this.panelJoint.Controls.Add(this.label4);
            this.panelJoint.Controls.Add(this.btnMinus3);
            this.panelJoint.Controls.Add(this.textBoxJt2);
            this.panelJoint.Controls.Add(this.btnMinus2);
            this.panelJoint.Controls.Add(this.label5);
            this.panelJoint.Controls.Add(this.btnMinus1);
            this.panelJoint.Controls.Add(this.btnAdd2);
            this.panelJoint.Controls.Add(this.btnAdd6);
            this.panelJoint.Controls.Add(this.label6);
            this.panelJoint.Controls.Add(this.textBoxJt6);
            this.panelJoint.Controls.Add(this.textBoxJt3);
            this.panelJoint.Controls.Add(this.btnAdd5);
            this.panelJoint.Controls.Add(this.label7);
            this.panelJoint.Controls.Add(this.textBoxJt5);
            this.panelJoint.Controls.Add(this.btnAdd3);
            this.panelJoint.Controls.Add(this.btnAdd4);
            this.panelJoint.Controls.Add(this.textBoxJt4);
            this.panelJoint.Location = new System.Drawing.Point(19, 170);
            this.panelJoint.Name = "panelJoint";
            this.panelJoint.Size = new System.Drawing.Size(363, 312);
            this.panelJoint.TabIndex = 8;
            // 
            // btnJoint
            // 
            this.btnJoint.Location = new System.Drawing.Point(42, 262);
            this.btnJoint.Name = "btnJoint";
            this.btnJoint.Size = new System.Drawing.Size(272, 44);
            this.btnJoint.TabIndex = 9;
            this.btnJoint.Text = "实际关节位置";
            this.btnJoint.UseVisualStyleBackColor = true;
            this.btnJoint.Click += new System.EventHandler(this.btnJoint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "速度比例：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "%";
            // 
            // richBoxResult
            // 
            this.richBoxResult.Location = new System.Drawing.Point(442, 12);
            this.richBoxResult.Name = "richBoxResult";
            this.richBoxResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richBoxResult.Size = new System.Drawing.Size(396, 455);
            this.richBoxResult.TabIndex = 12;
            this.richBoxResult.Text = "";
            // 
            // labelNowSpeedFactor
            // 
            this.labelNowSpeedFactor.AutoSize = true;
            this.labelNowSpeedFactor.Location = new System.Drawing.Point(226, 100);
            this.labelNowSpeedFactor.Name = "labelNowSpeedFactor";
            this.labelNowSpeedFactor.Size = new System.Drawing.Size(89, 12);
            this.labelNowSpeedFactor.TabIndex = 9;
            this.labelNowSpeedFactor.Text = "当前速度比例：";
            // 
            // labelRobotMode
            // 
            this.labelRobotMode.AutoSize = true;
            this.labelRobotMode.Location = new System.Drawing.Point(17, 136);
            this.labelRobotMode.Name = "labelRobotMode";
            this.labelRobotMode.Size = new System.Drawing.Size(77, 12);
            this.labelRobotMode.TabIndex = 9;
            this.labelRobotMode.Text = "机器人模式：";
            // 
            // panelXYZR
            // 
            this.panelXYZR.Controls.Add(this.btnXYZR);
            this.panelXYZR.Controls.Add(this.btnAddX);
            this.panelXYZR.Controls.Add(this.label10);
            this.panelXYZR.Controls.Add(this.btnMinusRZ);
            this.panelXYZR.Controls.Add(this.textBoxX);
            this.panelXYZR.Controls.Add(this.btnMinusRY);
            this.panelXYZR.Controls.Add(this.label11);
            this.panelXYZR.Controls.Add(this.btnMinusRX);
            this.panelXYZR.Controls.Add(this.label12);
            this.panelXYZR.Controls.Add(this.btnMinusZ);
            this.panelXYZR.Controls.Add(this.textBoxY);
            this.panelXYZR.Controls.Add(this.btnMinusY);
            this.panelXYZR.Controls.Add(this.label13);
            this.panelXYZR.Controls.Add(this.btnMinusX);
            this.panelXYZR.Controls.Add(this.btnAddY);
            this.panelXYZR.Controls.Add(this.btnAddRZ);
            this.panelXYZR.Controls.Add(this.label14);
            this.panelXYZR.Controls.Add(this.textBoxRZ);
            this.panelXYZR.Controls.Add(this.textBoxZ);
            this.panelXYZR.Controls.Add(this.btnAddRY);
            this.panelXYZR.Controls.Add(this.label15);
            this.panelXYZR.Controls.Add(this.textBoxRY);
            this.panelXYZR.Controls.Add(this.btnAddZ);
            this.panelXYZR.Controls.Add(this.btnAddRX);
            this.panelXYZR.Controls.Add(this.textBoxRX);
            this.panelXYZR.Location = new System.Drawing.Point(19, 170);
            this.panelXYZR.Name = "panelXYZR";
            this.panelXYZR.Size = new System.Drawing.Size(363, 312);
            this.panelXYZR.TabIndex = 8;
            // 
            // btnXYZR
            // 
            this.btnXYZR.Location = new System.Drawing.Point(42, 262);
            this.btnXYZR.Name = "btnXYZR";
            this.btnXYZR.Size = new System.Drawing.Size(272, 44);
            this.btnXYZR.TabIndex = 9;
            this.btnXYZR.Text = "TCP笛卡尔实际坐标值";
            this.btnXYZR.UseVisualStyleBackColor = true;
            this.btnXYZR.Click += new System.EventHandler(this.btnXYZR_Click);
            // 
            // btnAddX
            // 
            this.btnAddX.Location = new System.Drawing.Point(202, 15);
            this.btnAddX.Name = "btnAddX";
            this.btnAddX.Size = new System.Drawing.Size(49, 32);
            this.btnAddX.TabIndex = 7;
            this.btnAddX.Text = "X+";
            this.btnAddX.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "X：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMinusRZ
            // 
            this.btnMinusRZ.Location = new System.Drawing.Point(285, 215);
            this.btnMinusRZ.Name = "btnMinusRZ";
            this.btnMinusRZ.Size = new System.Drawing.Size(49, 32);
            this.btnMinusRZ.TabIndex = 7;
            this.btnMinusRZ.Text = "RZ-";
            this.btnMinusRZ.UseVisualStyleBackColor = true;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(48, 21);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(133, 21);
            this.textBoxX.TabIndex = 6;
            // 
            // btnMinusRY
            // 
            this.btnMinusRY.Location = new System.Drawing.Point(285, 177);
            this.btnMinusRY.Name = "btnMinusRY";
            this.btnMinusRY.Size = new System.Drawing.Size(49, 32);
            this.btnMinusRY.TabIndex = 7;
            this.btnMinusRY.Text = "RY-";
            this.btnMinusRY.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "Y：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMinusRX
            // 
            this.btnMinusRX.Location = new System.Drawing.Point(285, 139);
            this.btnMinusRX.Name = "btnMinusRX";
            this.btnMinusRX.Size = new System.Drawing.Size(49, 32);
            this.btnMinusRX.TabIndex = 7;
            this.btnMinusRX.Text = "RX-";
            this.btnMinusRX.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Z：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMinusZ
            // 
            this.btnMinusZ.Location = new System.Drawing.Point(285, 101);
            this.btnMinusZ.Name = "btnMinusZ";
            this.btnMinusZ.Size = new System.Drawing.Size(49, 32);
            this.btnMinusZ.TabIndex = 7;
            this.btnMinusZ.Text = "Z-";
            this.btnMinusZ.UseVisualStyleBackColor = true;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(48, 69);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(133, 21);
            this.textBoxY.TabIndex = 6;
            // 
            // btnMinusY
            // 
            this.btnMinusY.Location = new System.Drawing.Point(285, 63);
            this.btnMinusY.Name = "btnMinusY";
            this.btnMinusY.Size = new System.Drawing.Size(49, 32);
            this.btnMinusY.TabIndex = 7;
            this.btnMinusY.Text = "Y-";
            this.btnMinusY.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "RX：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMinusX
            // 
            this.btnMinusX.Location = new System.Drawing.Point(285, 15);
            this.btnMinusX.Name = "btnMinusX";
            this.btnMinusX.Size = new System.Drawing.Size(49, 32);
            this.btnMinusX.TabIndex = 7;
            this.btnMinusX.Text = "X-";
            this.btnMinusX.UseVisualStyleBackColor = true;
            // 
            // btnAddY
            // 
            this.btnAddY.Location = new System.Drawing.Point(202, 63);
            this.btnAddY.Name = "btnAddY";
            this.btnAddY.Size = new System.Drawing.Size(49, 32);
            this.btnAddY.TabIndex = 7;
            this.btnAddY.Text = "Y+";
            this.btnAddY.UseVisualStyleBackColor = true;
            // 
            // btnAddRZ
            // 
            this.btnAddRZ.Location = new System.Drawing.Point(202, 215);
            this.btnAddRZ.Name = "btnAddRZ";
            this.btnAddRZ.Size = new System.Drawing.Size(49, 32);
            this.btnAddRZ.TabIndex = 7;
            this.btnAddRZ.Text = "RZ+";
            this.btnAddRZ.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "RY：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxRZ
            // 
            this.textBoxRZ.Location = new System.Drawing.Point(48, 221);
            this.textBoxRZ.Name = "textBoxRZ";
            this.textBoxRZ.Size = new System.Drawing.Size(133, 21);
            this.textBoxRZ.TabIndex = 6;
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(48, 107);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(133, 21);
            this.textBoxZ.TabIndex = 6;
            // 
            // btnAddRY
            // 
            this.btnAddRY.Location = new System.Drawing.Point(202, 177);
            this.btnAddRY.Name = "btnAddRY";
            this.btnAddRY.Size = new System.Drawing.Size(49, 32);
            this.btnAddRY.TabIndex = 7;
            this.btnAddRY.Text = "RY+";
            this.btnAddRY.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "RZ：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxRY
            // 
            this.textBoxRY.Location = new System.Drawing.Point(48, 183);
            this.textBoxRY.Name = "textBoxRY";
            this.textBoxRY.Size = new System.Drawing.Size(133, 21);
            this.textBoxRY.TabIndex = 6;
            // 
            // btnAddZ
            // 
            this.btnAddZ.Location = new System.Drawing.Point(202, 101);
            this.btnAddZ.Name = "btnAddZ";
            this.btnAddZ.Size = new System.Drawing.Size(49, 32);
            this.btnAddZ.TabIndex = 7;
            this.btnAddZ.Text = "Z+";
            this.btnAddZ.UseVisualStyleBackColor = true;
            // 
            // btnAddRX
            // 
            this.btnAddRX.Location = new System.Drawing.Point(202, 139);
            this.btnAddRX.Name = "btnAddRX";
            this.btnAddRX.Size = new System.Drawing.Size(49, 32);
            this.btnAddRX.TabIndex = 7;
            this.btnAddRX.Text = "RX+";
            this.btnAddRX.UseVisualStyleBackColor = true;
            // 
            // textBoxRX
            // 
            this.textBoxRX.Location = new System.Drawing.Point(48, 145);
            this.textBoxRX.Name = "textBoxRX";
            this.textBoxRX.Size = new System.Drawing.Size(133, 21);
            this.textBoxRX.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(268, 57);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清除错误";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(84, 96);
            this.textBoxSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSpeed.MaxLength = 3;
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(41, 21);
            this.textBoxSpeed.TabIndex = 13;
            // 
            // btnSetSpeed
            // 
            this.btnSetSpeed.Location = new System.Drawing.Point(145, 92);
            this.btnSetSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSetSpeed.Name = "btnSetSpeed";
            this.btnSetSpeed.Size = new System.Drawing.Size(76, 28);
            this.btnSetSpeed.TabIndex = 14;
            this.btnSetSpeed.Text = "设置速度";
            this.btnSetSpeed.UseVisualStyleBackColor = true;
            this.btnSetSpeed.Click += new System.EventHandler(this.btnSetSpeed_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(442, 473);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(141, 28);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "清除日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 510);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnSetSpeed);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.richBoxResult);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelRobotMode);
            this.Controls.Add(this.labelNowSpeedFactor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panelXYZR);
            this.Controls.Add(this.panelJoint);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.btnPowerOff);
            this.Controls.Add(this.btnPowerOn);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panelJoint.ResumeLayout(false);
            this.panelJoint.PerformLayout();
            this.panelXYZR.ResumeLayout(false);
            this.panelXYZR.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnPowerOn;
        private System.Windows.Forms.Button btnPowerOff;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxJt1;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnMinus1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxJt2;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.Button btnMinus2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxJt3;
        private System.Windows.Forms.Button btnAdd3;
        private System.Windows.Forms.Button btnMinus3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxJt4;
        private System.Windows.Forms.Button btnAdd4;
        private System.Windows.Forms.Button btnMinus4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxJt5;
        private System.Windows.Forms.Button btnAdd5;
        private System.Windows.Forms.Button btnMinus5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxJt6;
        private System.Windows.Forms.Button btnAdd6;
        private System.Windows.Forms.Button btnMinus6;
        private System.Windows.Forms.Panel panelJoint;
        private System.Windows.Forms.Button btnJoint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richBoxResult;
        private System.Windows.Forms.Label labelNowSpeedFactor;
        private System.Windows.Forms.Label labelRobotMode;
        private System.Windows.Forms.Panel panelXYZR;
        private System.Windows.Forms.Button btnXYZR;
        private System.Windows.Forms.Button btnAddX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMinusRZ;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button btnMinusRY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMinusRX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnMinusZ;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button btnMinusY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnMinusX;
        private System.Windows.Forms.Button btnAddY;
        private System.Windows.Forms.Button btnAddRZ;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxRZ;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Button btnAddRY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxRY;
        private System.Windows.Forms.Button btnAddZ;
        private System.Windows.Forms.Button btnAddRX;
        private System.Windows.Forms.TextBox textBoxRX;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Button btnSetSpeed;
        private System.Windows.Forms.Button btnClearLog;
    }
}