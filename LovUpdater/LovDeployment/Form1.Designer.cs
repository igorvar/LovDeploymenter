namespace LovDeployment
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFromClipboard = new System.Windows.Forms.Button();
            this.dgMainGrid = new System.Windows.Forms.DataGridView();
            this.clmnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnLic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnLanguageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnParentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnTranslate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnMultilingual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgMainGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFromClipboard
            // 
            this.btnFromClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnFromClipboard.Image")));
            this.btnFromClipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFromClipboard.Location = new System.Drawing.Point(0, 0);
            this.btnFromClipboard.Name = "btnFromClipboard";
            this.btnFromClipboard.Size = new System.Drawing.Size(99, 37);
            this.btnFromClipboard.TabIndex = 0;
            this.btnFromClipboard.Text = "Insert from clipboard";
            this.btnFromClipboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFromClipboard.UseVisualStyleBackColor = true;
            this.btnFromClipboard.Click += new System.EventHandler(this.btnFromClipboard_Click);
            // 
            // dgMainGrid
            // 
            this.dgMainGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgMainGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMainGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnType,
            this.clmnValue,
            this.clmnLic,
            this.clmnParent,
            this.clmnLanguageCode,
            this.clmnParentType,
            this.clmnActive,
            this.clmnTranslate,
            this.clmnMultilingual,
            this.clmnOrder,
            this.clmnHigh,
            this.clmnLow,
            this.clmnComment});
            this.dgMainGrid.Location = new System.Drawing.Point(0, 43);
            this.dgMainGrid.Name = "dgMainGrid";
            this.dgMainGrid.Size = new System.Drawing.Size(1331, 456);
            this.dgMainGrid.TabIndex = 1;
            this.dgMainGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMainGrid_CellEnter);
            this.dgMainGrid.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgMainGrid_CellParsing);
            this.dgMainGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMainGrid_CellValidated);
            this.dgMainGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgMainGrid_DefaultValuesNeeded);
            this.dgMainGrid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgMainGrid_RowValidating);
            // 
            // clmnType
            // 
            this.clmnType.FillWeight = 200F;
            this.clmnType.HeaderText = "Type";
            this.clmnType.Name = "clmnType";
            this.clmnType.Width = 200;
            // 
            // clmnValue
            // 
            this.clmnValue.FillWeight = 200F;
            this.clmnValue.HeaderText = "Value";
            this.clmnValue.Name = "clmnValue";
            this.clmnValue.Width = 200;
            // 
            // clmnLic
            // 
            this.clmnLic.HeaderText = "LIC";
            this.clmnLic.Name = "clmnLic";
            this.clmnLic.Width = 200;
            // 
            // clmnParent
            // 
            this.clmnParent.HeaderText = "Parent";
            this.clmnParent.Name = "clmnParent";
            this.clmnParent.Width = 300;
            // 
            // clmnLanguageCode
            // 
            this.clmnLanguageCode.HeaderText = "Language Code";
            this.clmnLanguageCode.Name = "clmnLanguageCode";
            this.clmnLanguageCode.Width = 50;
            // 
            // clmnParentType
            // 
            this.clmnParentType.HeaderText = "Parent Type";
            this.clmnParentType.Name = "clmnParentType";
            this.clmnParentType.Width = 200;
            // 
            // clmnActive
            // 
            this.clmnActive.FalseValue = "N";
            this.clmnActive.HeaderText = "Active";
            this.clmnActive.IndeterminateValue = "N";
            this.clmnActive.Name = "clmnActive";
            this.clmnActive.TrueValue = "Y";
            this.clmnActive.Width = 40;
            // 
            // clmnTranslate
            // 
            this.clmnTranslate.FalseValue = "N";
            this.clmnTranslate.HeaderText = "Translate";
            this.clmnTranslate.IndeterminateValue = "Y";
            this.clmnTranslate.Name = "clmnTranslate";
            this.clmnTranslate.TrueValue = "Y";
            this.clmnTranslate.Width = 60;
            // 
            // clmnMultilingual
            // 
            this.clmnMultilingual.FalseValue = "N";
            this.clmnMultilingual.HeaderText = "Multilingual";
            this.clmnMultilingual.IndeterminateValue = "N";
            this.clmnMultilingual.Name = "clmnMultilingual";
            this.clmnMultilingual.TrueValue = "Y";
            this.clmnMultilingual.Width = 70;
            // 
            // clmnOrder
            // 
            this.clmnOrder.HeaderText = "Order";
            this.clmnOrder.Name = "clmnOrder";
            this.clmnOrder.Width = 40;
            // 
            // clmnHigh
            // 
            this.clmnHigh.HeaderText = "High";
            this.clmnHigh.Name = "clmnHigh";
            // 
            // clmnLow
            // 
            this.clmnLow.HeaderText = "Low";
            this.clmnLow.Name = "clmnLow";
            // 
            // clmnComment
            // 
            this.clmnComment.HeaderText = "Comment";
            this.clmnComment.Name = "clmnComment";
            this.clmnComment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnComment.Width = 240;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1110, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 37);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save XML";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "Xml|*.xml|All files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 499);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgMainGrid);
            this.Controls.Add(this.btnFromClipboard);
            this.Name = "Form1";
            this.Text = "LOV Deployer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgMainGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFromClipboard;
        private System.Windows.Forms.DataGridView dgMainGrid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnMultilingual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnTranslate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnLanguageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnLic;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnType;
    }
}

