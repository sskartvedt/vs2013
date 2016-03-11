using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        const string noValue = "0";
        const string zeroDecimal = ",000";
        const string plusSign = "+";
        const string minusSign = "-";
        const string divisionSign = "/";
        const string multiplicationSign = "x";
        const string decimalSign = ",";

        string memory = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ± 00B1
            // ← 2190
            // √ 221A

            //lblValue.TextAlign = ContentAlignment.MiddleRight;
            //lblValue.Font = new Font("Consolas", 20);
            //lblValue.BorderStyle = BorderStyle.Fixed3D;
            //lblValue.BackColor = Color.White;
            //lblValue.AutoSize = false;
            //lblValue.Width = 274;
            //lblValue.Height = 41;
            //lblValue.Text = "0";
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (lblValue.Text == noValue)
                lblValue.Text = String.Empty;

            lblValue.Text += btn.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string newValue = noValue;
            int length = Convert.ToInt32(lblValue.Text.Length);

            if (length > 1)
                newValue = lblValue.Text.Substring(0, length - 1);

            lblValue.Text = newValue;

            if (lblValue.Text.Equals(minusSign))
                lblValue.Text = noValue;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string newValue = noValue;
            lblValue.Text = newValue;
        }

        private void btnMemory_Click(object sender, EventArgs e)
        {
            memory = lblValue.Text;
            lblValue.Text = noValue;
        }

        private void btnMemoryRecall_Click(object sender, EventArgs e)
        {
            lblValue.Text = memory;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            bool hasDecimal = lblValue.Text.Contains(decimalSign);
            if (!hasDecimal)
                lblValue.Text += decimalSign;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            bool hasSign = lblValue.Text.Contains(minusSign);
            if (hasSign)
                lblValue.Text = lblValue.Text.Replace(minusSign, String.Empty);
            else if (lblValue.Text != noValue)
                lblValue.Text = lblValue.Text.Insert(0, minusSign);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lblMathFunction.Text = btn.Text;
            lblNumber1.Text = lblValue.Text;
            lblValue.Text = noValue;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            var endsWithDecimalSign = lblNumber1.Text.EndsWith(decimalSign);
            int length = Convert.ToInt32(lblNumber1.Text.Length);
            if(endsWithDecimalSign)
                lblNumber1.Text = lblNumber1.Text.Substring(0, length - 1);

            endsWithDecimalSign = lblValue.Text.EndsWith(decimalSign);
            length = Convert.ToInt32(lblValue.Text.Length);
            if (endsWithDecimalSign)
                lblValue.Text = lblValue.Text.Substring(0, length - 1);

            var value1 = Convert.ToDouble(lblNumber1.Text);
            var value2 = Convert.ToDouble(lblValue.Text);
            var mathFunction = lblMathFunction.Text;
            var result = 0d; //decimal = 0m, double = 0d

            if (mathFunction.Equals(plusSign))
                result = value1 + value2;

            if (mathFunction.Equals(minusSign))
                result = value1 - value2;

            if (mathFunction.Equals(divisionSign))
                result = value1 / value2;

            if (mathFunction.Equals(multiplicationSign))
                result = value1 * value2;

            lblMathFunction.Text = String.Empty;
            lblNumber1.Text = String.Empty;
            lblValue.Text = result.ToString("F3").Replace(zeroDecimal, String.Empty); //change "0," to "" and result is displayed with 3 decimals
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            bool hasSign = lblValue.Text.Contains(minusSign);
            if (hasSign)
            {
                MessageBox.Show("Cannot calculate the square root of a negative number");
                return;
            }

            var endsWithDecimalSign = lblValue.Text.EndsWith(decimalSign);
            int length = Convert.ToInt32(lblValue.Text.Length);
            if (endsWithDecimalSign)
                lblValue.Text = lblValue.Text.Substring(0, length - 1);

            var value = Convert.ToDouble(lblValue.Text);
            var result = Math.Sqrt(value);
            lblValue.Text = result.ToString();
        }
    }
}
