using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TypeFaster.Domain.Entities;
using TypeFaster.Persistence.Contracts;

namespace TypeFaster.Persistence.Repositories
{
    public class SentenceTxtFileRepository : ISentenceRepository
    {
        private readonly IList<Sentence> _sentences;

        public SentenceTxtFileRepository(string filepath)
        {
            filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, filepath);

            if (!File.Exists(filepath))
                throw new FileNotFoundException();

            var readText = File.ReadAllText(filepath, Encoding.UTF8);
            _sentences = ParseFileTextToSentenceList(readText);
        }

        public int SentencesCount { get => _sentences.Count; }

        public IList<Sentence> GetAllSentences() => _sentences;

        public Sentence GetSentenceById(int sentence_id) => 
            _sentences.SingleOrDefault(s => s.Id == sentence_id);

        private  IList<Sentence> ParseFileTextToSentenceList(string text)
        {
            var sentences = text.Split(";\r\n").Select(sentence =>
            {
                var split_sentence = sentence.Split(@". ", 2);
                var id = Convert.ToInt32(split_sentence[0]);
                var words = split_sentence[1].Trim();

                return new Sentence { Id = id, Words = words };
            }).ToList();

            return sentences;
        }
    }
}
