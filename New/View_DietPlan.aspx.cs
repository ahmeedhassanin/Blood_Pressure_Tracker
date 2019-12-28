using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class View_DietPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sample = add_bloodpressure.pressure;

            string[] temp = sample.Split('/');
            int high = int.Parse(temp[0]);
            int low = int.Parse(temp[1]);

            ServiceReference1.WebService1SoapClient s = new ServiceReference1.WebService1SoapClient();

            ServiceReference1.DietPlanClass plan = new ServiceReference1.DietPlanClass();
            //-------------------------------------------------------------------------------------
            if (add_bloodpressure.agee() >= 6 && add_bloodpressure.agee() <= 29)
            {
                if (high >= 109 && high <= 133 && low >= 76 && low <= 85)
                {
                  
                    plan = s.ViewDietPlan("TypeA");

                }
                else if (high < 109 && low < 76)
                {
                    
                    plan = s.ViewDietPlan("TypeB");

                }
                else if (high > 133 && low > 85)
                {
                    
                    plan = s.ViewDietPlan("TypeC");

                }



            }
            else if (add_bloodpressure.agee() >= 30 && add_bloodpressure.agee() <= 39)
            {
                if (high >= 111 && high <= 135 && low >= 78 && low <= 86)
                {
                 
                    plan = s.ViewDietPlan("TypeD");

                }
                else if (high < 111 && low < 78)
                {
                    
                    plan = s.ViewDietPlan("TypeA");

                }
                else if (high > 135 && low > 86)
                {
                   
                    plan = s.ViewDietPlan("TypeB");

                }


            }
            else if (add_bloodpressure.agee() >= 40)
            {
                if (high >= 121 && high <= 147 && low >= 83 && low <= 91)
                {
                   
                    plan = s.ViewDietPlan("TypeC");

                }
                else if (high < 121 && low < 83)
                {
                    
                    plan = s.ViewDietPlan("TypeD");

                }
                else if (high > 147 && low > 91)
                {
                    
                    plan = s.ViewDietPlan("TypeB");

                }


            }
            //------------------------------------------------------------------------------------
          

            Label_Veges.Text = plan.veges;
            Label_Fruit.Text = plan.fruit;
            Label_Meat.Text = plan.meat;
            Label_Drinks.Text = plan.drinks;
            Label_Milk.Text = plan.milk;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Main_Form.aspx");
        }
    }
}