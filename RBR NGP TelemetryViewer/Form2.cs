using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBR_NGP_TelemetryViewer
{
    public partial class Form2 : Form
    {
        List<ComboBox> comboBoxes = new List<ComboBox>();

        public Form2()
        {
            InitializeComponent();
            comboBoxes.Add(comboBox1);
            comboBoxes.Add(comboBox2);
            comboBoxes.Add(comboBox3);
            comboBoxes.Add(comboBox4);
            comboBoxes.Add(comboBox5);
            comboBoxes.Add(comboBox6);
            comboBoxes.Add(comboBox7);
            comboBoxes.Add(comboBox8);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            object[] newobj = Form1.columnsname_form2.ToArray();
            foreach (ComboBox cb in comboBoxes)
                cb.Items.AddRange(newobj);
            Form1.user_workspace.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ComboBox cb in comboBoxes)
                Form1.user_workspace.Add(cb.Text);
            this.Close();
        }
    }
}
