using NUnit.Framework;
using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using Newtonsoft.Json;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace TestProject1
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";


        static string indianStateCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateData.csv";
        static string wrongIndianStateCensusFileType = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndianStateCensus.txt";
        static string delimiterIndianCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndianStateCesusDelimeter.csv";
        static string wrongHeaderIndianCensusFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\WrongIndiaStateCensusData.csv";

        static string indianStateCodeFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateCodes.csv";
        static string wrongIndianStateCodeFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndianStatesCodes.csv";
        static string wrongIndianStateCodeFileType = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\IndiaStateCodes.txt";
        static string delimiterIndianStateCodeFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\DelimiterIndiaStateCodes.csv";
        static string wrongHeaderStateCodeFilePath = @"D:\AllAssignment\IndianStateAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSV\WrongHeaderIndiaStateCodes.csv";

        IndianStatesCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        //count
        //TC 1.1 - Check to ensure the Number of Record matches
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(5, totalRecord.Count);
        }
        //Wrong File Path
        //Tc 1.2 -  While giving incorrect CSV File it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        //WrongFileType
        //TC 1.3 - While giving incorrect type CSV File it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        //FileWithWrongDelimeter
        //TC 1.4 - While giving incorrect Delimeter it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        //WrongHeader
        //TC 1.5 - While giving wrong header it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        //TC 2.1 -  - Check to ensure the Number of Record matches
        [Test]

        public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        //TC 2.2 - -  While giving incorrect CSV File it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        //TC 2.3 -While giving incorrect type CSV File it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
        }
        //TC 2.4 -  - While giving incorrect Delimeter it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianStateCodeDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);

        }
        //TC 2.5 - While giving wrong header it should Returns a custom Exception
        [Test]
        public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateCodeException.eType);
        }
    }
}