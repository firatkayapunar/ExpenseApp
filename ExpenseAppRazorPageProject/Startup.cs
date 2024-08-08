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
            //Bu sat�r, da��t�lm�� bir bellek �nbelle�i hizmetini ekler.Da��t�lm�� bellek �nbelle�i, verilerin bellekte ge�ici olarak saklanmas�n� sa�lar ve genellikle birden fazla sunucu �zerinde �al��abilen uygulamalar i�in kullan�l�r. Uygulaman�n �e�itli yerlerinde h�zl� veri eri�imi i�in kullan��l�d�r.
            //Session ile �li�kisi: Da��t�lm�� bellek �nbelle�i, oturum verilerinin saklanmas� i�in kullan�labilir.Oturum y�netimi, oturum verilerini saklamak i�in bu �nbelle�i kullanarak performans� art�rabilir.
           
            //services.AddSession(opt => { ... });
            //Bu sat�r, oturum (session) y�netimi hizmetini ekler.ASP.NET Core'da oturum y�netimi, kullan�c�lar�n web uygulamas�nda dola��rken baz� verilerin korunmas�n� sa�lar. AddSession metodu, oturum y�netimi se�eneklerini yap�land�rmak i�in bir lambda ifadesi kullan�r.
            //Session ile �li�kisi: Bu yap�land�rma, oturumlar�n nas�l y�netilece�ini belirler.�rne�in, oturum verilerinin saklanmas� i�in kullan�lacak �nbellek t�r�n� ve oturum zaman a��m�n� ayarlayabilirsiniz.

            //opt.Cookie.Name = "expenseapp.session";
            //Bu se�enek, oturum verilerini saklamak i�in kullan�lacak �erezin ad�n� belirler.Bu durumda, �erezin ad� "expenseapp.session" olarak ayarlanm��t�r. Bu �erez, oturumla ili�kilendirilen verileri tan�mlamak i�in kullan�l�r.
            //Session ile �li�kisi: Bu �erez, kullan�c�n�n oturumunu tan�mlamak ve oturum verilerini ili�kilendirmek i�in kullan�l�r. Kullan�c� taray�c�s�nda saklan�r ve oturum boyunca yap�lan i�lemler i�in bir kimlik sa�lar.

            //opt.IdleTimeout = TimeSpan.FromMinutes(20);
            //Bu se�enek, oturumun etkin olmad���(kullan�c� herhangi bir i�lem yapmad���) s�reyi belirler. Burada, oturumun zaman a��m�na u�ramadan �nce 20 dakika boyunca etkin kalaca�� ayarlanm��t�r.Kullan�c� 20 dakika boyunca hi�bir i�lem yapmazsa, oturum sona erer ve oturumla ili�kilendirilen veriler silinir.
            //Session ile �li�kisi: Bu ayar, oturumun ne kadar s�re boyunca etkin kalaca��n� belirler.Kullan�c� belirlenen s�re boyunca herhangi bir i�lem yapmazsa, oturum sona erer ve oturum verileri silinir.

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
