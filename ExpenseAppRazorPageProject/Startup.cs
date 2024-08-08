using ExpenseAppRazorPageProject.Entities;
using MFramework.Services.FakeData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace ExpenseAppRazorPageProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDistributedMemoryCache();
            //Bu satýr, daðýtýlmýþ bir bellek önbelleði hizmetini ekler.Daðýtýlmýþ bellek önbelleði, verilerin bellekte geçici olarak saklanmasýný saðlar ve genellikle birden fazla sunucu üzerinde çalýþabilen uygulamalar için kullanýlýr. Uygulamanýn çeþitli yerlerinde hýzlý veri eriþimi için kullanýþlýdýr.
            //Session ile Ýliþkisi: Daðýtýlmýþ bellek önbelleði, oturum verilerinin saklanmasý için kullanýlabilir.Oturum yönetimi, oturum verilerini saklamak için bu önbelleði kullanarak performansý artýrabilir.
           
            //services.AddSession(opt => { ... });
            //Bu satýr, oturum (session) yönetimi hizmetini ekler.ASP.NET Core'da oturum yönetimi, kullanýcýlarýn web uygulamasýnda dolaþýrken bazý verilerin korunmasýný saðlar. AddSession metodu, oturum yönetimi seçeneklerini yapýlandýrmak için bir lambda ifadesi kullanýr.
            //Session ile Ýliþkisi: Bu yapýlandýrma, oturumlarýn nasýl yönetileceðini belirler.Örneðin, oturum verilerinin saklanmasý için kullanýlacak önbellek türünü ve oturum zaman aþýmýný ayarlayabilirsiniz.

            //opt.Cookie.Name = "expenseapp.session";
            //Bu seçenek, oturum verilerini saklamak için kullanýlacak çerezin adýný belirler.Bu durumda, çerezin adý "expenseapp.session" olarak ayarlanmýþtýr. Bu çerez, oturumla iliþkilendirilen verileri tanýmlamak için kullanýlýr.
            //Session ile Ýliþkisi: Bu çerez, kullanýcýnýn oturumunu tanýmlamak ve oturum verilerini iliþkilendirmek için kullanýlýr. Kullanýcý tarayýcýsýnda saklanýr ve oturum boyunca yapýlan iþlemler için bir kimlik saðlar.

            //opt.IdleTimeout = TimeSpan.FromMinutes(20);
            //Bu seçenek, oturumun etkin olmadýðý(kullanýcý herhangi bir iþlem yapmadýðý) süreyi belirler. Burada, oturumun zaman aþýmýna uðramadan önce 20 dakika boyunca etkin kalacaðý ayarlanmýþtýr.Kullanýcý 20 dakika boyunca hiçbir iþlem yapmazsa, oturum sona erer ve oturumla iliþkilendirilen veriler silinir.
            //Session ile Ýliþkisi: Bu ayar, oturumun ne kadar süre boyunca etkin kalacaðýný belirler.Kullanýcý belirlenen süre boyunca herhangi bir iþlem yapmazsa, oturum sona erer ve oturum verileri silinir.

            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.Cookie.Name = "expenseapp.session";
                opt.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddRazorPages();
            string defUsernName = Configuration.GetValue<string>("AppSettings:DefaultUsername");
            string defUserPass = Configuration.GetValue<string>("AppSettings:DefaultUserPass");

            var dbContext = new DatabaseContext();
            if (dbContext.Users.Any() == false)
            {
                dbContext.Users.Add(new User { UserName = defUsernName, Password = defUserPass });
                dbContext.SaveChanges();
            }
            if (dbContext.Expenses.Any() == false)
            {
                string[] categories = new string[] { "Transport", "Communication", "Trip", "Clothes" };

                int userId = dbContext.Users.First().Id;

                for (int i = 0; i < 100; i++)
                {
                    dbContext.Expenses.Add(new Expense()
                    {
                        Category = CollectionData.GetElement(categories),
                        Date = DateTimeData.GetDatetime(DateTime.Now.AddYears(-8), DateTime.Now),
                        Price = NumberData.GetNumber(100, 1500),
                        Description = TextData.GetSentence(),
                        UserId = userId
                    });
                }

                dbContext.SaveChanges();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
