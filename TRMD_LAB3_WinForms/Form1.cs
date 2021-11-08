using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRMD_LAB3_WinForms
{
    public partial class Form1 : Form
    {
        public User CurrentUser { get; set; }
        public List<User> AllUsers { get; set; } = new List<User>();

        public Form1()
        {
            InitializeComponent();
            SetRegisterElementVisisble(false);
            SetEntryElementVisisble(false);
            SetFilterElementVisisble(false);
            SetMsgLabel("", false, Color.Red);
            CurrentUser = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void реєстраціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRegisterElementVisisble(true);
            SetEntryElementVisisble(false);
            SetFilterElementVisisble(false);
            SetMsgLabel("", false, Color.Red);
        }

        private void вхідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                SetMsgLabel($"Current user is {CurrentUser.Login}", true, Color.Green);
                return;
            }
            SetRegisterElementVisisble(false);
            SetEntryElementVisisble(true);
            SetFilterElementVisisble(false);
            SetMsgLabel("", false, Color.Red);
            
        }

        private void отриманняДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRegisterElementVisisble(false);
            SetEntryElementVisisble(false);
            SetFilterElementVisisble(true);
            SetMsgLabel("", false, Color.Red);
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SetRegisterElementVisisble(false);
            SetEntryElementVisisble(false);
            SetFilterElementVisisble(false);
            SetMsgLabel("Exit successfuly",  true, Color.Green);
            CurrentUser = null;
        }

        private void SetRegisterElementVisisble(bool visible)
        {
            Register_textBox1.Visible = visible;
            Register_textBox2.Visible = visible;
            Register_dateTimePicker1.Visible = visible;
            Register_textBox4.Visible = visible;

            Register_label1.Visible = visible;
            Register_label2.Visible = visible;
            Register_label3.Visible = visible;
            Register_label4.Visible = visible;

            Register_button1.Visible = visible;
        }
        private void SetEntryElementVisisble(bool visible)
        {
            Login_textBox1.Visible = visible;
            Login_textBox2.Visible = visible;

            Login_Label1.Visible = visible;
            Login_label2.Visible = visible;

            Login_button1.Visible = visible;
        }
        private void SetFilterElementVisisble(bool visible)
        {
            Filter_dateTimePicker1.Visible = visible;
            Filter_dateTimePicker2.Visible = visible;
            Filter_textBox5.Visible = visible;
            Filter_textBox6.Visible = visible;

            Filter_label1.Visible = visible;
            Filter_label2.Visible = visible;
            Filter_label3.Visible = visible;
            Filter_label4.Visible = visible;

            Filter_checkBox1.Visible = visible;
            Filter_checkBox2.Visible = visible;
            Filter_checkBox3.Visible = visible;
            Filter_checkBox4.Visible = visible;


            Filter_button1.Visible = visible;
        }

        private void Register_textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void SetMsgLabel(string text, bool visible, Color forecolor)
        {
            Message_label1.Text = text;
            Message_label1.Visible = visible;
            Message_label1.ForeColor = forecolor;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_button1_Click(object sender, EventArgs e)
        {
            var login = Login_textBox1.Text;
            var pass = Login_textBox2.Text;
            if (string.IsNullOrEmpty(login))
            {
                SetMsgLabel("Incorrect login", true, Color.Red);
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                SetMsgLabel("Incorrect password", true, Color.Red);
                return;
            }
            var user = AllUsers.FirstOrDefault(x => x.Login==login && x.Password==pass);
            if (user == null)
            {
                SetMsgLabel("Incorrect login or password", true, Color.Red);
                return;
            }
            CurrentUser = user;

            SetMsgLabel($"Welcome, {login}!", true, Color.Green);
            return;
        }

        private void Filter_button1_Click(object sender, EventArgs e)
        {
            var login = Filter_textBox5.Text;
            var datecreated = Filter_dateTimePicker1.Value;
            var age = DateTime.Now.Year - Filter_dateTimePicker2.Value.Year;
            var gender = Filter_textBox6.Text;
            var useLogin = Filter_checkBox1.Checked ;
            var useDatecreated = Filter_checkBox2.Checked;
            var useAge = Filter_checkBox3.Checked;
            var useGender = Filter_checkBox4.Checked;
            var usercount = 0;
            var successMsg = "Users ";
            var errorMsg = "User not found";

            if (useLogin)
            {
                usercount = AllUsers.Where(x => x.Login == login).ToList().Count;
                successMsg = $"{successMsg} with login {login},";
            }
            if (useDatecreated)
            {
                usercount = AllUsers.Where(x => x.DateCreated.Date >= datecreated.Date).ToList().Count;
                successMsg = $"{successMsg}  datecreated after {datecreated.Date.Date},";
            }
            if (useAge)
            {
                usercount = AllUsers.Where(x => x.Age == age).ToList().Count;
                successMsg = $"{successMsg} with age {age},";
            }
            if (useGender)
            {
                usercount = AllUsers.Where(x => x.Gender == gender).ToList().Count;
                successMsg = $"{successMsg} with gender {gender}";
            }

            if (usercount == 0)
            {
                SetMsgLabel($"{errorMsg}", true, Color.Red);
                return;
            }

            SetMsgLabel($"{successMsg} count = {usercount}", true, Color.Green);
        }

        private void Register_button1_Click(object sender, EventArgs e)
        {
            var login = Register_textBox1.Text;
            var pass = Register_textBox2.Text;
            var age = DateTime.Now.Year - Register_dateTimePicker1.Value.Year;
            var gender = Register_textBox4.Text;


            if (age < 15)
            {
                SetMsgLabel("You must more 15 age old", true, Color.Red);
                return;
            }
            if (string.IsNullOrEmpty(login))
            {
                SetMsgLabel("Incorrect login", true, Color.Red);
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                SetMsgLabel("Incorrect password", true, Color.Red);
                return;
            }
            if (string.IsNullOrEmpty(gender))
            {
                SetMsgLabel("Incorrect gender", true, Color.Red);
                return;
            }
            var userWithLogin = AllUsers.Any(x => x.Login == login);
            if (userWithLogin)
            {
                SetMsgLabel($"User with login {login} already exist", true, Color.Red);
                return;
            }



            var newUser = new User()
            {
                Login = login,
                Password = pass,
                Age = age,
                Gender = gender,
                DateCreated = DateTime.Now
            };
            AllUsers.Add(newUser);

            SetMsgLabel($"User with Nickname {login} has registered successfully", true, Color.Green);
            SetRegisterElementVisisble(false);
            return;
        }
    }
}
