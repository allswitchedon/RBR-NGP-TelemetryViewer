
namespace RBR_NGP_TelemetryViewer
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.firstMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Show_WheelSpeed_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tyrePressureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tyreTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.suspensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Suspension_Lines_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Suspension_Histogram_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.dampersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dampers_Lines_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Dampers_Histogram_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Front_Bump_Treshold = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Rear_Bump_Treshold = new System.Windows.Forms.ToolStripTextBox();
            this.addWorkspaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Dampers = new System.Windows.Forms.TabPage();
            this.DamperRB_OP = new OxyPlot.WindowsForms.PlotView();
            this.DamperLB_OP = new OxyPlot.WindowsForms.PlotView();
            this.DamperRF_OP = new OxyPlot.WindowsForms.PlotView();
            this.DamperLF_OP = new OxyPlot.WindowsForms.PlotView();
            this.Suspension = new System.Windows.Forms.TabPage();
            this.SuspensionRB_OP = new OxyPlot.WindowsForms.PlotView();
            this.SuspensionLB_OP = new OxyPlot.WindowsForms.PlotView();
            this.SuspensionRF_OP = new OxyPlot.WindowsForms.PlotView();
            this.SuspensionLF_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyreTemp = new System.Windows.Forms.TabPage();
            this.TyreTempsRB_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyreTempsLB_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyreTempsRF_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyreTempsLF_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyrePressure = new System.Windows.Forms.TabPage();
            this.TyrePressureRB_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyrePressureLB_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyrePressureRF_OP = new OxyPlot.WindowsForms.PlotView();
            this.TyrePressureLF_OP = new OxyPlot.WindowsForms.PlotView();
            this.Main = new System.Windows.Forms.TabPage();
            this.Engine_Plot = new OxyPlot.WindowsForms.PlotView();
            this.GForces_Plot = new OxyPlot.WindowsForms.PlotView();
            this.Speed_Plot = new OxyPlot.WindowsForms.PlotView();
            this.TimeDiff_Plot = new OxyPlot.WindowsForms.PlotView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TrackLeght_OP = new OxyPlot.WindowsForms.PlotView();
            this.RaceTrack_OP = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.Dampers.SuspendLayout();
            this.Suspension.SuspendLayout();
            this.TyreTemp.SuspendLayout();
            this.TyrePressure.SuspendLayout();
            this.Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstMenuToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.wTFToolStripMenuItem,
            this.workspaceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1519, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // firstMenuToolStripMenuItem
            // 
            this.firstMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.firstMenuToolStripMenuItem.Name = "firstMenuToolStripMenuItem";
            this.firstMenuToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.firstMenuToolStripMenuItem.Text = "FIle";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // wTFToolStripMenuItem
            // 
            this.wTFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.wTFToolStripMenuItem.Name = "wTFToolStripMenuItem";
            this.wTFToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.wTFToolStripMenuItem.Text = "StageMap";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // workspaceToolStripMenuItem
            // 
            this.workspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWorkspaceToolStripMenuItem,
            this.tyrePressureToolStripMenuItem,
            this.tyreTempToolStripMenuItem,
            this.suspensionToolStripMenuItem,
            this.dampersToolStripMenuItem,
            this.addWorkspaceToolStripMenuItem1});
            this.workspaceToolStripMenuItem.Name = "workspaceToolStripMenuItem";
            this.workspaceToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.workspaceToolStripMenuItem.Text = "Workspace";
            // 
            // addWorkspaceToolStripMenuItem
            // 
            this.addWorkspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Show_WheelSpeed_Menu});
            this.addWorkspaceToolStripMenuItem.Name = "addWorkspaceToolStripMenuItem";
            this.addWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.addWorkspaceToolStripMenuItem.Text = "Main Page";
            // 
            // Show_WheelSpeed_Menu
            // 
            this.Show_WheelSpeed_Menu.Name = "Show_WheelSpeed_Menu";
            this.Show_WheelSpeed_Menu.Size = new System.Drawing.Size(220, 26);
            this.Show_WheelSpeed_Menu.Text = "Show Wheel Speed";
            this.Show_WheelSpeed_Menu.Click += new System.EventHandler(this.Show_WheelSpeed_Menu_Click);
            // 
            // tyrePressureToolStripMenuItem
            // 
            this.tyrePressureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.tyrePressureToolStripMenuItem.Name = "tyrePressureToolStripMenuItem";
            this.tyrePressureToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.tyrePressureToolStripMenuItem.Text = "Tyre Pressure";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // tyreTempToolStripMenuItem
            // 
            this.tyreTempToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem1,
            this.histogramToolStripMenuItem1});
            this.tyreTempToolStripMenuItem.Name = "tyreTempToolStripMenuItem";
            this.tyreTempToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.tyreTempToolStripMenuItem.Text = "Tyre Temperature";
            // 
            // lineToolStripMenuItem1
            // 
            this.lineToolStripMenuItem1.Name = "lineToolStripMenuItem1";
            this.lineToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.lineToolStripMenuItem1.Text = "Line";
            this.lineToolStripMenuItem1.Click += new System.EventHandler(this.lineToolStripMenuItem1_Click);
            // 
            // histogramToolStripMenuItem1
            // 
            this.histogramToolStripMenuItem1.Name = "histogramToolStripMenuItem1";
            this.histogramToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.histogramToolStripMenuItem1.Text = "Histogram";
            this.histogramToolStripMenuItem1.Click += new System.EventHandler(this.histogramToolStripMenuItem1_Click);
            // 
            // suspensionToolStripMenuItem
            // 
            this.suspensionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Suspension_Lines_Menu,
            this.Suspension_Histogram_Menu});
            this.suspensionToolStripMenuItem.Name = "suspensionToolStripMenuItem";
            this.suspensionToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.suspensionToolStripMenuItem.Text = "Suspension";
            // 
            // Suspension_Lines_Menu
            // 
            this.Suspension_Lines_Menu.Name = "Suspension_Lines_Menu";
            this.Suspension_Lines_Menu.Size = new System.Drawing.Size(162, 26);
            this.Suspension_Lines_Menu.Text = "Lines";
            this.Suspension_Lines_Menu.Click += new System.EventHandler(this.Suspension_Lines_Menu__Click);
            // 
            // Suspension_Histogram_Menu
            // 
            this.Suspension_Histogram_Menu.Name = "Suspension_Histogram_Menu";
            this.Suspension_Histogram_Menu.Size = new System.Drawing.Size(162, 26);
            this.Suspension_Histogram_Menu.Text = "Histogram";
            this.Suspension_Histogram_Menu.Click += new System.EventHandler(this.Suspension_Histogram_Menu_Click);
            // 
            // dampersToolStripMenuItem
            // 
            this.dampersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dampers_Lines_Menu,
            this.Dampers_Histogram_Menu});
            this.dampersToolStripMenuItem.Name = "dampersToolStripMenuItem";
            this.dampersToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.dampersToolStripMenuItem.Text = "Dampers";
            // 
            // Dampers_Lines_Menu
            // 
            this.Dampers_Lines_Menu.Name = "Dampers_Lines_Menu";
            this.Dampers_Lines_Menu.Size = new System.Drawing.Size(162, 26);
            this.Dampers_Lines_Menu.Text = "Lines";
            this.Dampers_Lines_Menu.Click += new System.EventHandler(this.Dampers_Lines_Menu_Click);
            // 
            // Dampers_Histogram_Menu
            // 
            this.Dampers_Histogram_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.Front_Bump_Treshold,
            this.toolStripMenuItem2,
            this.Rear_Bump_Treshold});
            this.Dampers_Histogram_Menu.Name = "Dampers_Histogram_Menu";
            this.Dampers_Histogram_Menu.Size = new System.Drawing.Size(162, 26);
            this.Dampers_Histogram_Menu.Text = "Histogram";
            this.Dampers_Histogram_Menu.Click += new System.EventHandler(this.Dampers_Histrogram_Menu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem1.Text = "Front Threshold (mm/s)";
            // 
            // Front_Bump_Treshold
            // 
            this.Front_Bump_Treshold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Front_Bump_Treshold.Name = "Front_Bump_Treshold";
            this.Front_Bump_Treshold.Size = new System.Drawing.Size(100, 27);
            this.Front_Bump_Treshold.Text = "30";
            this.Front_Bump_Treshold.TextChanged += new System.EventHandler(this.Front_Bump_Treshold_TextChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(247, 26);
            this.toolStripMenuItem2.Text = "Rear Threshold (mm/s)";
            // 
            // Rear_Bump_Treshold
            // 
            this.Rear_Bump_Treshold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Rear_Bump_Treshold.Name = "Rear_Bump_Treshold";
            this.Rear_Bump_Treshold.Size = new System.Drawing.Size(100, 27);
            this.Rear_Bump_Treshold.Text = "30";
            this.Rear_Bump_Treshold.TextChanged += new System.EventHandler(this.Rear_Bump_Treshold_TextChanged);
            // 
            // addWorkspaceToolStripMenuItem1
            // 
            this.addWorkspaceToolStripMenuItem1.Name = "addWorkspaceToolStripMenuItem1";
            this.addWorkspaceToolStripMenuItem1.Size = new System.Drawing.Size(207, 26);
            this.addWorkspaceToolStripMenuItem1.Text = "Add Workspace";
            this.addWorkspaceToolStripMenuItem1.Click += new System.EventHandler(this.addWorkspaceToolStripMenuItem_Click);
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 25);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1200, 597);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "tabPage11";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1200, 597);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 25);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1200, 597);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1200, 597);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1200, 597);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1200, 597);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Dampers
            // 
            this.Dampers.Controls.Add(this.DamperRB_OP);
            this.Dampers.Controls.Add(this.DamperLB_OP);
            this.Dampers.Controls.Add(this.DamperRF_OP);
            this.Dampers.Controls.Add(this.DamperLF_OP);
            this.Dampers.Location = new System.Drawing.Point(4, 25);
            this.Dampers.Name = "Dampers";
            this.Dampers.Size = new System.Drawing.Size(1200, 597);
            this.Dampers.TabIndex = 4;
            this.Dampers.Text = "Dampers";
            this.Dampers.UseVisualStyleBackColor = true;
            // 
            // DamperRB_OP
            // 
            this.DamperRB_OP.Location = new System.Drawing.Point(0, 448);
            this.DamperRB_OP.Name = "DamperRB_OP";
            this.DamperRB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.DamperRB_OP.Size = new System.Drawing.Size(1200, 150);
            this.DamperRB_OP.TabIndex = 19;
            this.DamperRB_OP.Text = "plotView5";
            this.DamperRB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.DamperRB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.DamperRB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // DamperLB_OP
            // 
            this.DamperLB_OP.Location = new System.Drawing.Point(0, 298);
            this.DamperLB_OP.Name = "DamperLB_OP";
            this.DamperLB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.DamperLB_OP.Size = new System.Drawing.Size(1200, 150);
            this.DamperLB_OP.TabIndex = 18;
            this.DamperLB_OP.Text = "plotView4";
            this.DamperLB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.DamperLB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.DamperLB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // DamperRF_OP
            // 
            this.DamperRF_OP.Location = new System.Drawing.Point(0, 148);
            this.DamperRF_OP.Name = "DamperRF_OP";
            this.DamperRF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.DamperRF_OP.Size = new System.Drawing.Size(1200, 150);
            this.DamperRF_OP.TabIndex = 17;
            this.DamperRF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.DamperRF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.DamperRF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // DamperLF_OP
            // 
            this.DamperLF_OP.Location = new System.Drawing.Point(0, -2);
            this.DamperLF_OP.Name = "DamperLF_OP";
            this.DamperLF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.DamperLF_OP.Size = new System.Drawing.Size(1200, 150);
            this.DamperLF_OP.TabIndex = 16;
            this.DamperLF_OP.Text = "plotView2";
            this.DamperLF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.DamperLF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.DamperLF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Suspension
            // 
            this.Suspension.Controls.Add(this.SuspensionRB_OP);
            this.Suspension.Controls.Add(this.SuspensionLB_OP);
            this.Suspension.Controls.Add(this.SuspensionRF_OP);
            this.Suspension.Controls.Add(this.SuspensionLF_OP);
            this.Suspension.Location = new System.Drawing.Point(4, 25);
            this.Suspension.Name = "Suspension";
            this.Suspension.Size = new System.Drawing.Size(1200, 597);
            this.Suspension.TabIndex = 3;
            this.Suspension.Text = "Suspension";
            this.Suspension.UseVisualStyleBackColor = true;
            // 
            // SuspensionRB_OP
            // 
            this.SuspensionRB_OP.Location = new System.Drawing.Point(0, 448);
            this.SuspensionRB_OP.Name = "SuspensionRB_OP";
            this.SuspensionRB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.SuspensionRB_OP.Size = new System.Drawing.Size(1200, 150);
            this.SuspensionRB_OP.TabIndex = 15;
            this.SuspensionRB_OP.Text = "plotView5";
            this.SuspensionRB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.SuspensionRB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.SuspensionRB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // SuspensionLB_OP
            // 
            this.SuspensionLB_OP.Location = new System.Drawing.Point(0, 298);
            this.SuspensionLB_OP.Name = "SuspensionLB_OP";
            this.SuspensionLB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.SuspensionLB_OP.Size = new System.Drawing.Size(1200, 150);
            this.SuspensionLB_OP.TabIndex = 14;
            this.SuspensionLB_OP.Text = "plotView4";
            this.SuspensionLB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.SuspensionLB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.SuspensionLB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // SuspensionRF_OP
            // 
            this.SuspensionRF_OP.Location = new System.Drawing.Point(0, 148);
            this.SuspensionRF_OP.Name = "SuspensionRF_OP";
            this.SuspensionRF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.SuspensionRF_OP.Size = new System.Drawing.Size(1200, 150);
            this.SuspensionRF_OP.TabIndex = 13;
            this.SuspensionRF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.SuspensionRF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.SuspensionRF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // SuspensionLF_OP
            // 
            this.SuspensionLF_OP.Location = new System.Drawing.Point(0, -2);
            this.SuspensionLF_OP.Name = "SuspensionLF_OP";
            this.SuspensionLF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.SuspensionLF_OP.Size = new System.Drawing.Size(1200, 150);
            this.SuspensionLF_OP.TabIndex = 12;
            this.SuspensionLF_OP.Text = "plotView2";
            this.SuspensionLF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.SuspensionLF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.SuspensionLF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyreTemp
            // 
            this.TyreTemp.Controls.Add(this.TyreTempsRB_OP);
            this.TyreTemp.Controls.Add(this.TyreTempsLB_OP);
            this.TyreTemp.Controls.Add(this.TyreTempsRF_OP);
            this.TyreTemp.Controls.Add(this.TyreTempsLF_OP);
            this.TyreTemp.Location = new System.Drawing.Point(4, 25);
            this.TyreTemp.Margin = new System.Windows.Forms.Padding(2);
            this.TyreTemp.Name = "TyreTemp";
            this.TyreTemp.Size = new System.Drawing.Size(1200, 597);
            this.TyreTemp.TabIndex = 2;
            this.TyreTemp.Text = "Tyres Temps";
            this.TyreTemp.UseVisualStyleBackColor = true;
            // 
            // TyreTempsRB_OP
            // 
            this.TyreTempsRB_OP.Location = new System.Drawing.Point(0, 450);
            this.TyreTempsRB_OP.Name = "TyreTempsRB_OP";
            this.TyreTempsRB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyreTempsRB_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyreTempsRB_OP.TabIndex = 11;
            this.TyreTempsRB_OP.Text = "plotView5";
            this.TyreTempsRB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyreTempsRB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyreTempsRB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyreTempsLB_OP
            // 
            this.TyreTempsLB_OP.Location = new System.Drawing.Point(0, 300);
            this.TyreTempsLB_OP.Name = "TyreTempsLB_OP";
            this.TyreTempsLB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyreTempsLB_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyreTempsLB_OP.TabIndex = 10;
            this.TyreTempsLB_OP.Text = "plotView4";
            this.TyreTempsLB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyreTempsLB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyreTempsLB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyreTempsRF_OP
            // 
            this.TyreTempsRF_OP.Location = new System.Drawing.Point(0, 150);
            this.TyreTempsRF_OP.Name = "TyreTempsRF_OP";
            this.TyreTempsRF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyreTempsRF_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyreTempsRF_OP.TabIndex = 9;
            this.TyreTempsRF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyreTempsRF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyreTempsRF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyreTempsLF_OP
            // 
            this.TyreTempsLF_OP.Location = new System.Drawing.Point(0, 0);
            this.TyreTempsLF_OP.Name = "TyreTempsLF_OP";
            this.TyreTempsLF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyreTempsLF_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyreTempsLF_OP.TabIndex = 8;
            this.TyreTempsLF_OP.Text = "plotView2";
            this.TyreTempsLF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyreTempsLF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyreTempsLF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyrePressure
            // 
            this.TyrePressure.Controls.Add(this.TyrePressureRB_OP);
            this.TyrePressure.Controls.Add(this.TyrePressureLB_OP);
            this.TyrePressure.Controls.Add(this.TyrePressureRF_OP);
            this.TyrePressure.Controls.Add(this.TyrePressureLF_OP);
            this.TyrePressure.Location = new System.Drawing.Point(4, 25);
            this.TyrePressure.Name = "TyrePressure";
            this.TyrePressure.Padding = new System.Windows.Forms.Padding(3);
            this.TyrePressure.Size = new System.Drawing.Size(1200, 597);
            this.TyrePressure.TabIndex = 1;
            this.TyrePressure.Text = "Tyres Pressure";
            this.TyrePressure.UseVisualStyleBackColor = true;
            // 
            // TyrePressureRB_OP
            // 
            this.TyrePressureRB_OP.Location = new System.Drawing.Point(0, 450);
            this.TyrePressureRB_OP.Name = "TyrePressureRB_OP";
            this.TyrePressureRB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyrePressureRB_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyrePressureRB_OP.TabIndex = 7;
            this.TyrePressureRB_OP.Text = "plotView5";
            this.TyrePressureRB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyrePressureRB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyrePressureRB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyrePressureLB_OP
            // 
            this.TyrePressureLB_OP.Location = new System.Drawing.Point(0, 300);
            this.TyrePressureLB_OP.Name = "TyrePressureLB_OP";
            this.TyrePressureLB_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyrePressureLB_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyrePressureLB_OP.TabIndex = 6;
            this.TyrePressureLB_OP.Text = "plotView4";
            this.TyrePressureLB_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyrePressureLB_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyrePressureLB_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyrePressureRF_OP
            // 
            this.TyrePressureRF_OP.Location = new System.Drawing.Point(0, 150);
            this.TyrePressureRF_OP.Name = "TyrePressureRF_OP";
            this.TyrePressureRF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyrePressureRF_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyrePressureRF_OP.TabIndex = 5;
            this.TyrePressureRF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyrePressureRF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyrePressureRF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TyrePressureLF_OP
            // 
            this.TyrePressureLF_OP.Location = new System.Drawing.Point(0, 0);
            this.TyrePressureLF_OP.Name = "TyrePressureLF_OP";
            this.TyrePressureLF_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TyrePressureLF_OP.Size = new System.Drawing.Size(1200, 150);
            this.TyrePressureLF_OP.TabIndex = 4;
            this.TyrePressureLF_OP.Text = "plotView2";
            this.TyrePressureLF_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TyrePressureLF_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TyrePressureLF_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Main
            // 
            this.Main.Controls.Add(this.Engine_Plot);
            this.Main.Controls.Add(this.GForces_Plot);
            this.Main.Controls.Add(this.Speed_Plot);
            this.Main.Controls.Add(this.TimeDiff_Plot);
            this.Main.Location = new System.Drawing.Point(4, 25);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(1200, 597);
            this.Main.TabIndex = 0;
            this.Main.Text = "MainPage";
            this.Main.UseVisualStyleBackColor = true;
            // 
            // Engine_Plot
            // 
            this.Engine_Plot.Location = new System.Drawing.Point(0, 450);
            this.Engine_Plot.Name = "Engine_Plot";
            this.Engine_Plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.Engine_Plot.Size = new System.Drawing.Size(1200, 150);
            this.Engine_Plot.TabIndex = 3;
            this.Engine_Plot.Text = "G_Froce";
            this.Engine_Plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.Engine_Plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.Engine_Plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // GForces_Plot
            // 
            this.GForces_Plot.Location = new System.Drawing.Point(0, 300);
            this.GForces_Plot.Name = "GForces_Plot";
            this.GForces_Plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.GForces_Plot.Size = new System.Drawing.Size(1200, 150);
            this.GForces_Plot.TabIndex = 2;
            this.GForces_Plot.Text = "G_Froce";
            this.GForces_Plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.GForces_Plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.GForces_Plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Speed_Plot
            // 
            this.Speed_Plot.Location = new System.Drawing.Point(0, 150);
            this.Speed_Plot.Name = "Speed_Plot";
            this.Speed_Plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.Speed_Plot.Size = new System.Drawing.Size(1200, 150);
            this.Speed_Plot.TabIndex = 1;
            this.Speed_Plot.Text = "Speed";
            this.Speed_Plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.Speed_Plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.Speed_Plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TimeDiff_Plot
            // 
            this.TimeDiff_Plot.Location = new System.Drawing.Point(0, 0);
            this.TimeDiff_Plot.Name = "TimeDiff_Plot";
            this.TimeDiff_Plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TimeDiff_Plot.Size = new System.Drawing.Size(1200, 150);
            this.TimeDiff_Plot.TabIndex = 0;
            this.TimeDiff_Plot.Text = "Time_Diff_PV";
            this.TimeDiff_Plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TimeDiff_Plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TimeDiff_Plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1213, 48);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(300, 300);
            this.dataGridView1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Main);
            this.tabControl1.Controls.Add(this.TyrePressure);
            this.tabControl1.Controls.Add(this.TyreTemp);
            this.tabControl1.Controls.Add(this.Suspension);
            this.tabControl1.Controls.Add(this.Dampers);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.MaximumSize = new System.Drawing.Size(1536, 864);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1208, 626);
            this.tabControl1.TabIndex = 2;
            // 
            // TrackLeght_OP
            // 
            this.TrackLeght_OP.Location = new System.Drawing.Point(4, 650);
            this.TrackLeght_OP.Name = "TrackLeght_OP";
            this.TrackLeght_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.TrackLeght_OP.Size = new System.Drawing.Size(1210, 100);
            this.TrackLeght_OP.TabIndex = 6;
            this.TrackLeght_OP.Text = "plotView1";
            this.TrackLeght_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.TrackLeght_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.TrackLeght_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.TrackLeght_OP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrackLeght_OP_Zoom_Changed);
            this.TrackLeght_OP.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.TrackLeght_OP_Zoom_Changed);
            // 
            // RaceTrack_OP
            // 
            this.RaceTrack_OP.Location = new System.Drawing.Point(1215, 450);
            this.RaceTrack_OP.Name = "RaceTrack_OP";
            this.RaceTrack_OP.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.RaceTrack_OP.Size = new System.Drawing.Size(300, 300);
            this.RaceTrack_OP.TabIndex = 7;
            this.RaceTrack_OP.Text = "plotView6";
            this.RaceTrack_OP.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.RaceTrack_OP.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.RaceTrack_OP.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1214, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1519, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackLeght_OP);
            this.Controls.Add(this.RaceTrack_OP);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RBR NGP Telemetry Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Dampers.ResumeLayout(false);
            this.Suspension.ResumeLayout(false);
            this.TyreTemp.ResumeLayout(false);
            this.TyrePressure.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem firstMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wTFToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage Dampers;
        private System.Windows.Forms.TabPage Suspension;
        private System.Windows.Forms.TabPage TyreTemp;
        private System.Windows.Forms.TabPage TyrePressure;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private OxyPlot.WindowsForms.PlotView TrackLeght_OP;
        private OxyPlot.WindowsForms.PlotView TimeDiff_Plot;
        private OxyPlot.WindowsForms.PlotView RaceTrack_OP;
        private OxyPlot.WindowsForms.PlotView TyrePressureRB_OP;
        private OxyPlot.WindowsForms.PlotView TyrePressureLB_OP;
        private OxyPlot.WindowsForms.PlotView TyrePressureRF_OP;
        private OxyPlot.WindowsForms.PlotView TyrePressureLF_OP;
        private OxyPlot.WindowsForms.PlotView TyreTempsRB_OP;
        private OxyPlot.WindowsForms.PlotView TyreTempsLB_OP;
        private OxyPlot.WindowsForms.PlotView TyreTempsRF_OP;
        private OxyPlot.WindowsForms.PlotView TyreTempsLF_OP;
        private System.Windows.Forms.ToolStripMenuItem workspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tyrePressureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tyreTempToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Suspension_Lines_Menu;
        private System.Windows.Forms.ToolStripMenuItem Suspension_Histogram_Menu;
        private OxyPlot.WindowsForms.PlotView SuspensionRB_OP;
        private OxyPlot.WindowsForms.PlotView SuspensionLB_OP;
        private OxyPlot.WindowsForms.PlotView SuspensionRF_OP;
        private OxyPlot.WindowsForms.PlotView SuspensionLF_OP;
        private OxyPlot.WindowsForms.PlotView DamperRB_OP;
        private OxyPlot.WindowsForms.PlotView DamperLB_OP;
        private OxyPlot.WindowsForms.PlotView DamperRF_OP;
        private OxyPlot.WindowsForms.PlotView DamperLF_OP;
        private System.Windows.Forms.ToolStripMenuItem dampersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Dampers_Lines_Menu;
        private System.Windows.Forms.ToolStripMenuItem Dampers_Histogram_Menu;
        private System.Windows.Forms.ToolStripMenuItem Show_WheelSpeed_Menu;
        private System.Windows.Forms.ToolStripMenuItem addWorkspaceToolStripMenuItem1;
        private OxyPlot.WindowsForms.PlotView GForces_Plot;
        private OxyPlot.WindowsForms.PlotView Speed_Plot;
        private OxyPlot.WindowsForms.PlotView Engine_Plot;
        private System.Windows.Forms.ToolStripTextBox Front_Bump_Treshold;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox Rear_Bump_Treshold;
        private System.Windows.Forms.Label label1;
    }
}

