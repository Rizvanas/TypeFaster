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
            if (!File.Exists(filepath))
                throw new FileNotFoundException();

            var readText = File.ReadAllText(filepath, Encoding.UTF8);
            _sentences = ParseFileTextToSentenceList(readText);
        }

        public int SentenceCount { get => _sentences.Count; }

        public IList<Sentence> GetAllSentences()
        {
            return _sentences;
        }

        public Sentence GetSentenceById(int sentence_id)
        {
            return _sentences.SingleOrDefault(s => s.Id == sentence_id);
        }

        private  IList<Sentence> ParseFileTextToSentenceList(string text)
        {
            var sentences = text.Split(";\n").Select(sentence =>
            {
                var split_sentence = sentence.Split(@".\");
                var id = Convert.ToInt32(split_sentence[0]);
                var words = split_sentence[1].Trim().Split(" ");

                return new Sentence { Id = id, Words = words };
            }).ToList();

            return sentences;
        }
    }
}
