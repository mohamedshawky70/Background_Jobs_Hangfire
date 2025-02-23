builder.Services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
builder.Services.AddHangfireServer();


app.UseHangfireDashboard("/jobs");//Dashboard

builder.Services.AddScoped<INotificationService, NotificationService>();

var scopFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using var scop = scopFactory.CreateScope();
var notificationService = scop.ServiceProvider.GetRequiredService<INotificationService>();
//سيرفس انا عاملها بترسل ايميلات لليوزرز يوميا , التاسك ده يبدا يتحط في الداشبورد علشان يشتغل في معاده اول ما البرنامج يشتغل
RecurringJob.AddOrUpdate("SendNewPollNotification",() => notificationService.SendNewPollNotification(), Cron.Daily);//https://crontab.guru/ يوميا الساعه 12 ,ممكن تحدد كرون بالساعه واليوم والدقيقه وإلخ عن طريق عمل كرون 
