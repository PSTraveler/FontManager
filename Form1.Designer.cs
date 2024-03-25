namespace FontManager
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.cbErase = new System.Windows.Forms.CheckBox();
            this.cbEveryone = new System.Windows.Forms.CheckBox();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "경로 : ";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(70, 21);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(400, 21);
            this.tbLocation.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(480, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "찾아보기..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(25, 82);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(222, 40);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "설치";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // cbErase
            // 
            this.cbErase.AutoSize = true;
            this.cbErase.Location = new System.Drawing.Point(272, 83);
            this.cbErase.Name = "cbErase";
            this.cbErase.Size = new System.Drawing.Size(148, 16);
            this.cbErase.TabIndex = 4;
            this.cbErase.Text = "설치 후 임시 폴더 삭제";
            this.cbErase.UseVisualStyleBackColor = true;
            this.cbErase.CheckedChanged += new System.EventHandler(this.cbErase_CheckedChanged);
            // 
            // cbEveryone
            // 
            this.cbEveryone.AutoSize = true;
            this.cbEveryone.Location = new System.Drawing.Point(272, 106);
            this.cbEveryone.Name = "cbEveryone";
            this.cbEveryone.Size = new System.Drawing.Size(128, 16);
            this.cbEveryone.TabIndex = 4;
            this.cbEveryone.Text = "모든 사용자용 설치";
            this.cbEveryone.UseVisualStyleBackColor = true;
            this.cbEveryone.CheckedChanged += new System.EventHandler(this.cbEveryone_CheckedChanged);
            // 
            // tbResults
            // 
            this.tbResults.Location = new System.Drawing.Point(25, 128);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.Size = new System.Drawing.Size(529, 308);
            this.tbResults.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "* 폰트 압축파일을 사용하시려면 해당 압축파일 하나만 존재하는 폴더를 지정해주세요.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.cbEveryone);
            this.Controls.Add(this.cbErase);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.CheckBox cbErase;
        private System.Windows.Forms.CheckBox cbEveryone;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Label label2;
    }
}

