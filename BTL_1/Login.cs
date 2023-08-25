using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string connstring = "Data Source = LAPTOP-CGDMGH31\\MSSQLSERVER2023; Initial Catalog = QL_THU_VIEN; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
                string tk = txt_ID.Text;
                string mk = txt_Password.Text;
                string sql = "select * from Taikhoan where tk = '" + tk + "' and mk = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối!!!");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Do you want to close this window?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
