namespace kursach
{
    partial class SokobanEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SokobanEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolWall = new System.Windows.Forms.ToolStripButton();
            this.toolAbox = new System.Windows.Forms.ToolStripButton();
            this.toolHere = new System.Windows.Forms.ToolStripButton();
            this.toolDone = new System.Windows.Forms.ToolStripButton();
            this.toolNone = new System.Windows.Forms.ToolStripButton();
            this.toolUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolResize = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolResizeAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolResizeDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolResizeAddCol = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolResizeDelCol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolPrev = new System.Windows.Forms.ToolStripButton();
            this.toolNext = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSlateGray;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolWall,
            this.toolAbox,
            this.toolHere,
            this.toolDone,
            this.toolNone,
            this.toolUser,
            this.toolStripSeparator1,
            this.toolResize,
            this.toolSave,
            this.toolPrev,
            this.toolNext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(829, 57);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolWall
            // 
            this.toolWall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWall.Image = global::kursach.Properties.Resources.wall;
            this.toolWall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWall.Name = "toolWall";
            this.toolWall.Size = new System.Drawing.Size(54, 54);
            this.toolWall.Text = "toolStripButton1";
            this.toolWall.Click += new System.EventHandler(this.toolWall_Click);
            // 
            // toolAbox
            // 
            this.toolAbox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAbox.Image = global::kursach.Properties.Resources.abox;
            this.toolAbox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbox.Name = "toolAbox";
            this.toolAbox.Size = new System.Drawing.Size(54, 54);
            this.toolAbox.Text = "toolStripButton2";
            this.toolAbox.Click += new System.EventHandler(this.toolAbox_Click);
            // 
            // toolHere
            // 
            this.toolHere.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolHere.Image = global::kursach.Properties.Resources.here;
            this.toolHere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHere.Name = "toolHere";
            this.toolHere.Size = new System.Drawing.Size(54, 54);
            this.toolHere.Text = "toolStripButton3";
            this.toolHere.Click += new System.EventHandler(this.toolHere_Click);
            // 
            // toolDone
            // 
            this.toolDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDone.Image = global::kursach.Properties.Resources.done;
            this.toolDone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDone.Name = "toolDone";
            this.toolDone.Size = new System.Drawing.Size(54, 54);
            this.toolDone.Text = "toolStripButton4";
            this.toolDone.Click += new System.EventHandler(this.toolDone_Click);
            // 
            // toolNone
            // 
            this.toolNone.Checked = true;
            this.toolNone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNone.Image = global::kursach.Properties.Resources.none;
            this.toolNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNone.Name = "toolNone";
            this.toolNone.Size = new System.Drawing.Size(54, 54);
            this.toolNone.Text = "toolStripButton5";
            this.toolNone.Click += new System.EventHandler(this.toolNone_Click);
            // 
            // toolUser
            // 
            this.toolUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUser.Image = global::kursach.Properties.Resources.user1;
            this.toolUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUser.Name = "toolUser";
            this.toolUser.Size = new System.Drawing.Size(54, 54);
            this.toolUser.Text = "toolStripButton6";
            this.toolUser.Click += new System.EventHandler(this.toolUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // toolResize
            // 
            this.toolResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolResize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolResizeAddRow,
            this.ToolResizeDelRow,
            this.ToolResizeAddCol,
            this.ToolResizeDelCol});
            this.toolResize.Image = global::kursach.Properties.Resources._new;
            this.toolResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolResize.Name = "toolResize";
            this.toolResize.Size = new System.Drawing.Size(64, 54);
            this.toolResize.Text = "toolStripDropDownButton1";
            // 
            // ToolResizeAddRow
            // 
            this.ToolResizeAddRow.Name = "ToolResizeAddRow";
            this.ToolResizeAddRow.Size = new System.Drawing.Size(224, 26);
            this.ToolResizeAddRow.Text = "+1 строка";
            this.ToolResizeAddRow.Click += new System.EventHandler(this.ToolResizeAddRow_Click);
            // 
            // ToolResizeDelRow
            // 
            this.ToolResizeDelRow.Name = "ToolResizeDelRow";
            this.ToolResizeDelRow.Size = new System.Drawing.Size(224, 26);
            this.ToolResizeDelRow.Text = "-1 строка";
            this.ToolResizeDelRow.Click += new System.EventHandler(this.ToolResizeDelRow_Click);
            // 
            // ToolResizeAddCol
            // 
            this.ToolResizeAddCol.Name = "ToolResizeAddCol";
            this.ToolResizeAddCol.Size = new System.Drawing.Size(224, 26);
            this.ToolResizeAddCol.Text = "+1 столбец";
            this.ToolResizeAddCol.Click += new System.EventHandler(this.ToolResizeAddCol_Click);
            // 
            // ToolResizeDelCol
            // 
            this.ToolResizeDelCol.Name = "ToolResizeDelCol";
            this.ToolResizeDelCol.Size = new System.Drawing.Size(224, 26);
            this.ToolResizeDelCol.Text = "-1 столбец";
            this.ToolResizeDelCol.Click += new System.EventHandler(this.ToolResizeDelCol_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = global::kursach.Properties.Resources.save;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(54, 54);
            this.toolSave.Text = "toolStripButton1";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolPrev
            // 
            this.toolPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrev.Image = global::kursach.Properties.Resources.prev;
            this.toolPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrev.Name = "toolPrev";
            this.toolPrev.Size = new System.Drawing.Size(54, 54);
            this.toolPrev.Text = "toolStripButton1";
            this.toolPrev.Click += new System.EventHandler(this.toolPrev_Click);
            // 
            // toolNext
            // 
            this.toolNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNext.Image = global::kursach.Properties.Resources.next;
            this.toolNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNext.Name = "toolNext";
            this.toolNext.Size = new System.Drawing.Size(54, 54);
            this.toolNext.Text = "toolStripButton2";
            this.toolNext.Click += new System.EventHandler(this.toolNext_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 657);
            this.panel1.TabIndex = 1;
            // 
            // SokobanEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(829, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SokobanEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор уровней для игры Sokoban";
            this.Load += new System.EventHandler(this.SokobanEditor_Load);
            this.Resize += new System.EventHandler(this.SokobanEditor_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolWall;
        private System.Windows.Forms.ToolStripButton toolAbox;
        private System.Windows.Forms.ToolStripButton toolHere;
        private System.Windows.Forms.ToolStripButton toolDone;
        private System.Windows.Forms.ToolStripButton toolNone;
        private System.Windows.Forms.ToolStripButton toolUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripDropDownButton toolResize;
        private System.Windows.Forms.ToolStripMenuItem ToolResizeAddRow;
        private System.Windows.Forms.ToolStripMenuItem ToolResizeDelRow;
        private System.Windows.Forms.ToolStripMenuItem ToolResizeAddCol;
        private System.Windows.Forms.ToolStripMenuItem ToolResizeDelCol;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolPrev;
        private System.Windows.Forms.ToolStripButton toolNext;
    }
}
