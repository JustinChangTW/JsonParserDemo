namespace JsonParserDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TbFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CbFunction = new System.Windows.Forms.ComboBox();
            this.TbPostData = new System.Windows.Forms.TextBox();
            this.saleInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.step01BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.step02BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.step03BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bKSingatureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.saleInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step01BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step02BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.step03BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bKSingatureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TbFile
            // 
            this.TbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbFile.Location = new System.Drawing.Point(132, 12);
            this.TbFile.Name = "TbFile";
            this.TbFile.Size = new System.Drawing.Size(1077, 25);
            this.TbFile.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 43);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(111, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(16, 219);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1196, 501);
            this.tabControl1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Parser Json";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnParserJson_Click);
            // 
            // CbFunction
            // 
            this.CbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFunction.FormattingEnabled = true;
            this.CbFunction.Items.AddRange(new object[] {
            "File",
            "Post"});
            this.CbFunction.Location = new System.Drawing.Point(13, 12);
            this.CbFunction.Name = "CbFunction";
            this.CbFunction.Size = new System.Drawing.Size(110, 23);
            this.CbFunction.TabIndex = 4;
            this.CbFunction.SelectedIndexChanged += new System.EventHandler(this.CbFunction_SelectedIndexChanged);
            // 
            // TbPostData
            // 
            this.TbPostData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPostData.Location = new System.Drawing.Point(13, 96);
            this.TbPostData.Multiline = true;
            this.TbPostData.Name = "TbPostData";
            this.TbPostData.Size = new System.Drawing.Size(1192, 101);
            this.TbPostData.TabIndex = 5;
            // 
            // saleInfoBindingSource
            // 
            this.saleInfoBindingSource.DataSource = typeof(JsonParserDemo.SaleInfo);
            // 
            // step01BindingSource
            // 
            this.step01BindingSource.DataSource = typeof(JsonParserDemo.Step01);
            // 
            // step02BindingSource
            // 
            this.step02BindingSource.DataSource = typeof(JsonParserDemo.Step02);
            // 
            // step03BindingSource
            // 
            this.step03BindingSource.DataSource = typeof(JsonParserDemo.Step03);
            // 
            // bKSingatureBindingSource
            // 
            this.bKSingatureBindingSource.DataSource = typeof(JsonParserDemo.BKSingature);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 724);
            this.Controls.Add(this.TbPostData);
            this.Controls.Add(this.CbFunction);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.TbFile);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.saleInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step01BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step02BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.step03BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bKSingatureBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TbFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.BindingSource saleInfoBindingSource;
        private System.Windows.Forms.BindingSource step01BindingSource;
        private System.Windows.Forms.BindingSource step02BindingSource;
        private System.Windows.Forms.BindingSource step03BindingSource;
        private System.Windows.Forms.BindingSource bKSingatureBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox CbFunction;
        private System.Windows.Forms.TextBox TbPostData;
    }
}

