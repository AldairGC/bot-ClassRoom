using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Threading;//
using OpenQA.Selenium;//
using OpenQA.Selenium.Chrome;//
using Telegram.Bot;//
using System.Runtime.InteropServices;
using Telegram.Bot.Args;//

namespace bot
{
	class Program
	{
		private static readonly TelegramBotClient Bot = new TelegramBotClient("1125705817:AAGMhlh3NmAkhw_wwE9YTgLCseAco3ODTpM");
		static void Main(string[] args)
		{

			try//ocupamos este try para ver los problemas que tengamos
			{
				IWebDriver Cliente = new ChromeDriver(@"C:\Users\aldeb\source\repos\bot\bot");// llamamos al driver 
				Cliente.Navigate().GoToUrl("https://classroom.google.com/calendar/this-week/course/all");// llamamos el link de la pg que queremos acceder
				var correo = Cliente.FindElement(By.XPath("//*[@id='identifierId']"));//seleccionamos el elemento para insertar el correo
				correo.SendKeys("utp0143459@alumno.utpuebla.edu.mx");//escribimos el correo
				correo.SendKeys(Keys.Enter);//damos enter
				Thread.Sleep(10000);//esperamnos lo que se se a necesario para caragar la pagina de logeo // usign threading; para los segundos
				var pass = Cliente.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input"));//seleccionamos el xpath del input para escribir la contraseña
				pass.SendKeys("aldairGC15");//escrbimos la contraseña
				pass.SendKeys(Keys.Enter);//damos enter
				Thread.Sleep(5000);//esperamos a que cargue la contraseña
				DateTime Hoy = DateTime.Today;//nos interesa saber la fecha de hoy 
				int eldia = (int)Hoy.DayOfWeek;//la convertimos en numero 
				var i = 1;//inicialisamos el contador
				while (true)
				{//while para contar las tareas{
					try{
						var tarea = Cliente.FindElement(By.XPath("/html/body/div[2]/div/div/div[3]/section[" + eldia + "]/div/div[" + i + "]/a/div[1]"));
						Bot.SendTextMessageAsync("830728456", tarea.Text);
						Bot.SendTextMessageAsync("1254381945", tarea.Text); 
						Bot.SendTextMessageAsync("992734063", tarea.Text);
						Console.WriteLine(tarea.Text);
						i++;
					}
					catch
					{
						break;
					}
				}

			}
			catch (Exception ex)// escribimos los errores
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.ToString());
				Console.ReadLine();
			}
	       Console.ReadKey(true);
		 }
	}
}
