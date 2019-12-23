using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;


namespace StokTakip
{
    public partial class Form1 : Form
    {
        List<Product> product = new List<Product>();
        List<Category> cate = new List<Category>();
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new Connection().GetConnection();
            conn.Open();
            SqlCommand cmdCate = new SqlCommand("SELECT * FROM category", conn);
            SqlDataReader dr = cmdCate.ExecuteReader();
            comboBoxCategory.Items.Clear();
            while (dr.Read())
            {
                comboBoxCategory.Items.Add(dr["cate_name"]);
                cate.Add(new Category() {
                    cate_id = ((int)dr["cate_id"]),
                    cate_name = dr["cate_name"] as string
                });
            }
            conn.Close();
            conn.Open();
            SqlCommand cmdProduct = new SqlCommand("SELECT * FROM product", conn);
            SqlDataReader dr1 = cmdProduct.ExecuteReader(); 
            while (dr1.Read())
            {
                product.Add(new Product()
                {
                    product_id = ((int) dr1["product_id"]),
                    product_name = dr1["product_name"] as string,
                    id = ((int) dr1["id"])
            });

            }
            conn.Close();
        }
        private string[] GetProductById(int cate_id)
        {
            return product.Where(line => line.id == cate_id).Select(l => l.product_name).ToArray();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //comboBoxProduct.ProductName.Take = ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProduct.Items.Clear(); 
            int id = cate[comboBoxCategory.SelectedIndex].cate_id;
            foreach (string product_name in GetProductById(id)) 
            {
                this.comboBoxProduct.Items.Add(product_name);
            }

        }
        

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    [Serializable]
    class Category
    {
        public int cate_id { get; set; }
        public string cate_name { get; set; }
    }
    class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int id { get; set; }

    }
}
