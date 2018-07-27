Application Name: Contact Management

N-Tier Application
ContactManagement.Web : View
ContactMangement.Services: Business Layer
ContactManagement.Data: Database

I have added Web Api in ContactManagement.Web. We can create seprate project for that and deploy it seperatly. 

Technologies and Framwork:
.Net Framework: 4.5
Sql Server 2017
 MVC5, WebAPI, JQuery,Unity Container,Entity Framework

How to deploy database:

 Run 'DBScript/Contactdb.sql' Script File on Sql server


 DB Authentication: Windows Authentication
 
 Change 'data source' from coonection string in web.cofig file
 
 <connectionStrings>
	<add name="CustomersEntities" connectionString="metadata=res://*/CustomersModel.csdl|res://*/CustomersModel.ssdl|res://*/CustomersModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=VIKRAM\SQLEXPRESS;initial catalog=Contact;Trusted_Connection=Yes;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>
 </configuration>


 How to run application:

 1. Right click on solution and 'Restore Nuget Packages'
 2. Build the solution
 3. Run Application ctr + f5