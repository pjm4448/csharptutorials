// See https://aka.ms/new-console-template for more information
using solid_principles_in_c_sharp;
using Microsoft.Extensions.Logging;
using System.Net.Mail;


Console.WriteLine("Single Responsibility Principle (SRP)");

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("SOLID_tutorials");

// Create an instance of SmtpClient
SmtpClient smtpClient = new SmtpClient("smtp.mydomain.com");

// Create an instance of EmailService
EmailService emailService = new EmailService(smtpClient, logger);

// Create an instance of UserService
UserService userService = new UserService(emailService, logger);

// Now you can use userService to register a user
userService.Register("user@example.com", "password123");


Console.WriteLine("Open/Closed Principle");

Rectangle r1 = new Rectangle { Height = 10, Width = 5 };
Rectangle r2 = new Rectangle { Height = 4, Width = 6 };
Circle c1 = new Circle { Radius = 7 };
Circle c2 = new Circle { Radius = 3 };
AreaCalculator areaCalculator = new AreaCalculator(logger);
Shape[] arrShapes = { r1, r2, c1, c2 };
double totalArea = areaCalculator.TotalArea(arrShapes);


Console.ReadLine();