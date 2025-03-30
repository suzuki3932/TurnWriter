using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class TurnWriter : Form {
    private TextBox textbox1;
    private MenuStrip menu;
    private ToolStripMenuItem filemenu;
    private ToolStripMenuItem opensubmenu;
    private ToolStripMenuItem savesubmenu;
    private ToolStripMenuItem exitsubmenu;
    private ToolStripMenuItem overwritesavesubmenu;
    public TurnWriter() {
        InitializeComponent();
        this.Resize += TurnWriter_Resize;
    }
    private void InitializeComponent() {
        // ウィンドウのサイズ
        this.Size = new Size(600, 750);
        // 一番上のメニュー
        this.Text = "TurnWriter 1.0";
        this.filemenu = new ToolStripMenuItem();
        filemenu.Text = "ファイル";
        this.opensubmenu = new ToolStripMenuItem();
        opensubmenu.Text = "開く";
        opensubmenu.Click += opensubmenu_clicked;
        this.overwritesavesubmenu = new ToolStripMenuItem();
        overwritesavesubmenu.Text = "上書き保存";
        overwritesavesubmenu.Click += overwritesavesubmenu_clicked;
        this.savesubmenu = new ToolStripMenuItem();
        savesubmenu.Text = "名前を付けて保存";
        savesubmenu.Click += savesubmenu_clicked;
        this.exitsubmenu = new ToolStripMenuItem();
        exitsubmenu.Text = "終了";
        exitsubmenu.Click += exitsubmenu_clicked;
        this.menu = new MenuStrip();
        filemenu.DropDownItems.Add(opensubmenu);
        filemenu.DropDownItems.Add(overwritesavesubmenu);
        filemenu.DropDownItems.Add(savesubmenu);
        filemenu.DropDownItems.Add(exitsubmenu);
        menu.Items.Add(filemenu);
        this.Controls.Add(menu);
        // 入力欄
        this.textbox1 = new TextBox();
        this.textbox1.Multiline = true;
        this.textbox1.Dock = DockStyle.None;
        this.textbox1.Location = new Point(0, menu.Height);
        this.textbox1.Width = this.ClientSize.Width;
        this.textbox1.Height = this.ClientSize.Height - menu.Height;
        this.Controls.Add(textbox1);
    }
    public static void Main(string[] args) {
     Application.EnableVisualStyles();
     Application.SetCompatibleTextRenderingDefault(false);
     Application.Run(new TurnWriter());
    }
    private void TurnWriter_Resize(object sender, EventArgs e) {
        if (textbox1 != null && menu !=null) {
            textbox1.Width = this.ClientSize.Width;
            textbox1.Height = this.ClientSize.Height;
        }
    }
    private void exitsubmenu_clicked(object sender, EventArgs e) {
        Application.Exit();
    }
    private void savesubmenu_clicked(object sender, EventArgs e) {
     SaveFileDialog savedialog = new SaveFileDialog();
     savedialog.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
     if (savedialog.ShowDialog() == DialogResult.OK) {
        string filepath = savedialog.FileName;
        try {
            File.WriteAllText(filepath, textbox1.Text);
        } catch (Exception ex) {
            MessageBox.Show("名前を付けて保存できませんでした。\n" + ex.Message, "TurnWriter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
     } 
    }
}