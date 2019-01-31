using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace TechnicalAssessment
{
    public class MyData
    {
        private int formula;
        private int numA;
        private int numB;
        private int numC;
        private int ans;

        public string[] data;

        private string builder;


        public MyData()
        {
            builder = "datasource=remotemysql.com;port=3306;username=phKxA8OSDn;password=roup8hs4Pa;database=phKxA8OSDn";


        }

        public MyData(int f,int a, int b, int c)
        {
            formula = f;
            numA = a;
            numB = b;
            numC = c;

            ans = 0;
        }

        public int calcAns(int f)
        {
            int num = 0;
            switch (f)
            {
                case 1:
                    num = numA * numB / numC;
                    break;

                case 2:
                    num = numA % numB * numC;

                    break;

                case 3:
                    num = (int)Math.Pow(numA, numC) - (int)Math.Sqrt(numB) * numC;
                    break;
                
                default:
                    num = 0;
                    break;
            }

            return num;
        }

        public void readToDataBase(string[] attr)
        {
            formula = Convert.ToInt32(attr[0]);
            numA = Convert.ToInt32(attr[1]);
            numB = Convert.ToInt32(attr[2]);
            numC = Convert.ToInt32(attr[3]);

            ans = calcAns(formula);

            string sqlQuery = $"insert into myTable (formula, varA, varB, varC, answer) values({formula}, {numA},{numB}, {numC}, {ans})";

            MySqlConnection connection = new MySqlConnection(builder);
            try
            {                
                MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, connection);                

                connection.Open();

                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                connection.Close();
            }

        }

        public void readFromFile(string fileName)
        {

            StreamReader myFile = new StreamReader(fileName);
            
            string line = "";

            while (!myFile.EndOfStream)
            {
                line = myFile.ReadLine();
                data = line.Split(';');
                Console.WriteLine(data[0]);
                readToDataBase(data);
            }

            
        }
    }
}