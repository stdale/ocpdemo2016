namespace amaxOcpSummit2016
{
    partial class frm_main
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
            this.pnl_pdu = new System.Windows.Forms.Panel();
            this.pnl_battTime = new System.Windows.Forms.Panel();
            this.lbl_battTime = new System.Windows.Forms.Label();
            this.lbl_battTimeTxt = new System.Windows.Forms.Label();
            this.pnl_battCharge = new System.Windows.Forms.Panel();
            this.lbl_battChargeLvl = new System.Windows.Forms.Label();
            this.lbl_battChargeTxt = new System.Windows.Forms.Label();
            this.pnl_battStatus = new System.Windows.Forms.Panel();
            this.lbl_battStatus = new System.Windows.Forms.Label();
            this.lbl_battStsText = new System.Windows.Forms.Label();
            this.pnl_rack = new System.Windows.Forms.Panel();
            this.pnl_srv6 = new System.Windows.Forms.Panel();
            this.lbl_srv6 = new System.Windows.Forms.Label();
            this.lbl_srv6Txt = new System.Windows.Forms.Label();
            this.pnl_srv5 = new System.Windows.Forms.Panel();
            this.lbl_srv5 = new System.Windows.Forms.Label();
            this.lbl_srv5Txt = new System.Windows.Forms.Label();
            this.pnl_srv4 = new System.Windows.Forms.Panel();
            this.lbl_srv4 = new System.Windows.Forms.Label();
            this.lbl_srv4Txt = new System.Windows.Forms.Label();
            this.pnl_srv3 = new System.Windows.Forms.Panel();
            this.lbl_srv3 = new System.Windows.Forms.Label();
            this.lbl_srv3Txt = new System.Windows.Forms.Label();
            this.pnl_srv2 = new System.Windows.Forms.Panel();
            this.lbl_srv2 = new System.Windows.Forms.Label();
            this.lbl_srv2Txt = new System.Windows.Forms.Label();
            this.pnl_srv1 = new System.Windows.Forms.Panel();
            this.lbl_srv1 = new System.Windows.Forms.Label();
            this.lbl_srv1Txt = new System.Windows.Forms.Label();
            this.pnl_rackPwr = new System.Windows.Forms.Panel();
            this.lbl_rackPwr = new System.Windows.Forms.Label();
            this.lbl_rackPwrTxt = new System.Windows.Forms.Label();
            this.pnl_status = new System.Windows.Forms.Panel();
            this.pnl_extPwr = new System.Windows.Forms.Panel();
            this.lbl_extPwr = new System.Windows.Forms.Label();
            this.lbl_mainPwrTxt = new System.Windows.Forms.Label();
            this.tb_addy = new System.Windows.Forms.TextBox();
            this.lbl_notiTxt = new System.Windows.Forms.Label();
            this.btn_testNotf = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lblThreadStatus = new System.Windows.Forms.Label();
            this.pnl_pdu.SuspendLayout();
            this.pnl_battTime.SuspendLayout();
            this.pnl_battCharge.SuspendLayout();
            this.pnl_battStatus.SuspendLayout();
            this.pnl_rack.SuspendLayout();
            this.pnl_srv6.SuspendLayout();
            this.pnl_srv5.SuspendLayout();
            this.pnl_srv4.SuspendLayout();
            this.pnl_srv3.SuspendLayout();
            this.pnl_srv2.SuspendLayout();
            this.pnl_srv1.SuspendLayout();
            this.pnl_rackPwr.SuspendLayout();
            this.pnl_status.SuspendLayout();
            this.pnl_extPwr.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_pdu
            // 
            this.pnl_pdu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_pdu.Controls.Add(this.pnl_battTime);
            this.pnl_pdu.Controls.Add(this.pnl_battCharge);
            this.pnl_pdu.Controls.Add(this.pnl_battStatus);
            this.pnl_pdu.Location = new System.Drawing.Point(12, 157);
            this.pnl_pdu.Name = "pnl_pdu";
            this.pnl_pdu.Size = new System.Drawing.Size(217, 359);
            this.pnl_pdu.TabIndex = 0;
            // 
            // pnl_battTime
            // 
            this.pnl_battTime.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_battTime.Controls.Add(this.lbl_battTime);
            this.pnl_battTime.Controls.Add(this.lbl_battTimeTxt);
            this.pnl_battTime.Location = new System.Drawing.Point(39, 233);
            this.pnl_battTime.Name = "pnl_battTime";
            this.pnl_battTime.Size = new System.Drawing.Size(131, 100);
            this.pnl_battTime.TabIndex = 2;
            // 
            // lbl_battTime
            // 
            this.lbl_battTime.AutoSize = true;
            this.lbl_battTime.Location = new System.Drawing.Point(46, 56);
            this.lbl_battTime.Name = "lbl_battTime";
            this.lbl_battTime.Size = new System.Drawing.Size(43, 13);
            this.lbl_battTime.TabIndex = 1;
            this.lbl_battTime.Text = "55 mins";
            // 
            // lbl_battTimeTxt
            // 
            this.lbl_battTimeTxt.AutoSize = true;
            this.lbl_battTimeTxt.Location = new System.Drawing.Point(22, 16);
            this.lbl_battTimeTxt.Name = "lbl_battTimeTxt";
            this.lbl_battTimeTxt.Size = new System.Drawing.Size(89, 26);
            this.lbl_battTimeTxt.TabIndex = 0;
            this.lbl_battTimeTxt.Text = "Battery Estimated\r\n   Charge Time:\r\n";
            // 
            // pnl_battCharge
            // 
            this.pnl_battCharge.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_battCharge.Controls.Add(this.lbl_battChargeLvl);
            this.pnl_battCharge.Controls.Add(this.lbl_battChargeTxt);
            this.pnl_battCharge.Location = new System.Drawing.Point(39, 131);
            this.pnl_battCharge.Name = "pnl_battCharge";
            this.pnl_battCharge.Size = new System.Drawing.Size(131, 76);
            this.pnl_battCharge.TabIndex = 1;
            // 
            // lbl_battChargeLvl
            // 
            this.lbl_battChargeLvl.AutoSize = true;
            this.lbl_battChargeLvl.Location = new System.Drawing.Point(54, 43);
            this.lbl_battChargeLvl.Name = "lbl_battChargeLvl";
            this.lbl_battChargeLvl.Size = new System.Drawing.Size(27, 13);
            this.lbl_battChargeLvl.TabIndex = 1;
            this.lbl_battChargeLvl.Text = "50%";
            // 
            // lbl_battChargeTxt
            // 
            this.lbl_battChargeTxt.AutoSize = true;
            this.lbl_battChargeTxt.Location = new System.Drawing.Point(12, 17);
            this.lbl_battChargeTxt.Name = "lbl_battChargeTxt";
            this.lbl_battChargeTxt.Size = new System.Drawing.Size(109, 13);
            this.lbl_battChargeTxt.TabIndex = 0;
            this.lbl_battChargeTxt.Text = "Battery Charge Level:";
            // 
            // pnl_battStatus
            // 
            this.pnl_battStatus.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_battStatus.Controls.Add(this.lbl_battStatus);
            this.pnl_battStatus.Controls.Add(this.lbl_battStsText);
            this.pnl_battStatus.Location = new System.Drawing.Point(39, 22);
            this.pnl_battStatus.Name = "pnl_battStatus";
            this.pnl_battStatus.Size = new System.Drawing.Size(131, 73);
            this.pnl_battStatus.TabIndex = 0;
            // 
            // lbl_battStatus
            // 
            this.lbl_battStatus.AutoSize = true;
            this.lbl_battStatus.Location = new System.Drawing.Point(44, 40);
            this.lbl_battStatus.Name = "lbl_battStatus";
            this.lbl_battStatus.Size = new System.Drawing.Size(40, 13);
            this.lbl_battStatus.TabIndex = 1;
            this.lbl_battStatus.Text = "Normal";
            // 
            // lbl_battStsText
            // 
            this.lbl_battStsText.AutoSize = true;
            this.lbl_battStsText.Location = new System.Drawing.Point(27, 20);
            this.lbl_battStsText.Name = "lbl_battStsText";
            this.lbl_battStsText.Size = new System.Drawing.Size(76, 13);
            this.lbl_battStsText.TabIndex = 0;
            this.lbl_battStsText.Text = "Battery Status:";
            // 
            // pnl_rack
            // 
            this.pnl_rack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_rack.Controls.Add(this.pnl_srv6);
            this.pnl_rack.Controls.Add(this.pnl_srv5);
            this.pnl_rack.Controls.Add(this.pnl_srv4);
            this.pnl_rack.Controls.Add(this.pnl_srv3);
            this.pnl_rack.Controls.Add(this.pnl_srv2);
            this.pnl_rack.Controls.Add(this.pnl_srv1);
            this.pnl_rack.Controls.Add(this.pnl_rackPwr);
            this.pnl_rack.Location = new System.Drawing.Point(259, 158);
            this.pnl_rack.Name = "pnl_rack";
            this.pnl_rack.Size = new System.Drawing.Size(217, 359);
            this.pnl_rack.TabIndex = 1;
            // 
            // pnl_srv6
            // 
            this.pnl_srv6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_srv6.Controls.Add(this.lbl_srv6);
            this.pnl_srv6.Controls.Add(this.lbl_srv6Txt);
            this.pnl_srv6.Location = new System.Drawing.Point(121, 281);
            this.pnl_srv6.Name = "pnl_srv6";
            this.pnl_srv6.Size = new System.Drawing.Size(75, 72);
            this.pnl_srv6.TabIndex = 6;
            // 
            // lbl_srv6
            // 
            this.lbl_srv6.AutoSize = true;
            this.lbl_srv6.Location = new System.Drawing.Point(21, 40);
            this.lbl_srv6.Name = "lbl_srv6";
            this.lbl_srv6.Size = new System.Drawing.Size(36, 13);
            this.lbl_srv6.TabIndex = 1;
            this.lbl_srv6.Text = "250 w";
            // 
            // lbl_srv6Txt
            // 
            this.lbl_srv6Txt.AutoSize = true;
            this.lbl_srv6Txt.Location = new System.Drawing.Point(13, 13);
            this.lbl_srv6Txt.Name = "lbl_srv6Txt";
            this.lbl_srv6Txt.Size = new System.Drawing.Size(50, 13);
            this.lbl_srv6Txt.TabIndex = 0;
            this.lbl_srv6Txt.Text = "Server 6:";
            // 
            // pnl_srv5
            // 
            this.pnl_srv5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_srv5.Controls.Add(this.lbl_srv5);
            this.pnl_srv5.Controls.Add(this.lbl_srv5Txt);
            this.pnl_srv5.Location = new System.Drawing.Point(17, 281);
            this.pnl_srv5.Name = "pnl_srv5";
            this.pnl_srv5.Size = new System.Drawing.Size(75, 72);
            this.pnl_srv5.TabIndex = 5;
            // 
            // lbl_srv5
            // 
            this.lbl_srv5.AutoSize = true;
            this.lbl_srv5.Location = new System.Drawing.Point(22, 38);
            this.lbl_srv5.Name = "lbl_srv5";
            this.lbl_srv5.Size = new System.Drawing.Size(36, 13);
            this.lbl_srv5.TabIndex = 1;
            this.lbl_srv5.Text = "250 w";
            // 
            // lbl_srv5Txt
            // 
            this.lbl_srv5Txt.AutoSize = true;
            this.lbl_srv5Txt.Location = new System.Drawing.Point(12, 12);
            this.lbl_srv5Txt.Name = "lbl_srv5Txt";
            this.lbl_srv5Txt.Size = new System.Drawing.Size(50, 13);
            this.lbl_srv5Txt.TabIndex = 0;
            this.lbl_srv5Txt.Text = "Server 5:";
            // 
            // pnl_srv4
            // 
            this.pnl_srv4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_srv4.Controls.Add(this.lbl_srv4);
            this.pnl_srv4.Controls.Add(this.lbl_srv4Txt);
            this.pnl_srv4.Location = new System.Drawing.Point(120, 199);
            this.pnl_srv4.Name = "pnl_srv4";
            this.pnl_srv4.Size = new System.Drawing.Size(75, 72);
            this.pnl_srv4.TabIndex = 4;
            // 
            // lbl_srv4
            // 
            this.lbl_srv4.AutoSize = true;
            this.lbl_srv4.Location = new System.Drawing.Point(22, 43);
            this.lbl_srv4.Name = "lbl_srv4";
            this.lbl_srv4.Size = new System.Drawing.Size(36, 13);
            this.lbl_srv4.TabIndex = 1;
            this.lbl_srv4.Text = "250 w";
            // 
            // lbl_srv4Txt
            // 
            this.lbl_srv4Txt.AutoSize = true;
            this.lbl_srv4Txt.Location = new System.Drawing.Point(14, 14);
            this.lbl_srv4Txt.Name = "lbl_srv4Txt";
            this.lbl_srv4Txt.Size = new System.Drawing.Size(50, 13);
            this.lbl_srv4Txt.TabIndex = 0;
            this.lbl_srv4Txt.Text = "Server 4:";
            // 
            // pnl_srv3
            // 
            this.pnl_srv3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_srv3.Controls.Add(this.lbl_srv3);
            this.pnl_srv3.Controls.Add(this.lbl_srv3Txt);
            this.pnl_srv3.Location = new System.Drawing.Point(16, 199);
            this.pnl_srv3.Name = "pnl_srv3";
            this.pnl_srv3.Size = new System.Drawing.Size(75, 72);
            this.pnl_srv3.TabIndex = 3;
            // 
            // lbl_srv3
            // 
            this.lbl_srv3.AutoSize = true;
            this.lbl_srv3.Location = new System.Drawing.Point(20, 43);
            this.lbl_srv3.Name = "lbl_srv3";
            this.lbl_srv3.Size = new System.Drawing.Size(36, 13);
            this.lbl_srv3.TabIndex = 1;
            this.lbl_srv3.Text = "250 w";
            // 
            // lbl_srv3Txt
            // 
            this.lbl_srv3Txt.AutoSize = true;
            this.lbl_srv3Txt.Location = new System.Drawing.Point(13, 15);
            this.lbl_srv3Txt.Name = "lbl_srv3Txt";
            this.lbl_srv3Txt.Size = new System.Drawing.Size(50, 13);
            this.lbl_srv3Txt.TabIndex = 0;
            this.lbl_srv3Txt.Text = "Server 3:";
            // 
            // pnl_srv2
            // 
            this.pnl_srv2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_srv2.Controls.Add(this.lbl_srv2);
            this.pnl_srv2.Controls.Add(this.lbl_srv2Txt);
            this.pnl_srv2.Location = new System.Drawing.Point(120, 115);
            this.pnl_srv2.Name = "pnl_srv2";
            this.pnl_srv2.Size = new System.Drawing.Size(75, 72);
            this.pnl_srv2.TabIndex = 2;
            // 
            // lbl_srv2
            // 
            this.lbl_srv2.AutoSize = true;
            this.lbl_srv2.Location = new System.Drawing.Point(22, 44);
            this.lbl_srv2.Name = "lbl_srv2";
            this.lbl_srv2.Size = new System.Drawing.Size(36, 13);
            this.lbl_srv2.TabIndex = 1;
            this.lbl_srv2.Text = "250 w";
            // 
            // lbl_srv2Txt
            // 
            this.lbl_srv2Txt.AutoSize = true;
            this.lbl_srv2Txt.Location = new System.Drawing.Point(14, 15);
            this.lbl_srv2Txt.Name = "lbl_srv2Txt";
            this.lbl_srv2Txt.Size = new System.Drawing.Size(50, 13);
            this.lbl_srv2Txt.TabIndex = 0;
            this.lbl_srv2Txt.Text = "Server 2:";
            // 
            // pnl_srv1
            // 
            this.pnl_srv1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_srv1.Controls.Add(this.lbl_srv1);
            this.pnl_srv1.Controls.Add(this.lbl_srv1Txt);
            this.pnl_srv1.Location = new System.Drawing.Point(16, 115);
            this.pnl_srv1.Name = "pnl_srv1";
            this.pnl_srv1.Size = new System.Drawing.Size(75, 72);
            this.pnl_srv1.TabIndex = 1;
            // 
            // lbl_srv1
            // 
            this.lbl_srv1.AutoSize = true;
            this.lbl_srv1.Location = new System.Drawing.Point(19, 44);
            this.lbl_srv1.Name = "lbl_srv1";
            this.lbl_srv1.Size = new System.Drawing.Size(36, 13);
            this.lbl_srv1.TabIndex = 1;
            this.lbl_srv1.Text = "250 w";
            // 
            // lbl_srv1Txt
            // 
            this.lbl_srv1Txt.AutoSize = true;
            this.lbl_srv1Txt.Location = new System.Drawing.Point(13, 16);
            this.lbl_srv1Txt.Name = "lbl_srv1Txt";
            this.lbl_srv1Txt.Size = new System.Drawing.Size(50, 13);
            this.lbl_srv1Txt.TabIndex = 0;
            this.lbl_srv1Txt.Text = "Server 1:";
            // 
            // pnl_rackPwr
            // 
            this.pnl_rackPwr.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_rackPwr.Controls.Add(this.lbl_rackPwr);
            this.pnl_rackPwr.Controls.Add(this.lbl_rackPwrTxt);
            this.pnl_rackPwr.Location = new System.Drawing.Point(36, 22);
            this.pnl_rackPwr.Name = "pnl_rackPwr";
            this.pnl_rackPwr.Size = new System.Drawing.Size(141, 73);
            this.pnl_rackPwr.TabIndex = 0;
            // 
            // lbl_rackPwr
            // 
            this.lbl_rackPwr.AutoSize = true;
            this.lbl_rackPwr.Location = new System.Drawing.Point(53, 39);
            this.lbl_rackPwr.Name = "lbl_rackPwr";
            this.lbl_rackPwr.Size = new System.Drawing.Size(42, 13);
            this.lbl_rackPwr.TabIndex = 1;
            this.lbl_rackPwr.Text = "1500 w";
            // 
            // lbl_rackPwrTxt
            // 
            this.lbl_rackPwrTxt.AutoSize = true;
            this.lbl_rackPwrTxt.Location = new System.Drawing.Point(27, 11);
            this.lbl_rackPwrTxt.Name = "lbl_rackPwrTxt";
            this.lbl_rackPwrTxt.Size = new System.Drawing.Size(98, 13);
            this.lbl_rackPwrTxt.TabIndex = 0;
            this.lbl_rackPwrTxt.Text = "Rack Level Power:";
            // 
            // pnl_status
            // 
            this.pnl_status.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_status.Controls.Add(this.pnl_extPwr);
            this.pnl_status.Controls.Add(this.lbl_mainPwrTxt);
            this.pnl_status.Location = new System.Drawing.Point(57, 4);
            this.pnl_status.Name = "pnl_status";
            this.pnl_status.Size = new System.Drawing.Size(343, 123);
            this.pnl_status.TabIndex = 2;
            // 
            // pnl_extPwr
            // 
            this.pnl_extPwr.BackColor = System.Drawing.Color.Lime;
            this.pnl_extPwr.Controls.Add(this.lbl_extPwr);
            this.pnl_extPwr.Location = new System.Drawing.Point(25, 47);
            this.pnl_extPwr.Name = "pnl_extPwr";
            this.pnl_extPwr.Size = new System.Drawing.Size(299, 62);
            this.pnl_extPwr.TabIndex = 1;
            // 
            // lbl_extPwr
            // 
            this.lbl_extPwr.AutoSize = true;
            this.lbl_extPwr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_extPwr.Location = new System.Drawing.Point(124, 19);
            this.lbl_extPwr.Name = "lbl_extPwr";
            this.lbl_extPwr.Size = new System.Drawing.Size(45, 25);
            this.lbl_extPwr.TabIndex = 0;
            this.lbl_extPwr.Text = "ON";
            // 
            // lbl_mainPwrTxt
            // 
            this.lbl_mainPwrTxt.AutoSize = true;
            this.lbl_mainPwrTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mainPwrTxt.Location = new System.Drawing.Point(20, 18);
            this.lbl_mainPwrTxt.Name = "lbl_mainPwrTxt";
            this.lbl_mainPwrTxt.Size = new System.Drawing.Size(312, 25);
            this.lbl_mainPwrTxt.TabIndex = 0;
            this.lbl_mainPwrTxt.Text = "External Rack Power Status:";
            // 
            // tb_addy
            // 
            this.tb_addy.Location = new System.Drawing.Point(241, 133);
            this.tb_addy.Name = "tb_addy";
            this.tb_addy.Size = new System.Drawing.Size(70, 20);
            this.tb_addy.TabIndex = 5;
            // 
            // lbl_notiTxt
            // 
            this.lbl_notiTxt.AutoSize = true;
            this.lbl_notiTxt.Location = new System.Drawing.Point(94, 136);
            this.lbl_notiTxt.Name = "lbl_notiTxt";
            this.lbl_notiTxt.Size = new System.Drawing.Size(137, 13);
            this.lbl_notiTxt.TabIndex = 7;
            this.lbl_notiTxt.Text = "Notification Phone Number:";
            // 
            // btn_testNotf
            // 
            this.btn_testNotf.Location = new System.Drawing.Point(318, 134);
            this.btn_testNotf.Name = "btn_testNotf";
            this.btn_testNotf.Size = new System.Drawing.Size(75, 19);
            this.btn_testNotf.TabIndex = 8;
            this.btn_testNotf.Text = "test";
            this.btn_testNotf.UseVisualStyleBackColor = true;
            this.btn_testNotf.Click += new System.EventHandler(this.btn_testNotf_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(407, 22);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 9;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(407, 52);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 10;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblThreadStatus
            // 
            this.lblThreadStatus.AutoSize = true;
            this.lblThreadStatus.Location = new System.Drawing.Point(419, 82);
            this.lblThreadStatus.Name = "lblThreadStatus";
            this.lblThreadStatus.Size = new System.Drawing.Size(16, 13);
            this.lblThreadStatus.TabIndex = 11;
            this.lblThreadStatus.Text = "...";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 531);
            this.Controls.Add(this.lblThreadStatus);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_testNotf);
            this.Controls.Add(this.lbl_notiTxt);
            this.Controls.Add(this.tb_addy);
            this.Controls.Add(this.pnl_status);
            this.Controls.Add(this.pnl_rack);
            this.Controls.Add(this.pnl_pdu);
            this.Name = "frm_main";
            this.Text = "AMAX OCP Summit 2016";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.pnl_pdu.ResumeLayout(false);
            this.pnl_battTime.ResumeLayout(false);
            this.pnl_battTime.PerformLayout();
            this.pnl_battCharge.ResumeLayout(false);
            this.pnl_battCharge.PerformLayout();
            this.pnl_battStatus.ResumeLayout(false);
            this.pnl_battStatus.PerformLayout();
            this.pnl_rack.ResumeLayout(false);
            this.pnl_srv6.ResumeLayout(false);
            this.pnl_srv6.PerformLayout();
            this.pnl_srv5.ResumeLayout(false);
            this.pnl_srv5.PerformLayout();
            this.pnl_srv4.ResumeLayout(false);
            this.pnl_srv4.PerformLayout();
            this.pnl_srv3.ResumeLayout(false);
            this.pnl_srv3.PerformLayout();
            this.pnl_srv2.ResumeLayout(false);
            this.pnl_srv2.PerformLayout();
            this.pnl_srv1.ResumeLayout(false);
            this.pnl_srv1.PerformLayout();
            this.pnl_rackPwr.ResumeLayout(false);
            this.pnl_rackPwr.PerformLayout();
            this.pnl_status.ResumeLayout(false);
            this.pnl_status.PerformLayout();
            this.pnl_extPwr.ResumeLayout(false);
            this.pnl_extPwr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_pdu;
        private System.Windows.Forms.Panel pnl_rack;
        private System.Windows.Forms.Panel pnl_status;
        private System.Windows.Forms.Panel pnl_battStatus;
        private System.Windows.Forms.Label lbl_battStatus;
        private System.Windows.Forms.Label lbl_battStsText;
        private System.Windows.Forms.Panel pnl_battCharge;
        private System.Windows.Forms.Panel pnl_battTime;
        private System.Windows.Forms.Label lbl_battTime;
        private System.Windows.Forms.Label lbl_battTimeTxt;
        private System.Windows.Forms.Label lbl_battChargeLvl;
        private System.Windows.Forms.Label lbl_battChargeTxt;
        private System.Windows.Forms.Panel pnl_rackPwr;
        private System.Windows.Forms.Label lbl_rackPwr;
        private System.Windows.Forms.Label lbl_rackPwrTxt;
        private System.Windows.Forms.Panel pnl_srv6;
        private System.Windows.Forms.Panel pnl_srv5;
        private System.Windows.Forms.Panel pnl_srv4;
        private System.Windows.Forms.Panel pnl_srv3;
        private System.Windows.Forms.Panel pnl_srv1;
        private System.Windows.Forms.Label lbl_srv6;
        private System.Windows.Forms.Label lbl_srv6Txt;
        private System.Windows.Forms.Label lbl_srv5;
        private System.Windows.Forms.Label lbl_srv5Txt;
        private System.Windows.Forms.Label lbl_srv4;
        private System.Windows.Forms.Label lbl_srv4Txt;
        private System.Windows.Forms.Label lbl_srv3;
        private System.Windows.Forms.Label lbl_srv3Txt;
        private System.Windows.Forms.Panel pnl_srv2;
        private System.Windows.Forms.Label lbl_srv2;
        private System.Windows.Forms.Label lbl_srv2Txt;
        private System.Windows.Forms.Label lbl_srv1;
        private System.Windows.Forms.Label lbl_srv1Txt;
        private System.Windows.Forms.Panel pnl_extPwr;
        private System.Windows.Forms.Label lbl_extPwr;
        private System.Windows.Forms.Label lbl_mainPwrTxt;
        private System.Windows.Forms.TextBox tb_addy;
        private System.Windows.Forms.Label lbl_notiTxt;
        private System.Windows.Forms.Button btn_testNotf;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label lblThreadStatus;
    }
}

