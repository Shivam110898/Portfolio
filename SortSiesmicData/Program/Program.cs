using System;
using System.IO;
using System.Collections.Generic;
namespace EarthquackAssignment
{
	//main class
	class MainClass
	{
		//main method
		public static void Main(string[] args)
		{
			//call the Earthquacke class
			EarthQuake e = new EarthQuake();
			//call the Algorithms class
			Algorithms a = new Algorithms();

			//array variables to hole the file paths
			string[] year1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Year_1.txt");
			string[] timestamp1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Timestamp_1.txt");
			string[] time1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Time_1.txt");
			string[] region1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Region_1.txt");
			string[] month1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Month_1.txt");
			string[] longitude1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Longitude_1.txt");
			string[] magnitude1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Magnitude_1.txt");
			string[] latitude1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Latitude_1.txt");
			string[] irisID1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/IRIS_ID_1.txt");
			string[] depth1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Depth_1.txt");
			string[] day1 = File.ReadAllLines(@"/Users/shivampanday/Desktop/assignmentFiles/Day_1.txt");

			int[] year_1 = Array.ConvertAll(year1, int.Parse);
			int[] day_1 = Array.ConvertAll(day1, int.Parse);
			int[] month_1 = new int[month1.Length];
			DateTime[] time = Array.ConvertAll(time1, DateTime.Parse);
			double[] mag_1 = Array.ConvertAll(magnitude1, double.Parse);
			double[] lat_1 = Array.ConvertAll(latitude1, double.Parse);
			double[] long_1 = Array.ConvertAll(longitude1, double.Parse);
			double[] depth_1 = Array.ConvertAll(depth1, double.Parse);
			int[] irisID_1 = Array.ConvertAll(irisID1, int.Parse);
			int[] timestamp_1 = Array.ConvertAll(timestamp1, int.Parse);
			List<int> region_1 = new List<int>();

			//use the earthquake class object a to call the getRegion and getMonth method
			a.getRegion(region1, region_1);
			a.getMonth(month1, month_1);

			//call the menu
			e.Menu(year1, month1, day1, time1, magnitude1, latitude1, longitude1, depth1, region1, irisID1, timestamp1,
				   year_1, month_1, day_1, time, mag_1, lat_1, long_1, depth_1, region_1, irisID_1, timestamp_1);

		}
	}
	//Earthquake class
	class EarthQuake
	{
		public void Menu(string[] year, string[] month, string[] day, string[] time, string[] mag, string[] latitude, string[] longitude, string[] depth, string[] region,
						 string[] irisID, string[] timestamp, int[] int_year, int[] int_month, int[] int_day, DateTime[] d_time, double[] double_mag, double[] double_lat,
						 double[] double_long, double[] double_depth, List<int> list_region, int[] int_irisID, int[] int_timestamp)
		{
			//var to hold array choice
			int varChoice;
			Algorithms a = new Algorithms();
			bool done = false;
			do
			{
				Console.WriteLine("");
				Console.WriteLine("Select an array to process: ");
				Console.WriteLine("1:Year \n2:Month \n3:Day \n4:Time \n5:Magnitude \n6:Latitude \n7:Longitude \n8:Depth " +
								  "\n9:Region \n10:IRIS_ID \n11:Timestamp ");
				varChoice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Sort this by: \n1: Ascending \n2: Descending \n3: Search for a specific record \n4: Search by month ");
				int sortChoice = Convert.ToInt32(Console.ReadLine());//var to get function choice
																	 //switch statement to perform the user choice
				switch (sortChoice)
				{
					case 1:
						//call the ascending method
						a.AscSort(varChoice, year, month, day, time, mag, latitude, longitude, depth, region, irisID, timestamp,
								  int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, int_irisID, int_timestamp);
						break;
					case 2:
						//call the descending method
						a.DescSort(varChoice, year, month, day, time, mag, latitude, longitude, depth, region, irisID, timestamp,
								  int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, int_irisID, int_timestamp);
						break;
					case 3:
						//call the search method
						a.Search(year, month, day, time, timestamp, mag, latitude, longitude, depth, irisID, region);
						break;
					case 4:
						//call the month search method
						a.monthSearch(year, month, day, time, timestamp, mag, latitude, longitude, depth, irisID, region);
						break;


				}
			} while (done == false);
		}

	}
	//all the algorithms class
	class Algorithms
	{
		//method to search by month
		public void monthSearch(string[] year, string[] monthStr, string[] day, string[] time, string[] timestamp, string[] mag, string[] lat, string[] lon,
							   string[] depth, string[] iris,
							   string[] region)
		{ 
				
			string userInput = "";//var to get the month input
			Console.Write("Enter a month to search: ");
			userInput = Console.ReadLine();
			//for loop run throught the month array and check if input is in the array
			for (int i = 0; i < monthStr.Length; i++)
			{
				//if input is in the array output the corresponding record
				if (userInput == monthStr[i])
				{
					//output to the record to the console
					Console.Write("Year: {0} ", year[i]);
					Console.Write("Month: {0} ", monthStr[i]);
					Console.Write("Day: {0} ", day[i]);
					Console.Write("Time: {0} ", time[i]);
					Console.Write("Mag: {0} ", mag[i]);
					Console.Write("Lat: {0} ", lat[i]);
					Console.Write("Long: {0} ", lon[i]);
					Console.Write("Depth: {0} ", depth[i]);
					Console.Write("Region: {0} ", region[i]);
					Console.Write("Timestamp : {0}", timestamp[i]);
					Console.Write("IRIS ID: " + iris[i] + "\n");

				}
			}

		}
		//search by date method
		public void Search(string[] year, string[] monthStr, string[] day, string[] time, string[] timestamp, string[] mag, string[] lat, string[] lon,
							   string[] depth, string[] iris,
							   string[] region)
		{
			//var to get user input
			string userYearInput = "";
			string userMonthInput = "";
			string userDayinput = "";


			Console.Write("Enter year: ");
			userYearInput = Console.ReadLine();
			Console.Write("Enter month: ");
			userMonthInput = Console.ReadLine();
			Console.Write("Enter day: ");
			userDayinput = Console.ReadLine();
			//for loop to run to the length of the year array. 
			for (int i = 0; i < year.Length; i++)
			{
				//if input is equal to the array value then ouput the corresponding record
				if (userYearInput == year[i] && userMonthInput == monthStr[i] && userDayinput == day[i])
				{
					//output to the console
					Console.Write("Year: {0} ", year[i]);
					Console.Write("Month: {0} ", monthStr[i]);
					Console.Write("Day: {0} ", day[i]);
					Console.Write("Time: {0} ", time[i]);
					Console.Write("Mag: {0} ", mag[i]);
					Console.Write("Lat: {0} ", lat[i]);
					Console.Write("Long: {0} ", lon[i]);
					Console.Write("Depth: {0} ", depth[i]);
					Console.Write("Region: {0} ", region[i]);
					Console.Write("Timestamp : {0}", timestamp[i]);
					Console.Write("IRIS ID: " + iris[i] + "\n");

				}
			}
		}
		//method to convert the months to int value
		public void getMonth(string[] Month_str, int[] Month_int)
		{
			//for loop to iterate throght the month array
			for (int i = 0; i < Month_str.Length; i++)
			{
				//if else statements to assign each month an int value
				if (Month_str[i] == "January " || Month_str[i] == "January")
				{
					Month_int[i] = 1;
					Month_str[i] = "January";
				}
				else if (Month_str[i] == "February " || Month_str[i] == "February")
				{
					Month_int[i] = 2;
					Month_str[i] = "February";
				}
				else if (Month_str[i] == "March " || Month_str[i] == "March")
				{
					Month_int[i] = 3;
					Month_str[i] = "March";
				}
				else if (Month_str[i] == "April " || Month_str[i] == "April")
				{
					Month_int[i] = 4;
					Month_str[i] = "April";
				}
				else if (Month_str[i] == "May " || Month_str[i] == "May")
				{
					Month_int[i] = 5;
					Month_str[i] = "May";
				}
				else if (Month_str[i] == "June " || Month_str[i] == "June")
				{
					Month_int[i] = 6;
					Month_str[i] = "June";
				}
				else if (Month_str[i] == "July " || Month_str[i] == "July")
				{
					Month_int[i] = 7;
					Month_str[i] = "July";
				}
				else if (Month_str[i] == "August " || Month_str[i] == "August")
				{
					Month_int[i] = 8;
					Month_str[i] = "August";
				}
				else if (Month_str[i] == "September " || Month_str[i] == "September")
				{
					Month_int[i] = 9;
					Month_str[i] = "September";
				}
				else if (Month_str[i] == "October " || Month_str[i] == "October")
				{
					Month_int[i] = 10;
					Month_str[i] = "October";
				}
				else if (Month_str[i] == "November " || Month_str[i] == "November")
				{
					Month_int[i] = 11;
					Month_str[i] = "November";
				}
				else if (Month_str[i] == "December " || Month_str[i] == "December")
				{
					Month_int[i] = 12;
					Month_str[i] = "December";
				}
			}
		}
		//method to assign each region int value and add to a list for processing
		public void getRegion(string[] region, List<int> regionInt)
		{
			for (int i = 0; i < region.Length; i++)
			{
				if (region[i] == "AEGEAN SEA")
					regionInt.Add(1);
				if (region[i] == "ALBANIA")
					regionInt.Add(2);
				if (region[i] == "BLACK SEA")
					regionInt.Add(3);
				if (region[i] == "BULGARIA")
					regionInt.Add(4);
				if (region[i] == "CENTRAL MEDITERRANEAN SEA")
					regionInt.Add(5);
				if (region[i] == "CRETE")
					regionInt.Add(6);
				if (region[i] == "CRETE, GREECE")
					regionInt.Add(7);
				if (region[i] == "CYPRUS REGION")
					regionInt.Add(8);
				if (region[i] == "DEAD SEA REGION")
					regionInt.Add(9);
				if (region[i] == "DODECANESE ISLANDS")
					regionInt.Add(10);
				if (region[i] == "DODECANESE ISLANDS, GREECE")
					regionInt.Add(11);
				if (region[i] == "EASTERN MEDITERRANEAN SEA")
					regionInt.Add(12);
				if (region[i] == "EGYPT")
					regionInt.Add(13);
				if (region[i] == "GREECE")
					regionInt.Add(14);
				if (region[i] == "GREECE-ALBANIA BORDER REGION")
					regionInt.Add(15);
				if (region[i] == "GREECE-BULGARIA BORDER REGION")
					regionInt.Add(16);
				if (region[i] == "IONIAN SEA")
					regionInt.Add(17);
				if (region[i] == "JORDAN - SYRIA REGION")
					regionInt.Add(18);
				if (region[i] == "NEAR COAST OF LIBYA")
					regionInt.Add(19);
				if (region[i] == "NORTHWESTERN BALKAN REGION")
					regionInt.Add(20);
				if (region[i] == "ROMANIA")
					regionInt.Add(21);
				if (region[i] == "SOUTHERN GREECE")
					regionInt.Add(22);
				if (region[i] == "SOUTHERN ITALY")
					regionInt.Add(23);
				if (region[i] == "TURKEY")
					regionInt.Add(24);
			}

		}
		//ascending sort method
		public void AscSort(int choice, string[] year, string[] month, string[] day, string[] time, string[] mag, string[] latitude, string[] longitude, string[] depth, string[] region,
						 string[] irisID, string[] timestamp, int[] int_year, int[] int_month, int[] int_day, DateTime[] d_time, double[] double_mag, double[] double_lat,
						 double[] double_long, double[] double_depth, List<int> list_region, int[] int_irisID, int[] int_timestamp)
		{

			int length = int_year.Length; 
			//assign each array start index a corresponding data type var for bubble sort
			int temp1 = int_year[0]; int temp2 = int_month[0]; int temp3 = int_day[0];
			DateTime temp4 = d_time[0]; int temp5 = int_timestamp[0]; double temp6 = double_mag[0]; double temp7 = double_lat[0];
			double temp8 = double_lat[0]; double temp9 = double_depth[0]; int temp10 = int_irisID[0]; string temp11 = region[0]; 
			int temp12 = list_region[0];
			//switch statement to check which array to sort
			switch (choice)
			{
				case 1:
					//for loop to iterate to the max array length
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							//if value is greater 
							if (int_year[i] > int_year[j])
							{
								//call the bubble sort method
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 2:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_month[i] > int_month[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 3:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_day[i] > int_day[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 4:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (d_time[i] > d_time[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 5:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_mag[i] > double_mag[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 6:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_lat[i] > double_lat[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 7:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_long[i] > double_long[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 8:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_depth[i] > double_depth[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 9:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (list_region[i] > list_region[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 10:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_irisID[i] > int_irisID[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
					case 11:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_timestamp[i] > int_timestamp[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;

			}
			//output the record
			for (int i = 0; i < year.Length; i++)
			{ 
				Console.Write("Date: " + int_year[i] + " ");
				switch (int_month[i])
				{
					case 1:
						Console.Write("January");
						break;
					case 2:
						Console.Write("February");
						break;
					case 3:
						Console.Write("March");
						break;
					case 4:
						Console.Write("April");
						break;
					case 5:
						Console.Write("May");
						break;
					case 6:
						Console.Write("June");
						break;
					case 7:
						Console.Write("July");
						break;
					case 8:
						Console.Write("August");
						break;
					case 9:
						Console.Write("September");
						break;
					case 10:
						Console.Write("October");
						break;
					case 11:
						Console.Write("Novemeber");
						break;
					case 12:
						Console.Write("December");
						break;

				}
				Console.Write(" Day: " + int_day[i] + " Time: " + d_time[i].ToString("HH:mm:ss") + " Mag: " +  double_mag[i] + " Lat: "
				              + double_lat[i] + " Long " + double_long[i] + " Depth " +  double_depth[i] + " Region: " 
				              + region[i] + " IRIS " + int_irisID[i] + " Timestamp " + int_timestamp[i] + "\n");
			}

		}
		//descending sort method
		public void DescSort(int choice, string[] year, string[] month, string[] day, string[] time, string[] mag, string[] latitude, string[] longitude, string[] depth, string[] region,
						 string[] irisID, string[] timestamp, int[] int_year, int[] int_month, int[] int_day, DateTime[] d_time, double[] double_mag, double[] double_lat,
						 double[] double_long, double[] double_depth, List<int> list_region, int[] int_irisID, int[] int_timestamp)
		{

			int length = int_year.Length;
			int temp1 = int_year[0]; int temp2 = int_month[0]; int temp3 = int_day[0];
			DateTime temp4 = d_time[0]; int temp5 = int_timestamp[0]; double temp6 = double_mag[0]; double temp7 = double_lat[0];
			double temp8 = double_lat[0]; double temp9 = double_depth[0]; int temp10 = int_irisID[0]; string temp11 = region[0];
			int temp12 = list_region[0];
			//switch statement for which array to sort
			switch (choice)
			{
				case 1:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_year[i] < int_year[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 2:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_month[i] < int_month[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 3:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_day[i] < int_day[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 4:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (d_time[i] < d_time[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 5:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_mag[i] < double_mag[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 6:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_lat[i] < double_lat[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 7:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_long[i] < double_long[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 8:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (double_depth[i] < double_depth[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 9:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (list_region[i] < list_region[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 10:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_irisID[i] < int_irisID[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;
				case 11:
					for (int i = 0; i < length; i++)
					{
						for (int j = i + 1; j < length; j++)
						{
							if (int_timestamp[i] < int_timestamp[j])
							{
								BubbleSort(int_year, int_month, int_day, d_time, double_mag, double_lat, double_long, double_depth, list_region, region, int_irisID, int_timestamp,
										  temp1, temp2, temp3, temp4, temp5, temp6, temp7, temp8, temp9, temp10, temp11, temp12, i, j);
							}
						}
					}
					break;

			}
			for (int i = 0; i < year.Length; i++)
			{
				Console.Write("Date: " + int_year[i] + " ");
				switch (int_month[i])
				{
					case 1:
						Console.Write("January");
						break;
					case 2:
						Console.Write("February");
						break;
					case 3:
						Console.Write("March");
						break;
					case 4:
						Console.Write("April");
						break;
					case 5:
						Console.Write("May");
						break;
					case 6:
						Console.Write("June");
						break;
					case 7:
						Console.Write("July");
						break;
					case 8:
						Console.Write("August");
						break;
					case 9:
						Console.Write("September");
						break;
					case 10:
						Console.Write("October");
						break;
					case 11:
						Console.Write("Novemeber");
						break;
					case 12:
						Console.Write("December");
						break;

				}
				Console.Write(" " + int_day[i] + " " + d_time[i].ToString("HH:mm:ss") + " " + double_mag[i] + " " + double_lat[i] + " " + double_long[i] + " " +
							  double_depth[i] + " " + region[i] + " " + int_irisID[i] + " " + int_timestamp[i] + "\n");
			}

		}
		//bubble sort method
		public void BubbleSort(int[] Year, int[] Month, int[] Day, DateTime[] Time, double[] Magnitude, double[] Latitude, double[] Longitude, double[] Depth,
							   List<int> Region_int, string[] Region,
							  int[] IRIS_ID, int[] Timestamp, int temp_1, int temp_2, int temp_3, DateTime temp_4, int temp_5, double temp_6, double temp_7, double temp_8,
							   double temp_9, int temp_10, string temp_11, int temp12, int i, int j)
		{
			//swaps
			temp_1 = Year[i];
			temp_2 = Month[i];
			temp_3 = Day[i];
			temp_4 = Time[i];
			temp_5 = Timestamp[i];
			temp_6 = Magnitude[i];
			temp_7 = Latitude[i];
			temp_8 = Longitude[i];
			temp_9 = Depth[i];
			temp_10 = IRIS_ID[i];
			temp_11 = Region[i];
			temp12 = Region_int[i];

			Year[i] = Year[j];
			Month[i] = Month[j];
			Day[i] = Day[j];
			Time[i] = Time[j];
			Timestamp[i] = Timestamp[j];
			Magnitude[i] = Magnitude[j];
			Latitude[i] = Latitude[j];
			Longitude[i] = Longitude[j];
			Depth[i] = Depth[j];
			IRIS_ID[i] = IRIS_ID[j];
			Region[i] = Region[j];
			Region_int[i] = Region_int[j];

			Year[j] = temp_1;
			Month[j] = temp_2;
			Day[j] = temp_3;
			Time[j] = temp_4;
			Timestamp[j] = temp_5;
			Magnitude[j] = temp_6;
			Latitude[j] = temp_7;
			Longitude[j] = temp_8;
			Depth[j] = temp_9;
			IRIS_ID[j] = temp_10;
			Region[j] = temp_11;
			Region_int[j] = temp12;

		}
	}
}
