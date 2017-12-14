using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstChallenge
{
    public partial class FirstChallenge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_Click(object sender, EventArgs e)
        {
            string age = ageBox.Text;
            string money = moneyBox.Text;

            string result = "At " + age + " years old, I would have expected you would have more than " + money + " dollars in your pocket.";

            resultLabel.Text = result;

        }
    }
}