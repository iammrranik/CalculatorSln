using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorPro
{
    public partial class Design : Form
    {
        private double result = 0;
        private string operation = "";
        private bool enterValue = false;
        public Design()
        {
            InitializeComponent();
        }

        private void Design_Load(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblCalculation.Text = "";
        }


        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            enterValue = false;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            lblCalculation.Text = "";
            result = 0;
            operation = "";
            enterValue = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !enterValue)
            {
                double secondOperand;
                if (double.TryParse(txtDisplay.Text, out secondOperand))
                {
                    lblCalculation.Text = $"{result} {operation} {secondOperand} =";

                    switch (operation)
                    {
                        case "+":
                            result += secondOperand;
                            break;
                        case "-":
                            result -= secondOperand;
                            break;
                        case "*":
                            result *= secondOperand;
                            break;
                        case "/":
                            if (secondOperand != 0)
                            {
                                result /= secondOperand;
                            }
                            else
                            {
                                txtDisplay.Text = "Error: Division by zero";
                                //ResetCalculator();
                                enterValue = true;
                                operation= "";
                                result = 0;
                                lblCalculation.Text = "";
                                return;
                            }
                            break;
                    }

                    txtDisplay.Text = result.ToString();
                    operation = "";
                    enterValue = true;
                }
            }
            else if (enterValue)
            {
                lblCalculation.Text = "";
            }
        }

        private void PerformCalculation()
        {
            if (string.IsNullOrEmpty(operation)) return;

            double secondOperand;
            if (double.TryParse(txtDisplay.Text, out secondOperand))
            {
                switch (operation)
                {
                    case "+":
                        result += secondOperand;
                        break;
                    case "-":
                        result -= secondOperand;
                        break;
                    case "*":
                        result *= secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                        {
                            result /= secondOperand;
                        }
                        else
                        {
                            txtDisplay.Text = "Error: Division by zero";
                            //ResetCalculator();
                            enterValue = true;
                            operation = "";
                            result = 0;
                            lblCalculation.Text = "";
                            return;
                        }
                        break;
                    default:
                        break;
                }
                txtDisplay.Text = result.ToString();
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (enterValue)
            {
                txtDisplay.Text = "0.";
                enterValue = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !enterValue)
            {
                PerformCalculation();
            }

            if (double.TryParse(txtDisplay.Text, out double currentInputValue))
            {
                result = currentInputValue;
            }
            else
            {
                txtDisplay.Text = "Error";
                ResetCalculator();
                return;
            }

            operation = "+";
            enterValue = true;
            lblCalculation.Text = $"{result} +";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !enterValue)
            {
                PerformCalculation();
            }

            if (double.TryParse(txtDisplay.Text, out double currentInputValue))
            {
                result = currentInputValue;
            }
            else
            {
                txtDisplay.Text = "Error";
                ResetCalculator();
                return;
            }

            operation = "-";
            enterValue = true;
            lblCalculation.Text = $"{result} -";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !enterValue)
            {
                PerformCalculation();
            }

            if (double.TryParse(txtDisplay.Text, out double currentInputValue))
            {
                result = currentInputValue;
            }
            else
            {
                txtDisplay.Text = "Error";
                ResetCalculator();
                return;
            }

            operation = "*";
            enterValue = true;
            lblCalculation.Text = $"{result} x";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation) && !enterValue)
            {
                PerformCalculation();
            }

            if (double.TryParse(txtDisplay.Text, out double currentInputValue))
            {
                result = currentInputValue;
            }
            else
            {
                txtDisplay.Text = "Error";
                ResetCalculator();
                return;
            }

            operation = "/";
            enterValue = true;
            lblCalculation.Text = $"{result} /";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "0";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "0";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "1";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "1";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "2";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "2";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "3";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "3";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "4";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "4";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "5";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "5";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "6";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "6";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "7";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "7";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "8";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "8";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (enterValue || txtDisplay.Text == "0" || txtDisplay.Text == "Error: Division by zero")
            {
                txtDisplay.Text = "9";
                enterValue = false;
            }
            else
            {
                txtDisplay.Text += "9";
            }
            if (!string.IsNullOrEmpty(operation) && result != 0)
            {
                lblCalculation.Text = $"{result} {operation} {txtDisplay.Text}";
            }
        }

        private void Design_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
