using LearnWebApiMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Services
{
    public class SurveyService
    {
        private readonly IMongoCollection<Survey> _surveys;

        public SurveyService(IRestaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _surveys = database.GetCollection<Survey>(settings.SurveysCollectionName);
        }

        public List<Survey> Get() =>
            _surveys.Find(survey => true).ToList();

        public Survey Get(string id) =>
            _surveys.Find<Survey>(survey => survey.Id == id).FirstOrDefault();

        public List<Survey> Get(int page) =>
            _surveys.Find<Survey>(survey => survey.Page == page).ToList();

        public Survey Create(Survey survey)
        {
            _surveys.InsertOne(survey);
            return survey;
        }

        public void Update(string id, Survey surveyIn) =>
            _surveys.ReplaceOne(survey => survey.Id == id, surveyIn);

        public void Remove(Survey surveyIn) =>
            _surveys.DeleteOne(survey => survey.Id == survey.Id);

        public void Remove(string id) =>
            _surveys.DeleteOne(survey => survey.Id == id);
    }
}
