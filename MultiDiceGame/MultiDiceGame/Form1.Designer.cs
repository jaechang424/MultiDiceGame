
namespace MultiDiceGame
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_openServer = new System.Windows.Forms.Button();
            this.btn_connectServer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_openServer
            // 
            this.btn_openServer.Location = new System.Drawing.Point(150, 128);
            this.btn_openServer.Name = "btn_openServer";
            this.btn_openServer.Size = new System.Drawing.Size(127, 33);
            this.btn_openServer.TabIndex = 0;
            this.btn_openServer.Text = "서버 열기";
            this.btn_openServer.UseVisualStyleBackColor = true;
            this.btn_openServer.Click += new System.EventHandler(this.btn_openServer_Click);
            // 
            // btn_connectServer
            // 
            this.btn_connectServer.Location = new System.Drawing.Point(150, 182);
            this.btn_connectServer.Name = "btn_connectServer";
            this.btn_connectServer.Size = new System.Drawing.Size(127, 33);
            this.btn_connectServer.TabIndex = 1;
            this.btn_connectServer.Text = "서버 접속";
            this.btn_connectServer.UseVisualStyleBackColor = true;
            this.btn_connectServer.Click += new System.EventHandler(this.btn_connectServer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "숨기기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_connectServer);
            this.Controls.Add(this.btn_openServer);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_openServer;
        private System.Windows.Forms.Button btn_connectServer;
        private System.Windows.Forms.Button button1;
    }
}

