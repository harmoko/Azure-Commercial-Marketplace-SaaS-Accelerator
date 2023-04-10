﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.SaaS.Accelerator.DataAccess.Migrations.Custom
{
    internal static class BaselineV6_Seed
    {
        public static void BaselineV6_SeedData(this MigrationBuilder migrationBuilder)
        {
            var seedDate = DateTime.Now;
            migrationBuilder.Sql(@$"
IF NOT EXISTS (SELECT * FROM [dbo].[SchedulerFrequency] WHERE [Frequency] = 'OneTime')
BEGIN
    INSERT INTO [dbo].[SchedulerFrequency] (Frequency) VALUES ('OneTime')
END
GO");
            migrationBuilder.Sql(@$"
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnableHourlyMeterSchedules', N'False', N'This will enable to run Hourly meter scheduled items')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnableDailyMeterSchedules', N'False', N'This will enable to run Daily meter scheduled items')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnableWeeklyMeterSchedules', N'False', N'This will enable to run Weekly meter scheduled items')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnableMonthlyMeterSchedules', N'False', N'This will enable to run Monthly meter scheduled items')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnableYearlyMeterSchedules', N'False', N'This will enable to run Yearly meter scheduled items')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnableOneTimeMeterSchedules', N'False', N'This will enable to run OneTime meter scheduled items')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnablesSuccessfulSchedulerEmail', N'False', N'This will enable sending email for successful mertered usage.')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'EnablesFailureSchedulerEmail', N'False', N'This will enable sending email for failure mertered usage.')
INSERT [dbo].[ApplicationConfiguration] ( [Name], [Value], [Description]) VALUES ( N'SchedulerEmailTo', N'', N'Scheduler email receiver(s) ')
INSERT [dbo].[EmailTemplate] ([Status],[Description],[InsertDate],[TemplateBody],[Subject],[isActive]) VALUES (N'Accepted',N'Accepted',GetDate(),N'<html> 	<head> 		<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""/> 	</head> 	<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0""> 		<center> 			<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable""> 				<tr> 					<td align=""center"" valign=""top"" id=""bodyCell""> 						<!-- BEGIN TEMPLATE // --> 						<table border=""0"" cellpadding=""0"" cellspacing=""0"" id=""templateContainer""> 							<tr> 								<td align=""center"" valign=""top""> 									<!-- BEGIN BODY // --> 									<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateBody""> 										<tr> 											<td valign=""top"" class=""bodyContent""> 												<h2>Subscription ${{SubscriptionName}}</h2> 												<br> 													<p>The Scheduled Task ${{SchedulerTaskName}} was fired <b>Successfully</b> 													</p> 													<p>The following section is the deatil results.</p> 													<hr/> 													<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateBody"">                                                                              ${{ResponseJson}}                                                          </table> 												</td> 											</tr> 										</table> 									</td> 								</tr> 							</table> 							<!-- // END BODY --> 						</td> 					</tr> 				</table> 				<!-- // END TEMPLATE --> 			</center> 		</body> 	</html>',N'Scheduled SaaS Metered Usage Submitted Successfully!',N'True')
INSERT [dbo].[EmailTemplate] ([Status],[Description],[InsertDate],[TemplateBody],[Subject],[isActive]) VALUES (N'Failure',N'Failure',GetDate(),N'<html> 	<head> 		<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""/> 	</head> 	<body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0""> 		<center> 			<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable""> 				<tr> 					<td align=""center"" valign=""top"" id=""bodyCell""> 						<!-- BEGIN TEMPLATE // --> 						<table border=""0"" cellpadding=""0"" cellspacing=""0"" id=""templateContainer"">  							<tr> 								<td align=""center"" valign=""top""> 									<!-- BEGIN BODY // --> 									<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateBody""> 										<tr> 											<td valign=""top"" class=""bodyContent""> 												<h2 >Subscription ${{SubscriptionName}}</h2> 												<br> 												<p>The Scheduled Task ${{SchedulerTaskName}} was fired<b> but Failed to Submit Data</b></p> 												<br> 												Please try again or contact technical support to troubleshoot the issue. 												<p>The following section is the deatil results.</p> 												<hr/> 												<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateBody"">                                                                              ${{ResponseJson}}                                                          </table> 															 											</td> 										</tr>  									</table> 								</td> 							</tr> 						</table> 						<!-- // END BODY --> 					</td> 				</tr> 			</table> 			<!-- // END TEMPLATE --> 		</center> 	</body> </html>',N'Scheduled SaaS Metered Usage Failure!',N'True')

GO
");
        }
    }
}