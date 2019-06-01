using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            [Test]
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();

            }

            [Test]
            public void ViewandDelete()
            {
                test = extent.StartTest("Manage Listings of Skills");

                //Class and object 
                ManageListing view = new ManageListing();
                view.ViewListing();
                
            }

            [Test]
            public void AddSkill()
            {
                test = extent.StartTest("Add Skills");

                //Class and Object
                ShareSkill addnew = new ShareSkill();
                    addnew.AddNewShareSkill();
            }
        }
    }
}