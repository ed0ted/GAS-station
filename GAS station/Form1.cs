using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;
namespace GAS_station
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			timer1.Interval = 5000;
			groupBox1.Text = "Gas";
			label1.Text = "Gas type: ";
			comboBox1.Items.AddRange(new string[] {"A-95", "Diesel", "Gas" });
			comboBox1.SelectedItem = "A-95";
			label2.Text = "Price: ";
			textBox1.Enabled = false;
			//label3.Text = "Amount";
			groupBox2.Text = "Amount";
			radioButton1.Text = "Litres";
			radioButton2.Text = "Sum";
			label3.Text = "L.";
			label4.Text = "UAH";
			radioButton1.Checked = true;
			groupBox3.Text = "";
			label5.Text = "To pay: ";
			label6.Text = "0";
			label11.Text = "UAH";

			textBox2.Text = "0";
			textBox3.Text = "0";
			label14.Text = "0";
			groupBox5.Text = "";
			groupBox4.Text = "Mini-shop";
			checkBox1.Text = "Hot-dog";
			checkBox2.Text = "Burger";
			checkBox3.Text = "Donut";
			checkBox4.Text = "Pepsi 0.5";
			checkBox5.Text = "Sprite 0.5";
			checkBox6.Text = "Coffee 0.25";
			checkBox7.Text = "Tea 0.25";

			label8.Text = "To pay: ";
			label7.Text = "0";
			label12.Text = "UAH";

			label9.Text = "Price";
			label10.Text = "Quantity";

			textBox4.Enabled = false;
			textBox4.Text = "34,50";
			textBox5.Enabled = false;
			textBox5.Text = "0";
			textBox7.Enabled = false;
			textBox7.Text = "39,00";
			textBox6.Enabled = false;
			textBox6.Text = "0";
			textBox9.Enabled = false;
			textBox9.Text = "19,99";
			textBox8.Enabled = false;
			textBox8.Text = "0";
			textBox11.Enabled = false;
			textBox11.Text = "19,00";
			textBox10.Enabled = false;
			textBox10.Text = "0";
			textBox13.Enabled = false;
			textBox13.Text = "19,00";
			textBox12.Enabled = false;
			textBox12.Text = "0";
			textBox15.Enabled = false;
			textBox15.Text = "16,00";
			textBox14.Enabled = false;
			textBox14.Text = "0";
			textBox17.Enabled = false;
			textBox17.Text = "10,50";
			textBox16.Enabled = false;
			textBox16.Text = "0";

			groupBox6.Text = "Sum up";
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			label13.Text = "Together: ";
			label15.Text = "UAH";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			string HtmlText = string.Empty;
			try
			{
				HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create("https://index.minfin.com.ua/ua/markets/fuel/");
				HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
				StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
				HtmlText = strm.ReadToEnd();
				//Console.Clear();


				if (comboBox1.SelectedItem.ToString() == "A-95")
				{
					Regex price95 = new Regex(@"\d+\,\d+");
					Regex r95 = new Regex(@"А-95\D+\d+\,\d+");
					Match m; Match mm;
					m = r95.Match(HtmlText);
					if (m.Success)
					{
						string mtemp = m.Value;
						mm = price95.Match(mtemp);
						string finalvalue = mm.Value.Replace(".", ",");
						textBox1.Text = finalvalue;
					}
				}

				else if (comboBox1.SelectedItem.ToString() == "Diesel")
				{
					Regex price95 = new Regex(@"\d+\,\d+");
					Regex r95 = new Regex(@"Дизельне\D+\d+\,\d+");
					Match m; Match mm;
					m = r95.Match(HtmlText);
					if (m.Success)
					{
						string mtemp = m.Value;
						mm = price95.Match(mtemp);
						string finalvalue = mm.Value.Replace(".", ",");
						textBox1.Text = finalvalue;
					}
				}
				else if (comboBox1.SelectedItem.ToString() == "Gas")
				{
					Regex price95 = new Regex(@"\d+\,\d+");
					Regex r95 = new Regex(@"Газ\D+\d+\,\d+");
					Match m; Match mm;
					m = r95.Match(HtmlText);
					if (m.Success)
					{
						string mtemp = m.Value;
						mm = price95.Match(mtemp);
						string finalvalue = mm.Value.Replace(".", ",");
						textBox1.Text = finalvalue;
					}
				}


			}
			catch
			{
				MessageBox.Show("Can not calculate price of the fuel!");
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			textBox2.Enabled = true;
			textBox3.Enabled = false;
		}
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			textBox2.Enabled = false;
			textBox3.Enabled = true;
		}
		double gassum = 0;
		private void textBox2_TextChanged(object sender, EventArgs e)
		{

			if (((TextBox)sender).Text == "") 
			{
				((TextBox)sender).Text = "0";
			}
			string s = textBox1.Text;
			double a=0;
			if(s!="")
			 a = Convert.ToDouble(s);
			string ss = textBox2.Text;

			float aa = float.Parse(ss);
			gassum = a * aa;
			label6.Text = Convert.ToString(a * aa);
			
			
		}
		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			string s = textBox1.Text;
			double a = 0;
			if (s != "")
				a = Convert.ToDouble(s);
			textBox2.Text = Convert.ToString(Convert.ToDouble(textBox3.Text) / a);
			gassum = Convert.ToDouble(textBox3.Text);
			label6.Text = textBox3.Text;
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}


		double shopsum;
		
		int tempquantity1 = 0;
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{ 
				textBox5.Enabled = true;
				textBox5.Text = "1";
				tempquantity1 = 1;
			}
			if(checkBox1.Checked==false)
			{
				double d = tempquantity1 * Convert.ToDouble(textBox4.Text);
				shopsum -= d;
				tempquantity1 = 0;
				textBox5.Enabled = false;
				textBox5.Text = "0";
			}
		}
		private void textBox5_TextChanged(object sender, EventArgs e)
		{


			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox4.Text) * (Convert.ToDouble(textBox5.Text)-tempquantity1);
			tempquantity1 = Convert.ToInt32(textBox5.Text);


			label7.Text = Convert.ToString(shopsum);
		}

		int tempquantity2 = 0;
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				textBox6.Enabled = true;
				textBox6.Text = "1";
				tempquantity2 = 1;
			}
			if (checkBox2.Checked == false)
			{
				double d = tempquantity2 * Convert.ToDouble(textBox7.Text);
				shopsum -= d;
				tempquantity2 = 0;
				textBox6.Enabled = false;
				textBox6.Text = "0";
			}
		}
		private void textBox6_TextChanged(object sender, EventArgs e)
		{

			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox7.Text) * (Convert.ToDouble(textBox6.Text)-tempquantity2);
			tempquantity2 = Convert.ToInt32(textBox6.Text);


			label7.Text = Convert.ToString(shopsum);
		}


		int tempquantity3 = 0;
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true)
			{
				textBox8.Enabled = true;
				textBox8.Text = "1";
				tempquantity3 = 1;
			}
			if (checkBox3.Checked == false)
			{
				double d = tempquantity3 * Convert.ToDouble(textBox9.Text);
				shopsum -= d;
				tempquantity3 = 0;
				textBox8.Enabled = false;
				textBox8.Text = "0";
			}
		}
		private void textBox8_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox9.Text) * (Convert.ToDouble(textBox8.Text) - tempquantity3);
			tempquantity3 = Convert.ToInt32(textBox8.Text);


			label7.Text = Convert.ToString(shopsum);
		}

		int tempquantity4 = 0;
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked == true)
			{
				textBox10.Enabled = true;
				textBox10.Text = "1";
				tempquantity4 = 1;
			}
			if (checkBox4.Checked == false)
			{
				double d = tempquantity4 * Convert.ToDouble(textBox11.Text);
				shopsum -= d;
				tempquantity4 = 0;
				textBox10.Enabled = false;
				textBox10.Text = "0";
			}
		}
		private void textBox10_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox11.Text) * (Convert.ToDouble(textBox10.Text) - tempquantity4);
			tempquantity4 = Convert.ToInt32(textBox10.Text);


			label7.Text = Convert.ToString(shopsum);
		}

		int tempquantity5 = 0;
		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.Checked == true)
			{
				textBox12.Enabled = true;
				textBox12.Text = "1";
				tempquantity5 = 1;
			}
			if (checkBox5.Checked == false)
			{
				double d = tempquantity5 * Convert.ToDouble(textBox13.Text);
				shopsum -= d;
				tempquantity5 = 0;
				textBox12.Enabled = false;
				textBox12.Text = "0";
			}
		}
		private void textBox12_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox13.Text) * (Convert.ToDouble(textBox12.Text) - tempquantity5);
			tempquantity5 = Convert.ToInt32(textBox12.Text);


			label7.Text = Convert.ToString(shopsum);
		}

		int tempquantity6 = 0;
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox6.Checked == true)
			{
				textBox14.Enabled = true;
				textBox14.Text = "1";
				tempquantity6 = 1;
			}
			if (checkBox6.Checked == false)
			{
				double d = tempquantity6 * Convert.ToDouble(textBox15.Text);
				shopsum -= d;
				tempquantity6 = 0;
				textBox14.Enabled = false;
				textBox14.Text = "0";
			}
		}
		private void textBox14_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox15.Text) * (Convert.ToDouble(textBox14.Text) - tempquantity6);
			tempquantity6 = Convert.ToInt32(textBox14.Text);


			label7.Text = Convert.ToString(shopsum);
		}

		int tempquantity7 = 0;
		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox7.Checked == true)
			{
				textBox16.Enabled = true;
				textBox16.Text = "1";
				tempquantity7 = 1;
			}
			if (checkBox7.Checked == false)
			{
				double d = tempquantity7 * Convert.ToDouble(textBox17.Text);
				shopsum -= d;
				tempquantity7 = 0;
				textBox16.Enabled = false;
				textBox16.Text = "0";
			}
		}
		private void textBox16_TextChanged(object sender, EventArgs e)
		{
			if (((TextBox)sender).Text == "")
			{
				((TextBox)sender).Text = "0";
			}
			shopsum += Convert.ToDouble(textBox17.Text) * (Convert.ToDouble(textBox16.Text) - tempquantity7);
			tempquantity7 = Convert.ToInt32(textBox16.Text);


			label7.Text = Convert.ToString(shopsum);
		}

		private void label6_TextChanged(object sender, EventArgs e)
		{
			//label14.Text = Convert.ToString(gassum+shopsum);
		}

		private void label7_TextChanged(object sender, EventArgs e)
		{
			//label14.Text = Convert.ToString(gassum + shopsum);
		}
		DialogResult d;
		private void button1_Click(object sender, EventArgs e)
		{
			
			
			timer1.Start();
			
			d = MessageBox.Show( "Counting...","Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			
			if (d == DialogResult.Cancel)
			{
				label6.Text = "0";
				label7.Text = "0";
				timer1.Stop();
			}

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label14.Text = Convert.ToString(gassum + shopsum); 
			timer1.Stop();
			
		}
	}
}

