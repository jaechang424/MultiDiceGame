
namespace MultiDiceGame
{
    partial class FormGame
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
            this.btn_rollDice = new System.Windows.Forms.Button();
            this.pbox_dice = new System.Windows.Forms.PictureBox();
            this.lbl_turn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_dice)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_rollDice
            // 
            this.btn_rollDice.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_rollDice.Enabled = false;
            this.btn_rollDice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_rollDice.FlatAppearance.BorderSize = 2;
            this.btn_rollDice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rollDice.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rollDice.Location = new System.Drawing.Point(1083, 529);
            this.btn_rollDice.Name = "btn_rollDice";
            this.btn_rollDice.Size = new System.Drawing.Size(116, 92);
            this.btn_rollDice.TabIndex = 0;
            this.btn_rollDice.Text = "주사위\r\n굴리기";
            this.btn_rollDice.UseVisualStyleBackColor = false;
            this.btn_rollDice.Click += new System.EventHandler(this.btn_rollDice_Click);
            // 
            // pbox_dice
            // 
            this.pbox_dice.BackColor = System.Drawing.SystemColors.Control;
            this.pbox_dice.Location = new System.Drawing.Point(1077, 643);
            this.pbox_dice.Name = "pbox_dice";
            this.pbox_dice.Size = new System.Drawing.Size(130, 130);
            this.pbox_dice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_dice.TabIndex = 1;
            this.pbox_dice.TabStop = false;
            // 
            // lbl_turn
            // 
            this.lbl_turn.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_turn.Location = new System.Drawing.Point(1076, 116);
            this.lbl_turn.Name = "lbl_turn";
            this.lbl_turn.Size = new System.Drawing.Size(116, 80);
            this.lbl_turn.TabIndex = 2;
            this.lbl_turn.Text = "내 턴";
            this.lbl_turn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 861);
            this.Controls.Add(this.lbl_turn);
            this.Controls.Add(this.pbox_dice);
            this.Controls.Add(this.btn_rollDice);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGame_FormClosing);
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGame_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_dice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_rollDice;
        private System.Windows.Forms.PictureBox pbox_dice;
        private System.Windows.Forms.Label lbl_turn;
    }
}