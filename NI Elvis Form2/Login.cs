using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NI_Elvis_Form2
{
    public partial class Login : Form
    {
        HttpClient client;
        public Login()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7184/");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User() { Email = textBox1.Text, Password = textBox2.Text };

            var postContent = new StringContent(JsonSerializer.Serialize(user, new JsonSerializerOptions()
            { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }), Encoding.UTF8, "application/json");


            var result = client.PostAsync("/api/Values/Login", postContent).GetAwaiter().GetResult();

            var message = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if(message == "Login success")
            {
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }

            //if (result.IsSuccessStatusCode)
            //{
            //    //var message = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //    //label2.Text = message;
            //    this.Hide();
            //    Form1 form = new Form1();
            //    form.Show();


            //}

            else { label2.Text = message; }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
