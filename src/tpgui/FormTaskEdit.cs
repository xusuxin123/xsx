using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xworks.taskprocess
{
    public partial class FormTaskEdit : Form
    {
        ListViewItem oldItem = new ListViewItem();
		public FormTaskEdit()
		{
			InitializeComponent();
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入作业者");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请输入详细");

            }
            else
            {
                //システム日付
                string system = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime sysDateTime = Convert.ToDateTime(system);

                //画面入力日付
                string input = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                DateTime inputDateTime = Convert.ToDateTime(input);

                if (sysDateTime > inputDateTime)
                {
                    MessageBox.Show("预定日应该为今天以后的日期");
                }
                else
                {
                    TaskFile tf = new TaskFile();
                    tf.addTask(dateTimePicker1.Value.ToString("yyyyMMddHHmmss"), textBox2.Text, textBox1.Text);
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("添加成功");
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("是否取消编辑?", "", messButton);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
