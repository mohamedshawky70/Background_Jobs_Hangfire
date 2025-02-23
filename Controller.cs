      
// 1) install Hangfire.AspNetCore and Hangfire.SqlServer package
     
//ضيفه في الكيو علشان يشتغل مع نفسه في الباك جراوند والتطبيق يوشف اكل عيشه
BackgroundJob.Enqueue(() => _emailSender.SendEmailAsync(Subscriber.Email, "Renew Message", body));
//إبعت الإميل بعد دقيقه من الأن
BackgroundJob.Schedule(() =>_emailSender.SendEmailAsync(Subscriber.Email, "Renew Message", body),TimeSpan.FromMinutes(1));
