using System;

namespace IndianStatesCensusAnalyser
{
    class Program
    {

        //static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        // CSV File Paths 
        // static string indianStateCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateCensusData.csv";
        // static string wrongIndianStateCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateData.csv";
        // static string wrongIndianStateCensusFileType = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndianStateCensus.txt";
        // static string delimiterIndianCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndianStateCesusDelimeter.csv";
        // static string wrongHeaderIndianCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\WrongIndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateCodes.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian State Census Analyser Problem ");

            IndianCensusAdapter indianCensusAdapter = new IndianCensusAdapter();
            // Loading the Census Data File
            // indianCensusAdapter.LoadCensusData(indianStateCensusFilePath, indianStateCensusHeaders);

            //1.2
            // indianCensusAdapter.LoadCensusData(wrongIndianStateCensusFilePath, indianStateCensusHeaders);

            //1.3
            // indianCensusAdapter.LoadCensusData(wrongIndianStateCensusFileType, indianStateCensusHeaders);

            //1.4
            //indianCensusAdapter.LoadCensusData(delimiterIndianCensusFilePath, indianStateCensusHeaders);

            //1.5
            //indianCensusAdapter.LoadCensusData(wrongHeaderIndianCensusFilePath, indianStateCensusHeaders);

            //Loading the State census Data File
            indianCensusAdapter.LoadCensusData(indianStateCodeFilePath, indianStateCodeHeaders);
        }

    }
}