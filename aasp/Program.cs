using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ������� ������������
        builder.Configuration
            .AddJsonFile("companyConfig.json")
            .AddXmlFile("companyConfig.xml")
            .AddIniFile("companyConfig.ini")
            .AddJsonFile("myInfoConfig.json");

        // ������� ������
        builder.Services.AddSingleton<CompanyService>();

        var app = builder.Build();

        // ������� ��� ��� ������ � ������� �� � �������
        var companyService = app.Services.GetRequiredService<CompanyService>();
        companyService.DisplayMostEmployedCompany();

        // ������� ��� ��� ��� � ���� ��������
        app.Map("/", () =>
        {
            var myInfo = builder.Configuration.GetSection("MyInfo").Get<MyInfo>();
            var company = companyService.GetMostEmployedCompany();

            return "My Information:" +
                   $" Name: {myInfo.Name}" +
                   $" Age: {myInfo.Age}" +
                   $" Occupation: {myInfo.Occupation}" +
                   $" Most Employed Company" +
                   $" Name: {company.Name}" +
                   $" Employees: {company.Employees}";
        });

        app.Run();
    }
}





