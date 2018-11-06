using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;
//using static System.Net.Mime.MediaTypeNames;

namespace Xamarin_Forms_Image_Resizer
{
	class Program
	{
		public static int[] resolutionsIos = { 40, 60, 58, 87, 80, 120, 180, 20, 29, 76, 152, 167, 1024  };
		public static int[] resolutionsAndroid = {  };
		public static string currentDirectory = Directory.GetCurrentDirectory();
		public static string outputIos = Directory.GetCurrentDirectory() + "\\ios\\";
		public static string outputAndroid = Directory.GetCurrentDirectory() + "\\android\\";

		public static Stack<Image> Images = new Stack<Image>();

		static void Main(string[] args)
		{
			CheckDirectoriesExist();

			try
			{
				GetFIles();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			

			Console.ReadLine();
		}

		public static void CheckDirectoriesExist()
		{
			if (!Directory.Exists(outputIos))
			{
				Directory.CreateDirectory(outputIos);
			}
			if (!Directory.Exists(outputAndroid))
			{
				Directory.CreateDirectory(outputAndroid);
			}
		}

		public static bool ThumbnailCallback()
		{
			return false;
		}

		public static void GetFIles()
		{
			try
			{
				string[] imageFiles = Directory.GetFiles(currentDirectory, "*.png");

				if (imageFiles.Count() > 0)
				{
					foreach (string imageFile in imageFiles)
					{
						try
						{
							Image myImage = Image.FromFile(imageFile);

							foreach (int resolution in resolutionsIos)
							{
								Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
									
								Image myThumbnail = myImage.GetThumbnailImage(resolution, resolution, myCallback, IntPtr.Zero);
								string outputFileName = outputIos + resolution + "x" + resolution + "_" + imageFile.Split('\\')[imageFile.Split('\\').Count() - 1];

								if (File.Exists(outputFileName))
								{
									File.Delete(outputFileName);
								}

								myThumbnail.Save(outputFileName);
							}
						}
						catch (Exception e)
						{

							Console.WriteLine(e.Message);
						}
					}
				}
				else
				{
					Console.WriteLine("0 files found");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		

		public static void Resize()
		{
			
		}



		public static void ThumbsIos()
		{
			


			
		}
	}
}
