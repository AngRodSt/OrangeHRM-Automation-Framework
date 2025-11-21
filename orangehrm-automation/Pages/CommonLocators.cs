using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orangehrm_Automation.Pages
{
    public static class CommonLocators
    {
        public static readonly By dashboardText = By.XPath("//h6[text()='Dashboard']");
        //Navigation Links
        public static By AdminLink = By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']");
        public static By PIMLink = By.XPath("//a[@href='/web/index.php/pim/viewPimModule']");
        public static By LeaveLink = By.XPath("//a[@href='/web/index.php/leave/viewLeaveModule']");
        public static By TimeLink = By.XPath("//a[@href='/web/index.php/time/viewTimeModule']");
        public static By RecruitmentLink = By.XPath("//a[@href='/web/index.php/recruitment/viewRecruitmentModule']");
        public static By MyInfoLink = By.XPath("//a[@href='/web/index.php/pim/viewMyDetails']");
        public static By PerformanceLink = By.XPath("//a[@href='/web/index.php/performance/viewPerformanceModule']");
        public static By DashboardLink = By.XPath("//a[@href='/web/index.php/dashboard/index']");
        public static By DirectoryLink = By.XPath("//a[@href='/web/index.php/directory/viewDirectory']");
        public static By MaintenanceLink = By.XPath("//a[@href='/web/index.php/maintenance/viewMaintenanceModule']");
        public static By BuzzLink = By.XPath("//a[@href='/web/index.php/buzz/viewBuzz']");
        public static By ClaimLink = By.XPath("//a[@href='/web/index.php/claim/viewClaimModule']");


    }
}
