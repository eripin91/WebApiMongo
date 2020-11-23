using LearnWebApiMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnWebApiMongo.Services
{
    public class AnswerService
    {
        private readonly IMongoCollection<Answer> _answers;

        public AnswerService(IRestaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _answers = database.GetCollection<Answer>(settings.AnswersCollectionName);
        }

        public List<Answer> Get() =>
            _answers.Find(answer => true).ToList();

        public Answer Get(string id) =>
            _answers.Find<Answer>(answer => answer.Id == id).FirstOrDefault();

        public Answer Create(Answer answer)
        {
            _answers.InsertOne(answer);
            return answer;
        }

        public void Update(string id, Answer answerIn) =>
            _answers.ReplaceOne(answer => answer.Id == id, answerIn);

        public void Remove(Answer answerIn) =>
            _answers.DeleteOne(answer => answer.Id == answer.Id);

        public void Remove(string id) =>
            _answers.DeleteOne(answer => answer.Id == id);
    }
}
