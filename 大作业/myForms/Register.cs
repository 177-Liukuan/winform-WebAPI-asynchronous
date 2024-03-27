using AutoScaleHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 大作业.DBModel;

namespace 大作业.myForms
{
    public partial class Register : Form
    {
        //静态实例，用于全局共享
        public static readonly HttpClient clientInstance = new HttpClient();
        AutoScale autoScale = new AutoScale();
        //记录图片路径
        string filePath = "";


        //委托，用于在主页中关闭注册页面
        public event Action RegisterClosed;

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            RegisterClosed?.Invoke();
        }

        public Register()
        {
            InitializeComponent();
            autoScale.SetContainer(this);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void Register_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            autoScale.UpdateControlsLayout();
            this.ResumeLayout();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // 启用拖放功能
            panel2.AllowDrop = true;
            // 关联拖放事件
            panel2.DragEnter += Panel_DragEnter;
            panel2.DragDrop += Panel_DragDrop;
        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            // 检查拖放的数据是否包含文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 允许拖放操作
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Panel_DragDrop(object sender, DragEventArgs e)
        {


            try
            {
                // 获取拖放的文件路径数组
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // 处理拖放的文件路径（这里只是简单输出）
                if (files.Length > 0)
                {
                    filePath = files[0];
                    // filePathTextBox.Text = filePath;

                    Console.WriteLine($"拖放文件路径: {filePath}");

                    //将图片显示在panel上
                    Image img = Image.FromFile(filePath);
                    panel2.BackgroundImage = img;

                    //将panel2上的两个label控件隐藏
                    label10.Visible = false;
                    label11.Visible = false;



                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("请使用图片文件！");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("未知错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //清空所有输入框中的文本
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            //将panel2上的label控件显示，并且将panel2上的背景图片清空
            label10.Visible = true;
            label11.Visible = true;
            panel2.BackgroundImage = null;

            //将panel1上的单选按钮清空
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            //将两个富文本框重置
            richTextBox1.Text = "在这里填写WeChatOpenID";
            richTextBox2.Text = "在这里填写其他想要录入的信息";

            //清空下拉框
            comboBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //点击注册按钮后，调用API将所有信息录入数据库
                string URL = "http://119.45.167.20/api/User/AddUser";
                //设置请求头，这里假设服务器期望的是JSON格式的内容
                clientInstance.DefaultRequestHeaders.Accept.Clear();
                clientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //将所有文本输入框中的信息封装成一个用户对象
                用户实体 user = new 用户实体
                {
                    用户名 = textBox1.Text,
                    密码 = textBox2.Text,
                    手机号 = textBox3.Text,
                    邮箱 = textBox4.Text,
                    性别 = radioButton1.Checked ? 1 : 0,
                    年龄 = !string.IsNullOrWhiteSpace(textBox5.Text) ? int.Parse(textBox5.Text) : 0,
                    头像URL = filePath,
                    状态 = comboBox1.Text == "可用" ? 1 : 0,
                    其他 = richTextBox2.Text,
                    角色ID = !string.IsNullOrWhiteSpace(textBox6.Text) ? textBox6.Text : null,
                };

                //创建POST请求的内容
                var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");





                //发送POST请求
                HttpResponseMessage response = clientInstance.PostAsync(URL, jsonContent).Result;

                //确保响应成功
                response.EnsureSuccessStatusCode();

                //读取响应内容
                string responseBody = response.Content.ReadAsStringAsync().Result;

                //反序列化JSON响应到用户实体类
                var datas = JsonConvert.DeserializeObject<APIDataResult<用户实体>>(responseBody);

                //如果用户实体不为空，说明注册成功
                if (datas.Data != null)
                {
                    MessageBox.Show("注册成功！");
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("注册失败，请检查网络连接！");
            }

            catch (Exception ex)
            {
                MessageBox.Show("未知错误！");
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
