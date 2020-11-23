using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Models
{
    public class RestaDatabaseSettings : IRestaDatabaseSettings
    {
        public string SurveysCollectionName { get; set; }
        public string AnswersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRestaDatabaseSettings
    {
        string SurveysCollectionName { get; set; }
        string AnswersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
