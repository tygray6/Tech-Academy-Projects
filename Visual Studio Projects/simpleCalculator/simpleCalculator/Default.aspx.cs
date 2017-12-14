using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace simpleCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string firstNumber = firstValue.Text;
            string secondNumber = secondValue.Text;

            int firstInt = int.Parse(firstNumber);
            int secondInt = int.Parse(secondNumber);

            int solution = firstInt + secondInt;

            string problemSolution = solution.ToString();

            resultLabel.Text = problemSolution;

        }

        protected void subtractButton_Click(object sender, EventArgs e)
        {
            string firstNumber = firstValue.Text;
            string secondNumber = secondValue.Text;

            int firstInt = int.Parse(firstNumber);
            int secondInt = int.Parse(secondNumber);

            int solution = firstInt - secondInt;

            string problemSolution = solution.ToString();

            resultLabel.Text = problemSolution;
        }

        protected void multiplyButton_Click(object sender, EventArgs e)
        {
            string firstNumber = firstValue.Text;
            string secondNumber = secondValue.Text;

            int firstInt = int.Parse(firstNumber);
            int secondInt = int.Parse(secondNumber);

            int solution = firstInt * secondInt;

            string problemSolution = solution.ToString();

            resultLabel.Text = problemSolution;
        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            string firstNumber = firstValue.Text;
            string secondNumber = secondValue.Text;

            double firstInt = double.Parse(firstNumber);
            double secondInt = double.Parse(secondNumber);

            double solution = firstInt / secondInt;

            string problemSolution = solution.ToString();

            resultLabel.Text = problemSolution;
        }
    }
}